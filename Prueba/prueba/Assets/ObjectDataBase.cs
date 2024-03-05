using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObjectDataBase", menuName = "Inventario/Lista", order = 1 )]
public class ObjectDataBase : ScriptableObject
{
    [System.Serializable]
    public struct ObjetoInventario
    {
        public string nombre;
        public int ID;
        public Sprite icono;
        public Tipo tipo;
        public string descripcion;
        public string Void;
    }

    public enum Tipo
    {
        bebida,
        comida,
        ropa,
        maquina
    }

    public ObjetoInventario[] baseDatos;
}
