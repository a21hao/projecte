using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    public float tiempoInicial;

    [Range(-30.0f, 30.0f)]
    public float escalaDeTiempo = 1;

    private Text timeText;
    private float tiempoDelFrameConTimeScale = 0f;
    private float tiempoAMostrarEnMinutos = 0f;
    private float escalaDeTiempoAlPausar, escalaDelTiempoInicial;
    private bool estaPausado = false;

    // Start is called before the first frame update
    void Start()
    {
        escalaDelTiempoInicial = escalaDeTiempo;//Establecer la escala del tiempo original
        timeText = GetComponent<Text>();//Get the text component
        tiempoAMostrarEnMinutos = tiempoInicial;//Inicializar la variable que acumula los tiempos de cada frame con el tiempo inicial
        ActualizarReloj(tiempoInicial);
    }

    // Update is called once per frame
    void Update()
    {
        //La siguiente variable representa el tiempo de cada considerado la escala de tiempo
        tiempoDelFrameConTimeScale = Time.deltaTime * escalaDeTiempo;
        //La siguiente variable va acumulando el tiempo transcurrido para el juego mostratlo en el reloj
        tiempoAMostrarEnMinutos += tiempoDelFrameConTimeScale;
        ActualizarReloj(tiempoAMostrarEnMinutos);
    }
    public void ActualizarReloj(float tiempoEnMinutos)
    {
        int hora = 0;
        int min = 0;
        string textoDelReloj;

        //Assegurar que el tiempo no sea negativo
        if (tiempoEnMinutos < 0) tiempoEnMinutos = 0;

        //Calcular minutos y horas
        hora = (int)tiempoEnMinutos / 60;
        min = (int)tiempoEnMinutos % 60;

        //Crear la cadena de caracteres con 2 digitos para los minutos, separados por ":"
        textoDelReloj = hora.ToString("00") + ":" + min.ToString("00");

        //Actualizar el elemento de text de UI con la cadena de caracteres
        timeText.text = textoDelReloj;
    }

    public void Pausa()
    {
        if (!estaPausado)
        {
            estaPausado = true;
            escalaDeTiempoAlPausar = escalaDeTiempo;
            escalaDeTiempo = 0;
        }
    }

    public void Play()
    {
        if (estaPausado)
        {
            estaPausado = false;
            escalaDeTiempo = escalaDeTiempoAlPausar;
        }
    }

    public void Velocidadpor2()
    {
        if (estaPausado)
        {
            estaPausado = false;
            escalaDeTiempo = escalaDeTiempoAlPausar * 2;
        }
        else
        {
            estaPausado = false;
            escalaDeTiempo = escalaDeTiempoAlPausar * 2;
        }
    }
}
