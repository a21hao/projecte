using UnityEngine;

[CreateAssetMenu(fileName = "Objeto", menuName = "Objeto Tienda")]
public class PlantillaObjetos : ScriptableObject
{
    private static int nextID = 0;

    [System.Serializable]
    public struct Mercancia
    {
        public int id;
        public Tipo tipo;
        public Sprite imagenObjeto;
        public bool acumulable;
        public string nameObjeto;
        public int maxStack;
        public string descripcionObjeto;
        public int precioObjeto;
        //public BaseItem item;
        
    }

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

    public Mercancia[] dataBase;

    private void OnEnable()
    {
        if (dataBase != null)
        {
            for (int i = 0; i < dataBase.Length; i++)
            {
                dataBase[i].id = nextID++;
            }
        }
    }

    private void OnValidate()
    {
        if(dataBase != null)
        {
            for(int i = 0; i < dataBase.Length; i++)
            {
                if (dataBase[i].id != i)
                {
                    dataBase[i].id = i;
                }
            }

        }
    }
}
