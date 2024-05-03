using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.InputSystem;

public class Save : MonoBehaviour
{
    public GameObject cameraMain;
    public string saveFile;
    public GameInfo gameInfo = new GameInfo();

    private void Awake()
    {
        cameraMain = GameObject.FindGameObjectWithTag("Camera");

        //saveFile = Application.dataPath + "/BlueBook/save.json";
        saveFile = Path.Combine("Assets", "BlueBook", "save.json");
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            LoadGame();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            SaveGame();
        }
    }

    private void LoadGame()
    {
        if (File.Exists(saveFile))
        {
            string content = File.ReadAllText(saveFile);
            gameInfo = JsonUtility.FromJson<GameInfo>(content);
        }
        else
        {
            Debug.Log("no existents");
        }
    }

    private void SaveGame()
    {
        GameInfo newInfo = new GameInfo()
        {
            position = cameraMain.transform.position
        };

        string cadenaJSON = JsonUtility.ToJson(newInfo);
        File.WriteAllText(saveFile, cadenaJSON);

        Debug.Log("Saved");
    }
}
