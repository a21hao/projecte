using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSSetter : MonoBehaviour
{
    [SerializeField] int fpsLimit = 60;

    void Awake()
    {
        Application.targetFrameRate = fpsLimit;
    }
}
