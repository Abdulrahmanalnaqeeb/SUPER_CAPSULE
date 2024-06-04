using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleButtons : MonoBehaviour
{
   public Button mainButton;
    public Button muteButton;
    public Button unmuteButton;

    private bool buttonsVisible = false;

    void Start()
    {
        // ربط دالة التبديل بزر الضغط الرئيسي
        mainButton.onClick.AddListener(ToggleOptions);

        // إخفاء الأزرار عند البدء
        muteButton.gameObject.SetActive(false);
        unmuteButton.gameObject.SetActive(false);

        // ربط وظائف الأزرار بالضغطات
        muteButton.onClick.AddListener(MuteSound);
        unmuteButton.onClick.AddListener(UnmuteSound);
    }

    void ToggleOptions()
    {
        // تبديل حالة ظهور الأزرار
        buttonsVisible = !buttonsVisible;
        muteButton.gameObject.SetActive(buttonsVisible);
        unmuteButton.gameObject.SetActive(buttonsVisible);
    }

    void MuteSound()
    {
        AudioListener.volume = 0;
    }

    void UnmuteSound()
    {
        AudioListener.volume = 1;
    }
}
