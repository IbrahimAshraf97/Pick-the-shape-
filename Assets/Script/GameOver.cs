using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public SceneFadder _fadder;
    public string _mainMenu = "MainMenu";

    public void Retry()
    {
        _fadder.FadeTo(SceneManager.GetActiveScene().name);
    }
    public void Menu()
    {
        dataPersistenceManager.instance.SaveGame();
        _fadder.FadeTo(_mainMenu);
    }
}
