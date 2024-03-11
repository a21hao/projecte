using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tienda : MonoBehaviour
{
    [SerializeField] GameObject prefabObjetoTienda;
    [SerializeField] Transform contenidoScrollView;
    [SerializeField] List<ObjectBase> listaObjetosTienda;

    private Dictionary<int, GameObject> diccionarioTienda = new Dictionary<int, GameObject>();

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
            diccionarioTienda.Add(objeto.ID, objetoTienda);
        }
    }

    private void ConfigurarObjetoTienda(GameObject objetoTienda, ObjectBase objeto)
    {
        // Aquí configura el objetoTienda con los datos del objeto
        // Por ejemplo, establece el nombre, sprite, descripción, etc.
        // Supongamos que tienes un script adjunto al prefab llamado "ObjetoTienda"
        ObjetoTienda scriptObjetoTienda = objetoTienda.GetComponent<ObjetoTienda>();
        scriptObjetoTienda.SetNombre(objeto.nombre);
        scriptObjetoTienda.SetSprite(objeto.sprite);
        scriptObjetoTienda.SetDescripcion(objeto.descripcion);
        // Configura otros campos según sea necesario
    }

    // Método para acceder al GameObject asociado a un ID específico
    public GameObject ObtenerObjetoPorID(int id)
    {
        GameObject objetoTienda;
        diccionarioTienda.TryGetValue(id, out objetoTienda);
        return objetoTienda;
    }
}
