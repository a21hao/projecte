using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableObject : MonoBehaviour
{
    // Start is called before the first frame update

    public void DisableObjectt()
    {
        gameObject.SetActive(false);
    }

    public void EnableObjectt()
    {
        gameObject.SetActive(true);
    }
}
