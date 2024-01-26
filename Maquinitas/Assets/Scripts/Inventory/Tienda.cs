using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tienda : MonoBehaviour
{
    [SerializeField] GameObject prefabObjetoTienda;
    [SerializeField] PlantillaObjetos[] listaTienda;

    private void Start()
    {
        // Itera sobre la lista de objetos de la tienda y crea un objeto para cada uno
        foreach (PlantillaObjetos objeto in listaTienda)
        {
            // Instancia un nuevo objeto de tienda
            GameObject tienda = Instantiate(prefabObjetoTienda, Vector2.zero, Quaternion.identity, transform);

            // Obtiene el componente Objeto del objeto de tienda instanciado
            Objeto objetoComponente = tienda.GetComponent<Objeto>();

            // Crea el objeto utilizando los datos de la plantilla correspondiente
            objetoComponente.CrearObjeto(objeto);
        }
    }

}