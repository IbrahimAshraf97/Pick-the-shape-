using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData
{
    public float _totalXp;

    public int _tLvls;

    public GameData()
    {
        this._totalXp = 0;
        this._tLvls = 0;
    }
}
