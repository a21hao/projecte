using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class VentanaCompra : MonoBehaviour
{
    public ObjetoTienda objetoTienda;

    [SerializeField] private MoneyManager moneyManager;
    [SerializeField] private Inventario inventario;
    [SerializeField] private GameObject prefabObjetoInventario;
    [SerializeField] private TextMeshProUGUI nombreText;
    [SerializeField] private Image spriteImage;
    [SerializeField] private TextMeshProUGUI precioText;
    [SerializeField] private TextMeshProUGUI descripcionText;
    [SerializeField] private Slider cantidadSlider;
    [SerializeField] private TextMeshProUGUI cantidadTexto;

    private void Start()
    {
        moneyManager = GameObject.FindWithTag("Money").GetComponent<MoneyManager>();
        inventario = FindObjectOfType<Inventario>(true);
        Debug.Log(inventario);
        if (objetoTienda != null)
        {
            nombreText.text = objetoTienda.nombreText;
            spriteImage.sprite = objetoTienda.spriteImage;
            precioText.text = objetoTienda.precioObjeto;
            descripcionText.text = objetoTienda.descripcionObjeto;
        }
        cantidadSlider.maxValue = (int)(MoneyManager.DineroTotal/(float.Parse(objetoTienda.precioObjeto)));
    }

    public void ActualizarCantidadTexto(float cantidad)
    {
        cantidadTexto.text = Mathf.RoundToInt(cantidad).ToString();
        if (objetoTienda != null)
        {
            float precio = float.Parse(objetoTienda.precioObjeto);
            float precioTotal = (cantidad * precio);
            precioText.text = Mathf.RoundToInt(precioTotal).ToString();
        }
    }

    public void Comprar()
    {
        int cantidad = (int)cantidadSlider.value;
        if (moneyManager != null && objetoTienda != null)
        {
            float precio = float.Parse(objetoTienda.precioObjeto);
            int precioTotal = Mathf.RoundToInt(cantidad * precio);
            MoneyManager.DecrementarDinero(precioTotal);
        }

        GameObject emptySlot = inventario.GetSlotVacio();
        if (emptySlot != null)
        {
            GameObject nuevoObjeto = Instantiate(prefabObjetoInventario);
            Item itemComponent = nuevoObjeto.GetComponent<Item>();
            itemComponent.SetInformacion(objetoTienda.nombreText, objetoTienda.spriteImage, objetoTienda.precioObjeto, objetoTienda.descripcionObjeto, objetoTienda.id, objetoTienda.tipo, cantidad,objetoTienda.objeto3d,objetoTienda.precioVenta);
            nuevoObjeto.transform.SetParent(emptySlot.transform);
            nuevoObjeto.transform.localScale = Vector3.one;
            nuevoObjeto.transform.localPosition = Vector3.zero;
        }
        else
        {
            Debug.Log("Inventario lleno");
        }
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
