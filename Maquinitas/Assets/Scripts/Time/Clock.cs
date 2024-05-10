using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Clock : MonoBehaviour
{
    public float tiempoInicial;
    public Calendar calendar;
    [Range(-30.0f, 30.0f)]
    private float escalaDeTiempo = 1;

    static public float tiempoDeUnDiaSegundos = 1440f;
    static public float tiempoDelJuego = 0f;
    
    private float tiempoAMostrarEnMinutos = 0f;
    private float escalaDeTiempoAlPausar, escalaDelTiempoInicial;
    private bool estaPausado = false;
    private FinalDayManager fnd;

    void Start()
    {
        escalaDelTiempoInicial = escalaDeTiempo;
        tiempoAMostrarEnMinutos = tiempoInicial;
        fnd = GameObject.Find("GameManager/FinalDayManager").gameObject.GetComponent<FinalDayManager>();
    }

    void Update()
    {
        tiempoDelJuego += Time.deltaTime * escalaDeTiempo;
        if (tiempoDelJuego > tiempoDeUnDiaSegundos)
        {
            tiempoDelJuego = 0f;
            calendar.AdvanceDay();
            fnd.FinishDay();
            Pausa();
        }
    }

    public void Pausa()
    {
        //if (!estaPausado)
        //{
            estaPausado = true;
            //escalaDeTiempoAlPausar = escalaDeTiempo;
            escalaDeTiempo = 0;
            Time.timeScale = escalaDeTiempo;
        //}
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
            escalaDeTiempo = 10;
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
        fnd.DisactiveFinalDay();
        Play();
    }
}
