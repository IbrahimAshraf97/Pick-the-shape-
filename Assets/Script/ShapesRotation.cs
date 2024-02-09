using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapesRotation : MonoBehaviour
{
    [SerializeField] private float _xRotationValue = 1.0f;
    [SerializeField] private float _yRotationValue = 1.0f;
    [SerializeField] private float _zRotationValue = 1.0f;

    public Vector3 _shapePos = new Vector3(12, 8.23f, -8);

    // Start is called before the first frame update
    void Start()
    {
        //transform.position = _shapePos;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(_xRotationValue, _yRotationValue, _zRotationValue);
    }
}
