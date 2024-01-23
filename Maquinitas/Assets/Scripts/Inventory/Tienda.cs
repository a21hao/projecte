using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tienda : MonoBehaviour
{
    [SerializeField] GameObject prefabObjetoTienda;
    [SerializeField] int numeroMaxTienda;
    [SerializeField] PlantillaObjetos[] listaTienda;

    private Objeto objeto;

    void Start()
    {
        for (int i = 0; i < numeroMaxTienda; i++) 
        {
            GameObject tienda = GameObject.Instantiate(prefabObjetoTienda, Vector2.zero, Quaternion.identity, GameObject.FindGameObjectWithTag("Tienda").transform);
            int indice = Random.Range(0, listaTienda.Length); 
            objeto = tienda.GetComponent<Objeto>();
            objeto.CrearObjeto(listaTienda[indice]); 
        }
    }
}
