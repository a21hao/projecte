using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Save : MonoBehaviour
{
    public string saveFile;
    public GameInfo gameInfo = new GameInfo();

    private void Awake()
    {

        saveFile = Application.dataPath + "/save.json";
        //saveFile = Path.Combine("Assets", "BlueBook", "save.json");
    }

    public void LoadGame()
    {
        if (File.Exists(saveFile))
        {
            
            string content = File.ReadAllText(saveFile);
            gameInfo = JsonUtility.FromJson<GameInfo>(content);
            Debug.Log("load");
        }
        else
        {
            Debug.Log("no existents");
        }
    }

    public void SaveGame()
    {
        GameInfo newInfo = new GameInfo()
        {
            money = gameInfo.money,
            //position = cameraMain.transform.position,
        };

        string cadenaJSON = JsonUtility.ToJson(newInfo);
        File.WriteAllText(saveFile, cadenaJSON);

        Debug.Log("Saved");
    }
}
