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
    //private int dineroInicioDia;
    //private int dineroFinDia;
    //[SerializeField] private GameObject FinDiaCanv;
    //[SerializeField] private GameObject textEarnedMoneyDay;
    //[SerializeField] private GameObject textMoneyThisDay;
    //[SerializeField] private GameObject winConditiontext;
    //[SerializeField] private GameObject winImage;
    //[SerializeField] private GameObject loseImage;
    //[SerializeField] private int moneyToWin;
    //private TextMeshProUGUI ernaedThisDay;
    //private TextMeshProUGUI moneyThisday;
    //private TextMeshProUGUI winCondition;

    void Start()
    {
        escalaDelTiempoInicial = escalaDeTiempo;
        tiempoAMostrarEnMinutos = tiempoInicial;
        //dineroInicioDia = MoneyManager.DineroTotal;
        //ernaedThisDay = textEarnedMoneyDay.GetComponent<TextMeshProUGUI>();
        //moneyThisday = textMoneyThisDay.GetComponent<TextMeshProUGUI>();
        //winCondition = winConditiontext.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        tiempoDelJuego += Time.deltaTime * escalaDeTiempo;
        if (tiempoDelJuego > tiempoDeUnDiaSegundos)
        {
            tiempoDelJuego = 0f;
            //dineroFinDia = MoneyManager.DineroTotal;
            //FinDiaCanv.SetActive(true);
            //moneyThisday.text = "You have this day: " + (dineroFinDia);
            //ernaedThisDay.text = "You earned this day: " + (dineroFinDia - dineroInicioDia);
            //if (dineroFinDia - dineroInicioDia >= moneyToWin)
            //{
            //    winImage.SetActive(true);
            //    loseImage.SetActive(false);
            //    winCondition.text = "You earned more than " + moneyToWin + ", YOU WIN";
            //}
            //else
            //{
            //    winImage.SetActive(false);
            //    loseImage.SetActive(true);
            //    winCondition.text = "You earned less than " + moneyToWin + ", YOU LOSE";
            //}
            Pausa();
        }
    }

    public void Pausa()
    {
        if (!estaPausado)
        {
            estaPausado = true;
            escalaDeTiempoAlPausar = escalaDeTiempo;
            escalaDeTiempo = 0;
            Time.timeScale = escalaDeTiempo;
        }
    }

    public void Play()
    {
        estaPausado = false;
        escalaDeTiempo = 1;
        Time.timeScale = escalaDeTiempo;
    }


    public void Acelerar()
    {
        if (escalaDeTiempo == 1 || escalaDeTiempo == 0)
        {
            estaPausado = false;
            escalaDeTiempo = 2;
        }
        else if (escalaDeTiempo == 2)
        {
            estaPausado = false;
            escalaDeTiempo = 4;
        }
        else
        {
            estaPausado = false;
            escalaDeTiempo = 2;
        }
        Time.timeScale = escalaDeTiempo;
    }

    public float GetTime()
    {
        return tiempoDelJuego;
    }

    public void resumeGame()
    {
        //FinDiaCanv.SetActive(false);
        Play();
    }

    public void GoTomenu()
    {

    }
}
