using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObjectBase", menuName = "Inventario/Objeto", order = 1)]
public class ObjectBase : ScriptableObject
{
    public string nombre;
    public int ID;
    public Sprite icono;
    public Tipo tipo;
    public string descripcion;

    public enum Tipo
    {
        bebida,
        comida,
        ropa,
        maquina
    }
}
