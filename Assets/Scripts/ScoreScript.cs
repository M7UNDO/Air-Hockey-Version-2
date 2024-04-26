using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public enum Score
    {
        AIScore, PlayerScore
    }

    public TMP_Text AIScoreTxt, PlayerScoreTxt;

    public UIManager uiManager;

    public int MaxScore;
    private int aiScore, playerScore;

    private int AIScore
    {
        get { return aiScore; }
        set
        {
            aiScore = value;
            if (value == MaxScore)
                uiManager.ShowRestartCanvas(true);

        }
    }

    private int PlayerScore
    {
        get { return playerScore; }
        set
        {
            playerScore = value;
            if (value == MaxScore)
                uiManager.ShowRestartCanvas(false);

        }
    }

   

    public void Increment(Score whichScore)
    {
        if (whichScore == Score.AIScore)
            AIScoreTxt.text = (++AIScore).ToString();
        else
            PlayerScoreTxt.text = (++PlayerScore).ToString();
    }

    public void Decrement(Score whichScore)
    {
     if (whichScore == Score.AIScore)
     {
      AIScoreTxt.text = (--AIScore).ToString();
      //if(AIScore < 0);
      //AIScore = 0; 
     }
     else
      {
     PlayerScoreTxt.text = (--PlayerScore).ToString();
     //if (PlayerScore < 0);
     //PlayerScore = 0;
     }


     }

    public void minusPlayerScore()
    {
        if (playerScore > 0)
        {
            playerScore = playerScore - 1;
            PlayerScoreTxt.text = playerScore.ToString("0");
            return;

        }
    }
    public void minusAIScore()
    {
        if (AIScore > 0)
        {
            AIScore = AIScore - 1;
            AIScoreTxt.text = AIScore.ToString("0");
            return;

        }
    }

    public void ResetScores()
    {

        AIScore = PlayerScore = 0;
        AIScoreTxt.text = PlayerScoreTxt.text = "0";
    }
}