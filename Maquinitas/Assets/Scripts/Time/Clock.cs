using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Clock : MonoBehaviour
{
    public float tiempoInicial;
    

    [Range(-30.0f, 30.0f)]
    private float escalaDeTiempo = 1;

    static public float tiempoDeUnDiaSegundos = 1440f;
    static public float tiempoDelJuego = 0f;
    private float tiempoAMostrarEnMinutos = 0f;
    private float escalaDeTiempoAlPausar, escalaDelTiempoInicial;
    private bool estaPausado = false;
    private int dineroInicioDia;
    private int dineroFinDia;
    [SerializeField]
    private GameObject FinDiaCanv;
    [SerializeField]
    private GameObject textEarnedMoneyDay;
    [SerializeField]
    private GameObject textMoneyThisDay;
    [SerializeField]
    private GameObject winConditiontext;
    [SerializeField]
    private GameObject winImage;
    [SerializeField]
    private GameObject loseImage;
    private TextMeshProUGUI ernaedThisDay;
    private TextMeshProUGUI moneyThisday;
    private TextMeshProUGUI winCondition;
    [SerializeField]
    private int moneyToWin;


    // Start is called before the first frame update
    void Start()
    {
        escalaDelTiempoInicial = escalaDeTiempo;//Establecer la escala del tiempo original
        tiempoAMostrarEnMinutos = tiempoInicial;//Inicializar la variable que acumula los tiempos de cada frame con el tiempo inicial
        dineroInicioDia = MoneyManager.DineroTotal;
        Debug.Log(dineroInicioDia);
        ernaedThisDay = textEarnedMoneyDay.GetComponent<TextMeshProUGUI>();
        moneyThisday = textMoneyThisDay.GetComponent<TextMeshProUGUI>();
        winCondition = winConditiontext.GetComponent<TextMeshProUGUI>();
        Debug.Log(ernaedThisDay);
        Debug.Log(moneyThisday.text);
        Debug.Log(winCondition.text);


        //ActualizarReloj(tiempoInicial);
    }

    // Update is called once per frame
    void Update()
    {
        //La siguiente variable representa el tiempo de cada considerado la escala de tiempo
        tiempoDelJuego += Time.deltaTime * escalaDeTiempo;
        if (tiempoDelJuego > tiempoDeUnDiaSegundos)
        {
            tiempoDelJuego = 0f;
            dineroFinDia = MoneyManager.DineroTotal;
            Debug.Log(dineroFinDia);
            FinDiaCanv.SetActive(true);
            moneyThisday.text = "You have this day: " + (dineroFinDia);
            ernaedThisDay.text = "You earned this day: " + (dineroFinDia - dineroInicioDia);
            if(dineroFinDia - dineroInicioDia >= moneyToWin)
            {
                winImage.SetActive(true);
                loseImage.SetActive(false);
                winCondition.text = "You earned more than " + moneyToWin + ", YOU WIN";
            }
            else
            {
                winImage.SetActive(false);
                loseImage.SetActive(true);
                winCondition.text = "You earned less than " + moneyToWin + ", YOU LOSE";
            }
            Pausa();
        }
        //La siguiente variable va acumulando el tiempo transcurrido para el juego mostratlo en el reloj
        //ActualizarReloj(tiempoDelFrameConTimeScale);
    }


    public void Pausa() //Pausa el Tiempo
    {
        if (!estaPausado)
        {
            estaPausado = true;
            escalaDeTiempoAlPausar = escalaDeTiempo;
            escalaDeTiempo = 0;
        }
    }

    public void Play()//Reprende el tiempo
    {
            estaPausado = false;
            escalaDeTiempo = 1;
    }

    public void Acelerar()//Acelera el tiempo por 2 y por 4, la tercera vez que le das vuelve el tiempo a 2
    {
        if (escalaDeTiempo == 1 || escalaDeTiempo == 0)
        {
            estaPausado = false;
            escalaDeTiempo = 2;
        }
        else if (escalaDeTiempo == 2)
        {
            estaPausado = false;
            escalaDeTiempo = 100;
        }
        else 
        {
            estaPausado = false;
            escalaDeTiempo = 2;
        }
    }
    public float GetTime()
    {
        return tiempoDelJuego;
    }

    public void resumeGame()
    {
        FinDiaCanv.SetActive(false);
        Play();
    }

    public void GoTomenu()
    {

    }
}
