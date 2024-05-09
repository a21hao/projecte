using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class MoneyManager : MonoBehaviour
{
    private GameInfo moneyinfo;
    public UnityEvent<int> NuevoDinero;
    public static MoneyManager instance;

    [SerializeField] private static TMP_Text textoDinero;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        moneyinfo = new GameInfo();
        textoDinero = GameObject.Find("Canvas/Dinero/TextoDinero").GetComponent<TMP_Text>();
        ActualizarTextoDinero();
    }

    public int DineroTotal
    {
        get { return moneyinfo.money;
            ActualizarTextoDinero();
        } 
        set { moneyinfo.money = value; 
            ActualizarTextoDinero(); }
    }

    public void IncrementarDinero(int cantidad)
    {
        DineroTotal += cantidad;
        if (DineroTotal >= 2500) ObjectivesAndStats.cumplirObjetivo2500Y();
        if (DineroTotal >= 15000) ObjectivesAndStats.cumplirObjetivo15000Yenes();
        NuevoDinero.Invoke(DineroTotal);
        ActualizarTextoDinero();
    }

    public void DecrementarDinero(int cantidad)
    {
        Debug.Log(cantidad + " menos");
        DineroTotal -= cantidad;
        NuevoDinero.Invoke(DineroTotal);
        ActualizarTextoDinero();
    }

    private void ActualizarTextoDinero()
    {
        textoDinero.text = DineroTotal.ToString() + "¥";
    }
}
