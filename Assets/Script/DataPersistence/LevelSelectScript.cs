using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectScript : MonoBehaviour
{
    public SceneFadder _fader;

    public NewLevelSystem _newLvlSys;
    public Button[] _buttons;

    // Start is called before the first frame update
    void Start()
    {
        int _lvlPassed = _newLvlSys._totalLvl;

        _buttons[0].interactable=true;
        _buttons[1].interactable= true;
        _buttons[2].interactable = true;
        _buttons[3].interactable = true;
        _buttons[4].interactable = true;
        _buttons[5].interactable = true;

        /*switch (_lvlPassed)
        {
            case int expression when (expression >= 5):
                _buttons[1].interactable = true;
                break;
            case int expression when (expression >= 8):
                _buttons[1].interactable = true;
                _buttons[2].interactable = true;
                break;
            case int expression when (expression >= 20 ):
                _buttons[1].interactable = true;
                _buttons[2].interactable = true;
                _buttons[3].interactable = true;
                break;
            case int expression when (expression >= 35):
                _buttons[1].interactable = true;
                _buttons[2].interactable = true;
                _buttons[3].interactable = true;
                _buttons[4].interactable = true;
                break;
            case int expression when (expression >= 50):
                _buttons[1].interactable = true;
                _buttons[2].interactable = true;
                _buttons[3].interactable = true;
                _buttons[4].interactable = true;
                _buttons[5].interactable = true;
                break;
        }*/
    }
    public void Select (string _levelName)
    {
        _fader.FadeTo(_levelName);
    }
}
