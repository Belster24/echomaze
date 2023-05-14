using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighScore : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI highScore;
    float highScoreValue;

    // Start is called before the first frame update
    void Start()
    {
        highScoreValue = PlayerPrefs.GetFloat("highscore");
        highScore.text = highScoreValue.ToString(); 
    }

  
}
