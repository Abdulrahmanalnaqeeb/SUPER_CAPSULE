using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    // Start is called before the first frame update
    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevel-3);
    }
}
