using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    public GameObject gameManager;          
    public GameObject soundManager;         


    void Start()
    {
        if (GameManager.instance == null)
            Instantiate(gameManager);

        if (SoundManager.instance == null)
            Instantiate(soundManager);
    }
}
