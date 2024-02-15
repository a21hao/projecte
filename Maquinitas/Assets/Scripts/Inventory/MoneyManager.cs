using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    // Start is called before the first frame update
{
    private static int dineroTotal = 50;

    public static int DineroTotal
    {
        get { return dineroTotal; }
        set { dineroTotal = value; }
    }

    public static void IncrementarDinero(int cantidad)
    {
        dineroTotal += cantidad;
    }

    public static void DecrementarDinero(int cantidad)
    {
        dineroTotal -= cantidad;
    }
}
}
