using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraTransition : MonoBehaviour
{
    // Start is called before the first frame update
    private CinemachineVirtualCamera vcam;

    void Start()
    {
        vcam = GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (vcam != null && vcam.isActiveAndEnabled)
        {
            Debug.Log("La cámara virtual está activa.");
        }
    }
}
