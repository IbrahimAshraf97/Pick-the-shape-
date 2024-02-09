using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
    [Header("Menu Buttons")]
    [SerializeField] private Button _newGameButton;
    [SerializeField] private Button _continueGameButton;

    public string sceneToLoad = "Map 1";
    public SceneFadder _sceneFadder;

    private void Start()
    {
        if (!dataPersistenceManager.instance.HasGameData())
        {
            _continueGameButton.interactable = false;
        }
    }

    public void Play()
    {
        DisableMenuButtons();

        dataPersistenceManager.instance.NewGame();

        _sceneFadder.FadeTo(sceneToLoad);
    }
    public void Continue()
    {
        DisableMenuButtons();

        dataPersistenceManager.instance.LoadGame();

        _sceneFadder.FadeTo(sceneToLoad);
    }
    public void Quit()
    {
        Debug.Log("Exiting ...... ");
        Application.Quit();
    }
    private void DisableMenuButtons()
    {
        _newGameButton.interactable = false;
        _continueGameButton.interactable = false;
    }
}
