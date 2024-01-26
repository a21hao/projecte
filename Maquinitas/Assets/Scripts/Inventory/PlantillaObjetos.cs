using UnityEngine;

[CreateAssetMenu(fileName = "Objeto", menuName = "Objeto Tienda")]
public class PlantillaObjetos : ScriptableObject
{
    private static int nextID = 0;

    public int id;
    public Sprite imagenObjeto;
    public string textoObjeto;
    public int precioObjeto;

    private void OnEnable()
    {
        id = nextID++;
    }
}
