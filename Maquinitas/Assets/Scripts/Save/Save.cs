using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Unity.VisualScripting;

public class Save : MonoBehaviour
{
    public string saveFile;
    [SerializeField] private GameInfo gameInfo;

    private void Awake()
    { 
        saveFile = Application.dataPath + "/save.json";
    }

    [ContextMenu("Load")]
    public void LoadGame()
    {
        if (File.Exists(saveFile))
        {
            string content = File.ReadAllText(saveFile);
            GameInfo loadGameInfo = JsonUtility.FromJson<GameInfo>(content);
            
            Debug.Log("load");
            
            gameInfo.money = loadGameInfo.money;
        }
        else
        {
            Debug.Log("no existents");
        }
    }

    [ContextMenu("Save")]
    public void SaveGame()
    {
        GameInfo newInfo = new GameInfo()
        {
            money = gameInfo.money,
        };

        string cadenaJSON = JsonUtility.ToJson(newInfo);
        File.WriteAllText(saveFile, cadenaJSON);

        Debug.Log("Saved");
    }
}
