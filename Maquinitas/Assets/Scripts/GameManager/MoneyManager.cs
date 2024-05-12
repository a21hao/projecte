using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using System.Collections;

public class MoneyManager : MonoBehaviour
{
    public int dineroTotal = 1500;
    public UnityEvent<int> NuevoDinero;
    public static MoneyManager instance;

    [SerializeField] private static TMP_Text textoDinero;

    private void Awake()
    {
        instance = this;
        
    }

    private void Start()
    {
        textoDinero = GameObject.Find("Canvas/Dinero/TextoDinero").GetComponent<TMP_Text>();
        StartCoroutine(_LoadInfo());
        ActualizarTextoDinero();
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
        dineroTotal += cantidad;
        if (dineroTotal >= 2500) ObjectivesAndStats.Instance.cumplirObjetivo2500Y();
        if (dineroTotal >= 10000) ObjectivesAndStats.Instance.cumplirObjetivo10000Yenes();
        if (dineroTotal >= 100000) ObjectivesAndStats.Instance.cumplirObjetivo100000Yenes();
        NuevoDinero.Invoke(dineroTotal);
        ActualizarTextoDinero();
    }

    public void DecrementarDinero(int cantidad)
    {
        Debug.Log(cantidad + " menos");
        DineroTotal -= cantidad;
        NuevoDinero.Invoke(DineroTotal);
        ActualizarTextoDinero();
    }

    public void ActualizarTextoDinero()
    {
        textoDinero.text = DineroTotal.ToString() + "�";
    }
}
