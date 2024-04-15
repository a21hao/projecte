using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineInventory : MonoBehaviour
{
    // Start is called before the first frame update
    private int maxSlots = 15; 
    public class Slot
    {
        public int maxQuantity = 4;
        public Item item = null;
        public int quantity = 0;
    }

    private Slot[] slots;
    void Start()
    {
        slots = new Slot[maxSlots]; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PutItem(Item itemm)
    {
        int quantityOfItem = itemm.GetCantidad();
    
        for(int i = 0; i < slots.Length; i++)
        {
            if(slots[i].item == null)
            {
                if(itemm.GetCantidad() > 0 && itemm.GetCantidad() <= 4)
                {

                }
            }
        }
    }
}
