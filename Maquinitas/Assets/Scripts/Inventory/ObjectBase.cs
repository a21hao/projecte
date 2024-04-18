using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObjectBase", menuName = "Inventario/Objeto", order = 1)]
public class ObjectBase : ScriptableObject
{
    public int ID;
    public int categoria;
    public string nombre;
    public Sprite sprite;
    public Tipo tipo;
    public string descripcion;
    public GameObject objeto3d;
    public int precio;
    private static int nextID = 1;
    public int precioVenta;
    public int stock;

    public enum Tipo
    {
        bebida,
        comida,
        ropa,
        maquina,
        juguete,
        electrodomesticos
    }
    private void OnEnable()
    {
        ID = nextID;
        nextID++;
        if (categoria == 1) precioVenta = precio + (int)(precio * 0.4f);
        if (categoria == 2) precioVenta = precio + (int)(precio * 0.7f);
        if (categoria == 3) precioVenta = precio + precio;
        
    }
}
