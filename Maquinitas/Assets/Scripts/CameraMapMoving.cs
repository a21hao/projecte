using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMapMoving : MonoBehaviour
{
    // Start is called before the first frame update
    float distance = 10;
    private Vector3 _lastMousePosition;
    [SerializeField]
    private float maxMapx;
    [SerializeField]
    private float maxMapy;
    [SerializeField]
    private float velocityDragCamera;
    private float cameraAltitude;
    private MovementBehaviour mb;

    void OnMouseDrag()
    {
        Debug.Log("Enter");
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        transform.position = objPosition;

    }
    void Start()
    {
        cameraAltitude = transform.position.z;
        mb = GetComponent<MovementBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
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
        }
    }
}

