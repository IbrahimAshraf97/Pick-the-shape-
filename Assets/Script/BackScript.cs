using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackScript : MonoBehaviour
{
    public SceneFadder _fader;

    public string _mainMenu = "MainMenu";
    public void Menu()
    {
        _fader.FadeTo(_mainMenu);
    }
}
