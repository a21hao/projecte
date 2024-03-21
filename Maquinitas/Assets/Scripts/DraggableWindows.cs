using UnityEngine;

public class DraggableWindow : MonoBehaviour
{
    private bool arrastrando = false;
    private Vector3 posicionInicial;
    private Vector3 posicionRatonInicial;
    public RectTransform parteArrastre; // Asigna la parte superior de la ventana aquí

    private void Update()
    {
        if (arrastrando && Input.GetMouseButton(0))
        {
            Vector3 diferencia = (Input.mousePosition - posicionRatonInicial);
            transform.position = posicionInicial + diferencia;
        }
    }

    public void OnMouseDown()
    {
        if (RectTransformUtility.RectangleContainsScreenPoint(parteArrastre, Input.mousePosition))
        {
            posicionInicial = transform.position;
            posicionRatonInicial = Input.mousePosition;
            arrastrando = true;
        }
    }

    public void OnMouseUp()
    {
        arrastrando = false;
    }
}