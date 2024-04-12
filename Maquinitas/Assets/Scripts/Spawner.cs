using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject prefab;
    private float spawnTime;
    private float timer;


    // Start is called before the first frame update
    void Start()
    {
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
            Instantiate(prefab, transform.position, Quaternion.identity);
            spawnTime = Random.Range(1f, 1f);
        }
    }
}
