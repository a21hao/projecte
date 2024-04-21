using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathBehavior : MonoBehaviour

{
    private Transform[] Waypoints;
    private List<Vector3> positions;


    // Start is called before the first frame update
    void Awake()
    {
        Waypoints = GetComponentsInChildren<Transform>();
        positions = new List<Vector3>();
        for(int i = 0; i < Waypoints.Length; i++)
        {
            positions.Add(Waypoints[i].position);
        }
    }

    public void setWaypoints(Transform[] wayps)
    {
        Waypoints = wayps;
    }

    public Transform[] GetWaypoints()
    {
        return Waypoints;
    }

    public List<Vector3> GetPositionsWaypoints()
    {
        return positions;
    }

}
