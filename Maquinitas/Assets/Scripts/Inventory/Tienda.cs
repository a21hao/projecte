using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tienda : MonoBehaviour
{
    [SerializeField] GameObject prefabObjetoTienda;
    [SerializeField] List<PlantillaObjetos> listaObjetosTienda; // Lista de ScriptableObjects

    // El Dictionary será generado a partir de los ScriptableObjects en la lista
    private Dictionary<int, PlantillaObjetos> diccionarioTienda = new Dictionary<int, PlantillaObjetos>();

    private void Awake()
    {
        // Llena el Dictionary con los ScriptableObjects de la lista
        for (int i = 0; i < listaObjetosTienda.Count; i++)
        {
            if (!diccionarioTienda.ContainsKey(listaObjetosTienda[i].id))
            {
                diccionarioTienda.Add(listaObjetosTienda[i].id, listaObjetosTienda[i]);
            }
            else
            {
                Debug.LogWarning("Se encontró un duplicado de ID en la lista de objetos de tienda: " + listaObjetosTienda[i].id);
            }
        }
    }

    private void Start()
    {
        // Itera sobre el diccionario de objetos de la tienda y crea un objeto para cada uno
        foreach (KeyValuePair<int, PlantillaObjetos> par in diccionarioTienda)
        {
            // Instancia un nuevo objeto de tienda
            GameObject tienda = Instantiate(prefabObjetoTienda, Vector2.zero, Quaternion.identity, transform);
            // Obtiene el componente Objeto del objeto de tienda instanciado
            Objeto objetoComponente = tienda.GetComponent<Objeto>();

            // Crea el objeto utilizando los datos de la plantilla correspondiente
            objetoComponente.CrearObjeto(par.Value);
        }
    }
}
