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
    int maxStock = 10;

    public ObjectBase item1;

    // Start is called before the first frame update
    void Start()
    {
        item1.stock = maxStock;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Buy()
    {
        Debug.Log("i");
        if (item1.stock > 0)
        {
            
            item1.stock -= 1;
            money += item1.precio;
            Debug.Log(item1.precio);
            //moneyUI.text = money.ToString();
            MoneyManager.IncrementarDinero(item1.precio);           

        }
    }

}
