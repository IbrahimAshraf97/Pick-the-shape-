using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targets : MonoBehaviour
{
    private GameManager _gameManager;
    private Rigidbody _rigidbody;
    [SerializeField] float _maxTorque = 5f;
    [SerializeField] float _yPos = 60f;
    [SerializeField] float _xRang = 20f;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        transform.position = RandomPos();

        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    float RandomTorque()
    {
        return Random.Range(-_maxTorque, _maxTorque);
    }
    Vector3 RandomPos()
    {
        return new Vector3(Random.Range(-_xRang, _xRang), _yPos, 0 );
    }
}
