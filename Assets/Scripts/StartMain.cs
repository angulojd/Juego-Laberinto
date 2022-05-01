using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMain : MonoBehaviour
{
    public string nextScene;
    void Start()
    {

    }
    void Update()
    {

    }
    public void ChangeScene()
    {
        SceneManager.LoadScene(nextScene);
    }

    private void OnMouseDown()
    {
        ChangeScene();
    }
}
