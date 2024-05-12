using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Inventario3 : MonoBehaviour
{
    // Start is called before the first frame update
    //[SerializeField]
    //private InputSystem inpSys;
    [SerializeField]
    private EventSystem eventSystem;
    public LayerMask capasRaycast;
    public GraphicRaycaster graphRay;
    public static Transform canvas;
    //public Canvas canv;
    public GameObject objetoSeleccionado;
    public Transform exParent;
    public Transform contenido;
    public ScrollRect scrollRect;
    public List<GameObject> slots;

    private PointerEventData pointerData;
    private List<RaycastResult> raycastResults;
    private bool objetoArrastrado = false;
    private int capaMaquina;

    private void Awake()
    {

        pointerData = new PointerEventData(eventSystem);
        raycastResults = new List<RaycastResult>();

        canvas = GetComponentInParent<Canvas>().transform;
        capaMaquina = LayerMask.GetMask("Maquina");
    }

    private void Update()
    {
        Arrastrar();
    }

    void Arrastrar()
    {
        if (Mouse.current.leftButton.isPressed && !objetoArrastrado)
        {
            pointerData.position = Mouse.current.position.ReadValue();
            graphRay.Raycast(pointerData, raycastResults);
            if (raycastResults.Count > 0)
            {
                foreach (var result in raycastResults)
                {

                    if (result.gameObject.GetComponent<Item>())
                    {
                        objetoSeleccionado = result.gameObject;
                        exParent = objetoSeleccionado.transform.parent.transform;
                        exParent.GetComponent<Image>().fillCenter = false;
                        objetoSeleccionado.transform.SetParent(canvas);
                        //objetoSeleccionado.transform.position = exParent.gameObject.transform.position;
                        //objetoSeleccionado.transform.localPosition = new Vector3(0f, 0f, 0f);
                        objetoArrastrado = true;
                        scrollRect.enabled = false;
                    }
                }

            }
            raycastResults.Clear();
        }

        if (objetoSeleccionado != null && Mouse.current.leftButton.isPressed)
        {
            objetoSeleccionado.GetComponent<RectTransform>().localPosition = CanvasScreen(Mouse.current.position.ReadValue());
            //objetoSeleccionado.transform.localPosition/*.GetComponent<RectTransform>().localPosition*/ = CanvasScreen(Mouse.current.position.ReadValue(), canv);
        }

        if (objetoSeleccionado != null && !Mouse.current.leftButton.isPressed)
        {
            pointerData.position = Mouse.current.position.ReadValue();
            raycastResults.Clear();
            graphRay.Raycast(pointerData, raycastResults);
            objetoSeleccionado.transform.SetParent(exParent);
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
                            resultado.gameObject.transform.SetParent(exParent);
                            resultado.gameObject.transform.localPosition = Vector3.zero;
                        }
                    }

                }
            }
            putInMachine();
            objetoSeleccionado.transform.localPosition = Vector3.zero;
            if (objetoSeleccionado.GetComponent<Item>().GetCantidad() <= 0)
            {
                Destroy(objetoSeleccionado);
            }
            objetoSeleccionado = null;
            objetoArrastrado = false;
            scrollRect.enabled = true;

        }
        raycastResults.Clear();
    }

    public GameObject GetSlotVacio()
    {
        foreach (Transform child in contenido)
        {
            if (child.childCount == 0)
            {
                return child.gameObject;
            }
        }
        return null;
    }

    public Item GetItemOfSlotByIdItem(int idItem)
    {
        foreach (Transform child in contenido)
        {
            if (child.childCount > 0)
            {
                Item itemToReturn = null;
                itemToReturn = child.GetChild(0).gameObject.GetComponent<Item>();
                if(itemToReturn != null)
                {
                    if(itemToReturn.GetID() == idItem)
                    return itemToReturn;
                }
            }
        }
        return null;
    }

    /*public Vector2 CanvasScreen(Vector2 screenPos, Canvas canvas)
    {
        // Convertir la posición de la pantalla a un punto en el espacio del mundo
        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(screenPos);

        // Convertir el punto del mundo a un punto en el espacio local del Canvas
        Vector2 localPos = canvas.transform.InverseTransformPoint(worldPoint);

        // Ajustar la posición local basada en el pivote del RectTransform del Canvas
        RectTransform canvasRect = canvas.GetComponent<RectTransform>();
        localPos += new Vector2(canvasRect.sizeDelta.x * canvasRect.pivot.x, canvasRect.sizeDelta.y * canvasRect.pivot.y);

        return localPos;
    }*/
    public Vector2 CanvasScreen(Vector2 screenPos)
    {
        Vector2 viewportPoint = Camera.main.ScreenToViewportPoint(screenPos);
        Vector2 canvasSize = canvas.GetComponent<RectTransform>().sizeDelta;
        Vector2 retVal = (new Vector2(viewportPoint.x * canvasSize.x, viewportPoint.y * canvasSize.y) - (canvasSize / 2));
        return retVal;
    }

    public void FiltrarPorTipo(string tipo = null)
    {
        foreach (GameObject slot in slots)
        {
            if (slot.GetComponentInChildren<Item>() != null)
            {
                Item item = slot.GetComponentInChildren<Item>();
                if (tipo == "All")
                {
                    slot.SetActive(true);
                }
                else
                {
                    if (tipo == null || item.tipo == tipo)
                    {
                        slot.SetActive(true);
                    }
                    else
                    {
                        slot.SetActive(false);
                    }
                }
            }
        }
    }

    private void putInMachine()
    {
        Debug.Log("Ha entrado");
        Vector2 mousePosition = Mouse.current.position.ReadValue();

        // Convertir la posición del ratón a una posición en el mundo
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(mousePosition.x, mousePosition.y, 1000));

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, capaMaquina))
        {
            //Instantiate(prefab, hit.point, Quaternion.identity);
            //Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 10));
            //Vector3 positionSpawn = new Vector3(Input.mousePosition.x, 0, Input.mousePosition.z);
            Debug.Log(hit.collider.gameObject.name);
            hit.collider.gameObject.GetComponent<MachineInventory>().PutItem(objetoSeleccionado.GetComponent<Item>());
            //vendingInstantiate = Instantiate(prefabVendingMachine, hit.point, prefabVendingMachine.transform.rotation);

        }
    }

}
