using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class dataPersistenceManager : MonoBehaviour
{
    [Header("Debugging")]
    [SerializeField] private bool initializeDataIfNull = false;

    [Header("File Storage Config")]
    [SerializeField] private string fileName;
    [SerializeField] private bool useEncryption;

    [Header("Auto Saving Configuration")]
    [SerializeField] private float _autoSaveTimeSec = 250f;


    private GameData gameData;

    private List<IDataPersistence> dataPersistencesObjects;

    private FileDataHandelar dataHandler;

    private Coroutine _autoSaveCourotine;

    public static dataPersistenceManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Found more than one data persistance manager in the scene. Destroying the newest one");
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
        this.dataHandler = new FileDataHandelar(Application.persistentDataPath, fileName, useEncryption);

    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded+=OnSceneLoaded;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void OnSceneLoaded(Scene _scene , LoadSceneMode _mode)
    {
        this.dataPersistencesObjects = FindAllDataPersistenceObjects();
        LoadGame();
        
        if(_autoSaveCourotine != null)
        {
            StopCoroutine(_autoSaveCourotine);
        }
        _autoSaveCourotine = StartCoroutine(AutoSave());
    }


    public void NewGame()
    {
        this.gameData = new GameData();
    }
    public void LoadGame()
    {

        this.gameData = dataHandler.Load();

        if(this.gameData == null && initializeDataIfNull)
        {
            NewGame();
        }

        if (this.gameData == null)
        {
            Debug.Log("No data was found . A new game needs to be started before data can be loaded.");
            return;
        }

        foreach (IDataPersistence dataPersistencesObj in dataPersistencesObjects)
        {
            dataPersistencesObj.LoadData(gameData);
        }
    }
    public void SaveGame()
    {
        if (this.gameData == null)
        {
            Debug.Log("No data was found . A new game needs to be started before data can be saved.");
            return;
        }

        foreach (IDataPersistence dataPersistencesObj in dataPersistencesObjects)
        {
            dataPersistencesObj.SaveData(gameData);
        }

        dataHandler.Save(gameData);
        Debug.Log("GameSaved");
    }
    private void OnApplicationQuit()
    {
        SaveGame();
    }
    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistencesObjects = FindObjectsOfType<MonoBehaviour>()
            .OfType<IDataPersistence>();
        return new List<IDataPersistence>(dataPersistencesObjects);
    }
    public bool HasGameData()
    {
        return gameData!= null;
    }

    private IEnumerator AutoSave()
    {
        while (true)
        {
            yield return new WaitForSeconds(_autoSaveTimeSec);
            SaveGame();
            Debug.Log("Auto Saved Game");
        }
    }
}
