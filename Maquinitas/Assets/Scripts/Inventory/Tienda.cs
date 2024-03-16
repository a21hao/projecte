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
    [SerializeField] GameObject ventanaCompraPrefab;

    private Dictionary<int, GameObject> dicionarioTienda = new Dictionary<int, GameObject>();

    private void Awake()
    {
        InstanciarObjetosTienda();
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
        scriptObjetoTienda.SetSprite(objeto.sprite);
        scriptObjetoTienda.SetPrecio(objeto.precio);
        scriptObjetoTienda.SetDescripcion(objeto.descripcion);
        scriptObjetoTienda.SetID(objeto.ID);
        scriptObjetoTienda.SetTipo(objeto.tipo.ToString());
        scriptObjetoTienda.SetTienda(this);
    }

    // Método para acceder al GameObject asociado a un ID específico
    public GameObject ObtenerObjetoPorID(int id)
    {
        GameObject objetoTienda;
        dicionarioTienda.TryGetValue(id, out objetoTienda);
        return objetoTienda;
    }
    public void MostrarVentanaCompra(int idObjeto)
    {
        GameObject objetoSeleccionado = ObtenerObjetoPorID(idObjeto);
        if (objetoSeleccionado != null)
        {
            // Instanciar la ventana de compra
            GameObject ventanaCompraInstance = Instantiate(ventanaCompraPrefab, transform.parent);
            // Obtener información del objeto seleccionado
            ObjectBase objetoBase = objetoSeleccionado.GetComponent<ObjectBase>();
            string nombre = objetoBase.nombre;
            Sprite sprite = objetoBase.sprite;
            string precio = objetoBase.precio;
            string descripcion = objetoBase.descripcion;

            // Configurar la ventana de compra con la información del objeto seleccionado
            VentanaCompra scriptVentanaCompra = ventanaCompraInstance.GetComponent<VentanaCompra>();
            scriptVentanaCompra.ConfigurarVentana(nombre, sprite, precio, descripcion);
            scriptVentanaCompra.SetTienda(this); // Establecer una referencia a esta tienda en la ventana de compra
        }
    }
}
