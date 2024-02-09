using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathBehavior : MonoBehaviour

{
    public static Transform[] Waypoints;


    // Start is called before the first frame update
    void Awake()
    {
        Waypoints = GetComponentsInChildren<Transform>();
    }

}
