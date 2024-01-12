 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCicle : MonoBehaviour
{
    public float min;
    public float grados;
    public float timeSpeed = 1; 
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        min += timeSpeed * Time.deltaTime;
        if (min >= 1440)
        {
            min = 0;
        }
        grados = min / 4;
        this.transform.localEulerAngles = new Vector3(grados, -90f, 0f);
    }
}
