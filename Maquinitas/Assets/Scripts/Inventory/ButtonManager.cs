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
    public GameObject tablet;


    void ToggleGameObject(GameObject obj)
    {
        obj.SetActive(!obj.activeSelf);
    }


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
        ToggleGameObject(tablet);
    }


    public void ToggleAll()
    {
        amazing.SetActive(!amazing.activeSelf);
        almacen.SetActive(!almacen.activeSelf);
        mapa.SetActive(!mapa.activeSelf);
        perfil.SetActive(!perfil.activeSelf);
        ajustes.SetActive(!ajustes.activeSelf);
        upgrades.SetActive(!upgrades.activeSelf);
        tablet.SetActive(!tablet.activeSelf);

    }
}
