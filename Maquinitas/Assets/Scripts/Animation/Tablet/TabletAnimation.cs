using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabletAnimation : MonoBehaviour
{
    private Animator tablet;

    // Start is called before the first frame update
    void Start()
    {
        tablet = GetComponentInChildren<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
