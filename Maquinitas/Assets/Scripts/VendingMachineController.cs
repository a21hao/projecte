using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Cinemachine;

public class VendingMachineController : MonoBehaviour, IPointerClickHandler
{

    private CinemachineVirtualCamera cameraVendingMachine;
    private bool canChangeToCamera = true;
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
    private MeshRenderer mshMachine;
    private Color originalColor;
    private Material matMachine;
    private Image imgCanvas;

    void Awake()
    {
        Transform cube = gameObject.transform.Find("Máquina_Low_Poly/Cube");
        mshMachine = cube.gameObject.GetComponent<MeshRenderer>();
        matMachine = mshMachine.materials[1];
        originalColor = matMachine.color;
        Transform img = gameObject.transform.Find("Canvas/Image");
        imgCanvas = img.gameObject.GetComponent<Image>();
    }
    void Start()
    {
        cameraVendingMachine = gameObject.transform.GetComponentInChildren<CinemachineVirtualCamera>();
        ortograficaCamera = CameraMapMoving.mapVirtualCamera;
        objetoCameraVendingMachine = transform.GetChild(0).gameObject;
        initialLocalPositionCameraVending = objetoCameraVendingMachine.transform.localPosition;
        
        //originalColor = materialMachine.color;
        //matMachine = materialMachine;
    }

    void Update()
    {

        if(NewControls.isEscPressed)
        {
            StartCoroutine(ChangeToOrthograficinTwoSeconds());
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(canChangeToCamera)
        {
            cameraVendingMachine.Priority = 12;
            StartCoroutine(ChangeToPerspectiveinTwoSeconds());
        }
    }

    private IEnumerator TransicionSuave()
    {
        float tiempoPasado = 0f;
        while (tiempoPasado < duracionTransicion)
        {
            float t = tiempoPasado / duracionTransicion;
            ortograficaCamera.m_Lens.OrthographicSize = Mathf.Lerp(ortograficaCamera.m_Lens.OrthographicSize, 10f, t);
            perspectivaCamera.m_Lens.FieldOfView = Mathf.Lerp(perspectivaCamera.m_Lens.FieldOfView, 60f, t);
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
            tiempoPasado += Time.deltaTime;
            yield return null;
        }
        cameraVendingMachine.m_Lens.Orthographic = true;
        cameraVendingMachine.Priority = 10;      
    }

    public void ChangeCanUseCamera(bool canChange)
    {
        canChangeToCamera = canChange;
    }

    public void ChangeToColorUsefull(bool useFull)
    {
        if(!useFull)
        {

            //originalColor = materialMachine.color;
            //Debug.Log(matMachine);
            matMachine.color = Color.gray;
            imgCanvas.color = Color.gray;
        }
        else
        {
            matMachine.color = originalColor;
            imgCanvas.color = new Color(11f/255f,97f/255f,174f/255f,0.8f);
            //imgCanvas.color = Color.blue;
        }
        
    }

    public void GetOutImageCanvas()
    {
        imgCanvas.color = new Color(1f, 1f, 1f, 0f);
    } 
}
