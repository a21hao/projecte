using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static InventarioData;

public class LogicaGuardadoInventario : MonoBehaviour
{
    public Inventario inventario;
    public string filePath;
    public GameObject objetoPrefabricado;

    public void GuardarInventario()
    {
        InventarioData inventarioData = new InventarioData();

        foreach (var slot in inventario.slots)
        {
            SlotData slotData = new SlotData();
            slotData.tieneHijo = slot.transform.childCount > 0;

            if (slotData.tieneHijo)
            {
                Item item = slot.transform.GetChild(0).GetComponent<Item>();
                if (item != null)
                {
                    ItemData itemData = new ItemData();
                    itemData.nombreText = item.nombreText;
                    // Aquí deberías gestionar cómo guardar y cargar la imagen del objeto (spriteImage)
                    itemData.spriteImageKey = item.spriteImage.name; // Ejemplo de clave de imagen
                    itemData.precioObjeto = item.precioObjeto;
                    itemData.descripcionObjeto = item.descripcionObjeto;
                    itemData.ID = item.GetID();
                    itemData.tipo = item.tipo;
                    itemData.cantidad = item.GetCantidad();

                    slotData.hijoData = itemData;
                }
            }

            inventarioData.slots.Add(slotData);
        }

        inventarioData.GuardarInventario(filePath);
    }

    public void CargarInventario()
    {
        InventarioData inventarioData = InventarioData.CargarInventario(filePath);
        if (inventarioData != null)
        {
            for (int i = 0; i < inventarioData.slots.Count; i++)
            {
                SlotData slotData = inventarioData.slots[i];
                if (slotData.tieneHijo && slotData.hijoData != null)
                {
                    GameObject slot = inventario.slots[i]; // Acceder al slot correspondiente en el inventario
                                                           // Instanciar el objeto hijo en el slot
                    GameObject objetoInstanciado = Instantiate(objetoPrefabricado, slot.transform);
                    Item itemComponent = objetoInstanciado.GetComponent<Item>();
                    if (itemComponent != null)
                    {
                        // Asignar la información del objeto desde los datos cargados
                        itemComponent.nombreText = slotData.hijoData.nombreText;
                        // Aquí deberías gestionar cómo cargar la imagen del objeto (spriteImage)
                        itemComponent.precioObjeto = slotData.hijoData.precioObjeto;
                        itemComponent.descripcionObjeto = slotData.hijoData.descripcionObjeto;
                        itemComponent.SetID(slotData.hijoData.ID);
                        itemComponent.tipo = slotData.hijoData.tipo;
                        itemComponent.SetCantidad(slotData.hijoData.cantidad);

                        // Restaurar imagen (si es necesario)
                        // itemComponent.spriteImage = ...;
                    }
                }
            }
        }
    }

}
