using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tienda : MonoBehaviour
{
    [SerializeField] GameObject prefabObjetoTienda;
    [SerializeField] Transform contenidoScrollView;
    [SerializeField] private GameObject objectsOfGame; 
    //[SerializeField] List<ObjectBase> listaObjetosTienda;
    private List<ObjectBase> listaObjetosTienda;
    private Dictionary<int, GameObject> dicionarioTienda = new Dictionary<int, GameObject>();

    private void Awake()
    {
        listaObjetosTienda = objectsOfGame.GetComponent<ObjectsList>().objectsList();
        InstanciarObjetosTienda();
    }

    private void InstanciarObjetosTienda()
    {
        dicionarioTienda.Clear();

        foreach (ObjectBase objeto in listaObjetosTienda)
        {
            GameObject objetoTienda = Instantiate(prefabObjetoTienda, contenidoScrollView);
            ConfigurarObjetoTienda(objetoTienda, objeto);

            dicionarioTienda.Add(objeto.ID, objetoTienda);
        }
    }

    private void ConfigurarObjetoTienda(GameObject objetoTienda, ObjectBase objeto)
    {
        ObjetoTienda scriptObjetoTienda = objetoTienda.GetComponent<ObjetoTienda>();
        scriptObjetoTienda.SetNombre(objeto.nombre);
        //Debug.Log("Nombre enviado a ObjetoTienda: " + objeto.nombre);

        scriptObjetoTienda.SetSprite(objeto.sprite);
        //Debug.Log("Sprite enviado a ObjetoTienda: " + objeto.sprite);

        scriptObjetoTienda.SetPrecio(objeto.precio.ToString());
        //Debug.Log("Precio enviado a ObjetoTienda: " + objeto.precio);

        scriptObjetoTienda.SetDescripcion(objeto.descripcion);
        //Debug.Log("Descripcion enviada a ObjetoTienda: " + objeto.descripcion);

        scriptObjetoTienda.SetID(objeto.ID);
        //Debug.Log("ID enviado a ObjetoTienda: " + objeto.ID);

        scriptObjetoTienda.SetTipo(objeto.tipo.ToString());
        //Debug.Log("Tipo enviado a ObjetoTienda: " + objeto.tipo.ToString());
        scriptObjetoTienda.SetObject3d(objeto.objeto3d);

        scriptObjetoTienda.SetPrecioVenta(objeto.precioVenta);

        scriptObjetoTienda.SetCategoria(objeto.categoria);
    }

    public GameObject ObtenerObjetoPorID(int id)
    {
        GameObject objetoTienda;
        dicionarioTienda.TryGetValue(id, out objetoTienda);
        return objetoTienda;
    }

    public void FiltrarPorTipo(string tipo = null)
    {
        foreach (KeyValuePair<int, GameObject> kvp in dicionarioTienda)
        {
            ObjetoTienda objetoTienda = kvp.Value.GetComponent<ObjetoTienda>();
            if (tipo == "All") 
            {
                kvp.Value.SetActive(true);
            }
            else
            {
                if (tipo != null && objetoTienda.tipo != tipo)
                {
                    kvp.Value.SetActive(false);
                }
                else
                {
                    kvp.Value.SetActive(true);
                }
            }
            
        }
    }
}
