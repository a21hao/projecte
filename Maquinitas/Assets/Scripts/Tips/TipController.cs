using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private int conterTime;
    private bool haveToCount = false;
    private float time;
    void Start()
    {
        time = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (haveToCount)
        {
            time += Time.deltaTime;
            if(time >= conterTime) 
            {
                time = 0;
                haveToCount = false;
                gameObject.SetActive(false);
            }
        }
    }

    private void OnEnable()
    {
        haveToCount = true;
    }

    public void disableTip()
    {
        gameObject.SetActive(false);
    }
}
