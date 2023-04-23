using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPH : MonoBehaviour
{
    private void OnDisable()
    {
        SceneManager.LoadScene("game");
    }
}
