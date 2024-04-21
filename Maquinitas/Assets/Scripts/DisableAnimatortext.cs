using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAnimatortext : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator canvasTextAnimator;
    private Canvas canvas;

    private void Awake()
    {
       /*canvasTextAnimator = gameObject.GetComponent<Animator>();
       canvas = gameObject.GetComponent<Canvas>();
        if (canvas.renderMode == RenderMode.ScreenSpaceCamera)
        {
            // Cambia la Event Camera del Canvas
            canvas.worldCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        }*/
        
    }

    public void DisableTextAnimator()
    {
        canvasTextAnimator.enabled = false;
        gameObject.SetActive(false);
    }
    
}
