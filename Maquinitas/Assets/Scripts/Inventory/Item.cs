using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour//, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private string nombreText;
    [SerializeField] private Image spriteImage;
    [SerializeField] private string precioObjeto;
    [SerializeField] private string descripcionObjeto;
    [SerializeField] private int ID;
    [SerializeField] private string tipo;
    [SerializeField] private int cantidad;
    [SerializeField] TextMeshProUGUI cantidadText;

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
        spriteImage.sprite = sprite;
        precioObjeto = precio;
        descripcionObjeto = descripcion;
        ID = id;
        this.tipo = tipo;
    }
    public void SetInformacion(string nombre, Sprite sprite, string precio, string descripcion, int id, string tipo, int cantidad)
    {
        nombreText = nombre;
        spriteImage.sprite = sprite;
        precioObjeto = precio;
        descripcionObjeto = descripcion;
        ID = id;
        this.tipo = tipo;
        this.cantidad = cantidad;
        cantidadText.text = cantidad.ToString();
    }
}
