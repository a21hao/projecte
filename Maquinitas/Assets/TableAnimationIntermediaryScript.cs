using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableAnimationIntermediaryScript : MonoBehaviour
{
    [SerializeField] ButtonManager buttonManager;
    

    public void Abrir(float f)
    {
        
        buttonManager.CanUseToggleTablet(false);
    }

    public void Cerrar()
    {
        
        buttonManager.CanUseToggleTablet(true);
    }

}
