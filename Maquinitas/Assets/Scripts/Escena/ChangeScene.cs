using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
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
