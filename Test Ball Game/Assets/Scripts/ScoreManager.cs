using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI highScoreTextHome;
    // Start is called before the first frame update
    void Start()
    {

        highScoreTextHome.text = "HIGHSCORE: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

}