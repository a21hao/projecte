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
    public GameObject calendar;
    private Animator almacenAnimator;
    private Animator amazingAnimator;
    private Animator tabletAnimator;
    private Animator mapaAnimator;
    private Animator perfilAnimator;
    private Animator upgradesAnimator;
    private Animator ajustesAnimator;
    private Animator calendarAnimator;
    private bool canUseToggleTablet;
    private bool isTabletInUse;
    
    [SerializeField]
    private GameObject cameraMap;
    private CameraMapMoving cmm;
    private CameraZoomOrthografic czo;

    private void Start()
    {
        //Debug.Log("StartEntered");
        cmm = cameraMap.GetComponent<CameraMapMoving>();
        czo = cameraMap.GetComponent<CameraZoomOrthografic>();
        canUseToggleTablet = true;
        isTabletInUse = false;
        Debug.Log(cmm == null);
        perfilAnimator = perfil.GetComponent<Animator>();
        almacenAnimator = almacen.GetComponent<Animator>();
        amazingAnimator = amazing.GetComponent<Animator>();
        tabletAnimator = tablet.GetComponent<Animator>();
        upgradesAnimator = upgrades.GetComponent<Animator>();
        mapaAnimator = mapa.GetComponent<Animator>();
        ajustesAnimator = ajustes.GetComponent<Animator>();
        calendarAnimator = calendar.GetComponent<Animator>();

    }

    IEnumerator ToggleGameObject(GameObject obj, Animator animator)
    {
        animator.SetTrigger("Abrir");
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length*5);
        obj.SetActive(!obj.activeSelf);
        if(obj == tablet)
        {
            Debug.Log("he entrado");
            
        }
    }


    public void ToggleAmazing()
    {
        //StartCoroutine(ToggleGameObject(amazing, amazingAnimator));

        amazingAnimator.SetTrigger("Abrir");
        if (!amazing.activeSelf) amazing.SetActive(true);
    }

    public void ToggleAlmacen()
    {
        //StartCoroutine(ToggleGameObject(almacen, almacenAnimator));
        almacenAnimator.SetTrigger("Abrir");
        if (!almacen.activeSelf) almacen.SetActive(true);
    }

    public void ToggleMapa()
    {
        StartCoroutine(ToggleGameObject(mapa, mapaAnimator));
    }

    public void TogglePerfil()
    {
        //StartCoroutine(ToggleGameObject(perfil, perfilAnimator));
        perfilAnimator.SetTrigger("Abrir");
        if (!perfil.activeSelf) perfil.SetActive(true);
    }

    public void ToggleAjustes()
    {
        //StartCoroutine(ToggleGameObject(ajustes, ajustesAnimator));
        ajustesAnimator.SetTrigger("Abrir");
        if (!ajustes.activeSelf) ajustes.SetActive(true);
    }

    public void ToggleUpgrades()
    {
        //StartCoroutine(ToggleGameObject(upgrades, upgradesAnimator));
        
    }

    public void ToggleTablet()
    {
        //StartCoroutine(ToggleGameObject(tablet, tabletAnimator));
        if(canUseToggleTablet)
        {
            if (!tablet.activeSelf) tablet.SetActive(true);
            tabletAnimator.SetTrigger("Abrir");
            cmm.CanUseCameraMap(isTabletInUse);
            czo.CanZoom(isTabletInUse);
            isTabletInUse = !isTabletInUse;
            
        }
        
    }

    public void ToggleCalendar(GameObject obj)
    {
        //obj.SetActive(!obj.activeSelf);
        perfilAnimator.SetTrigger("Abrir");
        if (!calendar.activeSelf) calendar.SetActive(true);
    }


    public void ToggleAll()
    {
        ToggleAmazing();
        ToggleAlmacen();
        ToggleTablet();
        TogglePerfil();
        ToggleAjustes();
        ToggleTablet();
    }

    public void CanUseToggleTablet(bool canUse)
    {
        canUseToggleTablet = canUse;
    }

}
