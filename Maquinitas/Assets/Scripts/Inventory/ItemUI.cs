using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ItemUI : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    //[SerializeField] private PlantillaObjetos db;
    //[SerializeField] private GameObject deletteButtom;
    //public int id;
    //public int quantity;
    //[HideInInspector] public PlantillaObjetos.Mercancia itemData;
    //[HideInInspector] public Transform exParent;

    //TextMeshProUGUI quantityText;
    //Image iconoImage;
    //Vector3 dragOffset;

    //void Awake()
    //{
    //    quantityText = transform.GetComponent<TextMeshProUGUI>();
    //    iconoImage = GetComponent<Image>();

    //    exParent = transform.parent;
    //    if (exParent.GetComponent<Image>())
    //    {
    //        exParent.GetComponent<Image>().fillCenter = true;
    //    }

    //    InitializeItem(id, quantity);
    //}

    //void Update()
    //{
    //    if(quantityText != null)
    //    {
    //        quantityText.text = quantity.ToString();
    //    }
    //}

    //public void InitializeItem(int id, int quantity)
    //{
    //    itemData.ID = id;
    //    itemData.acumulable = db.database[id].acumulable;
    //    itemData.descripcionObjeto = db.database[id].descripcionObjeto;
    //    itemData.imagenObjeto = db.database[id].imagenObjeto;
    //    itemData.nameObjeto = db.database[id].nameObjeto;
    //    itemData.tipo = db.database[id].tipo;
    //    itemData.maxStack = db.database[id].maxStack;
    //    itemData.item = db.database[id].item;

    //    deletteButtom.SetActive(false);
    //    iconoImage.sprite = itemData.icono;

    //    this.quantity = quantity;
    //}

    //public void EnableDeletion(bool enable)
    //{
    //    deletteButtom.SetActive(enable);
    //}

    //public void Delete()
    //{

    //}

    public void OnBeginDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
