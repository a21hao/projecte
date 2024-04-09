using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
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
        UpdateCalendar(DateTime.Now.Year, DateTime.Now.Month);
    }

    void UpdateCalendar(int year, int month)
    {
        string[] monthNames = { "Primavera", "Verano", "Otoño", "Invierno" };

        currDate = new DateTime(year, month, 1);
        MonthAndYear.text = monthNames[month - 1] + " " + year.ToString();

        if (days.Count == 0)
        {
            for (int w = 0; w < 4; w++)
            {
                for (int i = 0; i < 7; i++)
                {
                    Day newDay;
                    int currDay = (w * 7) + i;
                    if (currDay >= DateTime.DaysInMonth(year, month))
                    {
                        newDay = new Day(currDay - DateTime.DaysInMonth(year, month), Color.grey, weeks[w].GetChild(i).gameObject);
                    }
                    else
                    {
                        newDay = new Day(currDay, Color.white, weeks[w].GetChild(i).gameObject);
                    }
                    days.Add(newDay);
                }
            }
        }
        else
        {
            for (int i = 0; i < 28; i++)
            {
                if (i >= DateTime.DaysInMonth(year, month))
                {
                    days[i].UpdateColor(Color.grey);
                }
                else
                {
                    days[i].UpdateColor(Color.white);
                }

                days[i].UpdateDay(i);
            }
        }

        if (DateTime.Now.Year == year && DateTime.Now.Month == month)
        {
            days[(DateTime.Now.Day - 1)].UpdateColor(Color.green);
        }
    }

    int GetMonthStartDay(int year, int month)
    {
        DateTime temp = new DateTime(year, month, 1);
        return (int)temp.DayOfWeek;
    }

    int GetTotalNumberOfDays(int year, int month)
    {
        return DateTime.DaysInMonth(year, month);
    }

    public void SwitchMonth(int direction)
    {
        if (direction < 0)
        {
            currDate = currDate.AddMonths(-1);
        }
        else
        {
            currDate = currDate.AddMonths(1);
        }

        UpdateCalendar(currDate.Year, currDate.Month);
    }
}
