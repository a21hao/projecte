using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalDayManager : MonoBehaviour
{
    // Start is called before the first frame update
    private int dineroInicioDia;
    private int dineroFinDia;
    [SerializeField] private GameObject FinDiaCanv;
    [SerializeField] private GameObject textEarnedMoneyDay;
    [SerializeField] private GameObject textMoneyThisDay;
    [SerializeField] private GameObject winConditiontext;
    [SerializeField] private GameObject winImage;
    [SerializeField] private GameObject loseImage;
    [SerializeField] private GameObject soldItems;
    //[SerializeField] private int moneyToWin;
    private TextMeshProUGUI ernaedThisDay;
    private TextMeshProUGUI moneyThisday;
    private TextMeshProUGUI soldItemsText;
    private TextMeshProUGUI numberOfUnitsSold;
    private TextMeshProUGUI winCondition;
    private int itemSoldInitialday;
    private int daysTranscurred;
    void Start()
    {
        dineroInicioDia = MoneyManager.instance.DineroTotal;
        ernaedThisDay = textEarnedMoneyDay.GetComponent<TextMeshProUGUI>();
        moneyThisday = textMoneyThisDay.GetComponent<TextMeshProUGUI>();
        winCondition = winConditiontext.GetComponent<TextMeshProUGUI>();
        soldItemsText = soldItems.GetComponent<TextMeshProUGUI>();
        itemSoldInitialday = 0;
        daysTranscurred = 0;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FinishDay()
    {
        dineroFinDia = MoneyManager.instance.DineroTotal;
        FinDiaCanv.SetActive(true);
        moneyThisday.text = "You have this day: " + (dineroFinDia);
        ernaedThisDay.text = "You earned this day: " + (dineroFinDia - dineroInicioDia);
        soldItemsText.text = "You sold " + (ObjectivesAndStats.NumberOfItemsSold() - itemSoldInitialday) + " products";
        dineroInicioDia = dineroFinDia;
        itemSoldInitialday = ObjectivesAndStats.NumberOfItemsSold();
        daysTranscurred += 1;
        ObjectivesAndStats.Instance.CheckIfLose(daysTranscurred);

        /*if (dineroFinDia - dineroInicioDia >= moneyToWin)
        {
          winImage.SetActive(true);
          loseImage.SetActive(false);
          winCondition.text = "You earned more than " + moneyToWin + ", YOU WIN";
        }
        else
        {
          winImage.SetActive(false);
          loseImage.SetActive(true);
          winCondition.text = "You earned less than " + moneyToWin + ", YOU LOSE";
        }*/

    }

    public void DisactiveFinalDay()
    {
        FinDiaCanv.SetActive(false);
    }
}
