using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [SerializeField]GameObject tutorial;
    [SerializeField]GameObject Menu;
    // Start is called before the first frame update
    void Start()
    {
        int game = PlayerPrefs.GetInt("tutorial");
        if (game != 1)
        { 
            tutorial.SetActive(true);
        }
        else
        {
            Menu.SetActive(true);
        }
    }

    public void startGame()
    {
        SceneManager.LoadScene("level_1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
