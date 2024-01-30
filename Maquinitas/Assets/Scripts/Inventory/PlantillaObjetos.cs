using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Objeto", menuName = "Objeto Tienda")]
public class PlantillaObjetos : ScriptableObject
{
    public int id;
    public Sprite imagenObjeto;
    public string nameObjeto;
    public string descripcionObjeto;
    public int precioObjeto;
}
