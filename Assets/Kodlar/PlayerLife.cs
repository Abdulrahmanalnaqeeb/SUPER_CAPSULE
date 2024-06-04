using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerLife : MonoBehaviour
{
   public GameObject kafa;
    public AudioSource deathSound; // تأكد من تعيين مصدر الصوت في المحرر
    private bool dead = false;

    private void Update()
    {
        // مثال: خسارة اللاعب إذا سقط من الارتفاع
        if (transform.position.y < -1f && !dead)
        {
            Die();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // مثال: خسارة اللاعب عند الاصطدام بجسم العدو
        if (collision.gameObject.CompareTag("Enemy Body"))
        {
            HidePlayer();
            Die();
        }
    }

    private void HidePlayer()
    {
        // إخفاء مكونات اللاعب دون التأثير على الجسم الآخر
        GetComponent<MeshRenderer>().enabled = false;
        kafa.SetActive(false);
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<HareketEtmek>().enabled = false;
    }

    public void Die()
    {
        if (!dead)
        {
            dead = true;
            if (deathSound != null)
            {
                deathSound.Play();
            }
            // يمكنك إضافة أي تأثيرات أخرى هنا، مثل تشغيل رسوم متحركة للموت
            Debug.Log("Player has died.");
            // استدعاء دالة Restart بعد 3 ثوانٍ
            Invoke("Restart", 3f);
        }
    }

    void Restart()
    {
        // تحميل المستوى الحالي (أو المستوى السابق حسب المطلوب)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
