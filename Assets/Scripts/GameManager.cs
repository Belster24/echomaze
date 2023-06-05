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
        Levels[currentLevel].SetActive(false);
        // move to next level in passage
        currentLevel++;
        Levels[currentLevel].SetActive(true);
    }

    
    
}
