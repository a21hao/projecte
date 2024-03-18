using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tienda : MonoBehaviour
{
    [SerializeField] GameObject prefabObjetoTienda;
    [SerializeField] Transform contenidoScrollView;
    [SerializeField] List<ObjectBase> listaObjetosTienda;

    private MoneyManager moneyManager;

    private Dictionary<int, GameObject> dicionarioTienda = new Dictionary<int, GameObject>();

    private void Awake()
    {
        InstanciarObjetosTienda();
    }

    private void Start()
    {
        moneyManager.ActualizarTextoDinero();
    }

    private void InstanciarObjetosTienda()
    {
        dicionarioTienda.Clear();

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
        Debug.Log("Nombre enviado a ObjetoTienda: " + objeto.nombre);

        scriptObjetoTienda.SetSprite(objeto.sprite);
        Debug.Log("Sprite enviado a ObjetoTienda: " + objeto.sprite);

        scriptObjetoTienda.SetPrecio(objeto.precio);
        Debug.Log("Precio enviado a ObjetoTienda: " + objeto.precio);

        scriptObjetoTienda.SetDescripcion(objeto.descripcion);
        Debug.Log("Descripcion enviada a ObjetoTienda: " + objeto.descripcion);

        scriptObjetoTienda.SetID(objeto.ID);
        Debug.Log("ID enviado a ObjetoTienda: " + objeto.ID);

        scriptObjetoTienda.SetTipo(objeto.tipo.ToString());
        Debug.Log("Tipo enviado a ObjetoTienda: " + objeto.tipo.ToString());
    }

    // Método para acceder al GameObject asociado a un ID específico
    public GameObject ObtenerObjetoPorID(int id)
    {
        GameObject objetoTienda;
        dicionarioTienda.TryGetValue(id, out objetoTienda);
        return objetoTienda;
    }
}
