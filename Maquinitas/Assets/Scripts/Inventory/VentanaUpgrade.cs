using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class VentanaUpgrade : MonoBehaviour
{
    private ObjetoUpgrade objetoUpgrade;

    private MoneyManager moneyManager;
    [SerializeField] private TextMeshProUGUI nombreText;
    [SerializeField] private Image spritePublicidad;
    [SerializeField] private Image spriteProducto;
    [SerializeField] private TextMeshProUGUI precioActualText;
    [SerializeField] private TextMeshProUGUI precioNuevoText;
    [SerializeField] private TextMeshProUGUI precioText;
    [SerializeField] private TextMeshProUGUI descripcionText;
    [SerializeField] private TextMeshProUGUI numberOfNextUpgrade;
    [SerializeField] private TextMeshProUGUI estadoError;
    [SerializeField] private TextMeshProUGUI sinFondos;
    [SerializeField] private GameObject botonContratar;
    private ObjectsList objects;
    private Tienda tienda;

    private void Start()
    {
        //objects = GameObject.Find("ObjectList").GetComponent<ObjectsList>();
        objects = GameObject.FindObjectOfType<ObjectsList>();
        tienda = GameObject.FindObjectOfType<Tienda>();
        //moneyManager = GameObject.FindWithTag("Money").GetComponent<MoneyManager>();
        if (objetoUpgrade != null)
        {
            if(objetoUpgrade.numberOfUpgrades >= objetoUpgrade.MaxUpgrades)
            {
                estadoError.gameObject.SetActive(true);
                estadoError.text = "Has llegado al maximo de contratos para publicidad";
                precioText.gameObject.SetActive(false);
                nombreText.text = "Publicidad para la " + objetoUpgrade.nombreText;
                spriteProducto.sprite = objetoUpgrade.spriteImage;
                descripcionText.text = objetoUpgrade.descripcionUpgrade;
                precioActualText.gameObject.SetActive(false);
                precioNuevoText.gameObject.SetActive(false);
                numberOfNextUpgrade.gameObject.SetActive(false);
                botonContratar.SetActive(false);
            }
            else
            {
                nombreText.text = "Publicidad para la " + objetoUpgrade.nombreText;
                spriteProducto.sprite = objetoUpgrade.spriteImage;
                precioText.text = objetoUpgrade.priceOfUpgrade.ToString() + "¥";
                descripcionText.text = objetoUpgrade.descripcionUpgrade;
                int precioActual = objects.VendingPriceOfObjectbyId(objetoUpgrade.id);
                precioActualText.text = "Precio de venta actual: " + precioActual + "¥";
                precioNuevoText.text = "Nuevo precio de venta: " + ((int)(precioActual + precioActual * ((objetoUpgrade.incrementoDePrecio) / 100f))).ToString() + "¥";
                numberOfNextUpgrade.text = (objetoUpgrade.numberOfUpgrades + 1).ToString();
                if(MoneyManager.instance.DineroTotal < objetoUpgrade.priceOfUpgrade)
                {
                    botonContratar.SetActive(false);
                    sinFondos.gameObject.SetActive(true);
                }
            }
            
        }
        
        
    }

    public void Comprar()
    {
        if (objetoUpgrade != null && MoneyManager.instance.DineroTotal >= objetoUpgrade.priceOfUpgrade)
        {
            int precio = objetoUpgrade.priceOfUpgrade;
            int precioVentaActual = objects.VendingPriceOfObjectbyId(objetoUpgrade.id);
            objects.ActualizeVendingPriceOfObjectbyId(objetoUpgrade.id, precioVentaActual + ((int)(precioVentaActual * objetoUpgrade.incrementoDePrecio / 100f)));
            tienda.ActualizarPrecioVentaPorId(objetoUpgrade.id, objects.VendingPriceOfObjectbyId(objetoUpgrade.id));
            objetoUpgrade.numberOfUpgrades += 1;
            if (objetoUpgrade.numberOfUpgrades >= objetoUpgrade.MaxUpgrades)
            {
                objetoUpgrade.isVisible = false;
            }
            objetoUpgrade.gameObject.GetComponent<UIUpgrades>().ActulizarUpgradeUI();
            MoneyManager.instance.DecrementarDinero(precio);
            Cancelar();
        }
        
    }

    public void SetObjetoUpgrade(ObjetoUpgrade objUpgrade)
    {
        objetoUpgrade = objUpgrade;
    }

    public void Cancelar()
    {
        CerrarVentana();
    }

    private void CerrarVentana()
    {
        Destroy(gameObject);
    }
}