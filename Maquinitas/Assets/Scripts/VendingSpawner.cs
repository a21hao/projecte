using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefabVendingMachine;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnVendingMachine()
    {
        Vector3 positionSpawn = new Vector3(Input.mousePosition.x, 0, Input.mousePosition.z);
        Transform positionSpawnMachine = positionSpawn;
        Instantiate(prefabVendingMachine, positionSpawn);
    }
}
