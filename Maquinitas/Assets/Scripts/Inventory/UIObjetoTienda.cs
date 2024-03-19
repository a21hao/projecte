using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIObjetoTienda : MonoBehaviour
{
    [SerializeField] private ObjetoTienda objetoTienda;
    [SerializeField] private GameObject ventanaCompraPrefab;

    [SerializeField] private TextMeshProUGUI nombreTextUI;
    [SerializeField] private Image spriteImageUI;
    [SerializeField] private TextMeshProUGUI precioTextUI;

    private void Start()
    {
        if (objetoTienda != null)
        {
            nombreTextUI.text = objetoTienda.nombreText;
            spriteImageUI.sprite = objetoTienda.spriteImage;
            precioTextUI.text = objetoTienda.precioObjeto;
        }
    }

    public void MostrarVentanaCompra()
    {
        // Verifica si el prefab de la ventana de compra está asignado
        if (ventanaCompraPrefab != null)
        {
            // Encuentra el Canvas en la escena
            Canvas canvas = FindObjectOfType<Canvas>();
            if (canvas != null)
            {
                // Calcula la posición central del Canvas
                Vector3 centroCanvas = canvas.transform.position;

                // Instancia la ventana de compra en el centro del Canvas
                GameObject ventanaCompraInstance = Instantiate(ventanaCompraPrefab, centroCanvas, Quaternion.identity, canvas.transform);

                // Obtén una referencia al script VentanaCompra
                VentanaCompra ventanaCompra = ventanaCompraInstance.GetComponent<VentanaCompra>();
                // Configura la ventana de compra con la información del objeto de la tienda
                if (ventanaCompra != null && objetoTienda != null)
                {
                    ventanaCompra.objetoTienda = objetoTienda;
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
