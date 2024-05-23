using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class CameraMapMoving : MonoBehaviour
{
    // Start is called before the first frame update
    //float distance = 10;
    private Vector3 _lastMousePosition;
    [SerializeField]
    private GameObject pointRightUpVillage;
    [SerializeField]
    private GameObject pointLeftDownVillage;
    [SerializeField]
    private GameObject pointRightUpCity;
    [SerializeField]
    private GameObject pointLeftDownCity;
    private GameObject pointRightUp;
    private GameObject pointLeftDown;
    [SerializeField]
    private float velocityDragCamera;
    private Vector3 directionCameraz;
    private Vector3 directionCamerax;
    private bool canUseCameraMap;
    private bool isInVillage;
    [SerializeField]
    private GameObject pointVillage;
    [SerializeField]
    private GameObject pointCity;
    [SerializeField]
    private int orthoSizeVillage;
    [SerializeField]
    private int orthoSizeCity;
    [SerializeField]
    private CinemachineBrain cb;



    static public CinemachineVirtualCamera mapVirtualCamera;
    
    //[SerializeField]
    //private float speedScroll;
    private float cameraAltitude;
    private MovementBehaviour mb;


    /*void OnMouseDrag()
    {
        Debug.Log("Enter");
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        transform.position = objPosition;

    }*/

    private void Awake()
    {
        mapVirtualCamera = GetComponent<CinemachineVirtualCamera>();
        Debug.Log(mapVirtualCamera);
        canUseCameraMap = true;
        pointRightUp = pointRightUpVillage;
        pointLeftDown = pointLeftDownVillage;
    }
    void Start()
    {
        cameraAltitude = transform.position.z;
        mb = GetComponent<MovementBehaviour>();
        directionCameraz = transform.forward;
        directionCameraz = new Vector3(directionCameraz.x, 0, directionCameraz.z);
        directionCameraz.Normalize();
        directionCamerax = transform.right;
        directionCamerax = new Vector3(directionCamerax.x, 0, directionCamerax.z);
        directionCamerax.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        /* if (Input.GetMouseButton(0))
         {
             Vector3 currentMousePosition = new Vector3(Input.mousePosition.x*-velocityDragCamera, cameraAltitude , Input.mousePosition.y*-velocityDragCamera);
             if (_lastMousePosition != Vector3.zero)
             {
                 Vector3 delta = currentMousePosition - _lastMousePosition;
                 transform.position += delta;
             }
             _lastMousePosition = currentMousePosition;
         }
         else
         {
             _lastMousePosition = Vector3.zero;
         }

         if(NewControls.mapMovementDirection != new Vector2(0,0))
         {
             mb.Move(new Vector3 (NewControls.mapMovementDirection.x,0,NewControls.mapMovementDirection.y));
         }*/
        
        
        if(canUseCameraMap)
        {
            if (Mouse.current.leftButton.isPressed)
            {
                Vector3 currentMousePosition = new Vector3(Mouse.current.position.x.ReadValue() * -velocityDragCamera, -cameraAltitude, Mouse.current.position.y.ReadValue() * -velocityDragCamera);
                if (_lastMousePosition != Vector3.zero)
                {
                    Vector3 delta = (currentMousePosition - _lastMousePosition);
                    Vector3 newPositionx = delta.x * directionCamerax;
                    Vector3 newPositionz = delta.z * directionCameraz;
                    Vector3 newPosition = newPositionx + newPositionz + new Vector3(0, delta.y, 0);
                    transform.position += newPosition;
                    CheckCameraIntoPoints();

                }
                _lastMousePosition = currentMousePosition;
            }
            else
            {
                _lastMousePosition = Vector3.zero;
            }

            if (NewControls.mapMovementDirection != Vector2.zero)
            {
                mb.Move(NewControls.mapMovementDirection.x * directionCamerax);
                mb.Move(NewControls.mapMovementDirection.y * directionCameraz);
                CheckCameraIntoPoints();
            }
        }
        
        /*

        if(NewControls.scrollValue.y > 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - speedScroll, transform.position.z);
        }

        if (NewControls.scrollValue.y < 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + speedScroll, transform.position.z);
        }*/
    }

    private void CheckCameraIntoPoints()
    {
        if (transform.position.z > pointRightUp.transform.position.z)
            transform.position = new Vector3(transform.position.x, transform.position.y, pointRightUp.transform.position.z);
        if (transform.position.x > pointRightUp.transform.position.x)
            transform.position = new Vector3(pointRightUp.transform.position.x, transform.position.y, transform.position.z);
        if (transform.position.z < pointLeftDown.transform.position.z)
            transform.position = new Vector3(transform.position.x, transform.position.y, pointLeftDown.transform.position.z);
        if (transform.position.x < pointLeftDown.transform.position.x)
            transform.position = new Vector3(pointLeftDown.transform.position.x, transform.position.y, transform.position.z);
    }

    public static void ChangeTypeOfCameraToOrthografic(bool isOrthografic)
    {
        mapVirtualCamera.m_Lens.Orthographic = isOrthografic;
    }

    public void CanUseCameraMap(bool canUse)
    {
        canUseCameraMap = canUse;
    }

    public void ChangeCameraToVillage()
    {
        transform.position = pointVillage.transform.position;
        pointRightUp = pointRightUpVillage;
        pointLeftDown = pointLeftDownVillage;
        Debug.Log(mapVirtualCamera);
        mapVirtualCamera.m_Lens.OrthographicSize = 18;//orthoSizeVillage;
        Debug.Log(mapVirtualCamera.m_Lens.OrthographicSize);
        cb.ManualUpdate();
    }

    public void ChangeCameraToCity()
    {
        transform.position = pointCity.transform.position;
        pointRightUp = pointRightUpCity;
        pointLeftDown = pointLeftDownCity;
        Debug.Log(mapVirtualCamera);
        mapVirtualCamera.m_Lens.OrthographicSize = 50;
        /*LensSettings newSettings = new LensSettings()
        newSettings.OrthographicSize = 50;*/
        Debug.Log(mapVirtualCamera.m_Lens.OrthographicSize);
        cb.ManualUpdate();
    }

}

