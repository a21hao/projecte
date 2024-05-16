using UnityEngine;
using UnityEngine.EventSystems;

public class OutlineMapa : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Material outlineMaterial;
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        // Asegúrate de que el objeto tenga un Material asignado desde el editor
        rend.material = outlineMaterial;
        // Desactivar el efecto de contorno al inicio
        SetOutline(false);
    }

    // Método para activar o desactivar el efecto de contorno
    void SetOutline(bool outline)
    {
        if (outline)
        {
            // Activar el efecto de contorno
            rend.material.SetFloat("_Outline", 0.03f); // Ajusta el grosor del contorno según sea necesario
        }
        else
        {
            // Desactivar el efecto de contorno
            rend.material.SetFloat("_Outline", 0f);
        }
    }

    // Cuando el puntero entra en el objeto
    public void OnPointerEnter(PointerEventData eventData)
    {
        SetOutline(true); // Activar el efecto de contorno
    }

    // Cuando el puntero sale del objeto
    public void OnPointerExit(PointerEventData eventData)
    {
        SetOutline(false); // Desactivar el efecto de contorno
    }
}
