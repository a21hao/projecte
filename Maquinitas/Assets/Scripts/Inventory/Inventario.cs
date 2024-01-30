using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventario : MonoBehaviour
{
    [SerializeField] private int dineroTotal = 50;
    [SerializeField] TextMeshProUGUI textoDinero;
    [SerializeField] GameObject objetoDeTienda;
    //[SerializeField] Sprite imagenObjeto; // Definir la variable imagenObjeto
    private int numeroMaximoObjeto = 9999;

    private Dictionary<PlantillaObjetos, int> inventario = new Dictionary<PlantillaObjetos, int>();

    public void IncluirObjeto(PlantillaObjetos objeto, Sprite imageObjeto)
    {
        if (dineroTotal >= objeto.precioObjeto && !inventario.ContainsKey(objeto) && numeroMaximoObjeto > 0)
        {
            dineroTotal -= objeto.precioObjeto;
            numeroMaximoObjeto--;

            // Instancia el objeto utilizando la prefab
            GameObject objetoInstanciado = Instantiate(objetoDeTienda, Vector3.zero, Quaternion.identity, GameObject.FindGameObjectWithTag("ObjetoComprable").transform);
            // Obtiene el componente Image del nuevo objeto
            Image imagen = objetoInstanciado.GetComponent<Image>();

            // Asigna la imagen recibida al componente Image
            imagen.sprite = imageObjeto;
            // Asigna los datos del objeto a la instancia
            Objeto scriptObjeto = objetoInstanciado.GetComponent<Objeto>();
            scriptObjeto.CrearObjeto(objeto);

            // Agrega el objeto al inventario con cantidad 1
            inventario.Add(objeto, 1);
            Debug.Log("Se agreg� el objeto al inventario: " + objeto.nameObjeto);

            // Actualiza la UI
            ActualizarUI();
        }
        else
        {
            Debug.Log("No se puede agregar el objeto al inventario.");
        }
    }

    private void ActualizarUI()
    {
        textoDinero.text = dineroTotal.ToString();
    }
}
