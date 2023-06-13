using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI level;


    [SerializeField] TextMeshProUGUI name1;
    [SerializeField] TextMeshProUGUI name2;
    [SerializeField] TextMeshProUGUI name3;
    [SerializeField] TextMeshProUGUI name4;
    [SerializeField] TextMeshProUGUI score1;
    [SerializeField] TextMeshProUGUI score2;
    [SerializeField] TextMeshProUGUI score3;
    [SerializeField] TextMeshProUGUI score4;
    // Start is called before the first frame update
    void Start()
    {

        if(level.text == "Level1")
        {
            int level = 1;

            name1.text = "1." + PlayerPrefs.GetString("leadername" + level + 1);
            name2.text = "2." + PlayerPrefs.GetString("leadername" + level + 2);
            name3.text = "3." + PlayerPrefs.GetString("leadername" + level + 3);
            name4.text = "4." + PlayerPrefs.GetString("leadername" + level + 4);

            score1.text = PlayerPrefs.GetFloat("leader" + level + 1).ToString();
            score2.text = PlayerPrefs.GetFloat("leader" + level + 2).ToString();
            score3.text = PlayerPrefs.GetFloat("leader" + level + 3).ToString();
            score4.text = PlayerPrefs.GetFloat("leader" + level + 4).ToString();

            Debug.Log("1");
        }else if (level.text == "Level2")
        {
            int level = 2;

            name1.text = "1." + PlayerPrefs.GetString("leadername" + level + 1);
            name2.text = "2." + PlayerPrefs.GetString("leadername" + level + 2);
            name3.text = "3." + PlayerPrefs.GetString("leadername" + level + 3);
            name4.text = "4." + PlayerPrefs.GetString("leadername" + level + 4);

            score1.text = PlayerPrefs.GetFloat("leader" + level + 1).ToString();
            score2.text = PlayerPrefs.GetFloat("leader" + level + 2).ToString();
            score3.text = PlayerPrefs.GetFloat("leader" + level + 3).ToString();
            score4.text = PlayerPrefs.GetFloat("leader" + level + 4).ToString();


            Debug.Log("2");
        }
        else if (level.text == "Level3")
        {
            int level = 3;

            name1.text ="1."+ PlayerPrefs.GetString("leadername" + level + 1);
            name2.text = "2."+PlayerPrefs.GetString("leadername" + level + 2);
            name3.text = "3." + PlayerPrefs.GetString("leadername" + level + 3);
            name4.text = "4." + PlayerPrefs.GetString("leadername" + level + 4);

            score1.text = PlayerPrefs.GetFloat("leader" + level + 1).ToString();
            score2.text = PlayerPrefs.GetFloat("leader" + level + 2).ToString();
            score3.text = PlayerPrefs.GetFloat("leader" + level + 3).ToString();
            score4.text = PlayerPrefs.GetFloat("leader" + level + 4).ToString();


            Debug.Log("3");
        }
        else if (level.text == "Level4")
        {
            int level = 4;

            name1.text = "1." + PlayerPrefs.GetString("leadername" + level + 1);
            name2.text = "2." + PlayerPrefs.GetString("leadername" + level + 2);
            name3.text = "3." + PlayerPrefs.GetString("leadername" + level + 3);
            name4.text = "4." + PlayerPrefs.GetString("leadername" + level + 4);

            score1.text = PlayerPrefs.GetFloat("leader" + level + 1).ToString();
            score2.text = PlayerPrefs.GetFloat("leader" + level + 2).ToString();
            score3.text = PlayerPrefs.GetFloat("leader" + level + 3).ToString();
            score4.text = PlayerPrefs.GetFloat("leader" + level + 4).ToString();

            Debug.Log("4");
        }
       

    }


 
}
