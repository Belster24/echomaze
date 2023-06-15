using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class StartGame : MonoBehaviour
{
    [SerializeField]GameObject tutorial;
    [SerializeField]GameObject Menu;

    [SerializeField] GameObject menuText;
    [SerializeField] GameObject leader;

    


   

    public void startGame()
    {
        SceneManager.LoadScene("level_1");
    }

    public void playTutorial()
    {
        tutorial.SetActive(true);
        Menu.SetActive(false);
    }

    public void showLeader()
    {
        menuText.SetActive(false);
        leader.SetActive(true);
    }
    public void hideLeader()
    {
        menuText.SetActive(true);
        leader.SetActive(false);
    }




    public void QuitGame()
    {
        Application.Quit();
    }

}
