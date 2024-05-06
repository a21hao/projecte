using UnityEngine;
using UnityEngine.UI;

public class ObjetoUpgrade : MonoBehaviour
{
    public string nombreText;
    public Sprite spriteImage;
    public string precioObjeto;
    public int precioVenta;
    public string descripcionObjeto;
    public GameObject objeto3d;
    public int id;
    public string tipo;
    public int categoria;
    public bool isVisible = true;
    public bool isActivated = false;
    public int priceOfUpgrade;
    public string descripcionUpgrade;
    public int incrementoDePrecio;

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

    public void SetCategoria(int categ)
    {
        categoria = categ;
    }

    public void SetIsActivated(bool activ)
    {
        isActivated = activ;
    }

    public void SetIsVisible(bool visibl)
    {
        isVisible = visibl;
    }

    public void SetPriceOfUpgrade(int price)
    {
        priceOfUpgrade = price;
    }

    public void SetDescripcionEIncrementoUpgrade(int subida)
    {
        descripcionUpgrade = "Contrata publicidad para la " + nombreText + ", que consigue subir un " + subida + "% el precio de venta de la " + nombreText;
        incrementoDePrecio = subida;
    }
}
