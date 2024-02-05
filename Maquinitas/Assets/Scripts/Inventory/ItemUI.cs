using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ItemUI : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private PlantillaObjetos db;
    [SerializeField] private GameObject deletteButtom;
    public int id;
    public int quantity;
    [HideInInspector] public PlantillaObjetos.Mercancia itemData;
    [HideInInspector] public Transform exParent;

    TextMeshProUGUI quantityText;
    Image iconoImage;
    Vector3 dragOffset;

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
