using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class Inventario : MonoBehaviour
{

    public GraphicRaycaster graphRay;
    public Transform canvas;
    public GameObject objetoSeleccionado;

    private PointerEventData pointerData;
    private List<RaycastResult> raycastResults;

    private void Start()
    {
        pointerData = new PointerEventData(null);
        raycastResults = new List<RaycastResult>();
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
            if(raycastResults.Count >0)
            {
                if (raycastResults[0].gameObject.GetComponent<Item>());
                objetoSeleccionado = raycastResults[0].gameObject;
                objetoSeleccionado.transform.SetParent(canvas);
            }
        }

        if(objetoSeleccionado != null)
        {
            objetoSeleccionado.GetComponent<RectTransform>().localPosition = CanvasScreen(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            pointerData.position = Input.mousePosition;
            raycastResults.Clear();
            graphRay.Raycast(pointerData, raycastResults);
            if(raycastResults.Count > 0)
            {
                foreach(var resultado in raycastResults)
                {
                    if (resultado.gameObject.tag == "Slot")
                    {
                        objetoSeleccionado.transform.SetParent(resultado.gameObject.transform);
                        objetoSeleccionado.transform.localPosition = Vector2.zero;
                    }
                }
            }
            //objetoSeleccionado = null;
        }
        raycastResults.Clear();
    }
    //public void GetIndex(int index)
    //{

    //}
    public Vector2 CanvasScreen(Vector2 screenPos)
    {
        Vector2 viewportPoint = Camera.main.ScreenToViewportPoint(screenPos);
        Vector2 canvasSize = canvas.GetComponent<RectTransform>().sizeDelta;

        return (new Vector2(viewportPoint.x * canvasSize.x, viewportPoint.y * canvasSize.y) - (canvasSize / 2));
    }
}
