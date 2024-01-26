using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventario : MonoBehaviour
{
    [SerializeField] private int dineroTotal = 50;
    [SerializeField] TextMeshProUGUI textoDinero;
    [SerializeField] GameObject objetoDeTienda;

    private Dictionary<PlantillaObjetos, int> inventario = new Dictionary<PlantillaObjetos, int>();

    private int nuemroMaximoObjeto = 0;

    private void Start()
    {
        textoDinero.text = dineroTotal.ToString();
    }

    public void IncluirObjeto(int dinero, Image imageObjeto)
    {
        if (dinero <= dineroTotal && nuemroMaximoObjeto <= 99) 
        {
            dineroTotal -= dinero;
            nuemroMaximoObjeto++;
            GameObject inventario = GameObject.Instantiate(objetoDeTienda, Vector2.zero, Quaternion.identity, GameObject.FindGameObjectWithTag("ObjetoComprable").transform);
            Image imagen = inventario.GetComponent<Image>();
            imagen.sprite = imageObjeto.sprite;
            textoDinero.text = dineroTotal.ToString();
        }
    }
}
