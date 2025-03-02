using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChangeManager : MonoBehaviour
{
    public void SceneChange()
    {
        LodingSceneManager.LoadScene("Main");
        //SceneManager.LoadScene("Main");
    }
    public void ApplicationQuit1()
    {
        Application.Quit();
    }
}
