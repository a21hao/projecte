using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void EscenaPrincipal()
    {
        SceneManager.LoadScene(2);
    }
    void EscenaMenu()
    {

    }
    public void Salir()
    {
        Application.Quit();
    }
}
