using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BoxController : MonoBehaviour
{
    //Variables section
    [SerializeField] private float _horizontalInput;
    [SerializeField] private float _speed = 20f;

    [SerializeField] private float _xRang = 20f;

    private Rigidbody _rb;

    public TextMeshProUGUI CounterTextOne;
    public TextMeshProUGUI CounterTextTwo;
    public TextMeshProUGUI CounterTextThree;

    public int CountOne = 1;
    public int CountTwo = 1;
    public int CountThree = 1;


    private GameManager _gameManager;

    private Touch _touch;
    [SerializeField] private float _modifier;

    public int _finalCountOne;
    public int _finalCountTwo;
    public int _finalCountThree;

    private NewLevelSystem _newLvlSys;

    private void Awake()
    {
        _newLvlSys = GetComponent<NewLevelSystem>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _rb = GetComponent<Rigidbody>();
        CountOne = 0;
        _modifier = 0.05f;

        CounterTextOne.text = " 0 ";

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            _touch=Input.GetTouch(0);
            if(_touch.phase == TouchPhase.Moved)
            {
                if (transform.position.x < -_xRang)
                {
                    transform.position = new Vector3(-_xRang, transform.position.y, -transform.position.z);
                }
                if (transform.position.x > _xRang)
                {
                    transform.position = new Vector3(_xRang, transform.position.y, transform.position.z);
                }
                transform.position=new Vector3(
                    transform.position.x + _touch.deltaPosition.x * _modifier,
                    transform.position.y,
                    transform.position.z);
            }
        }

        //make the box move in left and right directions
        _horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * _speed * _horizontalInput * Time.deltaTime);
        if (transform.position.x < -_xRang)
        {
            transform.position = new Vector3(-_xRang, transform.position.y, -transform.position.z);
        }
        if (transform.position.x > _xRang)
        {
            transform.position = new Vector3(_xRang, transform.position.y, transform.position.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(_gameManager._shapeTag))
        {
            //Debug.Log("Im in Phase One");

            CountOne += 1;
            _finalCountOne = CountOne;
            CounterTextOne.text = _finalCountOne.ToString();
            _newLvlSys.GainExperienceFlateRate(50);

            if (_finalCountOne == _gameManager._randomNum)
            {
                CounterTextOne.text = " 0 ";
                //_finalCountOne = 0;
                Destroy(_gameManager._selectedShape);
                _gameManager.RandomLevelRespwan();
            }
            Destroy(other.gameObject);
        }

        else if(other.gameObject.CompareTag(_gameManager._shapeTagX)) 
        {
            //Debug.Log("Im in Phase Two");
            CountTwo += 1;
            _finalCountTwo = CountTwo;
            CounterTextTwo.text = _finalCountTwo.ToString();
            _newLvlSys.GainExperienceFlateRate(50);

            if (_finalCountTwo == _gameManager._randomNumX)
            {
                CounterTextTwo.text = " 0 ";
                //_finalCountTwo = 0;
                Destroy(_gameManager._selectedShapeX);
                _gameManager.RandomLevelRespwanTwo();
            }
            Destroy(other.gameObject);

        }

        else if (other.gameObject.CompareTag(_gameManager._shapeTagXX))
        {
            //Debug.Log("Im in Phase Three");
            CountThree += 1;
            _finalCountThree = CountThree;
            CounterTextThree.text = _finalCountThree.ToString();
            _newLvlSys.GainExperienceFlateRate(50);

            if (_finalCountThree == _gameManager._randomNumXX)
            {
                CounterTextThree.text = " 0 ";
                //_finalCountThree = 0;
                Destroy(_gameManager._selectedShapeXX);
                _gameManager.RandomLevelRespwanThree();
            }
            Destroy(other.gameObject);

        }

        else
        {
            Destroy(other.gameObject);
            _gameManager._timeLeft += 2f;
        }
    }
    
}
