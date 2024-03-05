using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class Inventario : MonoBehaviour
{
    [System.Serializable]
    public struct ObjetoInventarioId
    {
        public int id;
        public int cantidad;

        public ObjetoInventarioId(int id, int cantidad)
        {
            this.id = id;
            this.cantidad = cantidad;
        }
    }

    [SerializeField]
    ObjectDataBase data;
    [Header("Variables Drag nad Drop")]

    public GraphicRaycaster graphRay;
    public static Transform canvas;
    public GameObject objetoSeleccionado;
    public Transform exParent;

    [Header("Prefs y items")]
    public static GameObject description;
    //public CartelEliminacion CE;
    //public int OSC;
    //public int OSID;

    public Transform contenido;
    public Item item;
    public List<ObjetoInventarioId> inventario = new List<ObjetoInventarioId>();

    private PointerEventData pointerData;
    private List<RaycastResult> raycastResults;

    private void Start()
    {
        InventoryUpdate();

        pointerData = new PointerEventData(null);
        raycastResults = new List<RaycastResult>();

        description = GameObject.Find("Descripcion");
        //CE.gameObject.SetActive(false);

        canvas = transform.parent.transform;
    }

    private void Update()
    {
        Arrastrar();
    }

    void Arrastrar()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pointerData.position = Input.mousePosition;
            graphRay.Raycast(pointerData, raycastResults);
            if (raycastResults.Count > 0)
            {
                if (raycastResults[0].gameObject.GetComponent<Item>())
                {
                    objetoSeleccionado = raycastResults[0].gameObject;
                    exParent = objetoSeleccionado.transform.parent.transform;
                    exParent.GetComponent<Image>().fillCenter = false;
                    objetoSeleccionado.transform.SetParent(canvas);
                }
            }
        }

        if (objetoSeleccionado != null)
        {
            objetoSeleccionado.GetComponent<RectTransform>().localPosition = CanvasScreen(Input.mousePosition);
        }

        if (objetoSeleccionado != null)
        {
            if (Input.GetMouseButtonUp(0))
            {
                pointerData.position = Input.mousePosition;
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
                            if (resultado.gameObject.GetComponentInChildren<Item>().ID == objetoSeleccionado.GetComponent<Item>().ID)
                            {
                                Debug.Log("ID igual");
                                resultado.gameObject.GetComponentInChildren<Item>().cantidad += objetoSeleccionado.GetComponent<Item>().cantidad;
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
                objetoSeleccionado.transform.localPosition = Vector3.zero;
                objetoSeleccionado = null;
                //    {
                //        foreach(var resultado in raycastResults)
                //        {
                //            if (resultado.gameObject.tag == "Slot")
                //            {
                //                if (resultado.gameObject.GetComponentInChildren<Item>() == null)
                //                {
                //                    objetoSeleccionado.transform.SetParent(resultado.gameObject.transform);
                //                    objetoSeleccionado.transform.localPosition = Vector2.zero;
                //                    exParent = objetoSeleccionado.transform.parent.transform;
                //                    Debug.Log("Libre");
                //                }
                //                else
                //                {
                //                    if(resultado.gameObject.GetComponentInChildren<Item>().ID == objetoSeleccionado.GetComponent<Item>().ID){
                //                        Debug.Log("ID igual");
                //                        resultado.gameObject.GetComponentInChildren<Item>().cantidad += objetoSeleccionado.GetComponent<Item>().cantidad;
                //                        Destroy(objetoSeleccionado.gameObject);
                //                    }
                //                    else
                //                    {
                //                        Debug.Log("ID diferente");
                //                        objetoSeleccionado.transform.SetParent(exParent.transform);
                //                        objetoSeleccionado.transform.localPosition = Vector2.zero;
                //                    }
                //                }
                //            }
                //            else
                //            {
                //                Debug.Log("Fuera del inventario");
                //                objetoSeleccionado.transform.SetParent(exParent.transform);
                //                objetoSeleccionado.transform.localPosition = Vector2.zero;
                //            }
                //        }
                //        objetoSeleccionado = null;
                //    }   
                //}
            }
        }
        raycastResults.Clear();
    }
    public Vector2 CanvasScreen(Vector2 screenPos)
    {
        Vector2 viewportPoint = Camera.main.ScreenToViewportPoint(screenPos);
        Vector2 canvasSize = canvas.GetComponent<RectTransform>().sizeDelta;

        return (new Vector2(viewportPoint.x * canvasSize.x, viewportPoint.y * canvasSize.y) - (canvasSize / 2));
    }

    public void AgregarItem(int id, int cantidad)
    {

    }
    public void EliminarItem(int id, int cantidad)
    {

    }

    List<Item> pool = new List<Item>();

    public void InventoryUpdate()
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (i < inventario.Count)
            {
                ObjetoInventarioId o = inventario[i];
                pool[i].ID = o.id;
                pool[i].GetComponent<Image>().sprite = data.baseDatos[o.id].icono;
                pool[i].GetComponent<RectTransform>().localPosition = Vector3.zero;
                pool[i].cantidad = o.cantidad;
                //pool[i].Boton.onClick.RemoveAllListeners();
                //pool[i].Boton.onClick.AddListener(() => gameObject.SendMessage(data.baseDatos[o.id].Void, SendMessageOptions.DontRequireReceiver));
                pool[i].gameObject.SetActive(true);
            }
            else
            {
                pool[i].gameObject.SetActive(false);
                //pool[i]._descripcion.SetActive(false);
                pool[i].gameObject.transform.parent.GetComponent<Image>().fillCenter = false;
            }
        }
        if (inventario.Count > pool.Count)
        {
            for (int i = pool.Count; i < inventario.Count; i++)
            {
                Item it = Instantiate(item, contenido.GetChild(i));
                pool.Add(it);

                if (contenido.GetChild(0).childCount >= 2)
                {
                    for (int s = 0; s < contenido.childCount; s++)
                    {
                        if (contenido.GetChild(s).childCount == 0)
                        {
                            it.transform.SetParent(contenido.GetChild(s));
                            break;
                        }
                    }
                }
                it.transform.position = Vector3.zero;
                it.transform.localScale = Vector3.one;

                ObjetoInventarioId o = inventario[i];
                pool[i].ID = o.id;
                pool[i].GetComponent<RectTransform>().localPosition = Vector3.zero;
                pool[i].GetComponent<Image>().sprite = data.baseDatos[o.id].icono;
                pool[i].cantidad = o.cantidad;
                //pool[i].Boton.onClick.RemoveAllListeners();
                //pool[i].Boton.onClick.AddListener(() => gameObject.SendMessage(data.baseDatos[o.id].Void, SendMessageOptions.DontRequireReceiver));
                pool[i].gameObject.SetActive(true);
            }
        }
    }
}
