using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPGSLeaderBoards : MonoBehaviour
{
public void ShowLeaderBoard()
    {
        Social.ShowLeaderboardUI();
    }
    public void UpdateLeaderBoardScore()
    { 
        if (PlayerPrefs.GetInt("ScoreToUpdate", 0) == 0)
        {
            return;
        }
        Social.ReportScore(PlayerPrefs.GetInt("ScoreToUpdate", 1), GPGSIds.leaderboard_highscore, (bool success) =>
        {
            if(success)
            {
                PlayerPrefs.SetInt("ScoreToUpdate", 0);
            }
        });
    }
}
