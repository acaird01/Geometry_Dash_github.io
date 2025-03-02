using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main2Manager : MonoBehaviour
{
    public void GotoMain1()
    {
        SceneManager.LoadScene("Main");
    }
    public void GotoStartScene()
    {
        LodingSceneManager.LoadScene("Start");
    }
}
