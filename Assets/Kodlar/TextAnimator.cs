using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class TextAnimator : MonoBehaviour
{
      public TMP_Text textComponent;
    public Image imageComponent; // Added Image component
    public float displayDuration = 3.0f; 

    private bool isAnimating = false;

    void Start()
    {
        // Show the text and image at the start
        textComponent.gameObject.SetActive(true);
        imageComponent.gameObject.SetActive(true); // Show the image component

        // Start the coroutine to show message and image
        StartCoroutine(ShowMessage());
    }

    // Coroutine to display the message and image for a specified duration
    IEnumerator ShowMessage()
    {
        isAnimating = true;

        // Wait for the specified duration
        yield return new WaitForSeconds(displayDuration);

        // Hide the text and image
        textComponent.gameObject.SetActive(false);
        imageComponent.gameObject.SetActive(false); // Hide the image component
        isAnimating = false;
    }

    void Update()
    {
        if (!isAnimating) return;

        textComponent.ForceMeshUpdate();
        TMP_TextInfo textInfo = textComponent.textInfo;

        for (int i = 0; i < textInfo.characterCount; ++i)
        {
            var charInfo = textInfo.characterInfo[i];

            if (!charInfo.isVisible)
                continue;

            var meshInfo = textInfo.meshInfo[charInfo.materialReferenceIndex];

            for (int j = 0; j < 4; ++j)
            {
                var index = charInfo.vertexIndex + j;
                var orig = meshInfo.vertices[index];
                meshInfo.vertices[index] = orig + new Vector3(0, Mathf.Sin(Time.time * 2f + orig.x * 0.01f) * 10f, 0);
                meshInfo.colors32[index] = Color.red;
            }
        }

        for (int i = 0; i < textInfo.meshInfo.Length; ++i)
        {
            var meshInfo = textInfo.meshInfo[i];
            meshInfo.mesh.vertices = meshInfo.vertices;
            meshInfo.mesh.colors32 = meshInfo.colors32;
            textComponent.UpdateGeometry(meshInfo.mesh, i);
        }
    }
}
