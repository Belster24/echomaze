using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighScore : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI highScore1;
    [SerializeField]TextMeshProUGUI highScore2;
    [SerializeField]TextMeshProUGUI highScore3;
    [SerializeField]TextMeshProUGUI highScore4;
    float highScoreValue1;
    float highScoreValue2;
    float highScoreValue3;
    float highScoreValue4;

    // Start is called before the first frame update
    void Start()
    {
        highScoreValue1 = PlayerPrefs.GetFloat("level1score");
        highScoreValue2 = PlayerPrefs.GetFloat("level2score");
        highScoreValue3 = PlayerPrefs.GetFloat("level3score");
        highScoreValue4 = PlayerPrefs.GetFloat("level4score");
        highScore1.text = "Level 1 Time: " +highScoreValue1.ToString(); 
        highScore2.text = "Level 2 Time: " +highScoreValue2.ToString(); 
        highScore3.text = "Level 3 Time: " +highScoreValue3.ToString(); 
        highScore4.text = "Level 4 Time: " +highScoreValue4.ToString(); 
    }

  
}
