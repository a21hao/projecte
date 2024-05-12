using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCars : MonoBehaviour
{

    public GameObject prefabCar;
    private Transform[] Waypoints;
    private List<Vector3> positions;
    private float spawnTime;
    private float timer;
    //private int direction;


    // Start is called before the first frame update

    void Awake()
    {
        
        Waypoints = GetComponentsInChildren<Transform>();
        positions = new List<Vector3>();
        for (int i = 0; i < Waypoints.Length; i++)
        {
            positions.Add(Waypoints[i].position);
        }
        spawnTime = 1f;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnTime)
        {
            timer = 0;
            spawnTime = Random.Range(7, 20);
            if (Random.Range(0, 2) > 0) positions.Reverse();
            GameObject car = Instantiate(prefabCar, positions[0], Quaternion.identity);
            CarBehaviour carbh = car.GetComponent<CarBehaviour>();
            carbh.setPositions(positions);
            //pthPerson.setWaypoints(pth.GetWaypoints());
        }
    }
}
