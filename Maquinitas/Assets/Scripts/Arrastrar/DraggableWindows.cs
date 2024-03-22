using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DraggableWindows : MonoBehaviour
{
    public GraphicRaycaster graphRay;
    public Transform canvas;

    [SerializeField] private GameObject objetoSeleccionado;
    private PointerEventData pointerData;
    private List<RaycastResult> raycastResults;

    void Start()
    {
        pointerData = new PointerEventData(null);
        raycastResults = new List<RaycastResult>();
    }

    void Update()
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
                objetoSeleccionado = raycastResults[0].gameObject;
                // Si el objeto seleccionado es diferente al canvas, comenzamos a arrastrarlo
                if (objetoSeleccionado != canvas.gameObject)
                {
                    // Convertimos la posición del cursor a una posición en el mundo
                    Vector2 newPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
                    // Actualizamos la posición del objeto seleccionado
                    objetoSeleccionado.transform.position = newPosition;

                    // Agregar un Debug.Log para imprimir información sobre el objeto seleccionado
                    Debug.Log("Objeto seleccionado: " + objetoSeleccionado.name);
                }
            }
        }
    }
}
