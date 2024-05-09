using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{
    [SerializeField] GameObject prefabObjetoUpgrade;
    [SerializeField] Transform contenidoScrollView;
    [SerializeField] private GameObject objectsOfGame;
    [SerializeField] private int PrecioUpgradesCategoria1;
    [SerializeField] private int PrecioUpgradesCategoria2;
    [SerializeField] private int PrecioUpgradesCategoria3;
    [SerializeField] private int cat1incrementodesubida;
    [SerializeField] private int cat2incrementodesubida;
    [SerializeField] private int cat3incrementodesubida;
    [SerializeField] private int maxUpgrades;
    //[SerializeField] List<ObjectBase> listaObjetosTienda;
    private List<ObjectBase> listaObjetosTienda;
    private Dictionary<int, GameObject> dicionarioUpgrades = new Dictionary<int, GameObject>();

    private void Awake()
    {
        listaObjetosTienda = objectsOfGame.GetComponent<ObjectsList>().objectsList();
        InstanciarObjetosUpgrades();
    }

    private void InstanciarObjetosUpgrades()
    {
        dicionarioUpgrades.Clear();

        foreach (ObjectBase objeto in listaObjetosTienda)
        {
            GameObject objetoUpgrade = Instantiate(prefabObjetoUpgrade, contenidoScrollView);
            ConfigurarObjetoUpgrade(objetoUpgrade, objeto);

            dicionarioUpgrades.Add(objeto.ID, objetoUpgrade);
        }
    }

   /* private void ConfigurarObjetoTienda(GameObject objetoTienda, ObjectBase objeto)
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
    }*/

    private void ConfigurarObjetoUpgrade(GameObject objetoUpgrade, ObjectBase objeto)
    {
        ObjetoUpgrade scriptObjetoUpgrade = objetoUpgrade.GetComponent<ObjetoUpgrade>();
        scriptObjetoUpgrade.SetNombre(objeto.nombre);
        //Debug.Log("Nombre enviado a ObjetoTienda: " + objeto.nombre);

        scriptObjetoUpgrade.SetSprite(objeto.sprite);
        //Debug.Log("Sprite enviado a ObjetoTienda: " + objeto.sprite);

        scriptObjetoUpgrade.SetPrecio(objeto.precio.ToString());
        //Debug.Log("Precio enviado a ObjetoTienda: " + objeto.precio);

        scriptObjetoUpgrade.SetDescripcion(objeto.descripcion);
        //Debug.Log("Descripcion enviada a ObjetoTienda: " + objeto.descripcion);

        scriptObjetoUpgrade.SetID(objeto.ID);
        //Debug.Log("ID enviado a ObjetoTienda: " + objeto.ID);

        scriptObjetoUpgrade.SetTipo(objeto.tipo.ToString());
        //Debug.Log("Tipo enviado a ObjetoTienda: " + objeto.tipo.ToString());
        scriptObjetoUpgrade.SetObject3d(objeto.objeto3d);

        scriptObjetoUpgrade.SetPrecioVenta(objeto.precioVenta);

        scriptObjetoUpgrade.SetCategoria(objeto.categoria);

        if(objeto.categoria == 1)
        {
            scriptObjetoUpgrade.SetPriceOfUpgrade(PrecioUpgradesCategoria1);
            scriptObjetoUpgrade.SetDescripcionEIncrementoUpgrade(cat1incrementodesubida);

        }

        if (objeto.categoria == 2)
        {
            scriptObjetoUpgrade.SetPriceOfUpgrade(PrecioUpgradesCategoria2);
            scriptObjetoUpgrade.SetDescripcionEIncrementoUpgrade(cat2incrementodesubida);
        }

        if (objeto.categoria == 3)
        {
            scriptObjetoUpgrade.SetPriceOfUpgrade(PrecioUpgradesCategoria3);
            scriptObjetoUpgrade.SetDescripcionEIncrementoUpgrade(cat3incrementodesubida);
        }

        scriptObjetoUpgrade.SetMaxUpgrades(maxUpgrades);
    }

    public GameObject ObtenerObjetoPorID(int id)
    {
        GameObject objetoTienda;
        dicionarioUpgrades.TryGetValue(id, out objetoTienda);
        return objetoTienda;
    }

    public void ActualizarUpgrades(int nuevoDinero)
    {
        foreach (KeyValuePair<int, GameObject> kvp in dicionarioUpgrades)
        {
            ObjetoUpgrade objetoUpgrade = kvp.Value.GetComponent<ObjetoUpgrade>();
            UIUpgrades uiUpgrades = kvp.Value.GetComponent<UIUpgrades>();
            if (nuevoDinero >= objetoUpgrade.priceOfUpgrade && objetoUpgrade.numberOfUpgrades < maxUpgrades)
            {
                objetoUpgrade.isVisible = true;
                uiUpgrades.ActulizarUpgradeUI();
            }
            else
            {
                objetoUpgrade.isVisible = false;
                uiUpgrades.ActulizarUpgradeUI();
            }

        }
    }

    public void FiltrarPorTipo(string tipo = null)
    {
        foreach (KeyValuePair<int, GameObject> kvp in dicionarioUpgrades)
        {
            ObjetoUpgrade objetoTienda = kvp.Value.GetComponent<ObjetoUpgrade>();
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

