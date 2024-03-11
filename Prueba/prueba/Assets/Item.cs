using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour//, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private string nombre;
    [SerializeField] private int ID;
    [SerializeField] private Sprite sprite;
    [SerializeField] private int cantidad;
    [SerializeField] private TextMeshProUGUI textoCantidad;
    [SerializeField] private string descripcion;
    [SerializeField] private ObjectBase tipo;

    void Start()
    {

    }
    
    void Update()
    {
        textoCantidad.text = cantidad.ToString();
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
}
