using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gamemanger : MonoBehaviour
{
    // هذه الدالة تُستخدم للانتقال إلى المرحلة التالية

    public static gamemanger instance;

    private int[] coinsCollected;
    private int currentLevel;
    public Text totalCoinsText; // This is for displaying the total coins in level 4

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            coinsCollected = new int[3]; // Assuming there are 3 levels to collect coins
            currentLevel = 0;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateCoinText();
    }

    public void AddCoin()
    {
        if (currentLevel < 3)
        {
            coinsCollected[currentLevel]++;
        }
        UpdateCoinText();
    }

    void UpdateCoinText()
    {
        if (currentLevel == 3 && totalCoinsText != null)
        {
            int totalCoins = 0;
            for (int i = 0; i < coinsCollected.Length; i++)
            {
                totalCoins += coinsCollected[i];
            }
            totalCoinsText.text = "Total Coins from Level 1, 2, and 3: " + totalCoins;
        }
    }

    public void NextLevel()
    {
        currentLevel++;
        if (currentLevel < 3)
        {
            SceneManager.LoadScene("Level" + (currentLevel + 1));
        }
        else if (currentLevel == 3)
        {
            SceneManager.LoadScene("Level4");
        }
    }

    public void RestartGame()
    {
        currentLevel = 0;
        coinsCollected = new int[3];
        SceneManager.LoadScene("Level01");
    }
}
