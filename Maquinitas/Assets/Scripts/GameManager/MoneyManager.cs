using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class MoneyManager : MonoBehaviour
{
    private int dineroTotal = 1100;

    public UnityEvent<int> NuevoDinero;

    public static MoneyManager instance;
    

    [SerializeField] private static TMP_Text textoDinero;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        //textoDinero.text = dineroTotal.ToString();
        
        //dineroTotal = 900;
        textoDinero = GameObject.Find("Canvas/Dinero/TextoDinero").GetComponent<TMP_Text>();
        textoDinero.text = dineroTotal.ToString() + "¥";
    }

    public int DineroTotal
    {
        get { return dineroTotal; }
        set { dineroTotal = value; }
    }

    public void IncrementarDinero(int cantidad)
    {
        dineroTotal += cantidad;
        if (dineroTotal >= 2500) ObjectivesAndStats.cumplirObjetivo2500Y();
        if (dineroTotal >= 15000) ObjectivesAndStats.cumplirObjetivo15000Yenes();
        NuevoDinero.Invoke(dineroTotal);
        ActualizarTextoDinero();
    }

    public void DecrementarDinero(int cantidad)
    {
        Debug.Log(cantidad + "menos");
        dineroTotal -= cantidad;
        NuevoDinero.Invoke(dineroTotal);
        ActualizarTextoDinero();
    }

    private void ActualizarTextoDinero()
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
