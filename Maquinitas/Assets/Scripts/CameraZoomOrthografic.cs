using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraZoomOrthografic : MonoBehaviour
{
    //public GameObject player;
    private CinemachineVirtualCamera vcam;
    public float zoomSpeed = 1f;
    public float zoomAcceleration = 2.5f;
    public float Zoom;
    public float OutZoom;
    private float zoomInnerRange = 3f;
    private float zoomOuterRange = 50f;

    private float currentMiddleRigRadius;
    private float newMiddleRigRadius = 10f;
    private Vector3 initialPosition;
    private Vector3 dirZoom;
    private Vector3 vectorZoom;
    private Vector3 lastposition;
    private float initialOthograifcSize;

    private void Awake()
    {
        // Suscríbete a las acciones del mouse scroll
        //Input.mouseScrollDelta += ZoomWithMouseScroll;
        vcam = GetComponent<CinemachineVirtualCamera>();
        currentMiddleRigRadius = 0;
        newMiddleRigRadius = 0;
        //dirZoom = transform.forward.normalized;
        zoomInnerRange = -Zoom;
        zoomOuterRange = OutZoom;
        //initialPosition = transform.position;
        lastposition = transform.position;
        initialOthograifcSize = vcam.m_Lens.OrthographicSize;

    }

    private void Update()
    {
        // Actualiza el nivel de zoom
        if (NewControls.scrollValue.y != 0)
        {
            ZoomWithMouseScroll(NewControls.scrollValue);
        }
        UpdateZoomLevel();
    }

    private void ZoomWithMouseScroll(Vector2 scrollDelta)
    {
        float zoomYAxis = scrollDelta.y;
        AdjustCameraZoomIndex(zoomYAxis);
    }

    private void UpdateZoomLevel()
    {
        // Suaviza el cambio de FOV
        currentMiddleRigRadius = Mathf.Lerp(currentMiddleRigRadius, newMiddleRigRadius, zoomAcceleration * Time.deltaTime);
        currentMiddleRigRadius = Mathf.Clamp(currentMiddleRigRadius, zoomInnerRange, zoomOuterRange);

        /*// Actualiza el FOV de la cámara virtual
        freeLookCameraToZoom.m_Orbits[1].m_Radius = currentMiddleRigRadius;
        freeLookCameraToZoom.m_Orbits[0].m_Height = freeLookCameraToZoom.m_Orbits[1].m_Radius;
        freeLookCameraToZoom.m_Orbits[2].m_Height = -freeLookCameraToZoom.m_Orbits[1].m_Radius;*/
        //Vector3 vectorSum = transform.position.normalized * currentMiddleRigRadius;
        //transform.position = transform.position + vectorSum;

        //transform.position = new Vector3(transform.position.x, (initialPosition + (-dirZoom * currentMiddleRigRadius)).y, transform.position.z + (initialPosition + (-dirZoom * currentMiddleRigRadius)).z - lastposition.z);
        //Debug.Log((initialPosition + (-dirZoom * currentMiddleRigRadius)).z - lastposition.z);
        //lastposition = (initialPosition + (-dirZoom * currentMiddleRigRadius));
        vcam.m_Lens.OrthographicSize = initialOthograifcSize + currentMiddleRigRadius;

    }

    private void AdjustCameraZoomIndex(float zoomYAxis)
    {
        if (zoomYAxis == 0)
            return;

        // Ajusta el FOV según la dirección del scroll
        if (zoomYAxis < 0)
            newMiddleRigRadius = currentMiddleRigRadius + zoomSpeed;
        else if (zoomYAxis > 0)
            newMiddleRigRadius = currentMiddleRigRadius - zoomSpeed;
    }
}
