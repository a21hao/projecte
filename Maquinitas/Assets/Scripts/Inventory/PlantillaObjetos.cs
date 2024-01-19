using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Obejeto", menuName = "Objeto Tienda")]
public class PlantillaObjetos : ScriptableObject
{
    public Sprite imagenObjeto;
    public string textoObjeto;
    public int precioOBjeto;
}
