using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FarolasController : MonoBehaviour
{
    // Start is called before the first frame update
    List<Light> lights;
    [SerializeField]
    private int intensityOfLightDay;
    [SerializeField]
    private int intensityOfLightNight;
    void Awake()
    {
        lights = new List<Light>();
        lights.Clear();
        int numeroDeHijos = transform.childCount;
        for (int i = 0; i < numeroDeHijos; i++)
        {
            lights.Add(transform.GetChild(i).GetChild(0).GetComponent<Light>());
            Debug.Log(lights[i]);
        }
        Debug.Log(lights.Count);
    }

    public void EncenderLuces()
    {
        for(int i = 0; i < lights.Count; i++)
        {
            lights[i].intensity = intensityOfLightNight;
        }
    }

    public void ApagarLuces()
    {
        for (int i = 0; i < lights.Count; i++)
        {
            lights[i].intensity = intensityOfLightDay;
        }
    }
}
