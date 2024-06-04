using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI; // لاستيراد واجهة المستخدم


public class ItemCollector : MonoBehaviour
{
   int coins= 0;

    [SerializeField] Text coinsText;

    [SerializeField] AudioSource collectionSound;
  private void OnTriggerEnter(Collider other)
{
    if (other.gameObject.CompareTag("Coin"))
    {
        Destroy(other.gameObject);
        coins++;
        coinsText.text = "Coins: " + coins;
        collectionSound.Play();
    }
    else if (other.gameObject.CompareTag("BigCoin"))
    {
        Destroy(other.gameObject);
        coins += 5;
        coinsText.text = "Coins: " + coins;
        collectionSound.Play();
    }
}
}
