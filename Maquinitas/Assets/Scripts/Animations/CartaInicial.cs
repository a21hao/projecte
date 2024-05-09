using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class CartaInicial : MonoBehaviour
{
    [SerializeField] private GameObject letter;
    public bool eliminado = false;

    private void Awake()
    {
        if (eliminado == true)
        {
            Destroy(letter);
        }
    }

    public void EliminarLetter()
    {
        Destroy(letter);
        eliminado = true;
    }
}
