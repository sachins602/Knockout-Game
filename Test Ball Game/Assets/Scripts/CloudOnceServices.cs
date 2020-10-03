using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using CloudOnce;

public class CloudOnceServices : MonoBehaviour
{
    public static CloudOnceServices instance;
    private void Awake()
    {
        TestSingleton();
    }
    private void TestSingleton()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void SubmitScoreToLeaderboard(int Hscore)
    {
        Leaderboards.HighScore.SubmitScore(Hscore);
    }
}
