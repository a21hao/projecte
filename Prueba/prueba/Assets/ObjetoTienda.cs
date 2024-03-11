using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjetoTienda : MonoBehaviour
{
    // Referencias a los componentes UI para mostrar información del objeto
    public TextMeshProUGUI nombreText;
    public Image spriteImage;
    public TextMeshProUGUI precioObjeto;

    // Método para configurar el nombre del objeto
    public void SetNombre(string nombre)
    {
        nombreText.text = nombre;
    }

    // Método para configurar el sprite del objeto
    public void SetSprite(Sprite sprite)
    {
        spriteImage.sprite = sprite;
    }

    // Método para configurar la descripción del objeto
    public void SetDescripcion(string descripcion)
    {
        precioObjeto.text = descripcion;
    }
}
