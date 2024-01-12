using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class VendingMachineController : MonoBehaviour
{
    // Start is called before the first frame update

    //public Camera camera;

    private CinemachineVirtualCamera cameraVendingMachine;
    void Start()
    {
        cameraVendingMachine = gameObject.transform.GetComponentInChildren<CinemachineVirtualCamera>();
        //Debug.Log(cameraVendingMachine != null);
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Enter");
            cameraVendingMachine.Priority = 12;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Enter2");
            cameraVendingMachine.Priority = 10;
        }

        if (Input.GetMouseButton(0))
        {
            //Camera camera = cameraVendingMachine.GetComponent<Camera>();
            //Debug.Log(camera != null);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //if (Physics.Raycast(ray, out RaycastHit)) ;


        }
    }

    private void OnMouseEnter()
    {
        Debug.Log("Enter");
        cameraVendingMachine.Priority = 12;
        
    }

    private void OnMouseExit()
    {
        cameraVendingMachine.Priority = 10;
    }
}
