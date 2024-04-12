using UnityEngine;
using System.Collections.Generic;

public class Calendario : MonoBehaviour
{
    public string[] meses = { "Primavera", "Verano", "Otoño", "Invierno" };
    public List<string>[,] actividades = new List<string>[4, 28];
    public int mesActual = 0; // Índice del mes actual

    // Método para avanzar al siguiente mes
    public void SiguienteMes()
    {
        mesActual = (mesActual + 1) % 4;
        MostrarCalendario();
    }

    // Método para retroceder al mes anterior
    public void MesAnterior()
    {
        mesActual = (mesActual - 1 + 4) % 4;
        MostrarCalendario();
    }

    // Método para mostrar el calendario actual
    public void MostrarCalendario()
    {
        // Aquí puedes implementar la lógica para mostrar el calendario en la interfaz de usuario
        // Puedes acceder a las actividades utilizando la matriz 'actividades'
    }

    // Método para agregar una actividad a un día específico
    public void AgregarActividad(int dia, string actividad)
    {
        if (actividades[mesActual, dia] == null)
        {
            actividades[mesActual, dia] = new List<string>();
        }
        actividades[mesActual, dia].Add(actividad);
    }
}
