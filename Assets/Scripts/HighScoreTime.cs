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
    public float timer;
    // Update is called once per frame

    void Update()
    {
        if (startTimer)
        {
            timer += Time.deltaTime;
            timerText.text = timer.ToString("0.##");  
        }
    }




}
