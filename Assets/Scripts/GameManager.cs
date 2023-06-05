using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int currentLevel = 0;
    public List<Transform> levelSpawnPoint;
    public List<GameObject> levelUI;

    public Transform player;
    public string highScoreScene;

    public void Awake()
    {
        StartPassage();
    }

    public void StartPassage()
    {
        currentLevel = 0;
        player.position = levelSpawnPoint[0].position;
        //move to level 1
    }
    public void EndPassage()
    {
        //move to high score 
        SceneManager.LoadScene(highScoreScene);

    }
    public void EnemyHit()
    {
        player.position = levelSpawnPoint[currentLevel].position;
    }

    
    public void MoveToNextLevel()
    {
        // move to next level in passage
        currentLevel++;
        player.position = levelSpawnPoint[currentLevel].position;
        levelUI[currentLevel].SetActive(true);
    }

    
    
}
