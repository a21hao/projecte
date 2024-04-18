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
    private int maxStock = 10;

    [SerializeField]
    private ObjectBase item1;

    [SerializeField]
    private int stock;

    // Start is called before the first frame update


    void Start()
    {
        stock = maxStock;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Buy()
    {

        //if (stock > 0)

        
        if (item1.stock > 0)

        {
            
            stock -= 1;
            money += item1.precio;
            
            //moneyUI.text = money.ToString();
            MoneyManager.IncrementarDinero(item1.precio);           

        }
    }

    public int getItemID()
    {
        return item1.ID;
    }

}
