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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textoCantidad.text = cantidad.ToString();        
    }
}
