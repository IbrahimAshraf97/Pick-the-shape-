using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class NewLevelSystem : MonoBehaviour,IDataPersistence
{
    public int _level;
    public float _currentXP;
    public float _requiredXP;

    private float _lerpTime;
    private float _delayTimer;

    [Header("UI")]
    public Image _frontXpBar;
    public Image _backXpBar;
    public TextMeshProUGUI _levelText;
    public TextMeshProUGUI _xpText;

    [Header("Maltipliers")]
    [Range(1f, 300f)]
    public float _additionalMultiplier = 300f;
    [Range(2f, 4f)]
    public float _powerMultiplier = 2f;
    [Range(7f, 14f)]
    public float _divisionMultiplier = 7f;

    //public int solveForRequiredXp;
    //public int levelCycle;
    //public GameManager _gameManager;

    public float _ttlXp;
    public int _totalLvl;

    public void LoadData(GameData data)
    {
        this._ttlXp = data._totalXp;
        this._totalLvl = data._tLvls;
        //this._requiredXP = data._reqXP;
    }
    public void SaveData(GameData data)
    {
        data._totalXp = this._ttlXp;
        data._tLvls = this._totalLvl;
        //data._reqXP=this._requiredXP;
    }

    void Start()
    {
        _frontXpBar.fillAmount = _currentXP / _requiredXP;
        _backXpBar.fillAmount = _currentXP / _requiredXP;
        _requiredXP = CalculateRequiredXp();
        _levelText.text = _totalLvl.ToString();
    }

    void Update()
    {
        UpdateXpUI();

        if (_currentXP > _requiredXP)
        {
            LevelUP();
        }
    }
    public void UpdateXpUI()
    {
        float xpFraction = _currentXP / _requiredXP;
        float FXP = _frontXpBar.fillAmount;
        if (FXP < xpFraction)
        {
            _delayTimer += Time.deltaTime;
            _backXpBar.fillAmount = xpFraction;
            if (_delayTimer > 3)
            {
                _lerpTime += Time.deltaTime;
                float percentComplete = _lerpTime / 4;
                _frontXpBar.fillAmount = Mathf.Lerp(FXP, _backXpBar.fillAmount, percentComplete);
            }
        }
        _xpText.text = _ttlXp.ToString();

    }
    public void GainExperienceFlateRate(float xpGained)
    {
        _currentXP += xpGained;
        _lerpTime = 0;
        _delayTimer = 0;

        _ttlXp+=xpGained;
    }
    public void LevelUP()
    {
        _totalLvl++;

        _level++;
        _frontXpBar.fillAmount = 0f;
        _backXpBar.fillAmount = 0f;
        _currentXP = Mathf.RoundToInt(_currentXP - _requiredXP);
        _requiredXP=CalculateRequiredXp();
        _levelText.text = _totalLvl.ToString();
    }
    public int CalculateRequiredXp()
    {
        int solveForRequiredXp = 0;

        for(int levelCycle = 1; levelCycle <= _level; levelCycle++)
        {
            solveForRequiredXp+= (int)Mathf.Floor(levelCycle + _additionalMultiplier * Mathf.Pow(_powerMultiplier, levelCycle / _divisionMultiplier));
        }
        return solveForRequiredXp / 4;
    }
}
