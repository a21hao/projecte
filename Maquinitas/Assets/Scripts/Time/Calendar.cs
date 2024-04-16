using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Calendar : MonoBehaviour
{
    public class Day
    {
        public int dayNum;
        public Color dayColor;
        public GameObject obj;
        public EventData eventData; // Nuevo campo para almacenar el evento del día

        private Image image;

        public Day(int dayNum, Color dayColor, GameObject obj)
        {
            this.dayNum = dayNum;
            this.obj = obj;
            this.image = obj.GetComponent<Image>();
            UpdateColor(dayColor);
            UpdateDay(dayNum);
        }

        public void UpdateColor(Color newColor)
        {
            image.color = newColor;
            dayColor = newColor;
        }

        public void UpdateDay(int newDayNum)
        {
            this.dayNum = newDayNum;
            if (dayColor == Color.white || dayColor == Color.green)
            {
                obj.GetComponentInChildren<TextMeshProUGUI>().text = (dayNum + 1).ToString();
            }
            else
            {
                obj.GetComponentInChildren<TextMeshProUGUI>().text = "";
            }
        }

        // Método para establecer el evento del día
        public void SetEvent(EventData eventData)
        {
            this.eventData = eventData;
            // Actualizar la apariencia del día según el estado del evento
            if (eventData != null && eventData.eventState)
            {
                UpdateColor(Color.blue); // Color que indica un día con evento activo
            }
        }
    }


    private List<Day> days = new List<Day>();

    public Transform[] weeks;
    public TextMeshProUGUI MonthAndYear;

    private int currentYear = 1;
    private int currentSeasonIndex = 0;
    private int currentDayIndex = -1;
    Color brown = new Color(0.6f, 0.4f, 0.2f);

    [SerializeField] private GameObject botonNext;
    [SerializeField] private GameObject botonPrevius;

    private void Start()
    {
        UpdateCalendar(currentYear, currentSeasonIndex);
        currentYear = 1;
        currentSeasonIndex = 0;
        UpdateCalendar(currentYear, currentSeasonIndex);
    }

    void UpdateCalendar(int year, int seasonIndex)
    {
        // Verificar si el año está dentro del rango permitido
        if (year < 1 || year > 99)
        {
            Debug.LogWarning("El año está fuera del rango permitido.");
            return;
        }

        MonthAndYear.text = year.ToString() + " " + GetSeasonName(seasonIndex);

        int totalDays = 28;
        days = new List<Day>(totalDays);

        // Aquí cargarías los eventos del año actual desde el Scriptable Object
        EventData[] events = LoadEventsForYear(year);

        int startDay = 0;
        int endDay = 27;

        // Verificar si estamos en el primer año y la última estación es invierno
        if (year == 1 && seasonIndex == 3)
        {
            endDay = 0; // El último día es el 28 de invierno del año 1
        }
        // Verificar si estamos en el último año y la última estación es invierno
        else if (year == 99 && seasonIndex == 3)
        {
            endDay = 27; // El último día es el 28 de invierno del año 99
        }

        for (int w = 0; w < 6; w++)
        {
            for (int i = 0; i < 7; i++)
            {
                int currDay = (w * 7) + i;
                if (currDay < startDay || currDay - startDay > endDay)
                {
                    continue;
                }

                // Crear el nuevo día
                GameObject dayObject = weeks[w].GetChild(i).gameObject;
                Day newDay = new Day(currDay - startDay, Color.white, dayObject);
                days.Add(newDay);

                // Verificar si hay un evento para este día y establecerlo si lo hay
                if (events != null && events.Length > currDay)
                {
                    newDay.SetEvent(events[currDay]);
                }

                // Verificar si este día es el día actual (1 de primavera del año 1)
                if (currentYear == 1 && currentSeasonIndex == 0 && currDay == 0)
                {
                    // Cambiar el color del día actual
                    newDay.UpdateColor(new Color(0.6f, 0.4f, 0.2f));
                }
            }
        }
    }

    // Método para cargar eventos para un año específico
    EventData[] LoadEventsForYear(int year)
    {
        // Aquí cargarías los eventos para el año específico desde tu Scriptable Object
        // Retorna un array de EventData

        // Suponiendo que ya tienes implementada la lógica para cargar los eventos
        // Simplemente coloca un return al final del método
        return null; // o un array de EventData
    }




    string GetSeasonName(int seasonIndex)
    {
        string[] seasons = { "Primavera", "Verano", "Otoño", "Invierno" };
        return seasons[seasonIndex];
    }

    public void NextSeason()
    {
        currentSeasonIndex++;
        if (currentSeasonIndex >= 4)
        {
            currentSeasonIndex = 0;
            currentYear++;
        }
        UpdateCalendar(currentYear, currentSeasonIndex);

        // Desactivar el botón de mes siguiente si llegamos al último año
        if (currentYear >= 99 && currentSeasonIndex == 3)
        {
            botonNext.SetActive(false);
        }
        else
        {
            botonNext.SetActive(true);
        }
    }

    public void PreviousSeason()
    {
        currentSeasonIndex--;
        if (currentSeasonIndex < 0)
        {
            currentSeasonIndex = 3;
            currentYear--;
        }
        UpdateCalendar(currentYear, currentSeasonIndex);

        // Desactivar el botón de mes anterior si llegamos al primer año
        if (currentYear <= 1 && currentSeasonIndex == 0)
        {
            botonPrevius.SetActive(false);
        }
        else
        {
            botonPrevius.SetActive(true);
        }
    }

    public void SetCurrentDay(int dayIndex)
    {
        if (currentDayIndex != -1)
        {
            days[currentDayIndex].UpdateColor(Color.white);
        }

        currentDayIndex = dayIndex;

        if (currentDayIndex != -1)
        {
            days[currentDayIndex].UpdateColor(new Color(0.6f, 0.4f, 0.2f));
        }
    }
}