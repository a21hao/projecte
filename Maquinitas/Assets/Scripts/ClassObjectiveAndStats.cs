using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Objective
{
    public string nameOfObjective;
    public string descriptionOfObjective;
    public bool objectiveDesbloqued = false;
    public bool objectiveCompleted = false;
    public List<Objective> objectivesToNeedForComplete;
    public GameObject objectiveObj;

    public Objective()
    {
        objectivesToNeedForComplete = new List<Objective>();
    }

    public void ChangeDisbloquedObjective(bool desb)
    {
        objectiveDesbloqued = desb;
    }

    public void DesblocObjectiveIfOtherAreCompleted()
    {
        bool disbloc = true;
        for (int i = 0; i < objectivesToNeedForComplete.Count; i++)
        {
            if (!objectivesToNeedForComplete[i].objectiveCompleted)
            {
                disbloc = false;
            }
        }
        objectiveDesbloqued = disbloc;
    }

    public void ChangeObjectiveCompleted(bool completed)
    {
        objectiveCompleted = completed;
    }
}

public class Stat
{
    public int idItem;
    public int numberOfUnitsSold = 0;
    public Sprite spriteObject;
    public string name;
    public TextMeshProUGUI textNumberSold;
    public GameObject objStat;

}
public class ClassObjectiveAndStats : ScriptableObject
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
