using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    private static int dineroTotal = 145555;
    [SerializeField] private static TMP_Text textoDinero;

    private void Start()
    {
        //textoDinero.text = dineroTotal.ToString();
        textoDinero = GameObject.Find("Canvas/Dinero/TextoDinero").GetComponent<TMP_Text>();
        textoDinero.text = dineroTotal.ToString() + "¥";
    }

    public static int DineroTotal
    {
        get { return dineroTotal; }
        set { dineroTotal = value; }
    }

    public static void IncrementarDinero(int cantidad)
    {
        dineroTotal += cantidad;
        if (dineroTotal >= 2500) ObjectivesAndStats.cumplirObjetivo2500Y();
        if (dineroTotal >= 15000) ObjectivesAndStats.cumplirObjetivo15000Yenes();
        ActualizarTextoDinero();
    }

    public static void DecrementarDinero(int cantidad)
    {
        Debug.Log(cantidad + "menos");
        dineroTotal -= cantidad;
        ActualizarTextoDinero();
    }

    private static void ActualizarTextoDinero()
    {

        
        textoDinero.text = dineroTotal.ToString() + "¥";
        /*
        MoneyManager[] moneyManagers = FindObjectsOfType<MoneyManager>();
        foreach (MoneyManager manager in moneyManagers)
        {
            manager.textoDinero.text = dineroTotal.ToString();
        }*/
    }
}
