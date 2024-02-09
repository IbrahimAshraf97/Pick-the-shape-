using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBoundary : MonoBehaviour
{
    private float _lowerLimit = -40f;

    void Update()
    {
        if(transform.position.y < _lowerLimit)
        {
            Destroy(gameObject);
        }
    }
}
