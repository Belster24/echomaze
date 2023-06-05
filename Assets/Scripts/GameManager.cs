using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int currentLevel = 0;
    public List<Transform> levelSpawnPoint;
    public List<GameObject> levelUI;

    public List<GameObject> Levels;
    public List<GameObject> player;

    public string highScoreScene;
    public float highScoreTime;


    public void Awake()
    {
        StartPassage();
    }

   
    public void StartPassage()
    {
        Levels[currentLevel].SetActive(true);
        //move to level 1
    }
    public void EndPassage()
    {
        //move to high score 
        SceneManager.LoadScene(highScoreScene);

    }
    public void EnemyHit()
    {
        player[currentLevel].transform.position = levelSpawnPoint[currentLevel].position;
    }

    
    public void MoveToNextLevel()
    {
        highScoreTime = player[currentLevel].gameObject.GetComponent<HighScoreTime>().timer;
        if (currentLevel == 0)
        {
            Debug.Log("Level1");
            PlayerPrefs.SetFloat("level1score", highScoreTime);
        }
        else if (currentLevel == 1)
        {
            Debug.Log("Level1");
            PlayerPrefs.SetFloat("level2score", highScoreTime);
        }
        else if (currentLevel == 2)
        {
            Debug.Log("Level2");
            PlayerPrefs.SetFloat("level3score", highScoreTime);
        }
        else if (currentLevel == 3)
        {
            Debug.Log("Level3");
            PlayerPrefs.SetFloat("level4score", highScoreTime);
            SceneManager.LoadScene(highScoreScene);
        }
       
        Levels[currentLevel].SetActive(false);
        // move to next level in passage
        currentLevel++;
        Levels[currentLevel].SetActive(true);
    }

    
    
}
