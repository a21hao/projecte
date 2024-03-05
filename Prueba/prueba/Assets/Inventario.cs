using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.Rendering;

public class Inventario : MonoBehaviour
{

    public GraphicRaycaster graphRay;
    public Transform canvas;
    public GameObject objetoSeleccionado;
    public Transform exParent;

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
            if (raycastResults.Count > 0)
            {
                if (raycastResults[0].gameObject.GetComponent<Item>())
                {
                    objetoSeleccionado = raycastResults[0].gameObject;
                    exParent = objetoSeleccionado.transform.parent.transform;
                    objetoSeleccionado.transform.SetParent(canvas);
                }
            }
        }

        if (objetoSeleccionado != null)
        {
            objetoSeleccionado.GetComponent<RectTransform>().localPosition = CanvasScreen(Input.mousePosition);
        }

        if (Input.GetMouseButtonUp(0))
        {
            pointerData.position = Input.mousePosition;
            raycastResults.Clear();
            graphRay.Raycast(pointerData, raycastResults);

            objetoSeleccionado.transform.SetParent(exParent);

                if(raycastResults.Count > 0)
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
            //raycastResults.Clear();
        }
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
