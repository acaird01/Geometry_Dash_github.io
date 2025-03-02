using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneManager : MonoBehaviour
{
    public void BackStartScene()
    {
        LodingSceneManager.LoadScene("Start");
    }

    public void GoStage1()
    {
        LodingSceneManager.LoadScene("Stage1");
    }

    public void SceneChangeMain2()
    {
        SceneManager.LoadScene("Main2");
    }
}
