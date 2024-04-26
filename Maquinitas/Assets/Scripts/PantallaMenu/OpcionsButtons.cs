using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpcionsButtons : MonoBehaviour
{
    [SerializeField] GameObject buttonPressed;
    [SerializeField] GameObject buttonNotPressed1;
    [SerializeField] GameObject buttonNotPressed2;
    [SerializeField] GameObject buttonNotPressed3;

    public void SetActive()
    {
        buttonPressed.SetActive(true);
        buttonNotPressed1.SetActive(false);
        buttonNotPressed2.SetActive(false);
        buttonNotPressed3.SetActive(false);
    }
}
