using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Objeto : MonoBehaviour
{
    [SerializeField] int idObjeto;
    [SerializeField] Image imagenObjeto;
    [SerializeField] TextMeshProUGUI textoObjecto;
    [SerializeField] TextMeshProUGUI precioObjeto;
    [SerializeField] TextMeshProUGUI descripcionObjeto;

    private PlantillaObjetos datosObjeto; // Objeto asociado a este script
    private Inventario inventario;

    private void Awake()
    {
        inventario = FindObjectOfType<Inventario>();
    }

    public void CrearObjeto (PlantillaObjetos datos)
    {
        datosObjeto = datos;
        idObjeto = datosObjeto.id;
        precioObjeto.text = datosObjeto.precioObjeto.ToString();
        imagenObjeto.sprite = datosObjeto.imagenObjeto;
        textoObjecto.text = datosObjeto.nameObjeto;
        textoObjecto.text = datosObjeto.descripcionObjeto;
        precioObjeto.text = datosObjeto.precioObjeto.ToString();
    }

    public void ComprarObjetos()
    {
        if (datosObjeto != null)
        {
            inventario.IncluirObjeto(datosObjeto);
        }
        else
        {
            Debug.LogError("No se ha asignado ningún objeto a este script.");
        }
    }
}
