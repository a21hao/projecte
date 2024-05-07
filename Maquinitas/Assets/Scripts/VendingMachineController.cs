using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
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
    [SerializeField]
    private int MoneyToBuyMachine;
    private TextMeshProUGUI textMoneyMachine;
    private Color originalColorText;
    private Animator canvasTextAnimator;
    private GameObject canvasText;

    void Awake()
    {
        Transform cube = gameObject.transform.Find("Máquina_Low_Poly/Cube");
        mshMachine = cube.gameObject.GetComponent<MeshRenderer>();
        matMachine = mshMachine.materials[1];
        originalColor = matMachine.color;
        Transform img = gameObject.transform.Find("Canvas/Image");
        imgCanvas = img.gameObject.GetComponent<Image>();
        Transform textMoneyMachinetr = gameObject.transform.Find("Canvastext/TextMoneyMachine");
        textMoneyMachine = textMoneyMachinetr.gameObject.GetComponent<TextMeshProUGUI>();
        textMoneyMachine.text = MoneyToBuyMachine.ToString() + "¥";
        originalColorText = textMoneyMachine.color;
        textMoneyMachine.color = new Color(215f / 255f, 76f / 255f, 76f / 255f, 0.8f);
        Transform canvasTexttr = gameObject.transform.Find("Canvastext");
        canvasText = gameObject.transform.Find("Canvastext").gameObject;
        //canvasTextAnimator = canvasTexttr.gameObject.GetComponent<Animator>();
        //canvasTextAnimator.enabled = false;
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
            ObjectivesAndStats.cumplirAccedeAVistaDeMaquina();
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

    private IEnumerator textAnimation()
    {
        float tiempoPasado = 0f;
        float tiempo2 = 0f;
        float tiempo3 = 0f;
        float tiempo4 = 0f;
        while (tiempoPasado < 1.4f)
        {
            if(tiempoPasado <= 0.35f)
            {
                canvasText.transform.localPosition = new Vector3(tiempoPasado / 0.35f * 0.83f, tiempoPasado / 0.35f * 2.89f, 0f);
            }
            else if(tiempoPasado>0.35f&&tiempoPasado<=0.70f) {
                
                canvasText.transform.localPosition = new Vector3(0.83f - (tiempo2 / 0.35f * (0.83f-0.09f)), 2.89f + (tiempo2 / 0.35f * (3.16f - 2.89f)),0f);
                tiempo2 += Time.deltaTime;
            }
            else if (tiempoPasado > 0.70f && tiempoPasado <= 1.05f)
            {
                
                canvasText.transform.localPosition = new Vector3(0.09f + (tiempo3 / 0.35f * (1.18f - 0.09f)), 3.16f + (tiempo3 / 0.35f * (3.42f - 3.16f)), 0f);
                tiempo3 += Time.deltaTime;
            }
            else if (tiempoPasado > 1.05f && tiempoPasado <= 1.4f)
            {
                
                canvasText.transform.localPosition = new Vector3(1.18f - (tiempo4 / 0.35f * (1.18f - 0.02f)), 3.42f + (tiempo4 / 0.35f * (3.88f - 3.42f)), 0f);
                tiempo4 += Time.deltaTime;
            }

            tiempoPasado += Time.deltaTime;
            yield return null;
        }
        
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
            if (MoneyManager.instance.DineroTotal >= MoneyToBuyMachine)
            {
                matMachine.color = Color.gray;
                imgCanvas.color = Color.gray;
                textMoneyMachine.color = new Color(215f / 255f, 76f / 255f, 76f / 255f, 0.8f);
            }
            else
            {
                matMachine.color = new Color(215f / 255f, 76f / 255f, 76f / 255f, 0.8f);
                imgCanvas.color = new Color(215f / 255f, 76f / 255f, 76f / 255f, 0.8f);
                textMoneyMachine.color = new Color(215f / 255f, 76f / 255f, 76f / 255f, 0.8f);
            }
        }
        else
        {
            if(MoneyManager.instance.DineroTotal >= MoneyToBuyMachine)
            {
                matMachine.color = originalColor;
                imgCanvas.color = new Color(11f / 255f, 97f / 255f, 174f / 255f, 0.8f);
                textMoneyMachine.color = new Color(215f / 255f, 76f / 255f, 76f / 255f, 0.8f);
            }
            else
            {
                matMachine.color = new Color(215f / 255f, 76f / 255f, 76f / 255f, 0.8f);
                imgCanvas.color = new Color(215f / 255f, 76f / 255f, 76f / 255f, 0.8f);
                textMoneyMachine.color = new Color(215f / 255f, 76f / 255f, 76f / 255f, 0.8f);
            }
            
            //imgCanvas.color = Color.blue;
        }
        
    }

    public void GetOutImageCanvas()
    {
        imgCanvas.color = new Color(1f, 1f, 1f, 0f);
        textMoneyMachine.color = new Color(1f, 1f, 1f, 0f);
    }

    public void GetOutTextCanvas()
    {
        /*canvasTextAnimator.enabled = true;
        canvasTextAnimator.SetTrigger("BuyMachine");*/
        //StartCoroutine(textAnimation());
        canvasText.SetActive(false);
        
    }


    public int GetMoneyToBuyMachine()
    {
        return MoneyToBuyMachine;
    }

    public void DisableAnimatortext()
    {
        canvasTextAnimator.enabled = false;
    }
}
