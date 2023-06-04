using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class HighScoreTime : MonoBehaviour
{
    public bool startTimer;
    [SerializeField]TextMeshProUGUI timerText;
    [SerializeField] GameManager gameManager;
    float timer;
    // Update is called once per frame

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("manager").GetComponent<GameManager>();
    }
    void Update()
    {
        if (startTimer)
        {
            timer += Time.deltaTime;
            timerText.text = timer.ToString("0.##");  
        }
    }

    public void gameOver()
    {
        PlayerPrefs.SetFloat("highScore", timer);
        gameManager.EndPassage();

    }
}
