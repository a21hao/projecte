using UnityEngine;
using System.Collections.Generic;
using System.IO;

[CreateAssetMenu(fileName = "InventarioData", menuName = "ScriptableObjects/InventarioData", order = 1)]
public class InventarioData : ScriptableObject
{
    [System.Serializable]
    public class SlotData
    {
        public bool tieneHijo;
        public ItemData hijoData;
    }

    public List<SlotData> slots = new List<SlotData>();

    public void GuardarInventario(string filePath)
    {
        string jsonData = JsonUtility.ToJson(this, true);
        File.WriteAllText(filePath, jsonData);
    }

    public static InventarioData CargarInventario(string filePath)
    {
        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);
            return JsonUtility.FromJson<InventarioData>(jsonData);
        }
        else
        {
            Debug.LogError("El archivo de inventario no existe en la ruta: " + filePath);
            return null;
        }
    }
}
[System.Serializable]
public class ItemData
{
    public string nombreText;
    public string spriteImageKey; // Podrías guardar la clave para buscar la imagen en un diccionario o usar la ruta de archivo
    public string precioObjeto;
    public string descripcionObjeto;
    public int ID;
    public string tipo;
    public int cantidad;
}
