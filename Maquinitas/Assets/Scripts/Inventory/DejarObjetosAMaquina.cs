using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DejarObjetosAMaquina : MonoBehaviour
{
    public LayerMask capaObjetosArrastrables;
    public AAA aaaScript;

    void Update()
    {
        // Detectar si se está arrastrando un objeto con un collider
        if (Mouse.current.leftButton.isPressed)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, capaObjetosArrastrables))
            {
                GameObject objetoArrastrado = hit.collider.gameObject;

                // Añadir el objeto a la lista de objetos de AAA
                aaaScript.OnDropItem(objetoArrastrado);

                // Mensaje de depuración
                Debug.Log("Se ha detectado el objeto: " + objetoArrastrado.name);
            }
        }
    }
}
