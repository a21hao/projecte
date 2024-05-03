using UnityEngine;
using System.IO;

public static class Save
{
    public static void SaveData<T>(T data, string fileName)
    {
        string savePath = GetSavePath(fileName);
        string jsonData = JsonUtility.ToJson(data);
        File.WriteAllText(savePath, jsonData);
    }

    public static T LoadData<T>(string fileName)
    {
        string savePath = GetSavePath(fileName);
        if (File.Exists(savePath))
        {
            string jsonData = File.ReadAllText(savePath);
            return JsonUtility.FromJson<T>(jsonData);
        }
        else
        {
            Debug.LogWarning("No se encontró ningún archivo de datos guardado: " + fileName);
            return default(T);
        }
    }

    private static string GetSavePath(string fileName)
    {
        // Obtiene la ruta de la carpeta AppData/Local
        string localAppDataPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);

        // Comprueba si la carpeta BlueBook existe, si no, la crea
        string blueBookPath = Path.Combine(localAppDataPath, "BlueBook");
        if (!Directory.Exists(blueBookPath))
        {
            Directory.CreateDirectory(blueBookPath);
        }

        // Obtiene la ruta completa para el archivo de guardado dentro de la carpeta BlueBook
        return Path.Combine(blueBookPath, fileName);
    }
}
