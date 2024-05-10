using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using System.Collections;

public class MoneyManager : MonoBehaviour
{
    public UnityEvent<int> NuevoDinero;
    public static MoneyManager instance;
    public int dineroTotal = 1500;
    [SerializeField] private static TMP_Text textoDinero;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        textoDinero = GameObject.Find("Canvas/Dinero/TextoDinero").GetComponent<TMP_Text>();
        ActualizarTextoDinero();
        StartCoroutine(_LoadInfo());
    }

    IEnumerator _LoadInfo()
    {
        while (Save.GetGameInfo() == null)
        {
            yield return null;
        }
        ActualizarTextoDinero();

    }

    public int DineroTotal
    {
        get { return dineroTotal; }
        set { dineroTotal = value; }
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
