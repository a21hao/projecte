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

    private void Start()
    {
        moneyManager = GameObject.FindWithTag("Money").GetComponent<MoneyManager>();
        if (objetoUpgrade != null)
        {
            nombreText.text = objetoUpgrade.nombreText;
            spriteProducto.sprite = objetoUpgrade.spriteImage;
            precioText.text = objetoUpgrade.priceOfUpgrade.ToString();
            descripcionText.text = objetoUpgrade.descripcionObjeto;
        }
        
        
    }

    public void Comprar()
    {
        if (moneyManager != null && objetoUpgrade != null && MoneyManager.DineroTotal >= objetoUpgrade.priceOfUpgrade)
        {
            int precio = objetoUpgrade.priceOfUpgrade;
            MoneyManager.DecrementarDinero(precio);
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