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
        public List<string> events; // Lista de eventos
        public Sprite image; // Imagen del día
        public string eventName; // Nombre del evento

        private Image dayImage;
        private TextMeshProUGUI dayText;

        public Day(int dayNum, Color dayColor, GameObject obj)
        {
            this.dayNum = dayNum;
            this.obj = obj;
            this.dayImage = obj.GetComponent<Image>();
            this.dayText = obj.GetComponentInChildren<TextMeshProUGUI>();
            this.events = new List<string>(); // Inicializa la lista de eventos
            UpdateColor(dayColor);
            UpdateDay(dayNum);
        }

        public void UpdateColor(Color newColor)
        {
            dayImage.color = newColor;
            dayColor = newColor;
        }

        public void UpdateDay(int newDayNum)
        {
            this.dayNum = newDayNum;
            if (dayColor == Color.white || dayColor == Color.green)
            {
                dayText.text = (dayNum + 1).ToString();
            }
            else
            {
                dayText.text = "";
            }
        }

        public void SetImage(Sprite sprite)
        {
            image = sprite;
            dayImage.sprite = sprite;
        }

        public void SetEventName(string name)
        {
            eventName = name;
        }
    }

    private List<Day> days = new List<Day>();

    public Transform[] weeks;
    public TextMeshProUGUI MonthAndYear;
    public TextMeshProUGUI currentDateText;
    public TextMeshProUGUI eventNameText;
    public Sprite sprite1;
    public Sprite sprite2;

    private int currentYear = 1;
    private int currentSeasonIndex = 0;
    private int currentDayIndex = 0;
    //Color brown = new Color(0.6f, 0.4f, 0.2f);

    [SerializeField] private GameObject botonNext;
    [SerializeField] private GameObject botonPrevius;
    [SerializeField] private GameObject close;

    private void Start()
    {
        currentYear = 1;
        currentSeasonIndex = 0;
        UpdateCalendar(currentYear, currentSeasonIndex);
        UpdateCurrentDateText();
        UpdateCurrentDayColor();
    }

    void UpdateCurrentDateText()
    {
        string currentDate = "Día " + (currentDayIndex + 1) + ", " + currentYear.ToString() + " " + GetSeasonName(currentSeasonIndex);
        currentDateText.text = currentDate;
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

        // Dentro de la función UpdateCalendar
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
            }
        }

        if (days.Count >= 5 && currentSeasonIndex == 0)
        {
            Sprite daySprite = sprite1;
            days[4].SetImage(daySprite);
        }
        if (days.Count >= 10 && currentSeasonIndex == 0)
        {
            Sprite daySprite2 = sprite2;
            days[9].SetImage(daySprite2);
        }
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
        if (currentYear <= 1 && currentSeasonIndex == 0)
        {
            botonPrevius.SetActive(false);
        }
        else
        {
            botonPrevius.SetActive(true);
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
        if (currentYear >= 99 && currentSeasonIndex == 3)
        {
            botonNext.SetActive(false);
        }
        else
        {
            botonNext.SetActive(true);
        }

        //SetAllDaysImage(Sprite image);
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
            days[currentDayIndex].UpdateColor(new Color(0f, 1f, 0f));
        }
        // Verificar si hay un día actual seleccionado
        if (currentDayIndex != -1)
        {
            // Actualizar el color del día actual
            days[currentDayIndex].UpdateColor(new Color(0f, 1f, 0f));
        }
    }

    public void AdvanceDay()
    {
        // Avanzar al siguiente día en el calendario
        if (currentDayIndex != -1)
        {
            days[currentDayIndex].UpdateColor(Color.white);
        }

        currentDayIndex++;
        if (currentDayIndex >= days.Count)
        {
            // Pasar al siguiente mes si se alcanza el día 28
            currentSeasonIndex++;
            if (currentSeasonIndex >= 4)
            {
                currentSeasonIndex = 0;
                currentYear++;
            }

            UpdateCalendar(currentYear, currentSeasonIndex);

            // Restablecer el índice del día
            currentDayIndex = 0;
        }

        days[currentDayIndex].UpdateColor(new Color(0f, 1f, 0f));

        UpdateCurrentDateText(); // Actualizar el texto de la fecha actual
    }

    void UpdateCurrentDayColor()
    {
        // Verificar si hay un día actual seleccionado
        if (currentDayIndex != -1)
        {
            // Actualizar el color del día actual
            days[currentDayIndex].UpdateColor(new Color(0f, 1f, 0f));
        }
    }

    public void CloseCalendar()
    {
        close.SetActive(false);
    }

    public void SetAllDaysImage(Sprite image)
    {
        foreach (Day day in days)
        {
            day.SetImage(image);
        }
    }

    // Método para mostrar el nombre del evento cuando el ratón está encima del día
    public void ShowEventName(int dayIndex)
    {
        if (dayIndex >= 0 && dayIndex < days.Count)
        {
            if (!string.IsNullOrEmpty(days[dayIndex].eventName))
            {
                eventNameText.text = days[dayIndex].eventName;
            }
            else
            {
                eventNameText.text = "";
            }
        }
    }
}
