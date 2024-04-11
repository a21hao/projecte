using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableAnimationIntermediaryScript : MonoBehaviour
{
    [SerializeField] ButtonManager buttonManager;

    public void Abrir(float f)
    {
        Debug.Log("Abrir " + buttonManager, buttonManager.gameObject);
        buttonManager.CanUseToggleTablet(false);
    }

    public void Cerrar()
    {
        Debug.Log("Cierro " + buttonManager, buttonManager.gameObject);
        buttonManager.CanUseToggleTablet(true);
    }

}
