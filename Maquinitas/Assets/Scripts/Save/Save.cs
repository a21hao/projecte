using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Unity.VisualScripting;

public class Save : MonoBehaviour
{
    public string saveFile;
    [SerializeField] static private GameInfo gameInfo;
    [SerializeField] private GameObject sun;

    private void Awake()
    {
        saveFile = Application.dataPath + "/save.json";
        sun = GameObject.FindGameObjectWithTag("Sun");
    }

    [ContextMenu("Load")]
    public void LoadGame()
    {
        if (File.Exists(saveFile))
        {
            string content = File.ReadAllText(saveFile);
            GameInfo loadGameInfo = JsonUtility.FromJson<GameInfo>(content);
            gameInfo = new GameInfo(); //Machamos/inicializamos gameInfo (información local) 

            Debug.Log("load");

            //Sobreescribimos la información local con la guardada
            gameInfo.money = loadGameInfo.money;
            MoneyManager.instance.DineroTotal = loadGameInfo.money;
            gameInfo.positionSun = sun.transform.position;
        }
        else
        {
            Debug.Log("no existents");
        }
    }

    public static GameInfo GetGameInfo()
    {
        return gameInfo;
    }

    [ContextMenu("Save")]
    public void SaveGame()
    {
        GameInfo newInfo = new GameInfo()
        {
            money = MoneyManager.instance.DineroTotal, //gameInfo.money,
            positionSun = sun.transform.position,
            time = gameInfo.time,
        };

        string cadenaJSON = JsonUtility.ToJson(newInfo);
        File.WriteAllText(saveFile, cadenaJSON);

        Debug.Log("Saved");
    }
}
