using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FrameCounter : MonoBehaviour
{
    private float _fps;
    [SerializeField] private TextMeshProUGUI _textFps;

    public static FrameCounter Instance;

    private void Awake() {
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start() {
        InvokeRepeating("GetFPS", 1, 1);
    }
    void GetFPS() {

        _fps = (int)(1f / Time.unscaledDeltaTime);
        _textFps.text = "FPS: " + _fps.ToString();
    }
}
