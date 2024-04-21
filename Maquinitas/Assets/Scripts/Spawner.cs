using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject prefabPerson;
    private PathBehavior pth;
    private float spawnTime;
    private float timer;


    // Start is called before the first frame update
    void Start()
    {
        pth = gameObject.GetComponent<PathBehavior>();
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
            PositionsBehaviour pthPerson = person.GetComponent<PositionsBehaviour>();
            //pthPerson.setWaypoints(pth.GetWaypoints());
        }
    }
}
