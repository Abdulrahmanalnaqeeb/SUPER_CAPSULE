using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // لإستخدام عناصر واجهة المستخدم مثل النص
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 60f;
    public Text timerText;
    public GameObject gameOverScreen;
    public PlayerLife lossScript; // إشارة إلى سكريبت الخسارة

    private bool isGameOver = false;

    void Start()
    {
        // إخفاء شاشة الخسارة عند بدء اللعبة
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(false);
        }
    }

    void Update()
    {
        if (isGameOver)
            return;

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            DisplayTime(timeRemaining);
        }
        else
        {
            timeRemaining = 0;
            GameOver();
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        // تأكد من أن timerText ليس فارغًا قبل تعيين النص
        if (timerText != null)
        {
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else
        {
            Debug.LogWarning("timerText لم يتم تعيينه في Inspector.");
        }
    }

    void GameOver()
    {
        isGameOver = true;
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(true); // عرض شاشة الخسارة
        }
        // استدعاء دالة Die من سكريبت الخسارة
        if (lossScript != null)
        {
            lossScript.Die();
        }
        // استدعاء دالة Restart بعد 3 ثوانٍ
        Invoke("Restart", 3f);
    }

    void Restart()
    {
        // تحميل المستوى السابق
        int previousLevelIndex = SceneManager.GetActiveScene().buildIndex - 1;
        if (previousLevelIndex >= 0)
        {
            SceneManager.LoadScene(previousLevelIndex);
        }
        else
        {
            Debug.LogWarning("No previous level to load.");
        }
    }
}
