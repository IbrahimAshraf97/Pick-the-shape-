using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextLvlToOpen : MonoBehaviour
{
    public int _levelWants;
    public SceneFadder _fader;
    public NewLevelSystem _newLvlSys;
    public Button _nextLvlToOpenButton;

    // Start is called before the first frame update
    void Start()
    {
        int levelReached = _newLvlSys._totalLvl;

        _nextLvlToOpenButton.interactable = false;

        if(levelReached >= _levelWants)
        {
            _nextLvlToOpenButton.interactable = true;
        }

    }

    public void GoToNextLevel(string _levelToOpen)
    {
        _fader.FadeTo(_levelToOpen);
    }
}
