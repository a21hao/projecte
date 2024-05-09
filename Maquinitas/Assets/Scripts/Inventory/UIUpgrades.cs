using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIUpgrades : MonoBehaviour
{
    public Canvas canvas;

    [SerializeField] private ObjetoUpgrade objetoUpgrade;
    [SerializeField] private GameObject ventanaCompraUpgradePrefab;
    [SerializeField] private TextMeshProUGUI nombreTextUI;
    [SerializeField] private Image spritePublicidad;
    [SerializeField] private Image spriteProduct;
    [SerializeField] private TextMeshProUGUI precioTextUI;
    [SerializeField] private TextMeshProUGUI numberOfUpgradesText;

    private void Start()
    {
        canvas = GameObject.FindWithTag("Canvas").GetComponent<Canvas>();

        if (objetoUpgrade != null)
        {
            nombreTextUI.text = "Publicidad de " + objetoUpgrade.nombreText;
            spriteProduct.sprite = objetoUpgrade.spriteImage;
            precioTextUI.text = objetoUpgrade.priceOfUpgrade.ToString() + "¥";
            numberOfUpgradesText.text = objetoUpgrade.numberOfUpgrades.ToString();
        }
    }

    public void ActulizarUpgradeUI()
    {
        numberOfUpgradesText.text = objetoUpgrade.numberOfUpgrades.ToString();
        if (objetoUpgrade.isVisible) spritePublicidad.color = Color.white;
        else spritePublicidad.color = Color.gray;
    }

    public void MostrarVentanaCompra()
    {
        if (ventanaCompraUpgradePrefab != null)
        {
            if (canvas != null)
            {
                Vector3 centroCanvas = canvas.transform.position;

                GameObject ventanaCompraInstance = Instantiate(ventanaCompraUpgradePrefab, centroCanvas, Quaternion.identity, canvas.transform);
                VentanaUpgrade ventanaCompra = ventanaCompraInstance.GetComponent<VentanaUpgrade>();
                if (ventanaCompra != null && objetoUpgrade != null)
                {
                    ventanaCompra.SetObjetoUpgrade(objetoUpgrade);
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

