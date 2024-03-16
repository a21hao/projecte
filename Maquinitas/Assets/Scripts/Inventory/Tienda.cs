using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tienda : MonoBehaviour
{
    [SerializeField] GameObject prefabObjetoTienda;
    [SerializeField] Transform contenidoScrollView;
    [SerializeField] List<ObjectBase> listaObjetosTienda;

    private Dictionary<int, GameObject> dicionarioTienda = new Dictionary<int, GameObject>();

    private void Awake()
    {
        InstanciarObjetosTienda();
    }

    private void InstanciarObjetosTienda()
    {
        foreach (ObjectBase objeto in listaObjetosTienda)
        {
            GameObject objetoTienda = Instantiate(prefabObjetoTienda, contenidoScrollView);
            // Configura el objetoTienda con los datos del objeto ScriptableObject
            ConfigurarObjetoTienda(objetoTienda, objeto);

            // Agrega el objetoTienda al diccionario utilizando el ID del objeto como clave
            dicionarioTienda.Add(objeto.ID, objetoTienda);
        }
    }

    private void ConfigurarObjetoTienda(GameObject objetoTienda, ObjectBase objeto)
    {
        ObjetoTienda scriptObjetoTienda = objetoTienda.GetComponent<ObjetoTienda>();
        scriptObjetoTienda.SetNombre(objeto.nombre);
        scriptObjetoTienda.SetSprite(objeto.sprite);
        scriptObjetoTienda.SetPrecio(objeto.precio);
        scriptObjetoTienda.SetDescripcion(objeto.descripcion);
    }

    // Método para acceder al GameObject asociado a un ID específico
    public GameObject ObtenerObjetoPorID(int id)
    {
        GameObject objetoTienda;
        dicionarioTienda.TryGetValue(id, out objetoTienda);
        return objetoTienda;
    }
}
