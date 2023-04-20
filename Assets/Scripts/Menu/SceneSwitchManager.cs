using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class SceneSwitchManager : MonoBehaviour
{
    public string sceneToSwitch;

    public void GoToScene()
    {
        SceneManager.LoadScene(sceneToSwitch);
        Debug.Log("Scene loaded");
    }

    public void GoToLoad()
    {
    }
}
