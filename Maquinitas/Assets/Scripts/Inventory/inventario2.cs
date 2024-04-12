using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class inventario2 : MonoBehaviour
{

    [SerializeField] EventSystem m_EventSystem;
    private PointerEventData pointerData;
    private GraphicRaycaster graphRay;
    private List<RaycastResult> raycastResults;
    private Transform slotOfItemInitial;
    private GameObject objetoSeleccionado;
    private ScrollRect scrollRect;
    private Transform AlmacenTransform;
    private Transform canvas;
    private bool objetoArrastrandose = false;

    private void Awake()
    {

        pointerData = new PointerEventData(m_EventSystem);
        raycastResults = new List<RaycastResult>();
        scrollRect = gameObject.GetComponent<ScrollRect>();
        AlmacenTransform = gameObject.transform;
        canvas = transform.parent.transform;
    }

    void Update()
    {
        Arrastrar();

    }

    void Arrastrar()
    {
        if (Mouse.current.leftButton.isPressed && !objetoArrastrandose)
        {
            pointerData.position = Mouse.current.position.ReadValue();
            graphRay.Raycast(pointerData, raycastResults);
            if (raycastResults.Count > 0)
            {
                foreach (var result in raycastResults)
                {
                    Debug.Log("Objeto detectado: " + result.gameObject.name);
                    Item itemComponent = result.gameObject.GetComponent<Item>();
                    if (itemComponent != null)
                    {
                        objetoSeleccionado = result.gameObject;
                        slotOfItemInitial = objetoSeleccionado.transform.parent.transform;
                        slotOfItemInitial.GetComponent<Image>().fillCenter = false;
                        objetoSeleccionado.transform.SetParent(canvas);
                        objetoArrastrandose = true;
                        scrollRect.enabled = false;

                    }
                }
            }
        }
        if (Mouse.current.leftButton.isPressed && objetoArrastrandose)
        {
            objetoSeleccionado.GetComponent<RectTransform>().localPosition = CanvasScreen(Mouse.current.position.ReadValue());
        }

        if (!Mouse.current.leftButton.isPressed && objetoArrastrandose)
        {
            pointerData.position = Mouse.current.position.ReadValue();
            raycastResults.Clear();
            graphRay.Raycast(pointerData, raycastResults);
            objetoSeleccionado.transform.SetParent(slotOfItemInitial);
            if (raycastResults.Count > 0)
            {
                foreach (var resultado in raycastResults)
                {
                    if (resultado.gameObject == objetoSeleccionado) continue;
                    if (resultado.gameObject.CompareTag("Slot"))
                    {
                        if (resultado.gameObject.GetComponentInChildren<Item>() == null)
                        {
                            objetoSeleccionado.transform.SetParent(resultado.gameObject.transform);
                            Debug.Log("Slot Libre");
                        }
                    }
                    if (resultado.gameObject.CompareTag("Item"))
                    {
                        if (resultado.gameObject.GetComponentInChildren<Item>().GetID() == objetoSeleccionado.GetComponent<Item>().GetID())
                        {
                            Debug.Log("ID igual");
                            resultado.gameObject.GetComponentInChildren<Item>().SetCantidad(resultado.gameObject.GetComponentInChildren<Item>().GetCantidad() + objetoSeleccionado.GetComponent<Item>().GetCantidad());
                            Destroy(objetoSeleccionado.gameObject);
                        }
                        else
                        {
                            Debug.Log("ID diferente");
                            objetoSeleccionado.transform.SetParent(resultado.gameObject.transform.parent);
                            resultado.gameObject.transform.SetParent(slotOfItemInitial);
                            resultado.gameObject.transform.localPosition = Vector3.zero;
                        }
                    }
                }
                objetoSeleccionado.transform.localPosition = Vector3.zero;
                objetoSeleccionado = null;
                objetoArrastrandose = false;
                scrollRect.enabled = true;
            }
            raycastResults.Clear();
            //objetoSeleccionado.transform.SetParent(slotOfItemInitial);
        }
    }

    private Vector2 CanvasScreen(Vector2 screenPos)
    {
        Vector2 viewportPoint = Camera.main.ScreenToViewportPoint(screenPos);
        Vector2 canvasSize = canvas.GetComponent<RectTransform>().sizeDelta;

        return (new Vector2(viewportPoint.x * canvasSize.x, viewportPoint.y * canvasSize.y) - (canvasSize / 2));
    }
    // Start is called before the first frame update
    /*void Start()
    {

    }*/

    // Update is called once per frame
    /*void Update()
    {

    }*/
}
