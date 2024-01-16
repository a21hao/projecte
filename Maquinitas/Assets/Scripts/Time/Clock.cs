using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    // Start is called before the first frame update
    void Start()
    {
        escalaDelTiempoInicial = escalaDeTiempo;//Establecer la escala del tiempo original
        tiempoAMostrarEnMinutos = tiempoInicial;//Inicializar la variable que acumula los tiempos de cada frame con el tiempo inicial
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
}
