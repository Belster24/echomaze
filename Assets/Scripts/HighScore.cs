using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;


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
    public TMP_InputField names;
    

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

    
    public void SafeScore()
    {

        Debug.Log(names.text);

        //Level 1 Highscore 
        int count1 = 1;

        while (true)
        {
            if (PlayerPrefs.HasKey("leader1" + count1))
            {
                if (highScoreValue1 < PlayerPrefs.GetFloat("leader1" + count1))
                {
                    PlayerPrefs.SetString("leadername1" + count1, names.text);

                    PlayerPrefs.SetFloat("leader1" + count1, highScoreValue1);
                   break;
                }
                else
                {
                    count1++;
                }
            }
            else
            {
                PlayerPrefs.SetString("leadername1" + count1, names.text);
                PlayerPrefs.SetFloat("leader1" + count1, highScoreValue1);
                break;

            }

        }

        //Level 2 Highscore
        int count2 = 1;

        while (true)
        {
            if (PlayerPrefs.HasKey("leader2" + count2))
            {
                if (highScoreValue2 < PlayerPrefs.GetFloat("leader2" + count2))
                {
                    PlayerPrefs.SetString("leadername2" + count2, names.text);
                    PlayerPrefs.SetFloat("leader2" + count2, highScoreValue2);
                    break;
                }
                else
                {
                    count2++;
                }
            }
            else
            {
                PlayerPrefs.SetString("leadername2" + count2, names.text);
                PlayerPrefs.SetFloat("leader2" + count2, highScoreValue2);
                break;
            }

        }

        //Level 3 Highscore
        int count3 = 1;

        while (true)
        {
            if (PlayerPrefs.HasKey("leader3" + count3))
            {
                if (highScoreValue2 < PlayerPrefs.GetFloat("leader3" + count3))
                {
                    PlayerPrefs.SetString("leadername3" + count3, names.text);
                    PlayerPrefs.SetFloat("leader3" + count3, highScoreValue3);
                    break;
                }
                else
                {
                    count3++;
                }
            }
            else
            {
                PlayerPrefs.SetString("leadername3" + count3, names.text);
                PlayerPrefs.SetFloat("leader3" + count3, highScoreValue3);
                break;
            }

        }

        //Level 4 Highscore
        int count4 = 1;

        while (true)
        {
            if (PlayerPrefs.HasKey("leader4" + count4))
            {
                if (highScoreValue2 < PlayerPrefs.GetFloat("leader4" + count4))
                {
                    PlayerPrefs.SetString("leadername4" + count4, names.text);
                    PlayerPrefs.SetFloat("leader4" + count4, highScoreValue4);
                    break;
                }
                else
                {
                    count3++;
                }
            }
            else
            {
                PlayerPrefs.SetString("leadername4" + count4, names.text);
                PlayerPrefs.SetFloat("leader4" + count4, highScoreValue4);
                break;
            }

        }


        /*
        for (int i = 1; i < 5; i++)
        {
           

            //1
            if (PlayerPrefs.HasKey("leader1" + i))
            {
                if (highScoreValue1 < PlayerPrefs.GetFloat("leader1" + i))
                {
                    PlayerPrefs.SetString("leadername1" + i, names.text);

                    PlayerPrefs.SetFloat("leader1" + i, highScoreValue1);
                }
            }
            else
            {
                PlayerPrefs.SetString("leadername1" + i, names.text);
                PlayerPrefs.SetFloat("leader1" + i, highScoreValue1);

            }
            //2
            if (PlayerPrefs.HasKey("leader2" + i))
            {
                if (highScoreValue2 < PlayerPrefs.GetFloat("leader2" + i))
                {
                    PlayerPrefs.SetString("leadername2" + i, names.text);
                    PlayerPrefs.SetFloat("leader2" + i, highScoreValue2);
                }
            }
            else
            {
                PlayerPrefs.SetString("leadername2" + i, names.text);
                PlayerPrefs.SetFloat("leader2" + i, highScoreValue2);

            }
            //3
            if (PlayerPrefs.HasKey("leader3" + i))
            {
                if (highScoreValue3 < PlayerPrefs.GetFloat("leader3" + i))
                {
                    PlayerPrefs.SetString("leadername3" + i, names.text);
                    PlayerPrefs.SetFloat("leader3" + i, highScoreValue3);
                }
            }
            else
            {
                PlayerPrefs.SetString("leadername3" + i, names.text);
                PlayerPrefs.SetFloat("leader3" + i, highScoreValue3);

            }

            //4
            if (PlayerPrefs.HasKey("leader4" + i))
            {
                if (highScoreValue4 < PlayerPrefs.GetFloat("leader4" + i))
                {
                    PlayerPrefs.SetString("leadername4" + i, names.text);
                    PlayerPrefs.SetFloat("leader4" + i, highScoreValue4);
                }
            }
            else
            {
                PlayerPrefs.SetString("leadername4" + i, names.text);
                PlayerPrefs.SetFloat("leader4" + i, highScoreValue4);

            }


        }*/
        

        Debug.Log(PlayerPrefs.GetFloat("leader11"));
        Debug.Log(PlayerPrefs.GetFloat("leader12"));

        Debug.Log(PlayerPrefs.GetFloat("leader21"));
        Debug.Log(PlayerPrefs.GetFloat("leader22"));

        Debug.Log(PlayerPrefs.GetFloat("leader31"));
        Debug.Log(PlayerPrefs.GetFloat("leader32"));

        Debug.Log(PlayerPrefs.GetString("leadername11"));

    }


}
