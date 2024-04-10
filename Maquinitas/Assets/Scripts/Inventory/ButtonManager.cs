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
    
    private Animator almacenAnimator;
    private Animator amazingAnimator;
    private Animator tabletAnimator;
    private Animator mapaAnimator;
    private Animator perfilAnimator;
    private Animator upgradesAnimator;
    private Animator ajustesAnimator;
    
    [SerializeField]
    private GameObject cameraMap;
    private CameraMapMoving cmm;

    private void Start()
    {
        Debug.Log("StartEntered");
        cmm = cameraMap.GetComponent<CameraMapMoving>();
        Debug.Log(cmm == null);
        almacenAnimator = almacen.GetComponent<Animator>();
        amazingAnimator = amazing.GetComponent<Animator>();
        tabletAnimator = tablet.GetComponent<Animator>();
        mapaAnimator = mapa.GetComponent<Animator>();
        perfilAnimator = perfil.GetComponent<Animator>();
        upgradesAnimator = upgrades.GetComponent<Animator>();
        ajustesAnimator = ajustes.GetComponent<Animator>();
        
        
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
        StartCoroutine(ToggleGameObject(amazing, amazingAnimator));
    }

    public void ToggleAlmacen()
    {
        StartCoroutine(ToggleGameObject(almacen, almacenAnimator));
    }

    public void ToggleMapa()
    {
        StartCoroutine(ToggleGameObject(mapa, mapaAnimator));
    }

    public void TogglePerfil()
    {
        StartCoroutine(ToggleGameObject(perfil, perfilAnimator));
    }

    public void ToggleAjustes()
    {
        StartCoroutine(ToggleGameObject(ajustes, ajustesAnimator));
    }

    public void ToggleUpgrades()
    {
        StartCoroutine(ToggleGameObject(upgrades, upgradesAnimator));
    }

    public void ToggleTablet()
    {
        StartCoroutine(ToggleGameObject(tablet, tabletAnimator));
        cmm.CanUseCameraMap(tablet.activeSelf);
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
}
