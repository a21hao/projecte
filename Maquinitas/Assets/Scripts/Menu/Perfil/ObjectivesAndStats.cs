using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using FMODUnity;
using UnityEngine.InputSystem.LowLevel;

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
    public static ObjectivesAndStats Instance;
    [SerializeField] private GameObject GameOverOrWin;
    [SerializeField] private GameObject winImage;
    [SerializeField] private GameObject loseImage;
    [SerializeField] private GameObject Wintext;
    [SerializeField] private GameObject Losetext;
    [SerializeField] private int daysAfterLose;
    private TextMeshProUGUI textLose;
    /*[SerializeField]
    private GameObject objectivesAndStatsIntermediaryGO;*/
    [SerializeField] private GameObject botonCreditos;
    [SerializeField] private GameObject botonMenu;

    [SerializeField] private EventReference winSound;
    [SerializeField] private EventReference loseSound;

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


    private List<Objective> tutorialObjectives;
    private List<Objective> objectives;
    private List<ObjectBase> objectsListt;
    private List<Stat> stats;
    private Objective objectiveInCourse;

    //private GameObject instantiatedObjective;
    // Start is called before the first frame update
    void Awake()
    {

        Instance = this;
        textLose = Losetext.GetComponent<TextMeshProUGUI>();
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
        objectivet8.nameOfObjective = "Consigue 2500 yenes";
        objectivet8.objectivesToNeedForComplete.Add(objectivet7);
        tutorialObjectives.Add(objectivet8);
        //Game Objectives
        /*Objective objectiveg1 = new Objective();
        objectiveg1.nameOfObjective = "Compra algun espacio mas";
        objectiveg1.objectivesToNeedForComplete.Add(objectivet8);
        objectives.Add(objectiveg1);*/
        Objective objectiveg2 = new Objective();
        objectiveg2.nameOfObjective = "Compra alguna maquina mas";
        objectiveg2.objectivesToNeedForComplete.Add(objectivet7);
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

    public static void updateStat(int idItemm, int cantidad)
    {
        for(int i = 0; i < Instance.stats.Count; i++)
        {
            if(Instance.stats[i].idItem == idItemm)
            {
                Instance.stats[i].numberOfUnitsSold += cantidad;
                Instance.stats[i].textNumberSold.text = Instance.stats[i].numberOfUnitsSold.ToString();
            }
        }
        bool statsMoreThan20units = true;
        for (int i = 0; i < Instance.stats.Count; i++)
        {
            if(Instance.stats[i].numberOfUnitsSold < 20)
            {
                statsMoreThan20units = false;
            }
        }
        if (statsMoreThan20units) ObjectivesAndStats.cumplirObjetivo20unidProducto();
    }

    

    // Update is called once per frame

    public static void cumplirObjetivoTutorialColocarMaquina()
    {
        if(!Instance.tutorialObjectives[0].objectiveCompleted)
        {
            Instance.tutorialObjectives[0].objectiveCompleted = true;
            Instance.tutorialObjectives[0].objectiveObj.transform.Find("checkObjective/Cheked").gameObject.SetActive(true);
        }
        else
        {
            ObjectivesAndStats.cumplirObjetivoCompraAlgunaMaquinaMas();
        }
    }

    public static void cumplirObjetivoCompraTuPrimerProducto()
    {
        if (!Instance.tutorialObjectives[1].objectiveCompleted)
        {
            Instance.tutorialObjectives[1].objectiveCompleted = true;
            Instance.tutorialObjectives[1].objectiveObj.transform.Find("checkObjective/Cheked").gameObject.SetActive(true);
        }
    }

    public static void cumplirObjetivoAbreElAlmacen()
    {
        if (!Instance.tutorialObjectives[2].objectiveCompleted)
        {
            Instance.tutorialObjectives[2].objectiveCompleted = true;
            Instance.tutorialObjectives[2].objectiveObj.transform.Find("checkObjective/Cheked").gameObject.SetActive(true);
        }
    }

    public static void cumplirAccedeAVistaDeMaquina()
    {
        if (!Instance.tutorialObjectives[3].objectiveCompleted)
        {
            Instance.tutorialObjectives[3].objectiveCompleted = true;
            Instance.tutorialObjectives[3].objectiveObj.transform.Find("checkObjective/Cheked").gameObject.SetActive(true);
        }
    }

    public static void cumplirObjetivoColocaPrimerObjetoEnMaquina()
    {
        if (!Instance.tutorialObjectives[4].objectiveCompleted)
        {
            Instance.tutorialObjectives[4].objectiveCompleted = true;
            Instance.tutorialObjectives[4].objectiveObj.transform.Find("checkObjective/Cheked").gameObject.SetActive(true);
            Instance.StartCoroutine(Instance.Esperar30sYcumplirObjetivo());
        }
    }

    public static void cumplirObjetivo30Segundos()
    {
        if (!Instance.tutorialObjectives[5].objectiveCompleted)
        {
            Instance.tutorialObjectives[5].objectiveCompleted = true;
            Instance.tutorialObjectives[5].objectiveObj.transform.Find("checkObjective/Cheked").gameObject.SetActive(true);
        }
    }

    public static void cumplirObjetivoRellenaMaquinaCuandoEsteVacia()
    {
        if (!Instance.tutorialObjectives[6].objectiveCompleted)
        {
            Instance.tutorialObjectives[6].objectiveCompleted = true;
            Instance.tutorialObjectives[6].objectiveObj.transform.Find("checkObjective/Cheked").gameObject.SetActive(true);
        }
    }

    public static void cumplirObjetivo2500Y()
    {
        if (!Instance.tutorialObjectives[7].objectiveCompleted)
        {
            Instance.tutorialObjectives[7].objectiveCompleted = true;
            Instance.tutorialObjectives[7].objectiveObj.transform.Find("checkObjective/Cheked").gameObject.SetActive(true);
        }
    }

    public static void cumplirObjetivoCompraAlgunaMaquinaMas()
    {
        if (!Instance.objectives[0].objectiveCompleted)
        {
            Instance.objectives[0].objectiveCompleted = true;
            Instance.objectives[0].objectiveObj.transform.Find("checkObjective/Cheked").gameObject.SetActive(true);
            Instance.CheckAllObjectivesCompleted();
        }
    }

    public static void cumplirObjetivo20unidProducto()
    {
        if (!Instance.objectives[1].objectiveCompleted)
        {
            Instance.objectives[1].objectiveCompleted = true;
            Instance.objectives[1].objectiveObj.transform.Find("checkObjective/Cheked").gameObject.SetActive(true);
            Instance.CheckAllObjectivesCompleted();
        }
    }

    public static void cumplirObjetivo15000Yenes()
    {
        if (!Instance.objectives[2].objectiveCompleted)
        {
            Instance.objectives[2].objectiveCompleted = true;
            Instance.objectives[2].objectiveObj.transform.Find("checkObjective/Cheked").gameObject.SetActive(true);
            Instance.CheckAllObjectivesCompleted();
            //SceneManager.LoadScene("Credits");
        }
    }

    public void CheckAllObjectivesCompleted()
    {
        bool allCompleted = true;
        for(int i = 0; i < Instance.objectives.Count; i++)
        {
            if (!Instance.objectives[i].objectiveCompleted)
                allCompleted = false;
        }
        if(allCompleted)
        {
            Time.timeScale = 1;
            botonMenu.SetActive(false);
            GameOverOrWin.SetActive(true);
            winImage.SetActive(true);
            loseImage.SetActive(false);
            Wintext.SetActive(true);
            Losetext.SetActive(false);
            AudioManager.instance.PlayOneShot(winSound, this.transform.position);
            //textLoseOrWin.text = "All objectives completed, Congratulations YOU WIN";
        }
    }

    public void CheckIfLose(int daysTanscurred)
    {
        Debug.Log("Ha entrado");
        if(daysTanscurred >= daysAfterLose)
        {
            Time.timeScale = 1;
            botonCreditos.SetActive(false);
            botonMenu.SetActive(true);
            GameOverOrWin.SetActive(true);
            winImage.SetActive(false);
            loseImage.SetActive(true);
            Wintext.SetActive(false);
            textLose.text = "You don't achived all objectives before the " + daysAfterLose + " days, YOU LOSE, but you can continue playing";
            AudioManager.instance.PlayOneShot(loseSound, this.transform.position);
        }
    }

    public static int NumberOfItemsSold()
    {
        int numberOfItemsSold = 0;
        for (int i = 0; i < Instance.stats.Count; i++)
        {
            numberOfItemsSold += Instance.stats[i].numberOfUnitsSold;
        }
        return numberOfItemsSold;
    }

    public void ResumeGame()
    {
        Instance.GameOverOrWin.SetActive(false);
    }

    IEnumerator Esperar30sYcumplirObjetivo()
    {
        yield return new WaitForSeconds(30f);
        ObjectivesAndStats.cumplirObjetivo30Segundos();
    }


    void Update()
    {
        
    }
}
