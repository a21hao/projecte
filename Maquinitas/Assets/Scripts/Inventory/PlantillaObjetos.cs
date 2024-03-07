using UnityEngine;

[CreateAssetMenu(fileName = "Objeto", menuName = "Objeto Tienda")]
public class PlantillaObjetos : ScriptableObject
{
    private static int nextID = 0;

    public int id;
    public Tipo tipo;
    public Sprite imagenObjeto;
    public bool acumulable;
    public string nameObjeto;
    public string descripcionObjeto;
    public int precioObjeto;

    public enum Tipo
    {
        Bebida,
        ComidaPrehecha,
        Comida,
        Ropa,
        ProductosElectronicos,
        Juguetes,
        Libros
    }
}
