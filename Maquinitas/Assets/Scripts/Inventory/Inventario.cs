using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Inventario : MonoBehaviour
{
    public GraphicRaycaster graphRay;
    public static Transform canvas;
    public GameObject objetoSeleccionado;
    public Transform exParent;
    public Transform contenido;

    private PointerEventData pointerData;
    private List<RaycastResult> raycastResults;

    private void Awake()
    {

        pointerData = new PointerEventData(null);
        raycastResults = new List<RaycastResult>();

        canvas = transform.parent.transform;
    }

    private void Start()
    {
        NewControls.InputActions playerInput = new NewControls().Input;
        playerInput.Enable();
        playerInput.Player.MoveMap.performed += ctx => OnMoveMap(ctx.ReadValue<Vector2>());
        playerInput.Player.ExitVendingMachine.started += ctx => OnExitVendingMachinePressed();
        playerInput.Player.ExitVendingMachine.canceled += ctx => OnExitVendingMachineCanceled();
        playerInput.Player.MouseScroll.performed += ctx => OnScroll(ctx.ReadValue<Vector2>());
    }

    private void OnMoveMap(Vector2 direction)
    {
        Debug.Log("Movimiento del mapa: " + direction);
        // Implementa la lógica para mover el objeto seleccionado en el inventario según la dirección recibida
    }

    private void OnExitVendingMachinePressed()
    {
        Debug.Log("Botón de salida de la máquina expendedora presionado");
        // Implementa la lógica para manejar la salida de la máquina expendedora
    }

    private void OnExitVendingMachineCanceled()
    {
        Debug.Log("Botón de salida de la máquina expendedora soltado");
        // Implementa la lógica para manejar el evento de soltar el botón de salida de la máquina expendedora
    }

    private void OnScroll(Vector2 scrollValue)
    {
        Debug.Log("Valor de desplazamiento del mouse: " + scrollValue);
        // Implementa la lógica para manejar el desplazamiento del mouse en el inventario
    }

    // Resto del código del script...
    void Arrastrar()
    {
        // Método de arrastrar si es necesario
    }

    public Vector2 CanvasScreen(Vector2 screenPos)
    {
        // Método de conversión de coordenadas si es necesario
        return Vector2.zero;
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
}
