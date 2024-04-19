using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wishlist : MonoBehaviour
{
    // Start is called before the first frame update

    private List<ObjectBase> listItemsWishlist;
    private List<int> idsObjects;
    [SerializeField]
    private GameObject objectsOfGame;
    void Start()
    {
        listItemsWishlist = objectsOfGame.GetComponent<ObjectsList>().objectsList();
        //Debug.Log(listItemsWishlist.Count);
        idsObjects = new List<int>();
        
        for (int i = 0; i < listItemsWishlist.Count; i++)
        {
            idsObjects.Add(listItemsWishlist[i].ID);
        }
        

    }

    public int ItemToWishId()
    {
        Debug.Log(idsObjects.Count);
        //int randId = 
        Random.InitState(System.Environment.TickCount);
        int idRandom = Random.Range(0, idsObjects.Count);
        Debug.Log(idRandom);
        return idsObjects[idRandom];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
