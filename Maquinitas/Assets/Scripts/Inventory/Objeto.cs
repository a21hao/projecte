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

    public void CrearObjeto (PlantillaObjetos datosObjeto)
    {
        imagenObjeto.sprite = datosObjeto.imagenObjeto;
        textoObjecto.text = datosObjeto.textoObjeto;
        precioObjeto.text = datosObjeto.precioOBjeto.ToString();
    }
    
}
