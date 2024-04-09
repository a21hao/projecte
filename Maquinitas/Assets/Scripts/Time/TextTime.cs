using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextTime : MonoBehaviour
{

    private Text timeText;


    void Start()
    {
        timeText = GetComponent<Text>();//Get the text component

    }
    void Update()
    {
        ActualizarReloj(Clock.tiempoDelJuego);
    }

    private void ActualizarReloj(float tiempoEnMinutos)
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
}