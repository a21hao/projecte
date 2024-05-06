using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIUpgrades : MonoBehaviour
{
    public Canvas canvas;

    [SerializeField] private ObjetoUpgrade objetoUpgrade;
    [SerializeField] private GameObject ventanaCompraPrefab;
    [SerializeField] private TextMeshProUGUI nombreTextUI;
    //[SerializeField] private Image spritePublicidad;
    [SerializeField] private Image spriteProduct;
    [SerializeField] private TextMeshProUGUI precioTextUI;

    private void Start()
    {
        canvas = GameObject.FindWithTag("Canvas").GetComponent<Canvas>();

        if (objetoUpgrade != null)
        {
            nombreTextUI.text = "Publicidad de " + objetoUpgrade.nombreText;
            spriteProduct.sprite = objetoUpgrade.spriteImage;
            precioTextUI.text = objetoUpgrade.priceOfUpgrade.ToString() + "¥";
        }
    }

    private void UpgradePriceAdvertising(int price)
    {
        precioTextUI.text = price.ToString();
    }

    public void MostrarVentanaCompra()
    {
        if (ventanaCompraPrefab != null)
        {
            if (canvas != null)
            {
                Vector3 centroCanvas = canvas.transform.position;

                GameObject ventanaCompraInstance = Instantiate(ventanaCompraPrefab, centroCanvas, Quaternion.identity, canvas.transform);
                VentanaCompra ventanaCompra = ventanaCompraInstance.GetComponent<VentanaCompra>();
                if (ventanaCompra != null && objetoUpgrade != null)
                {
                    //ventanaCompra.objetoTienda = objetoUpgrade;
                }
            }
            else
            {
                Debug.LogError("No se encontró un Canvas en la escena.");
            }
        }
        else
        {
            Debug.LogError("Prefab de la ventana de compra no asignado en UIObjetoTienda.");
        }
    }
}

