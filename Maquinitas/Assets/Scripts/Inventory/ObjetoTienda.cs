using UnityEngine;
using UnityEngine.UI;

public class ObjetoTienda : MonoBehaviour
{
    public string nombreText;
    public Sprite spriteImage;
    public string precioObjeto;
    public int precioVenta;
    public string descripcionObjeto;
    public GameObject objeto3d;
    public int id;
    public string tipo;

    public void SetNombre(string nombre)
    {
        this.nombreText = nombre;
    }

    public void SetSprite(Sprite sprite)
    {
        this.spriteImage = sprite;
    }

    public void SetPrecio(string precio)
    {
        this.precioObjeto = precio;
    }

    public void SetDescripcion(string descripcion)
    {
        this.descripcionObjeto = descripcion;
    }

    public void SetID(int id)
    {
        this.id = id;
    }

    public void SetTipo(string tipo)
    {
        this.tipo = tipo;
    }

    public void SetObject3d(GameObject obj)
    {
        this.objeto3d = obj;
    }

    public void SetPrecioVenta(int prec)
    {
        precioVenta = prec;
    }
}
