using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] Button continueBoton;

    public void EscenaPrincipal()
    {
        SceneManager.LoadScene("PrincipalMapMaquina");
        string savePath = Path.Combine(Application.persistentDataPath, "save.json");
        if (File.Exists(savePath))
        {
            continueBoton.interactable = LoadMoneyData();
        }
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

    private static bool LoadMoneyData()
    {
        int dineroCargado = Save.LoadData<int>("moneyData.json");
        if (dineroCargado != default(int))
        {
            return true; // Los datos se cargaron correctamente
        }
        else
        {
            return false; // No se pudieron cargar los datos
        }
    }
}
