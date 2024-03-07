using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class Inventario : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textoDinero;
    [SerializeField] GameObject objetoDeTienda;
    private int numeroMaximoObjeto = 9999;
    private Dictionary<PlantillaObjetos, int> inventario = new Dictionary<PlantillaObjetos, int>();

    public GraphicRaycaster graphRay;
    public static Transform canvas;
    public GameObject objetoSeleccionado;
    public Transform exParent;
    public Transform contenido;

    private PointerEventData pointerData;
    private List<RaycastResult> raycastResults;

    private void Start()
    {

        pointerData = new PointerEventData(null);
        raycastResults = new List<RaycastResult>();

        canvas = transform.parent.transform;
    }

    private void Update()
    {
        ActualizarUI();
        Arrastrar();
    }

    void Arrastrar()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            pointerData.position = Mouse.current.position.ReadValue();
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
            if (Mouse.current.leftButton.wasPressedThisFrame)
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

    public void IncluirObjeto(PlantillaObjetos datos)
    {
        if (MoneyManager.DineroTotal >= datos.precioObjeto && !inventario.ContainsKey(datos) && numeroMaximoObjeto > 0)
        {
            MoneyManager.DecrementarDinero(datos.precioObjeto);
            numeroMaximoObjeto--;

            // Instancia el objeto utilizando la prefab
            GameObject objetoInstanciado = Instantiate(objetoDeTienda, Vector3.zero, Quaternion.identity, GameObject.FindGameObjectWithTag("ObjetoComprable").transform);
            // Obtiene el componente Image del nuevo objeto
            Image imagen = objetoInstanciado.GetComponent<Image>();
            // Asigna la imagen recibida al componente Image
            imagen.sprite = datos.imagenObjeto;
            // Asigna los datos del objeto a la instancia
            Objeto scriptObjeto = objetoInstanciado.GetComponent<Objeto>();
            scriptObjeto.CrearObjeto(datos);

            // Agrega el objeto al inventario con cantidad 1
            inventario.Add(datos, 1);
            Debug.Log("Se agregó el objeto al inventario: " + datos.nameObjeto);

            // Actualiza la UI
            ActualizarUI();
        }
        else
        {
            Debug.Log("No se puede agregar el objeto al inventario.");
        }
    }

    private void ActualizarUI()
    {
        textoDinero.text = MoneyManager.DineroTotal.ToString();
    }
}
