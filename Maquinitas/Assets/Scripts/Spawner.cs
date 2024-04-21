using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject prefabPerson;
    private Transform[] Waypoints;
    private List<Vector3> positions;
    private float spawnTime;
    private float timer;


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

        if(timer >= spawnTime)
        {
            timer = 0;
            GameObject person =Instantiate(prefabPerson, transform.position, Quaternion.identity);
            EnemyBehavior psPerson = person.GetComponent<EnemyBehavior>();
            psPerson.setPositions(positions);
            //pthPerson.setWaypoints(pth.GetWaypoints());
        }
    }
}
