using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObjectBase", menuName = "Inventario/Objeto", order = 1)]
public class ObjectBase : ScriptableObject
{
    public int ID;

    public string nombre;
    public Sprite sprite;
    public Tipo tipo;
    public string descripcion;
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
    }
}
