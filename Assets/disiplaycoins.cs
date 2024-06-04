using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class disiplaycoins : MonoBehaviour
{  public Text endGameText; // مرجع إلى عنصر الـ UI لعرض الرسالة النهائية

    void Start()
    {
        // تعيين المرحلة الحالية إلى 4 في PlayerPrefs
        PlayerPrefs.SetInt("CurrentStage", 4);
        PlayerPrefs.Save();

        // البحث عن CoinManager في المشهد
        CoinManager1 coinManager = FindObjectOfType<CoinManager1>();
        if (coinManager != null)
        {
            int totalCoins = coinManager.GetTotalCoins();

            // عرض رسالة الانتهاء والعدد الإجمالي للعملات
            if (endGameText != null)
            {
                endGameText.text = "لقد انتهيت من اللعبة! \nعدد العملات التي جمعتها: " + totalCoins;
            }
        }
        else
        {
            Debug.LogError("لم يتم العثور على CoinManager في المشهد.");
        }
    }
}
