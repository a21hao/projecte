using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjetoTienda : MonoBehaviour
{
    // Referencias a los componentes UI para mostrar información del objeto
    public TextMeshProUGUI nombreText;
    public Image spriteImage;
    public TextMeshProUGUI precioObjeto;
    public TextMeshProUGUI descripcionObjeto;
    public TextMeshProUGUI idText;
    public TextMeshProUGUI tipoText;

    public void SetNombre(string nombre)
    {
        nombreText.text = nombre;
        Debug.Log("nombre" + nombre);
    }

    public void SetSprite(Sprite sprite)
    {
        spriteImage.sprite = sprite;
        Debug.Log("sprite" + sprite);
    }

    public void SetPrecio(string precio)
    {
        precioObjeto.text = precio;
        Debug.Log("precio" + precio);
    }
    public void SetDescripcion(string descripcion)
    {
        descripcionObjeto.text = descripcion;
        Debug.Log("descripcion" + descripcion);
    }
    public void SetID(int id)
    {
        idText.text = "ID: " + id.ToString();
        Debug.Log("ID" + id);
    }

    public void SetTipo(string tipo)
    {
        tipoText.text = "Tipo: " + tipo;
        Debug.Log("Tipo" + tipo);
    }
    public void SetTienda(Tienda tienda)
    {

    }

    public void AbrirVentanaCompra(int id)
    {
        // Obtén una referencia a la tienda
        Tienda tienda = FindObjectOfType<Tienda>();

        // Si se encuentra la tienda, muestra la ventana de compra para este objeto
        if (tienda != null)
        {
            tienda.MostrarVentanaCompra(id);
        }
        else
        {
            Debug.LogError("No se pudo encontrar el objeto Tienda.");
        }
    }
}
