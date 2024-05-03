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
