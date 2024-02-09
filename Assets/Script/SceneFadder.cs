using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class SceneFadder : MonoBehaviour
{
    public AnimationCurve _curve;
    public Image _img;

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeTo(string scene)
    {
        StartCoroutine(FadeOut(scene));

    }

    IEnumerator FadeIn()
    {
        float time = 1f;
        while (time > 0f)
        {
            time -= Time.deltaTime;
            float a = _curve.Evaluate(time);
            _img.color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }
    }
    IEnumerator FadeOut(string scene)
    {
        float time = 0f;
        while (time < 1f)
        {
            time += Time.deltaTime;
            float a = _curve.Evaluate(time);
            _img.color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }
        dataPersistenceManager.instance.SaveGame();
        SceneManager.LoadScene(scene);

    }

}
