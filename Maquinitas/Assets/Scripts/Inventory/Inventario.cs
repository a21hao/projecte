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

    private void Update()
    {
        ActualizarUI();
    }

    public void IncluirObjeto(PlantillaObjetos datos)
    {
        if (dineroTotal >= datos.precioObjeto && !inventario.ContainsKey(datos) && numeroMaximoObjeto > 0)
        {
            dineroTotal -= datos.precioObjeto;
            numeroMaximoObjeto--;

            // Instancia el objeto utilizando la prefab
            GameObject objetoInstanciado = Instantiate(objetoDeTienda, Vector3.zero, Quaternion.identity, GameObject.FindGameObjectWithTag("ObjetoComprable").transform);
            // Obtiene el componente Image del nuevo objeto
            Image imagen = objetoInstanciado.GetComponent<Image>();

            // Asigna la imagen recibida al componente Image
            imagen.sprite = datos.imagenObjeto;
            // Asigna los datos del objeto a la instancia
            Objeto scriptObjeto = objetoInstanciado.GetComponent<Objeto>();
            scriptObjeto.CrearObjeto(datos);

            // Agrega el objeto al inventario con cantidad 1
            inventario.Add(datos, 1);
            Debug.Log("Se agregó el objeto al inventario: " + datos.nameObjeto);

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
