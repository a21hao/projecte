using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameObject amazing;
    public GameObject almacen;
    public GameObject mapa;
    public GameObject perfil;
    public GameObject ajustes;
    public GameObject upgrades;
    public GameObject apagar;

    // Método para activar o desactivar un GameObject según su estado actual
    void ToggleGameObject(GameObject obj)
    {
        obj.SetActive(!obj.activeSelf);
    }

    // Funciones que activan los GameObjects si están desactivados y los desactivan si están activados
    public void ToggleAmazing()
    {
        ToggleGameObject(amazing);
    }

    public void ToggleAlmacen()
    {
        ToggleGameObject(almacen);
    }

    public void ToggleMapa()
    {
        ToggleGameObject(mapa);
    }

    public void TogglePerfil()
    {
        ToggleGameObject(perfil);
    }

    public void ToggleAjustes()
    {
        ToggleGameObject(ajustes);
    }

    public void ToggleUpgrades()
    {
        ToggleGameObject(upgrades);
    }

    public void ToggleApagar()
    {
        ToggleGameObject(apagar);
    }
}
