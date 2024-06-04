using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager1 : MonoBehaviour
{
   
       public int currentCoins = 0; // عدد العملات في المرحلة الحالية
    private int currentStage; // المرحلة الحالية، سيتم تعيينها من PlayerPrefs

    void Start()
    {
        // استرجاع المرحلة الحالية من PlayerPrefs
        currentStage = PlayerPrefs.GetInt("CurrentStage", 1);
    }

    public void CollectCoin()
    {
        currentCoins++;
        SaveCoins();
    }

    public void SaveCoins()
    {
        PlayerPrefs.SetInt("Stage" + currentStage + "Coins", currentCoins);
        PlayerPrefs.Save();
    }

    public int GetTotalCoins()
    {
        int totalCoins = 0;
        for (int i = 1; i <= 4; i++) // تحديث العدد ليتضمن المرحلة الرابعة
        {
            totalCoins += PlayerPrefs.GetInt("Stage" + i + "Coins", 0);
        }
        return totalCoins;
    }
}
