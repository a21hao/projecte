using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AAA : MonoBehaviour
{

    public TMP_Text moneyUI;

    [SerializeField]
    int money;

    [SerializeField]
    int maxStock;

    public ObjectBase item1;

    void Start()
    {
        item1.stock = maxStock;
    }

    void Update()
    {

    }

    public void Buy()
    {
        if (item1.stock > 0)
        {
            item1.stock -= 1;
            money += item1.precio;
            moneyUI.text = money.ToString();

        }
    }

}
