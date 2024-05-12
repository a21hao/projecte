using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class GameInfo
{
    public int money;
    public Vector3 positionSun;
    public float time;
    public bool letter = false;

    public GameInfo()
    {
        money = 2000;
    }
}
