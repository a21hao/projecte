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

    void Awake()
    {
        quantityText = transform.GetComponent<TextMeshProUGUI>();
        iconoImage = GetComponent<Image>();

        exParent = transform.parent;
        if (exParent.GetComponent<Image>())
        {
            exParent.GetComponent<Image>().fillCenter = true;
        }

        InitializeItem(id, quantity);
    }

    void Update()
    {
        if (quantityText != null)
        {
            quantityText.text = quantity.ToString();
        }
    }

    public void InitializeItem(int id, int quantity)
    {
        itemData.ID = id;
        itemData.acumulable = db.database[id].acumulable;
        itemData.descripcionObjeto = db.database[id].descripcionObjeto;
        itemData.imagenObjeto = db.database[id].imagenObjeto;
        itemData.nameObjeto = db.database[id].nameObjeto;
        itemData.tipo = db.database[id].tipo;
        itemData.maxStack = db.database[id].maxStack;
        itemData.item = db.database[id].item; 

        deletteButtom.SetActive(false);
        iconoImage.sprite = itemData.icono;

        this.quantity = quantity;
    }

    public void EnableDeletion(bool enable)
    {
        deletteButtom.SetActive(enable);
    }

    public void Delete()
    {

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Inventory.Instance.HideDescription();
        quantityText.enabled = false;
        exParent = transform.parent;
        exParent.GetComponent<Image>().fillCenter = false;
        transform.etParent(Inventory.Instance.transform);
        dragOffset = transform.position - Input.mousePosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition + dragOffset;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        quantityText.enabled = true;

        List<RaycastResult> raycastResults = new List<RaycastResult>();
        Transform slot = null;

        Inventory.Instance.graphRay.Raycast(eventData, raycastResults);

        foreach(RaycastResult hit in raycastResults)
        {
            var hitObj = hit.gameObject;

            if(hitObj.CompareTag("Slot") && hit.gameObject.trnasform.childCount == 0)
            {
                slot = hit.gameObject.transform;
            }

            if (hitObj.CompareTag("Item_UI")
            {
                if(hitObj != this.gameObject)
                {
                    ItemUI hitObjItemData = hitObj.GetComponent<ItemUI>();
                    if(hitObjItemData.itemData.ID != id)
                    {
                        slot = hitObjItemData.transform.parent;

                        Inventory.Instance.UpdateParent(hitObjItemData, exparent);
                        break;
                    }
                    else
                    {
                        if(itemData.acumulable && hitObjItemData.quantity + quantity <= itemData.maxStack)
                        {
                            quantity += hitObjItemData.quantity;
                            slot = hitObjItemData.quantity;
                            Inventory.instance.DeleteItem(hitObjItemData, hitObjItemData.quantity, true);
                            break;
                        }
                        else
                        {
                            slot = hitObjItemData.transform.parent;
                            Inventory.Instance.UpdateParent(hitObjItemData, exParent);
                            break;
                        }
                    }
                }
            }
            Inventory.Instance.UpdateParent(this, slot != null ? slot : exParent);
        }
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
