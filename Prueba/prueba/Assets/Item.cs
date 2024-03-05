using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Item : MonoBehaviour
{
    public int cantidad = 1;
    public TextMeshProUGUI textoCantidad;
    public int ID;
    public bool acumulable;
    //public ObjetoDatabase DB;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent.GetComponent<Image>() != null)
        {
            transform.parent.GetComponent<Image>().fillCenter = true;
        }
        //textoCantidad.text = cantidad.ToString();        
    }
}
