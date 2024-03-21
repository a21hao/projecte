using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableWindow : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    private bool arrastrando = false;
    private RectTransform rectTransform;
    private Vector2 posicionInicialMouse;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Verificar si el clic ocurrió en la parte superior de la ventana
        if (RectTransformUtility.RectangleContainsScreenPoint(rectTransform, eventData.position))
        {
            arrastrando = true;
            // Guardar la posición inicial del ratón en relación con la ventana
            RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, eventData.position, eventData.pressEventCamera, out posicionInicialMouse);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (arrastrando)
        {
            Vector2 posicionRaton = eventData.position;
            // Convertir la posición del ratón a la posición local de la ventana
            RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform.parent as RectTransform, posicionRaton, eventData.pressEventCamera, out posicionRaton);
            // Calcular la posición de la ventana sumando la diferencia entre la posición del ratón y la posición inicial del ratón
            Vector2 nuevaPosicion = posicionRaton - posicionInicialMouse;
            rectTransform.localPosition = nuevaPosicion;
        }
    }
}