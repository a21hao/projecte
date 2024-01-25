using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Objeto : MonoBehaviour
{
    [SerializeField] Image imagenObjeto;
    [SerializeField] TextMeshProUGUI textoObjecto;
    [SerializeField] TextMeshProUGUI precioObjeto;

    private int precio;
    private Inventario inventario;

    private void Awake()
    {
        inventario = FindObjectOfType<Inventario>();
    }

    public void CrearObjeto (PlantillaObjetos datosObjeto)
    {
        precio = datosObjeto.precioObjeto;
        imagenObjeto.sprite = datosObjeto.imagenObjeto;
        textoObjecto.text = datosObjeto.textoObjeto;
        precioObjeto.text = datosObjeto.precioObjeto.ToString();
    }

    public void ComprarObjetos()
    {
        inventario.IncluirObjeto(precio, imagenObjeto);
    }
}
