using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour//, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private string nombre;
    [SerializeField] private Sprite sprite;
    [SerializeField] private int cantidad;
    [SerializeField] private TextMeshProUGUI textoCantidad;
    [SerializeField] private int ID;
    [SerializeField] private string descripcion;
    [SerializeField] private ObjectBase tipo;

    void Start()
    {

    }
    s
    void Update()
    {
        textoCantidad.text = cantidad.ToString();
    }
}
