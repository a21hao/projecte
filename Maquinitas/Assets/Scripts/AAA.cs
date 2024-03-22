using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AAA : MonoBehaviour
{

    [SerializeField] int money;
    [SerializeField] int stock;
    [SerializeField] int maxStock = 10;

    public MoneyManager moneyManager;

    public List<GameObject> objectList = new List<GameObject>();

    // Método que se llama cuando un objeto es arrastrado y soltado sobre el cubo
    public void OnDropItem(GameObject item)
    {
        Item itemComponent = item.GetComponent<Item>(); // Obtener componente Item del objeto arrastrado

        if (itemComponent != null)
        {
            // Verificar si ya existe un objeto similar en la lista
            bool found = false;
            foreach (GameObject obj in objectList)
            {
                Item objItem = obj.GetComponent<Item>();
                if (objItem != null && objItem.GetID() == itemComponent.GetID())
                {
                    objItem.SetCantidad(objItem.GetCantidad() + itemComponent.GetCantidad()); // Actualizar cantidad
                    found = true;
                    break;
                }
            }

            // Si no se encontró un objeto similar, agregarlo a la lista
            if (!found)
            {
                GameObject newItem = Instantiate(item); // Clonar el objeto
                newItem.transform.SetParent(transform); // Establecer como hijo del cubo
                newItem.transform.localPosition = Vector3.zero; // Colocar en el centro del cubo
                objectList.Add(newItem); // Agregar a la lista
                Debug.Log("Objeto añadido al cubo: " + newItem.name);
            }

            // Eliminar el objeto del inventario original
            Destroy(item);
        }
    }

    public void Buy()
    {

    }
}
