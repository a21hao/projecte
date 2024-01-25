using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tienda : MonoBehaviour
{
    [SerializeField] GameObject prefabObjetoTienda;
    [SerializeField] int numeroMaxTienda;
    [SerializeField] PlantillaObjetos[] listaTienda;
    [SerializeField] List<PlantillaObjetos> listaProvisionalTienda;

    private Objeto objeto;

    void Start()
    {
        listaProvisionalTienda.AddRange(listaTienda);

        for (int i = 0; i < numeroMaxTienda - 1; i++)
        {
            GameObject tienda = GameObject.Instantiate(prefabObjetoTienda, Vector2.zero, Quaternion.identity, GameObject.FindGameObjectWithTag("Tienda").transform);
            int indice = Random.Range(0, listaTienda.Length);
            objeto = tienda.GetComponent<Objeto>();
            objeto.CrearObjeto(listaTienda[indice]);
            listaProvisionalTienda.Remove(listaProvisionalTienda[indice]);
        }
    }
}