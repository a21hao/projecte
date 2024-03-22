using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class AASASASASA : MonoBehaviour
{

    [SerializeField] private EventReference buySound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            AudioManager.instance.PlayOneShot(buySound, this.transform.position);
        }
    }
}
