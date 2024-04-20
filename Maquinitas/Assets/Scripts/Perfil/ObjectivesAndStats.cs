using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ObjectivesAndStats : MonoBehaviour
{
    [SerializeField]
    private GameObject objectivePrefab;
    [SerializeField]
    private GameObject statPrefab;
    [SerializeField]
    private Transform contentParent;
    [SerializeField]
    private Transform ObjectivesTitle;
    private int indexOfObjectiveTitle;
    private int indexOfStatsTitle;
    [SerializeField]
    private GameObject itemsListGO;
    [SerializeField]
    private GameObject objectivesAndStatsIntermediaryGO;
    

    private List<Objective> tutorialObjectives;
    private List<Objective> objectives;
    private List<ObjectBase> objectsListt;
    private List<Stat> stats;
    private Objective objectiveInCourse;

    //private GameObject instantiatedObjective;
    // Start is called before the first frame update
    void Awake()
    {

        
        indexOfObjectiveTitle = ObjectivesTitle.GetSiblingIndex();
        objectsListt = itemsListGO.GetComponent<ObjectsList>().objectsList();
        stats = new List<Stat>();
        //Tutorial Objectives
        tutorialObjectives = new List<Objective>();
        objectives = new List<Objective>();
        Objective objectivet1 = new Objective();
        objectivet1.nameOfObjective = "Coloca una maquina en el mapa";
        objectivet1.objectiveDesbloqued = true;
        tutorialObjectives.Add(objectivet1);
        Objective objectivet2 = new Objective();
        objectivet2.nameOfObjective = "Compra tu primer producto";
        objectivet2.objectivesToNeedForComplete.Add(objectivet1);
        tutorialObjectives.Add(objectivet2);
        Objective objectivet3 = new Objective();
        objectivet3.nameOfObjective = "Abre el almacen";
        objectivet3.objectivesToNeedForComplete.Add(objectivet2);
        tutorialObjectives.Add(objectivet3);
        Objective objectivet4 = new Objective();
        objectivet4.nameOfObjective = "Accede a vista de maquina";
        objectivet4.objectivesToNeedForComplete.Add(objectivet3);
        tutorialObjectives.Add(objectivet4);
        Objective objectivet5 = new Objective();
        objectivet5.nameOfObjective = "Coloca tu primer objeto en la maquina";
        objectivet5.objectivesToNeedForComplete.Add(objectivet4);
        tutorialObjectives.Add(objectivet5);
        Objective objectivet6 = new Objective();
        objectivet6.nameOfObjective = "Observa el transcurso del juego durante 30 segundos";
        objectivet6.objectivesToNeedForComplete.Add(objectivet5);
        tutorialObjectives.Add(objectivet6);
        Objective objectivet7 = new Objective();
        objectivet7.nameOfObjective = "Rellena otra maquina con productos quando este vacia";
        objectivet7.objectivesToNeedForComplete.Add(objectivet6);
        tutorialObjectives.Add(objectivet7);
        Objective objectivet8 = new Objective();
        objectivet8.nameOfObjective = "Consigue 1500 yenes";
        objectivet8.objectivesToNeedForComplete.Add(objectivet7);
        tutorialObjectives.Add(objectivet8);
        //Game Objectives
        Objective objectiveg1 = new Objective();
        objectiveg1.nameOfObjective = "Compra algun espacio mas";
        objectiveg1.objectivesToNeedForComplete.Add(objectivet8);
        objectives.Add(objectiveg1);
        Objective objectiveg2 = new Objective();
        objectiveg2.nameOfObjective = "Compra alguna maquina mas";
        objectiveg2.objectivesToNeedForComplete.Add(objectiveg1);
        objectives.Add(objectiveg2);
        Objective objectiveg3 = new Objective();
        objectiveg3.nameOfObjective = "Vende al menos 20 unidad de cada producto de la categoria 1";
        objectiveg3.objectivesToNeedForComplete.Add(objectiveg2);
        objectives.Add(objectiveg3);
        Objective objectiveg4 = new Objective();
        objectiveg4.nameOfObjective = "Consigue 15000 yenes";
        objectiveg4.objectivesToNeedForComplete.Add(objectiveg2);
        objectives.Add(objectiveg4);
        //StatsGame
        for (int i = 0; i < objectsListt.Count; i++)
        {
            Stat stat = new Stat();
            stat.idItem = objectsListt[i].ID;
            stat.name = objectsListt[i].nombre;
            stat.spriteObject = objectsListt[i].sprite;
            stat.numberOfUnitsSold = 0;
            stats.Add(stat);
        }


        InstantiateObjectivesInPerfil();
        indexOfStatsTitle = gameObject.transform.Find("Viewport/Content/Stats").GetSiblingIndex();
        InstantiateStatsInPerfil();



    }

    private void InstantiateObjectivesInPerfil()
    {
        for(int i = 0; i < tutorialObjectives.Count; i++)
        {
            GameObject instantiatedObjective = Instantiate(objectivePrefab, contentParent);
            TextMeshProUGUI textObjective= instantiatedObjective.transform.Find("ObjectiveText").GetComponent<TextMeshProUGUI>();
            //-->GameObject checked = instantiatedObjective.transform.Find("ObjectiveText").GetComponent<TextMeshProUGUI>();
            textObjective.text = tutorialObjectives[i].nameOfObjective;
            indexOfObjectiveTitle += 1;
            instantiatedObjective.transform.SetSiblingIndex(indexOfObjectiveTitle);
            tutorialObjectives[i].objectiveObj = instantiatedObjective;
            //if (tutorialObjectives[i].objectiveCompleted) tutorialObjectives[i]

        }

        for (int i = 0; i < objectives.Count; i++)
        {
            GameObject instantiatedObjective = Instantiate(objectivePrefab, contentParent);
            TextMeshProUGUI textObjective = instantiatedObjective.transform.Find("ObjectiveText").GetComponent<TextMeshProUGUI>();
            //-->GameObject checked = instantiatedObjective.transform.Find("ObjectiveText").GetComponent<TextMeshProUGUI>();
            textObjective.text = objectives[i].nameOfObjective;
            indexOfObjectiveTitle += 1;
            instantiatedObjective.transform.SetSiblingIndex(indexOfObjectiveTitle);
            objectives[i].objectiveObj = instantiatedObjective;
            //if (tutorialObjectives[i].objectiveCompleted) tutorialObjectives[i]

        }

    }

    private void InstantiateStatsInPerfil()
    {
        Debug.Log("Ha entrado stats");
        for (int i = 0; i < stats.Count; i++)
        {
            GameObject instantiatedStat = Instantiate(statPrefab, contentParent);
            Image imgStat = instantiatedStat.transform.Find("SpriteItem").gameObject.GetComponent<Image>();
            imgStat.sprite = stats[i].spriteObject;
            TextMeshProUGUI textStat = instantiatedStat.transform.Find("StatText").GetComponent<TextMeshProUGUI>();
            textStat.text = stats[i].name + " vendidas: ";
            TextMeshProUGUI numberUnitysInfoText = instantiatedStat.transform.Find("StatsInfo").GetComponent<TextMeshProUGUI>();
            numberUnitysInfoText.text = stats[i].numberOfUnitsSold.ToString();
            stats[i].textNumberSold = numberUnitysInfoText;
            Image imgStatInfo = instantiatedStat.transform.Find("StatsInfo/spriteInfo").gameObject.GetComponent<Image>();
            imgStatInfo.sprite = stats[i].spriteObject;
            indexOfStatsTitle += 1;
            instantiatedStat.transform.SetSiblingIndex(indexOfStatsTitle);
            stats[i].objStat = instantiatedStat;
            //if (tutorialObjectives[i].objectiveCompleted) tutorialObjectives[i]

        }
    }

    public void updateStat(int idItemm, int cantidad)
    {
        for(int i = 0; i < stats.Count; i++)
        {
            if(stats[i].idItem == idItemm)
            {
                stats[i].numberOfUnitsSold += cantidad;
                stats[i].textNumberSold.text = stats[i].numberOfUnitsSold.ToString();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
