using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsList : MonoBehaviour
{
    // Start is called before the first frame update
    public List<ObjectBase> listObjects;

    public List<ObjectBase> objectsList()
    {
        return listObjects;
    }

    public ObjectBase getObjectbyId(int id)
    {
        for(int i = 0; i < listObjects.Count; i++)
        {
            if (listObjects[i].ID == id)
            {
                return listObjects[i];
            }
        }
        return null;
    }

    public ObjectBase getObjectbyName(string name)
    {
        for (int i = 0; i < listObjects.Count; i++)
        {
            if (listObjects[i].nombre == name)
            {
                return listObjects[i];
            }
        }
        return null;
    }
}
