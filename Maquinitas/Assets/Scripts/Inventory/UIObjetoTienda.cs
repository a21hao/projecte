using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIObjetoTienda : MonoBehaviour
{
    public Canvas canvas;

    [SerializeField] private ObjetoTienda objetoTienda;
    [SerializeField] private GameObject ventanaCompraPrefab;
    [SerializeField] private TextMeshProUGUI nombreTextUI;
    [SerializeField] private Image spriteImageUI;
    [SerializeField] private TextMeshProUGUI precioTextUI;

    private void Start()
    {
        canvas = GameObject.FindWithTag("Canvas").GetComponent<Canvas>();

        if (objetoTienda != null)
        {
            nombreTextUI.text = objetoTienda.nombreText;
            spriteImageUI.sprite = objetoTienda.spriteImage;
            precioTextUI.text = objetoTienda.precioObjeto;
        }
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
