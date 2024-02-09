using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AAA : MonoBehaviour
{

	[SerializeField]
	int money;

	[SerializeField]
	int maxStock;

	public Items item1;

    // Start is called before the first frame update
    void Start()
    {
		item1.stock = maxStock;
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown("space"))
		{
            Buy();
        }

        if(Input.GetKeyDown("n"))
        {
            if (item1.stock < maxStock && money >= item1.buyPrice)
            {
                item1.stock += 1;
                money -= item1.buyPrice;

                Debug.Log(item1.stock);
            }
        }
    }

    public void Buy()
    {
        if (item1.stock > 0)
        {
            item1.stock -= 1;
            money += item1.sellPrice;


            Debug.Log(item1.stock);

        }
    }

}
