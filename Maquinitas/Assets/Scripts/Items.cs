using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Item", menuName = "SellableItem")]
public class Items : ScriptableObject
{
    public string name;
    public string description;

    public int sellPrice;
    public int buyPrice;
    public int stock;
}