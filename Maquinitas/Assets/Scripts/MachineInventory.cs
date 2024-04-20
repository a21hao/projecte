using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class MachineInventory : MonoBehaviour
{
    // Start is called before the first frame update
    private int maxSlots = 15;
    private Transform slotsparent;
    private ObjectivesAndStats objAndStats;
    
    public class Slot
    {
        public int maxQuantity = 4;
        public Item item = null;
        public int quantity = 0;
        public Transform slotparent;
        public GameObject[] itemsObjects;
    }

    private Slot[] slots;
    void Start()
    {
        objAndStats = GameObject.Find("Canvas/Menú/PerfilT").gameObject.GetComponent<ObjectivesAndStats>();
        Debug.Log("Objs and stats " + objAndStats != null);
        slotsparent = transform.Find("Slots");
        slots = new Slot[maxSlots];
        for (int i = 0; i < slots.Length; i++)
        {
            Slot slot = new Slot();
            slot.slotparent = slotsparent.GetChild(i);
            slot.itemsObjects = new GameObject[4];
            slots[i] = slot;
            Debug.Log(slots[i]);
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PutItem(Item itemm)
    {
        int quantityOfitemm = itemm.GetCantidad();
        quantityOfitemm -= HasSlotOfThatItem(itemm);
        itemm.SetCantidad(quantityOfitemm);
        quantityOfitemm -= putItemsWithoutOthers(itemm);
        itemm.SetCantidad(quantityOfitemm);
        
    }

    private int HasSlotOfThatItem(Item itemm)
    {
        int idItem = itemm.GetID();
        int QuantityItemInitial = itemm.GetCantidad();
        int QuantityToRest = 0;
        
        for (int i = 0; i < slots.Length; i++)
        {
            Debug.Log(slots[i]);
            if (slots[i].item != null)
            {
                if (slots[i].item.GetID() == itemm.GetID() && slots[i].quantity > 0 && slots[i].quantity < 4 & QuantityItemInitial > 0)
                {
                    int slotMaxtoPut = slots[i].maxQuantity - slots[i].quantity;
                    if (QuantityItemInitial >= slotMaxtoPut)
                    {
                        QuantityToRest += slotMaxtoPut;
                        QuantityItemInitial -= slotMaxtoPut;
                        for (int j = slots[i].quantity; j < slots[i].maxQuantity; ++j)
                        {
                           slots[i].itemsObjects[j] = Instantiate(itemm.GetObjeto3d(), slots[i].slotparent.GetChild(j));
                           slots[i].itemsObjects[j].transform.localPosition = Vector3.zero;

                        }

                        slots[i].quantity = 4;
                    }
                    else
                    {
                        for (int j = slots[i].quantity; j < slots[i].quantity + QuantityItemInitial; ++j)
                        {
                            slots[i].itemsObjects[j] = Instantiate(itemm.GetObjeto3d(), slots[i].slotparent.GetChild(j));
                            slots[i].itemsObjects[j].transform.localPosition = Vector3.zero;

                        }
                        QuantityToRest += QuantityItemInitial;
                        slots[i].quantity += QuantityItemInitial;
                        QuantityItemInitial = 0;
                    }

                    slots[i].item.SetInformacion(itemm.nombreText, itemm.spriteImage.sprite, itemm.precioObjeto, itemm.descripcionObjeto, itemm.GetID(), itemm.tipo, slots[i].quantity, itemm.Objeto3d, itemm.precioVenta);
                }
            }
            
            
        }
        return QuantityToRest;
    }

    private int putItemsWithoutOthers(Item itemm)
    {
        int QuantityItemInitial = itemm.GetCantidad();
        int QuantityToRest = 0;
        for(int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item == null && QuantityItemInitial > 0)
            {
                if(QuantityItemInitial <= 4)
                {
                    QuantityToRest += QuantityItemInitial;
                    for (int j = 0; j < QuantityItemInitial; ++j)
                    {
                        slots[i].itemsObjects[j] = Instantiate(itemm.GetObjeto3d(), slots[i].slotparent.GetChild(j));
                        slots[i].itemsObjects[j].transform.localPosition = Vector3.zero;
                    }
                    slots[i].quantity = QuantityItemInitial;
                    QuantityItemInitial = 0;
                    
                }
                else
                {
                    for (int j = 0; j < 4; ++j)
                    {
                        slots[i].itemsObjects[j] = Instantiate(itemm.GetObjeto3d(), slots[i].slotparent.GetChild(j));
                        slots[i].itemsObjects[j].transform.localPosition = Vector3.zero;
                    }
                    QuantityToRest += 4;
                    QuantityItemInitial -= 4;
                    slots[i].quantity = 4;
                }
                Item slotitem = Instantiate(itemm);
                slotitem.SetInformacion(itemm.nombreText, itemm.spriteImage.sprite, itemm.precioObjeto, itemm.descripcionObjeto, itemm.GetID(), itemm.tipo, slots[i].quantity, itemm.Objeto3d, itemm.precioVenta);
                slots[i].item = slotitem;

            }
        }
        return QuantityToRest;
    }
    
    public void VenderItem(int ID, int cantidad)
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item != null)
            {
                if(slots[i].item.GetID() == ID && cantidad > 0 && slots[i].quantity > 0)
                {
                    if (slots[i].quantity > cantidad)
                    {
                        for(int j = slots[i].quantity - 1; j > slots[i].quantity - 1 - cantidad; j--)
                        {
                            Destroy(slots[i].itemsObjects[j]);
                        }
                        slots[i].quantity -= cantidad;
                        MoneyManager.IncrementarDinero(cantidad * slots[i].item.precioVenta);
                        objAndStats.updateStat(slots[i].item.GetID(), cantidad);
                        //SoldItem.Invoke(slots[i].item.GetID(), cantidad);
                        cantidad = 0;
                        
                    }
                    if (cantidad >= slots[i].quantity)
                    {
                        for (int j = 0; j < slots[i].itemsObjects.Length; j++)
                        {
                            if (slots[i].itemsObjects[j] != null)
                            Destroy(slots[i].itemsObjects[j]);
                        }
                        cantidad -= slots[i].quantity;
                        MoneyManager.IncrementarDinero(slots[i].quantity * slots[i].item.precioVenta);
                        objAndStats.updateStat(slots[i].item.GetID(), slots[i].quantity);
                        //SoldItem.Invoke(slots[i].item.GetID(), slots[i].quantity);
                        slots[i].quantity = 0;                        
                        slots[i].item = null;
                    }
                } 
                
            }
            
        }
    }
        
       
    
 }
