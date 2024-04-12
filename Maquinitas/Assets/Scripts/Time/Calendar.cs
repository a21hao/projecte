using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Calendar : MonoBehaviour
{
    public class Day
    {
        public int dayNum;
        public Color dayColor;
        public GameObject obj;

        public Day(int dayNum, Color dayColor, GameObject obj)
        {
            this.dayNum = dayNum;
            this.obj = obj;
            UpdateColor(dayColor);
            UpdateDay(dayNum);
        }

        public void UpdateColor(Color newColor)
        {
            obj.GetComponent<Image>().color = newColor;
            dayColor = newColor;
        }

        public void UpdateDay(int newDayNum)
        {
            this.dayNum = newDayNum;
            if (dayColor == Color.white || dayColor == Color.green)
            {
                obj.GetComponentInChildren<Text>().text = (dayNum + 1).ToString();
            }
            else
            {
                obj.GetComponentInChildren<Text>().text = "";
            }
        }
    }

    private List<Day> days = new List<Day>();

    public Transform[] weeks;
    public Text MonthAndYear;

    public DateTime currDate = DateTime.Now;

    private void Start()
    {
        UpdateCalendar(DateTime.Now.Year, 0); // Comienza en la "primavera"
    }

    void UpdateCalendar(int year, int seasonIndex)
    {
        int startDay = 0; // Comienza siempre en el primer día del mes
        int endDay = 27; // 28 días en cada mes

        string[] seasons = { "Primavera", "Verano", "Otoño", "Invierno" };
        string currentSeason = seasons[seasonIndex];
        MonthAndYear.text = currentSeason + " " + year.ToString();

        if (days.Count == 0)
        {
            for (int w = 0; w < 6; w++)
            {
                for (int i = 0; i < 7; i++)
                {
                    Day newDay;
                    int currDay = (w * 7) + i;
                    if (currDay < startDay || currDay - startDay > endDay)
                    {
                        newDay = new Day(currDay - startDay, Color.grey, weeks[w].GetChild(i).gameObject);
                    }
                    else
                    {
                        newDay = new Day(currDay - startDay, Color.white, weeks[w].GetChild(i).gameObject);
                    }
                    days.Add(newDay);
                }
            }
        }
        else
        {
            for (int i = 0; i < 42; i++)
            {
                if (i < startDay || i - startDay > endDay)
                {
                    days[i].UpdateColor(Color.grey);
                }
                else
                {
                    days[i].UpdateColor(Color.white);
                }

                days[i].UpdateDay(i - startDay);
            }
        }

        if (DateTime.Now.Year == year && DateTime.Now.Month == seasonIndex)
        {
            days[(DateTime.Now.Day - 1) + startDay].UpdateColor(Color.green);
        }

    }

    int GetMonthStartDay(int year, int month)
    {
        DateTime temp = new DateTime(year, month + 1, 1); // Se suma 1 al mes para que sea consistente con el índice de los meses de DateTime

        // DayOfWeek Sunday == 0, Saturday == 6 etc.
        return (int)temp.DayOfWeek;
    }

    int GetTotalNumberOfDays(int year, int month)
    {
        return 28; // Cada mes tiene 28 días
    }

    public void SwitchSeason(int direction)
    {
        int currentSeasonIndex = Array.IndexOf(new string[] { "Primavera", "Verano", "Otoño", "Invierno" }, MonthAndYear.text.Split(' ')[0]);

        if (direction < 0)
        {
            currentSeasonIndex = (currentSeasonIndex - 1 + 4) % 4;
        }
        else
        {
            currentSeasonIndex = (currentSeasonIndex + 1) % 4;
        }

        UpdateCalendar(currDate.Year, currentSeasonIndex);
    }
}
