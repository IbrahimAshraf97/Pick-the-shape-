using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DontDestroy : MonoBehaviour
{
    private static readonly string BackGroundPref = "BackGroundPref";
    private float _bkGroundSliderValue;
    public AudioSource _bkGroundAudioSource;

    void Awake()
    {
        /*GameObject[] objs = GameObject.FindGameObjectsWithTag("music");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);*/

        ContinueSetting();
    }
    public void ContinueSetting()
    {
        _bkGroundSliderValue= PlayerPrefs.GetFloat(BackGroundPref);

        _bkGroundAudioSource.volume = _bkGroundSliderValue;
    }
}
