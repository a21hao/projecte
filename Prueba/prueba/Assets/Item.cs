using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public int cantidad = 1;
    public TextMeshProUGUI textoCantidad;
    public int ID;
    public Button Boton;
    public GameObject _descripcion;
    public TextMeshProUGUI Nombre_;
    public TextMeshProUGUI Dato_;
    public Vector3 offset;
    public ObjectDataBase DB;

    // Start is called before the first frame update
    void Start()
    {
        Boton = GetComponent<Button>();
        _descripcion = Inventario.description;
        Nombre_ = _descripcion.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        Dato_ = _descripcion.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        _descripcion.SetActive(false);
        if (!_descripcion.GetComponent<Image>().enabled)
        {
            _descripcion.GetComponent <Image>().enabled = true;
            Nombre_.enabled = true;
            Dato_ .enabled = true;
        }
    }

    void Update()
    {
        if (transform.parent.GetComponent<Image>() != null)
        {
            transform.parent.GetComponent<Image>().fillCenter = true;
        }
        textoCantidad.text = cantidad.ToString();
        if (transform.parent == Inventario.canvas)
        {
            _descripcion.SetActive(false);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _descripcion.SetActive(true);
        Nombre_.text = DB.baseDatos[ID].nombre;
        Dato_.text = DB.baseDatos[ID].descripcion;
        _descripcion.transform.position = transform.position + offset;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _descripcion.SetActive(false);
    }
}
