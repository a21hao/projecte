using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] Button continueBoton;
    public string saveFile;
    [SerializeField]private Save save;

    private void Awake()
    {
        saveFile = Application.dataPath + "/save.json"; 
        
        if (File.Exists(saveFile))
        {
            continueBoton.interactable = true;
        }
        else
        {
            continueBoton.interactable= false;
        }
    }

    public void EscenaPrincipal()
    {
        SceneManager.LoadScene("PrincipalMapMaquina");
    }

    public void CargarDatos()
    {
        SceneManager.LoadScene("PrincipalMapMaquina");
        save.LoadGame();
    }

    public void EscenaMenu()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void EscenaCredit()
    {
        SceneManager.LoadScene("Credits");
    }
    
    public void Salir()
    {
        Application.Quit();
    }
}
