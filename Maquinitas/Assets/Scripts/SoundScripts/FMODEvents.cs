using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FMODEvents : MonoBehaviour
{


    [field: SerializeField] public EventReference music { get; private set; }

				[field: SerializeField] public EventReference ambience { get; private set; }

				public static FMODEvents instance { get; private set; }
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than 1  audio manager in scene");
        }
        instance = this;
    }




}
