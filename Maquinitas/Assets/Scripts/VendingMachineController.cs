using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Cinemachine;

public class VendingMachineController : MonoBehaviour, IPointerClickHandler
{
    // Start is called before the first frame update

    //public Camera camera;

    private CinemachineVirtualCamera cameraVendingMachine;

    //[SerializeField]
    //private float speedScroll;
    private float cameraAltitude;
    private MovementBehaviour mb;
    private CinemachineVirtualCamera ortograficaCamera;
    private CinemachineVirtualCamera perspectivaCamera;
    public float duracionTransicion = 1.9f;
    public float duracionTransicionP = 5f;// Duración de la transición en segundos
    private GameObject objetoCameraVendingMachine;
    private Vector3 initialLocalPositionCameraVending;
    [SerializeField]
    private Vector3 positionCameraInPerspective;
    [SerializeField]
    private float FOVinPerspective;

    void Start()
    {
        cameraVendingMachine = gameObject.transform.GetComponentInChildren<CinemachineVirtualCamera>();
        ortograficaCamera = CameraMapMoving.mapVirtualCamera;
 
        objetoCameraVendingMachine = transform.GetChild(0).gameObject;
        initialLocalPositionCameraVending = objetoCameraVendingMachine.transform.localPosition;
        //Debug.Log(cameraVendingMachine != null);
    }

    // Update is called once per frame
    void Update()
    {

        if(NewControls.isExitVendingMachine)
        {
            StartCoroutine(ChangeToOrthograficinTwoSeconds());
            

            //StartCoroutine(ChangeTypeOfCamerain2Seconds());
            //StartCoroutine(TransicionSuave());
            //TransicionSuave();
            //NewControls.isExitVendingMachine = false;
        }

       /*if (Input.GetKeyDown(KeyCode.S))
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


        }*/
    }

   /* private void OnMouseEnter()
    {
        Debug.Log("Enter");
        cameraVendingMachine.Priority = 12;
        
    }

    private void OnMouseExit()
    {
        cameraVendingMachine.Priority = 10;
    }*/

    /*private void OnMouseDown()
    {
        cameraVendingMachine.Priority = 12;
    }*/

    public void OnPointerClick(PointerEventData eventData)
    {
        cameraVendingMachine.Priority = 12;
        StartCoroutine(ChangeToPerspectiveinTwoSeconds());
        // CameraMapMoving.ChangeTypeOfCameraToOrthografic(false);
        //StartCoroutine(TransicionSuave());
    }

    private IEnumerator TransicionSuave()
    {
        float tiempoPasado = 0f;
        while (tiempoPasado < duracionTransicion)
        {
            float t = tiempoPasado / duracionTransicion;
            ortograficaCamera.m_Lens.OrthographicSize = Mathf.Lerp(ortograficaCamera.m_Lens.OrthographicSize, 10f, t);
            perspectivaCamera.m_Lens.FieldOfView = Mathf.Lerp(perspectivaCamera.m_Lens.FieldOfView, 60f, t);
            //perspectivaCamera.m_Lens.Orthographic = true;
            Debug.Log(ortograficaCamera.m_Lens.FieldOfView);
            Debug.Log(perspectivaCamera.m_Lens.FieldOfView + "2");
            tiempoPasado += Time.deltaTime;
            yield return null;
        }
    }

    private IEnumerator ChangeTypeOfCamerain2Seconds()
    {
        yield return new WaitForSeconds(2f);
        CameraMapMoving.ChangeTypeOfCameraToOrthografic(true);
    }

    private IEnumerator ChangeToPerspectiveinTwoSeconds()
    {
        yield return new WaitForSeconds(2f);
        cameraVendingMachine.m_Lens.Orthographic = false;
        cameraVendingMachine.m_Lens.FieldOfView = 10f;
        float tiempoPasado = 0f;
        Debug.Log(tiempoPasado);
        while (tiempoPasado < duracionTransicionP)
        {
            float t = tiempoPasado / duracionTransicionP;
            cameraVendingMachine.m_Lens.FieldOfView = Mathf.Lerp(10f, FOVinPerspective, t);
            objetoCameraVendingMachine.transform.localPosition = new Vector3(Mathf.Lerp(initialLocalPositionCameraVending.x, positionCameraInPerspective.x, t), Mathf.Lerp(initialLocalPositionCameraVending.y, positionCameraInPerspective.y, t), Mathf.Lerp(initialLocalPositionCameraVending.z, positionCameraInPerspective.z, t));
            Debug.Log(objetoCameraVendingMachine.transform.localPosition);
            tiempoPasado += Time.deltaTime;           
            yield return null;
        }
    }

    private IEnumerator ChangeToOrthograficinTwoSeconds()
    {
        float tiempoPasado = 0f;
        while (tiempoPasado < duracionTransicionP)
        {
            float t = tiempoPasado / duracionTransicionP;
            cameraVendingMachine.m_Lens.FieldOfView = Mathf.Lerp(FOVinPerspective, 10f, t);
            objetoCameraVendingMachine.transform.localPosition = new Vector3(Mathf.Lerp(positionCameraInPerspective.x, initialLocalPositionCameraVending.x, t), Mathf.Lerp(positionCameraInPerspective.y, initialLocalPositionCameraVending.y,t), Mathf.Lerp(positionCameraInPerspective.z, initialLocalPositionCameraVending.z, t));
            Debug.Log(objetoCameraVendingMachine.transform.localPosition);
            tiempoPasado += Time.deltaTime;
            yield return null;
        }
        cameraVendingMachine.m_Lens.Orthographic = true;
        cameraVendingMachine.Priority = 10;      
    }
}
