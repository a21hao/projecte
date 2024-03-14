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

    void ToggleGameObject(GameObject obj)
    {
        obj.SetActive(!obj.activeSelf);
        PlayAnimation(obj.activeSelf, obj);
    }

    void PlayAnimation(bool isActive, GameObject obj)
    {
        Animator animator = obj.GetComponentInChildren<Animator>();
        if (animator != null)
        {
            if (isActive)
            {
                animator.Play("Encender");
            }
            else
            {
                animator.Play("Apagar");
            }
        }
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
        ToggleGameObject(apagar);
    }

    void PlayAnimationToAll(bool isActive)
    {
        PlayAnimation(isActive, amazing);
        PlayAnimation(isActive, almacen);
        PlayAnimation(isActive, mapa);
        PlayAnimation(isActive, perfil);
        PlayAnimation(isActive, ajustes);
        PlayAnimation(isActive, upgrades);
        PlayAnimation(isActive, apagar);
    }

    public void ToggleAll()
    {
        amazing.SetActive(!amazing.activeSelf);
        almacen.SetActive(!almacen.activeSelf);
        mapa.SetActive(!mapa.activeSelf);
        perfil.SetActive(!perfil.activeSelf);
        ajustes.SetActive(!ajustes.activeSelf);
        upgrades.SetActive(!upgrades.activeSelf);
        apagar.SetActive(!apagar.activeSelf);

        PlayAnimationToAll(amazing.activeSelf);
    }
}
