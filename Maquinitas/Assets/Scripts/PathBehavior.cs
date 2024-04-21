using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathBehavior : MonoBehaviour

{
    public Transform[] Waypoints;


    // Start is called before the first frame update
    void Awake()
    {
        Waypoints = GetComponentsInChildren<Transform>();
    }

    public void setWaypoints(Transform[] wayps)
    {
        Waypoints = wayps;
    }

    public Transform[] GetWaypoints()
    {
        return Waypoints;
    }

}
