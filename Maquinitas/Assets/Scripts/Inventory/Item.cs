using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour//, IPointerEnterHandler, IPointerExitHandler
{

    public string nombreText;
    public Sprite spriteImage;
    public string precioObjeto;
    public string descripcionObjeto;
    public int ID;
    public string tipo;
    public int cantidad;
    public TextMeshProUGUI cantidadText; 

    void Start()
    {
        cantidadText.text = cantidad.ToString();
    }
    
    void Update()
    {
        cantidadText.text = cantidad.ToString();
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
    public void SetInformacion(string nombre, Sprite sprite, string precio, string descripcion, int id, string tipo)
    {
        nombreText = nombre;
        spriteImage = sprite;
        precioObjeto = precio;
        descripcionObjeto = descripcion;
        ID = id;
        this.tipo = tipo;
    }
}
