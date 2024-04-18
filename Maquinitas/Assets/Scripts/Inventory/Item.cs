using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour//, IPointerEnterHandler, IPointerExitHandler
{
    public string nombreText;
    public Image spriteImage;
    public string precioObjeto;
    public int precioVenta;
    public string descripcionObjeto;
    public GameObject Objeto3d;
    [SerializeField] private int ID;
    public  string tipo;
    [SerializeField] private int cantidad;
    [SerializeField] TextMeshProUGUI cantidadText;

    void Start()
    {
        if(cantidadText!=null)
        cantidadText.text = cantidad.ToString();
    }

    void Update()
    {
        if(cantidadText != null) 
        cantidadText.text = cantidad.ToString();
    }

    public string GetNombre()
    {
        return nombreText;
    }
    public int GetID()
    {
        return ID;
    }

    public void SetID(int newID)
    {
        ID = newID;
    }

    public int GetCantidad()
    {
        return cantidad;
    }

    public void SetCantidad(int newCantidad)
    {
        cantidad = newCantidad;
    }

    public void SetInformacion(string nombre, Sprite sprite, string precio, string descripcion, int id, string tipo, int cantidad, GameObject obj3d, int precVenta)
    {
        nombreText = nombre;
        spriteImage.sprite = sprite;
        precioObjeto = precio;
        descripcionObjeto = descripcion;
        ID = id;
        this.tipo = tipo;
        this.cantidad = cantidad;
        cantidadText.text = cantidad.ToString();
        Objeto3d = obj3d;
        this.precioVenta = precVenta;
    }


    public void IncrementCantidad(int cantid)
    {
        cantidad += cantid;
    }

    public void DecrementCantidad(int cantid)
    {
        cantidad -= cantid;
        if(cantidad <= 0)
        {
            cantidad = 0;
        }
    }

    public GameObject GetObjeto3d()
    {
        return Objeto3d;
    }
}
