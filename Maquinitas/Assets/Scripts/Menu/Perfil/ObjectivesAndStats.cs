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
    private Transform ObjectivesTitleTutorial;
    private int indexOfObjectiveTitleTutorial;
    [SerializeField]
    private Transform ObjectivesCat1Title;
    private int indexOfObjectivesCat1Title;
    [SerializeField]
    private Transform ObjectivesCat2Title;
    private int indexOfObjectivesCat2Title;
    [SerializeField]
    private Tienda tienda;
    [SerializeField]
    private Upgrades upgrades;
    [SerializeField]
    private Wishlist wishlist;
    [SerializeField]
    private int NumberOfMachinesForObjective;

    [SerializeField]
    private TextMeshProUGUI categoriaActualText;

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
        public int catObjective = 0;
        

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
    public int categoriaActual = 1;
    public int categoriaMaxima = 3;
    private bool objectivesCat1Completed = false;
    private bool objectivesCat2Completed = false;
    private ObjectsList objects;
    private bool hadWin = false;

    //private GameObject instantiatedObjective;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        objects = FindObjectOfType<ObjectsList>();
        categoriaActualText.text = "CATEGORIA ACTUAL: CATEGORIA " + categoriaActual.ToString();
        textLose = Losetext.GetComponent<TextMeshProUGUI>();
        indexOfObjectiveTitleTutorial = ObjectivesTitleTutorial.GetSiblingIndex();
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
        objectiveg2.catObjective = 1;
        objectiveg2.objectivesToNeedForComplete.Add(objectivet7);
        objectives.Add(objectiveg2);
        Objective objectiveg3 = new Objective();
        objectiveg3.nameOfObjective = "Vende al menos 20 unidades de cada producto de la categoria 1";
        objectiveg3.catObjective = 1;
        objectiveg3.objectivesToNeedForComplete.Add(objectiveg2);
        objectives.Add(objectiveg3);
        Objective objectiveg4 = new Objective();
        objectiveg4.nameOfObjective = "Consigue 10000 yenes";
        objectiveg4.catObjective = 1;
        objectiveg4.objectivesToNeedForComplete.Add(objectiveg2);
        objectives.Add(objectiveg4);
        Objective objectiveg5 = new Objective();
        objectiveg5.nameOfObjective = "Vende al menos 20 unidades de cada producto de la categoria 2";
        objectiveg5.catObjective = 2;
        //objectiveg5.objectivesToNeedForComplete.Add(objectiveg2);
        objectives.Add(objectiveg5);
        Objective objectiveg6 = new Objective();
        objectiveg6.nameOfObjective = "Consigue 100000 yenes";
        objectiveg6.catObjective = 2;
        //objectiveg4.objectivesToNeedForComplete.Add(objectiveg2);
        objectives.Add(objectiveg6);
        Objective objectiveg7 = new Objective();
        objectiveg7.nameOfObjective = "Pon " + NumberOfMachinesForObjective + " maquinas";
        objectiveg7.catObjective = 2;
        //objectiveg7.objectivesToNeedForComplete.Add(objectiveg2);
        objectives.Add(objectiveg7);
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

    private void IncrementarCategoriaActual()
    {
        categoriaActual += 1;
    }
    private void InstantiateObjectivesInPerfil()
    {
        for(int i = 0; i < tutorialObjectives.Count; i++)
        {
            GameObject instantiatedObjective = Instantiate(objectivePrefab, contentParent);
            TextMeshProUGUI textObjective= instantiatedObjective.transform.Find("ObjectiveText").GetComponent<TextMeshProUGUI>();
            //-->GameObject checked = instantiatedObjective.transform.Find("ObjectiveText").GetComponent<TextMeshProUGUI>();
            textObjective.text = tutorialObjectives[i].nameOfObjective;
            indexOfObjectiveTitleTutorial += 1;
            instantiatedObjective.transform.SetSiblingIndex(indexOfObjectiveTitleTutorial);
            tutorialObjectives[i].objectiveObj = instantiatedObjective;
            //if (tutorialObjectives[i].objectiveCompleted) tutorialObjectives[i]

        }
        indexOfObjectivesCat1Title = ObjectivesCat1Title.GetSiblingIndex();
        for (int i = 0; i < objectives.Count; i++)
        {
            if(objectives[i].catObjective == 1)
            {
                GameObject instantiatedObjective = Instantiate(objectivePrefab, contentParent);
                TextMeshProUGUI textObjective = instantiatedObjective.transform.Find("ObjectiveText").GetComponent<TextMeshProUGUI>();
                //-->GameObject checked = instantiatedObjective.transform.Find("ObjectiveText").GetComponent<TextMeshProUGUI>();
                textObjective.text = objectives[i].nameOfObjective;               
                indexOfObjectivesCat1Title += 1;
                instantiatedObjective.transform.SetSiblingIndex(indexOfObjectivesCat1Title);
                objectives[i].objectiveObj = instantiatedObjective;
            }
            //if (tutorialObjectives[i].objectiveCompleted) tutorialObjectives[i]

        }
        indexOfObjectivesCat2Title = ObjectivesCat2Title.GetSiblingIndex();
        for (int i = 0; i < objectives.Count; i++)
        {
            if (objectives[i].catObjective == 2)
            {
                GameObject instantiatedObjective = Instantiate(objectivePrefab, contentParent);
                TextMeshProUGUI textObjective = instantiatedObjective.transform.Find("ObjectiveText").GetComponent<TextMeshProUGUI>();
                //-->GameObject checked = instantiatedObjective.transform.Find("ObjectiveText").GetComponent<TextMeshProUGUI>();
                textObjective.text = objectives[i].nameOfObjective;
                indexOfObjectivesCat2Title += 1;
                instantiatedObjective.transform.SetSiblingIndex(indexOfObjectivesCat2Title);
                objectives[i].objectiveObj = instantiatedObjective;
            }
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
            TextMeshProUGUI catInfo = instantiatedStat.transform.Find("StatsInfo/CatInfo").GetComponent<TextMeshProUGUI>();
            catInfo.text = "cat " + (objects.getObjectbyId(stats[i].idItem).categoria).ToString();
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
        for(int i = 0; i < Instance.stats.Count; i++)
        {
            if(Instance.stats[i].idItem == idItemm)
            {
                Instance.stats[i].numberOfUnitsSold += cantidad;
                Instance.stats[i].textNumberSold.text = Instance.stats[i].numberOfUnitsSold.ToString();
            }
        }
        bool statsMoreThan20unitsCat1 = true;
        for (int i = 0; i < Instance.stats.Count; i++)
        {
            if(Instance.stats[i].numberOfUnitsSold < 20 && objects.getObjectbyId(stats[i].idItem).categoria == 1)
            {
                statsMoreThan20unitsCat1 = false;
            }
        }
        if (statsMoreThan20unitsCat1) ObjectivesAndStats.Instance.cumplirObjetivo20unidProductoCat1();
        bool statsMoreThan20unitsCat2 = true;
        for (int i = 0; i < Instance.stats.Count; i++)
        {
            if (Instance.stats[i].numberOfUnitsSold < 20 && objects.getObjectbyId(stats[i].idItem).categoria == 2)
            {
                statsMoreThan20unitsCat2 = false;
            }
        }
        if (statsMoreThan20unitsCat2) ObjectivesAndStats.Instance.cumplirObjetivoVende20ProductosDeCategoria2();
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
            ObjectivesAndStats.Instance.cumplirObjetivoCompraAlgunaMaquinaMas();
        }
    }

    public void cumplirObjetivoCompraTuPrimerProducto()
    {
        if (!Instance.tutorialObjectives[1].objectiveCompleted)
        {
            Instance.tutorialObjectives[1].objectiveCompleted = true;
            Instance.tutorialObjectives[1].objectiveObj.transform.Find("checkObjective/Cheked").gameObject.SetActive(true);
        }
    }

    public void cumplirObjetivoAbreElAlmacen()
    {
        if (!Instance.tutorialObjectives[2].objectiveCompleted)
        {
            Instance.tutorialObjectives[2].objectiveCompleted = true;
            Instance.tutorialObjectives[2].objectiveObj.transform.Find("checkObjective/Cheked").gameObject.SetActive(true);
        }
    }

    public void cumplirAccedeAVistaDeMaquina()
    {
        if (!Instance.tutorialObjectives[3].objectiveCompleted)
        {
            Instance.tutorialObjectives[3].objectiveCompleted = true;
            Instance.tutorialObjectives[3].objectiveObj.transform.Find("checkObjective/Cheked").gameObject.SetActive(true);
        }
    }

    public void cumplirObjetivoColocaPrimerObjetoEnMaquina()
    {
        if (!Instance.tutorialObjectives[4].objectiveCompleted)
        {
            Instance.tutorialObjectives[4].objectiveCompleted = true;
            Instance.tutorialObjectives[4].objectiveObj.transform.Find("checkObjective/Cheked").gameObject.SetActive(true);
            Instance.StartCoroutine(Instance.Esperar30sYcumplirObjetivo());
        }
    }

    public void cumplirObjetivo30Segundos()
    {
        if (!Instance.tutorialObjectives[5].objectiveCompleted)
        {
            Instance.tutorialObjectives[5].objectiveCompleted = true;
            Instance.tutorialObjectives[5].objectiveObj.transform.Find("checkObjective/Cheked").gameObject.SetActive(true);
        }
    }

    public void cumplirObjetivoRellenaMaquinaCuandoEsteVacia()
    {
        if (!Instance.tutorialObjectives[6].objectiveCompleted)
        {
            Instance.tutorialObjectives[6].objectiveCompleted = true;
            Instance.tutorialObjectives[6].objectiveObj.transform.Find("checkObjective/Cheked").gameObject.SetActive(true);
        }
    }

    public void cumplirObjetivo2500Y()
    {
        if (!Instance.tutorialObjectives[7].objectiveCompleted)
        {
            Instance.tutorialObjectives[7].objectiveCompleted = true;
            Instance.tutorialObjectives[7].objectiveObj.transform.Find("checkObjective/Cheked").gameObject.SetActive(true);
        }
    }

    public void cumplirObjetivoCompraAlgunaMaquinaMas()
    {
        if (!Instance.objectives[0].objectiveCompleted)
        {
            Instance.objectives[0].objectiveCompleted = true;
            Instance.objectives[0].objectiveObj.transform.Find("checkObjective/Cheked").gameObject.SetActive(true);
            Instance.CheckAllObjectivesCompleted();
        }
    }

    public void cumplirObjetivo20unidProductoCat1()
    {
        if (!Instance.objectives[1].objectiveCompleted)
        {
            Instance.objectives[1].objectiveCompleted = true;
            Instance.objectives[1].objectiveObj.transform.Find("checkObjective/Cheked").gameObject.SetActive(true);
            Instance.CheckAllObjectivesCompleted();
        }
    }

    public void cumplirObjetivo10000Yenes()
    {
        if (!Instance.objectives[2].objectiveCompleted)
        {
            Instance.objectives[2].objectiveCompleted = true;
            Instance.objectives[2].objectiveObj.transform.Find("checkObjective/Cheked").gameObject.SetActive(true);
            Instance.CheckAllObjectivesCompleted();
            //SceneManager.LoadScene("Credits");
        }
    }

    public void cumplirObjetivoVende20ProductosDeCategoria2()
    {
        if (!Instance.objectives[3].objectiveCompleted)
        {
            Instance.objectives[3].objectiveCompleted = true;
            Instance.objectives[3].objectiveObj.transform.Find("checkObjective/Cheked").gameObject.SetActive(true);
            Instance.CheckAllObjectivesCompleted();
            //SceneManager.LoadScene("Credits");
        }
    }

    public void cumplirObjetivo100000Yenes()
    {
        if (!Instance.objectives[4].objectiveCompleted)
        {
            Instance.objectives[4].objectiveCompleted = true;
            Instance.objectives[4].objectiveObj.transform.Find("checkObjective/Cheked").gameObject.SetActive(true);
            Instance.CheckAllObjectivesCompleted();
            //SceneManager.LoadScene("Credits");
        }
    }

    public void cumplirObjetivoPonLasMaquinasNecesarias(int busys)
    { 
        if (!Instance.objectives[5].objectiveCompleted && busys >= NumberOfMachinesForObjective)
        {
            Instance.objectives[5].objectiveCompleted = true;
            Instance.objectives[5].objectiveObj.transform.Find("checkObjective/Cheked").gameObject.SetActive(true);
            Instance.CheckAllObjectivesCompleted();
            //SceneManager.LoadScene("Credits");
        }
    }

    public void CheckAllObjectivesCompleted()
    {
        CheckAllObjectivesCompletedCAT1();
        CheckAllObjectivesCompletedCAT2();
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
            hadWin = true;
            //textLoseOrWin.text = "All objectives completed, Congratulations YOU WIN";
        }
    }

    public void CheckAllObjectivesCompletedCAT1()
    {
        bool allCompleted = true;
        for (int i = 0; i < objectives.Count; i++)
        {
            if (!objectives[i].objectiveCompleted && objectives[i].catObjective == 1)
                allCompleted = false;
        }
        if (allCompleted && !objectivesCat1Completed)
        {
            objectivesCat1Completed = true;
            if (categoriaActual < 2) categoriaActual = 2;
            //wishlist.SetCategoria(categoriaActual);
            categoriaActualText.text = "CATEGORIA ACTUAL: CATEGORIA " + categoriaActual.ToString();
            tienda.InstanciarObjetosTiendaDeCategoria(2);
            upgrades.InstanciarObjetosUpgradesDeCategoria(2);
        }
    }

    public void CheckAllObjectivesCompletedCAT2()
    {
        bool allCompleted = true;
        for (int i = 0; i < objectives.Count; i++)
        {
            if (!objectives[i].objectiveCompleted && objectives[i].catObjective == 2)
                allCompleted = false;
        }
        if (allCompleted && !objectivesCat2Completed)
        {
            objectivesCat2Completed = true;
            if (categoriaActual < 3) categoriaActual = 3;
            categoriaActualText.text = "CATEGORIA ACTUAL: CATEGORIA " + categoriaActual.ToString();
            //wishlist.SetCategoria(categoriaActual);
            tienda.InstanciarObjetosTiendaDeCategoria(3);
            upgrades.InstanciarObjetosUpgradesDeCategoria(3);
        }
    }

    public void CheckIfLose(int daysTanscurred)
    {
        Debug.Log("Ha entrado");
        if(daysTanscurred >= daysAfterLose && !hadWin)
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
        ObjectivesAndStats.Instance.cumplirObjetivo30Segundos();
    }

}
