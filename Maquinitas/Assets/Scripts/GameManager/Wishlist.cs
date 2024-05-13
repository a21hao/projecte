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
    private int countCat1 = 0;
    private int countCat2 = 0;
    private int countCat3 = 0;
    private int categoria = 1;
    void Start()
    {
        //random = new System.Random();
        categoria = ObjectivesAndStats.Instance.categoriaActual;
        listItemsWishlist = objectsOfGame.GetComponent<ObjectsList>().objectsList();
        //Debug.Log(listItemsWishlist.Count);
        idsObjects = new List<int>();
        for (int i = 0; i < listItemsWishlist.Count; i++)
        {
            if(listItemsWishlist[i].categoria == 1)
            {
                idsObjects.Add(listItemsWishlist[i].ID);
                countCat1 += 1;
            }
        
        }
        for (int i = 0; i < listItemsWishlist.Count; i++)
        {
            if (listItemsWishlist[i].categoria == 2)
            {
                idsObjects.Add(listItemsWishlist[i].ID);
                countCat2 += 1;
            }

        }
        for (int i = 0; i < listItemsWishlist.Count; i++)
        {
            if (listItemsWishlist[i].categoria == 3)
            {
                idsObjects.Add(listItemsWishlist[i].ID);
                countCat3 += 1;
            }

        }


    }

    public void SetCategoria(int cat)
    {
        categoria = cat;
    }

    public int ItemToWishId(int cat)
    {
        //Debug.Log(idsObjects.Count);
        //int randId = 
        if(Random.Range(0,100)>30)Random.InitState(System.Environment.TickCount);
        int idRandom = Random.Range(0, idsObjects.Count);
        if(cat == 1)
        {
            idRandom = Random.Range(0, countCat1);
        }
        if (cat == 2)
        {
            idRandom = Random.Range(0, countCat1 + countCat2);
        }
        if (cat == 3)
        {
            idRandom = Random.Range(0, idsObjects.Count);
        }

        //random.Next(min, max);

        //int idRandom = random.Next(0, idsObjects.Count);
        //Debug.Log(idRandom);
        return idsObjects[idRandom];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
