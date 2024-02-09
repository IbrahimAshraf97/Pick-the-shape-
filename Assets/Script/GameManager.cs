using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> _shapes;
    public List<GameObject> _SelectedShapes;
    public List<GameObject> _SelectedShapesX;
    public List<GameObject> _SelectedShapesXX;


    [SerializeField] public float _spawnRate = 3f;

    [SerializeField] public bool _isActive;
 
    public TextMeshProUGUI _theReqNum;
    public TextMeshProUGUI _theReqNumX;
    public TextMeshProUGUI _theReqNumXX;


    public TextMeshProUGUI ShapeName;
    public TextMeshProUGUI ShapeNameX;
    public TextMeshProUGUI ShapeNameXX;


    public int _randomNum;
    public int _randomNumX;
    public int _randomNumXX;


    private BoxController _boxController;

    public string _shapeTag;
    public string _shapeTagX;
    public string _shapeTagXX;


    public float _timeLeft = 30.0f;
    public TextMeshProUGUI _timeLeftText;

    public GameObject _selectedShape;
    public GameObject _selectedShapeX;
    public GameObject _selectedShapeXX;

    private NewLevelSystem _newLvlSys;

    private bool _isSpawned = false;
    private bool _isSpawnedX = false;

    public SceneFadder _fadder;

    public GameObject _gameOverUI;

    // Start is called before the first frame update
    void Start()
    {
        //print(Screen.currentResolution);
        Application.targetFrameRate = -1;

        _newLvlSys = GameObject.Find("Box").GetComponent<NewLevelSystem>();
        _boxController = GameObject.Find("Box").GetComponent < BoxController > ();

        _isActive = true;

        StartCoroutine(SpwanRandomShapes());

        RandomLevelRespwan();

        _shapeTagX = "Untagged";
        _shapeTagXX = "Untagged";

    }


    // Update is called once per frame
    void Update()
    {
        if (_isActive)
        {
            TimeLeft();

            if(_newLvlSys._level == 2 && _isSpawned == false)
            {
                RandomLevelRespwanTwo();
                _spawnRate = 2f;
                //Debug.Log("here");
                _isSpawned = true;  
            }
            if(_newLvlSys._level == 3 && _isSpawnedX == false)
            {
                RandomLevelRespwanThree();
                _spawnRate = 1f;
                //Debug.Log("Here Again");
                _isSpawnedX=true;
            }
        }
    }
    public void RandomLevelRespwan()
    {
        _boxController.CountOne = 0;

        _randomNum = Random.Range(1, 10);

        _theReqNum.text = "   " + _randomNum;

        float _theNewTimer = 60f;
        _timeLeft = _theNewTimer;

        int _randomIndex = Random.Range(0, _SelectedShapes.Count);

        _selectedShape = Instantiate(_SelectedShapes[_randomIndex]);
        _selectedShape.transform.SetParent(GameObject.FindGameObjectWithTag("ShapeOneSpawnPos").transform,false);

        // Shap A
        if (_selectedShape.CompareTag("Banana"))
        {
            ShapeName.text = "Banana";
            _shapeTag = "Banana";
        }
        if (_selectedShape.CompareTag("Carrot"))
        {
            ShapeName.text = "Carrot";
            _shapeTag = "Carrot";

        }
        if (_selectedShape.CompareTag("Green Apple"))
        {
            ShapeName.text = "Green Apple";
            _shapeTag = "Green Apple";
        }
        if (_selectedShape.CompareTag("Pear")) {
            ShapeName.text = "Pear";
            _shapeTag = "Pear";
        }
        if (_selectedShape.CompareTag("Red Apple")) {
            ShapeName.text = "Red Apple";
            _shapeTag = "Red Apple";
        }
        // Shap B
        if (_selectedShape.CompareTag("Bus")) {
            ShapeName.text = "Bus";
            _shapeTag = "Bus";
        }
        if (_selectedShape.CompareTag("Car")) {
            ShapeName.text = "Car";
            _shapeTag = "Car";

        }
        if (_selectedShape.CompareTag("Tank")) {
            ShapeName.text = "Tank";
            _shapeTag = "Tank";
        }
        if (_selectedShape.CompareTag("Truck")) {
            ShapeName.text = "Truck";
            _shapeTag = "Truck";
        }
        if (_selectedShape.CompareTag("Van")) {
            ShapeName.text = "Van";
            _shapeTag = "Van";
        }
        // Shap C
        if (_selectedShape.CompareTag("Barrel")) {
            ShapeName.text = "Barrel";
            _shapeTag = "Barrel";
        }
        if (_selectedShape.CompareTag("Barrier A")) {
            ShapeName.text = "Barrier A";
            _shapeTag = "Barrier A";
        }
        if (_selectedShape.CompareTag("Barrier B")) {
            ShapeName.text = "Barrier B";
            _shapeTag = "Barrier B";
        }
        if (_selectedShape.CompareTag("Crate")) {
            ShapeName.text = "Crate";
            _shapeTag = "Crate";
        }
        if (_selectedShape.CompareTag("Rock")) {
            ShapeName.text = "Rock";
            _shapeTag = "Rock";
        }
        if (_selectedShape.CompareTag("Tree")) {
            ShapeName.text = "Tree";
            _shapeTag = "Tree";
        }
        // Shap D
        if (_selectedShape.CompareTag("Cookie")) {
            ShapeName.text = "Cookie";
            _shapeTag = "Cookie";
        }
        if (_selectedShape.CompareTag("Fish")) {
            ShapeName.text = "Fish";
            _shapeTag = "Fish";
        }
        if (_selectedShape.CompareTag("Pizza")) {
            ShapeName.text = "Pizza";
            _shapeTag = "Pizza";
        }
        if (_selectedShape.CompareTag("Sandwich")) {
            ShapeName.text = "Sandwich";
            _shapeTag = "Sandwich";
        }
        if (_selectedShape.CompareTag("Steak")) {
            ShapeName.text = "Steak";
            _shapeTag = "Steak";
        }

        // Shap E
        if (_selectedShape.CompareTag("Fox")) {
            ShapeName.text = "Fox";
            _shapeTag = "Fox";
        }
        if (_selectedShape.CompareTag("Red Doe")) {
            ShapeName.text = "Red Doe";
            _shapeTag = "Red Doe";
        }
        if (_selectedShape.CompareTag("White Doe")) {
            ShapeName.text = "White Doe";
            _shapeTag = "White Doe";
        }
        if (_selectedShape.CompareTag("Red Moose")) {
            ShapeName.text = "Red Moose";
            _shapeTag = "Red Moose";
        }
        if (_selectedShape.CompareTag("Red Stag")) {
            ShapeName.text = "Red Stag";
            _shapeTag = "Red Stag";
        }
        if (_selectedShape.CompareTag("Yellow Moose")) {
            ShapeName.text = "Yellow Moose";
            _shapeTag = "Yellow Moose";
        }
        if (_selectedShape.CompareTag("Yellow Stag")) {
            ShapeName.text = "Yellow Stag";
            _shapeTag = "Yellow Stag";
        }

        // Shap F
        if (_selectedShape.CompareTag("Black Horse")) {
            ShapeName.text = "Black Horse";
            _shapeTag = "Black Horse";
        }
        if (_selectedShape.CompareTag("Brown Chicken")) {
            ShapeName.text = "Brown Chicken";
            _shapeTag = "Brown Chicken";
        }
        if (_selectedShape.CompareTag("Brown Cow")) {
            ShapeName.text = "Brown Cow";
            _shapeTag = "Brown Cow";
        }
        if (_selectedShape.CompareTag("Brown Horse")) {
            ShapeName.text = "Brown Horse";
            _shapeTag = "Brown Horse";
        }
        if (_selectedShape.CompareTag("Chick")) {
            ShapeName.text = "Chick";
            _shapeTag = "Chick";
        }
        if (_selectedShape.CompareTag("Rooster")) {
            ShapeName.text = "Rooster";
            _shapeTag = "Rooster";
        }
        if (_selectedShape.CompareTag("White Chicken")) {
            ShapeName.text = "White Chicken";
            _shapeTag = "White Chicken";
        }
        if (_selectedShape.CompareTag("White Cow")) {
            ShapeName.text = "White Cow";
            _shapeTag = "White Cow";
        }
    }

    IEnumerator SpwanRandomShapes()
    {
        while (_isActive)
        {
            yield return new WaitForSeconds(_spawnRate);
            int _randomIndex = Random.Range(0,_shapes.Count);
            Instantiate(_shapes[_randomIndex]);
        }
    }
    private void TimeLeft()
    {
        if (_timeLeft > 0)
        {
            _timeLeft -= Time.deltaTime;
        }
        double f = System.Math.Round(_timeLeft);
        _timeLeftText.text = f.ToString();
        if(_timeLeft == 2f)
        {
            dataPersistenceManager.instance.SaveGame();
        }
        if (_timeLeft < 0)
        {
            gameOver();
        }
    }
    public void RandomLevelRespwanTwo()
    {
        _boxController.CounterTextTwo.text = " 0 ";

        _boxController.CountTwo = 0;

        _randomNumX = Random.Range(1, 10);

        _theReqNumX.text = "   " + _randomNumX;
        float _theNewTimer = 60f;
        _timeLeft = _theNewTimer;
        int _randomIndex = Random.Range(0, _SelectedShapesX.Count);

        _selectedShapeX = Instantiate(_SelectedShapesX[_randomIndex]);
        _selectedShapeX.transform.SetParent(GameObject.FindGameObjectWithTag("ShapeTwoSpawnPos").transform, false);


        //Shap AX
        if (_selectedShapeX.CompareTag("Banana")) {
            ShapeNameX.text = "Banana";
            _shapeTagX = "Banana";
        }
        if (_selectedShapeX.CompareTag("Carrot")) {
            ShapeNameX.text = "Carrot";
            _shapeTagX = "Carrot";
        }
        if (_selectedShapeX.CompareTag("Green Apple")) {
            ShapeNameX.text = "Green Apple";
            _shapeTagX = "Green Apple";
        }
        if (_selectedShapeX.CompareTag("Pear")) {
            ShapeNameX.text = "Pear";
            _shapeTagX = "Pear";
        }
        if (_selectedShapeX.CompareTag("Red Apple")) {
            ShapeNameX.text = "Red Apple";
            _shapeTagX = "Red Apple";
        }
        //Shap BX
        if (_selectedShapeX.CompareTag("Bus")) {
            ShapeNameX.text = "Bus";
            _shapeTagX = "Bus";
        }
        if (_selectedShapeX.CompareTag("Car")) {
            ShapeNameX.text = "Car";
            _shapeTagX = "Car";

        }
        if (_selectedShapeX.CompareTag("Tank")) {
            ShapeNameX.text = "Tank";
            _shapeTagX = "Tank";
        }
        if (_selectedShapeX.CompareTag("Truck")) {
            ShapeNameX.text = "Truck";
            _shapeTagX = "Truck";
        }
        if (_selectedShapeX.CompareTag("Van")) {
            ShapeNameX.text = "Van";
            _shapeTagX = "Van";
        }
        // Shap CX
        if (_selectedShapeX.CompareTag("Barrel")) {
            ShapeNameX.text = "Barrel";
            _shapeTagX = "Barrel";
        }
        if (_selectedShapeX.CompareTag("Barrier A")) {
            ShapeNameX.text = "Barrier A";
            _shapeTagX = "Barrier A";
        }
        if (_selectedShapeX.CompareTag("Barrier B")) {
            ShapeNameX.text = "Barrier B";
            _shapeTagX = "Barrier B";
        }
        if (_selectedShapeX.CompareTag("Crate")) {
            ShapeNameX.text = "Crate";
            _shapeTagX = "Crate";
        }
        if (_selectedShapeX.CompareTag("Rock")) {
            ShapeNameX.text = "Rock";
            _shapeTagX = "Rock";
        }
        if (_selectedShapeX.CompareTag("Tree")) {
            ShapeNameX.text = "Tree";
            _shapeTagX = "Tree";
        }
        // Shap DX
        if (_selectedShapeX.CompareTag("Cookie")) {
            ShapeNameX.text = "Cookie";
            _shapeTagX = "Cookie";
        }
        if (_selectedShapeX.CompareTag("Fish")) {
            ShapeNameX.text = "Fish";
            _shapeTagX = "Fish";
        }
        if (_selectedShapeX.CompareTag("Pizza")) {
            ShapeNameX.text = "Pizza";
            _shapeTagX = "Pizza";
        }
        if (_selectedShapeX.CompareTag("Sandwich")) {
            ShapeNameX.text = "Sandwich";
            _shapeTagX = "Sandwich";
        }
        if (_selectedShapeX.CompareTag("Steak")) {
            ShapeNameX.text = "Steak";
            _shapeTagX = "Steak";
        }
        // Shap EX
        if (_selectedShapeX.CompareTag("Fox")) {
            ShapeNameX.text = "Fox";
            _shapeTagX = "Fox";
        }
        if (_selectedShapeX.CompareTag("Red Doe")) {
            ShapeNameX.text = "Red Doe";
            _shapeTagX = "Red Doe";
        }
        if (_selectedShapeX.CompareTag("White Doe")) {
            ShapeNameX.text = "White Doe";
            _shapeTagX = "White Doe";
        }
        if (_selectedShapeX.CompareTag("Red Moose")) {
            ShapeNameX.text = "Red Moose";
            _shapeTagX = "Red Moose";
        }
        if (_selectedShapeX.CompareTag("Red Stag")) {
            ShapeNameX.text = "Red Stag";
            _shapeTagX = "Red Stag";
        }
        if (_selectedShapeX.CompareTag("Yellow Moose")) {
            ShapeNameX.text = "Yellow Moose";
            _shapeTagX = "Yellow Moose";
        }
        if (_selectedShapeX.CompareTag("Yellow Stag")) {
            ShapeNameX.text = "Yellow Stag";
            _shapeTagX = "Yellow Stag";
        }
        // Shap FX
        if (_selectedShapeX.CompareTag("Black Horse")) {
            ShapeNameX.text = "Black Horse";
            _shapeTagX = "Black Horse";
        }
        if (_selectedShapeX.CompareTag("Brown Chicken")) {
            ShapeNameX.text = "Brown Chicken";
            _shapeTagX = "Brown Chicken";
        }
        if (_selectedShapeX.CompareTag("Brown Cow")) {
            ShapeNameX.text = "Brown Cow";
            _shapeTagX = "Brown Cow";
        }
        if (_selectedShapeX.CompareTag("Brown Horse")) {
            ShapeNameX.text = "Brown Horse";
            _shapeTagX = "Brown Horse";
        }
        if (_selectedShapeX.CompareTag("Chick")) {
            ShapeNameX.text = "Chick";
            _shapeTagX = "Chick";
        }
        if (_selectedShapeX.CompareTag("Rooster")) {
            ShapeNameX.text = "Rooster";
            _shapeTagX = "Rooster";
        }
        if (_selectedShapeX.CompareTag("White Chicken")) {
            ShapeNameX.text = "White Chicken";
            _shapeTagX = "White Chicken";
        }
        if (_selectedShapeX.CompareTag("White Cow")) {
            ShapeNameX.text = "White Cow";
            _shapeTagX = "White Cow";
        }
    }
    public void RandomLevelRespwanThree()
    {
        _boxController.CounterTextThree.text = " 0 ";

        _boxController.CountThree = 0;

        _randomNumXX = Random.Range(1, 10);

        _theReqNumXX.text = "   " + _randomNumXX;
        float _theNewTimer = 60f;
        _timeLeft = _theNewTimer;
        int _randomIndex = Random.Range(0, _SelectedShapesXX.Count);

        _selectedShapeXX = Instantiate(_SelectedShapesXX[_randomIndex]);
        _selectedShapeXX.transform.SetParent(GameObject.FindGameObjectWithTag("ShapeThreeSpawnPos").transform, false);


        if (_selectedShapeXX.CompareTag("Banana")) {
            ShapeNameXX.text = "Banana";
            _shapeTagXX = "Banana";
        }
        if (_selectedShapeXX.CompareTag("Carrot")) {
            ShapeNameXX.text = "Carrot";
            _shapeTagXX = "Carrot";
        }
        if (_selectedShapeXX.CompareTag("Green Apple")) {
            ShapeNameXX.text = "Green Apple";
            _shapeTagXX = "Green Apple";
        }
        if (_selectedShapeXX.CompareTag("Pear")) {
            ShapeNameXX.text = "Pear";
            _shapeTagXX = "Pear";
        }
        if (_selectedShapeXX.CompareTag("Red Apple")) {
            ShapeNameXX.text = "Red Apple";
            _shapeTagXX = "Red Apple";
        }
        //Shap BXX
        if (_selectedShapeXX.CompareTag("Bus")) {
            ShapeNameXX.text = "Bus";
            _shapeTagXX = "Bus";
        }
        if (_selectedShapeXX.CompareTag("Car")) {
            ShapeNameXX.text = "Car";
            _shapeTagXX = "Car";

        }
        if (_selectedShapeXX.CompareTag("Tank")) {
            ShapeNameXX.text = "Tank";
            _shapeTagXX = "Tank";
        }
        if (_selectedShapeXX.CompareTag("Truck")) {
            ShapeNameXX.text = "Truck";
            _shapeTagXX = "Truck";
        }
        if (_selectedShapeXX.CompareTag("Van")) {
            ShapeNameXX.text = "Van";
            _shapeTagXX = "Van";
        }
        // Shap CXX
        if (_selectedShapeXX.CompareTag("Barrel")) {
            ShapeNameXX.text = "Barrel";
            _shapeTagXX = "Barrel";
        }
        if (_selectedShapeXX.CompareTag("Barrier A")) {
            ShapeNameXX.text = "Barrier A";
            _shapeTagXX = "Barrier A";
        }
        if (_selectedShapeXX.CompareTag("Barrier B")) {
            ShapeNameXX.text = "Barrier B";
            _shapeTagXX = "Barrier B";
        }
        if (_selectedShapeXX.CompareTag("Crate")) {
            ShapeNameXX.text = "Crate";
            _shapeTagXX = "Crate";
        }
        if (_selectedShapeXX.CompareTag("Rock")) {
            ShapeNameXX.text = "Rock";
            _shapeTagXX = "Rock";
        }
        if (_selectedShapeXX.CompareTag("Tree")) {
            ShapeNameXX.text = "Tree";
            _shapeTagXX = "Tree";
        }
        // Shap DXX
        if (_selectedShapeXX.CompareTag("Cookie")) {
            ShapeNameXX.text = "Cookie";
            _shapeTagXX = "Cookie";
        }
        if (_selectedShapeXX.CompareTag("Fish")) {
            ShapeNameXX.text = "Fish";
            _shapeTagXX = "Fish";
        }
        if (_selectedShapeXX.CompareTag("Pizza")) {
            ShapeNameXX.text = "Pizza";
            _shapeTagXX = "Pizza";
        }
        if (_selectedShapeXX.CompareTag("Sandwich")) {
            ShapeNameXX.text = "Sandwich";
            _shapeTagXX = "Sandwich";
        }
        if (_selectedShapeXX.CompareTag("Steak")) {
            ShapeNameXX.text = "Steak";
            _shapeTagXX = "Steak";
        }
        // Shap EXX
        if (_selectedShapeXX.CompareTag("Fox")) {
            ShapeNameXX.text = "Fox";
            _shapeTagXX = "Fox";
        }
        if (_selectedShapeXX.CompareTag("Red Doe")) {
            ShapeNameXX.text = "Red Doe";
            _shapeTagXX = "Red Doe";
        }
        if (_selectedShapeXX.CompareTag("White Doe")) {
            ShapeNameXX.text = "White Doe";
            _shapeTagXX = "White Doe";
        }
        if (_selectedShapeXX.CompareTag("Red Moose")) {
            ShapeNameXX.text = "Red Moose";
            _shapeTagXX = "Red Moose";
        }
        if (_selectedShapeXX.CompareTag("Red Stag")) {
            ShapeNameXX.text = "Red Stag";
            _shapeTagXX = "Red Stag";
        }
        if (_selectedShapeXX.CompareTag("Yellow Moose")) {
            ShapeNameXX.text = "Yellow Moose";
            _shapeTagXX = "Yellow Moose";
        }
        if (_selectedShapeXX.CompareTag("Yellow Stag")) {
            ShapeNameXX.text = "Yellow Stag";
            _shapeTagXX = "Yellow Stag";
        }
        // Shap FXX
        if (_selectedShapeXX.CompareTag("Black Horse")) {
            ShapeNameXX.text = "Black Horse";
            _shapeTagXX = "Black Horse";
        }
        if (_selectedShapeXX.CompareTag("Brown Chicken")) {
            ShapeNameXX.text = "Brown Chicken";
            _shapeTagXX = "Brown Chicken";
        }
        if (_selectedShapeXX.CompareTag("Brown Cow")) {
            ShapeNameXX.text = "Brown Cow";
            _shapeTagXX = "Brown Cow";
        }
        if (_selectedShapeXX.CompareTag("Brown Horse")) {
            ShapeNameXX.text = "Brown Horse";
            _shapeTagXX = "Brown Horse";
        }
        if (_selectedShapeXX.CompareTag("Chick")) {
            ShapeNameXX.text = "Chick";
            _shapeTagXX = "Chick";
        }
        if (_selectedShapeXX.CompareTag("Rooster")) {
            ShapeNameXX.text = "Rooster";
            _shapeTagXX = "Rooster";
        }
        if (_selectedShapeXX.CompareTag("White Chicken")) {
            ShapeNameXX.text = "White Chicken";
            _shapeTagXX = "White Chicken";
        }
        if (_selectedShapeXX.CompareTag("White Cow")) {
            ShapeNameXX.text = "White Cow";
            _shapeTagXX = "White Cow";
        }
    }

    public void gameOver()
    {
        dataPersistenceManager.instance.SaveGame();
        _isActive = false;
        _gameOverUI.SetActive(true);
    }
}
