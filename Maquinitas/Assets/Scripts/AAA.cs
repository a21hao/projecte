using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AAA : MonoBehaviour
{
				[SerializeField]
				int stock;
				[SerializeField]
				int price;
				[SerializeField]
				int money;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
								if (Input.GetKeyDown("space"))
								{
												if (stock > 0)
												{
																stock -= 1;
																money += price;
												}
								}
    }

}
