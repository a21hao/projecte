using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using System.IO;

[System.Serializable]
public class ChildInfo
{
    public string nombre;
    public string spritePath;
    public string precio;
    public string descripcion;
    public int id;
    public string tipo;
    public int cantidad;
}

[System.Serializable]
public class SlotState
{
    public bool tieneHijos;
    public List<ChildInfo> hijos;

    public SlotState(bool tieneHijos, List<ChildInfo> hijos)
    {
        this.tieneHijos = tieneHijos;
        this.hijos = hijos;
    }
}

public class Inventario : MonoBehaviour
{
    public GraphicRaycaster graphRay;
    public static Transform canvas;
    public GameObject objetoSeleccionado;
    public Transform exParent;
    public Transform contenido;
    public ScrollRect scrollRect;
    public List<GameObject> slots;

    private PointerEventData pointerData;
    private List<RaycastResult> raycastResults;
    private bool objetoArrastrado = false;

    [SerializeField] GameObject prefabObjetoAlmacen;

    private void Awake()
    {

        pointerData = new PointerEventData(null);
        raycastResults = new List<RaycastResult>();

        canvas = transform.parent.transform;
        CargarEstadoSlots();
    }

    private void Update()
    {
        Arrastrar();
    }

    void Arrastrar()
    {
        if (Mouse.current.leftButton.isPressed)
        {
            pointerData.position = Mouse.current.position.ReadValue();
            graphRay.Raycast(pointerData, raycastResults);
            if (raycastResults.Count > 0)
            {
                foreach (var result in raycastResults)
                {
                    Debug.Log("Objeto detectado: " + result.gameObject.name); // Agregar mensaje de depuración
                }
                if (raycastResults[0].gameObject.GetComponent<Item>())
                {
                    objetoSeleccionado = raycastResults[0].gameObject;
                    exParent = objetoSeleccionado.transform.parent.transform;
                    exParent.GetComponent<Image>().fillCenter = false;
                    objetoSeleccionado.transform.SetParent(canvas);
                    objetoArrastrado = true;
                    scrollRect.enabled = false;
                }
            }
        }

        if (objetoSeleccionado != null && Mouse.current.leftButton.isPressed)
        {
            objetoSeleccionado.GetComponent<RectTransform>().localPosition = CanvasScreen(Mouse.current.position.ReadValue());
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
            objetoSeleccionado.transform.localPosition = Vector3.zero;
            objetoSeleccionado = null;
            objetoArrastrado = false;
            scrollRect.enabled = true;
            GuardarEstadoSlots();
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

    public Vector2 CanvasScreen(Vector2 screenPos)
    {
        Vector2 viewportPoint = Camera.main.ScreenToViewportPoint(screenPos);
        Vector2 canvasSize = canvas.GetComponent<RectTransform>().sizeDelta;

        return (new Vector2(viewportPoint.x * canvasSize.x, viewportPoint.y * canvasSize.y) - (canvasSize / 2));
    }

    public void FiltrarPorTipo(string tipo = null)
    {
        foreach (GameObject slot in slots)
        {
            if (slot.GetComponentInChildren<Item>() != null)
            {
                Item item = slot.GetComponentInChildren<Item>();
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

    void CargarEstadoSlots()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            string slotKey = "Slot" + i;
            string json = PlayerPrefs.GetString(slotKey);

            if (!string.IsNullOrEmpty(json))
            {
                SlotState slotState = JsonUtility.FromJson<SlotState>(json);

                if (slotState.tieneHijos)
                {
                    foreach (var childInfo in slotState.hijos)
                    {
                        GameObject nuevoObjeto = Instantiate(prefabObjetoAlmacen);
                        nuevoObjeto.transform.SetParent(slots[i].transform);
                        nuevoObjeto.transform.localPosition = Vector3.zero;

                        // Cargar la información del hijo desde ChildInfo
                        nuevoObjeto.GetComponent<Item>().SetInformacion(childInfo.nombre, Resources.Load<Sprite>(childInfo.spritePath), childInfo.precio, childInfo.descripcion, childInfo.id, childInfo.tipo, childInfo.cantidad);
                    }
                }
            }
        }
    }

    void GuardarEstadoSlots()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            string slotKey = "Slot" + i;
            Transform slotTransform = slots[i].transform;
            bool tieneHijos = slotTransform.childCount > 0;

            if (tieneHijos)
            {
                List<ChildInfo> hijos = new List<ChildInfo>();

                foreach (Transform hijoTransform in slotTransform)
                {
                    // Obtener la información del hijo
                    Item item = hijoTransform.GetComponent<Item>();
                    ChildInfo childInfo = new ChildInfo
                    {
                        nombre = item.nombreText,
                        spritePath = "Sprites/" + item.spriteImage.sprite.name, // Ruta relativa al sprite
                        precio = item.precioObjeto,
                        descripcion = item.descripcionObjeto,
                        id = item.GetID(),
                        tipo = item.tipo,
                        cantidad = item.GetCantidad()
                    };
                    hijos.Add(childInfo);
                }

                // Serializar la información de los hijos a JSON
                SlotState slotState = new SlotState(true, hijos);
                string json = JsonUtility.ToJson(slotState);

                // Guardar el estado del slot en PlayerPrefs
                PlayerPrefs.SetString(slotKey, json);
            }
            else
            {
                PlayerPrefs.DeleteKey(slotKey); // Eliminar la clave si no hay hijos
            }
        }

        PlayerPrefs.Save();
    }
}
