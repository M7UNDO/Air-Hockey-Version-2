using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleHit : MonoBehaviour
{
    public ScoreScript scoreScript;

    private int playerTouches = 0;
    private int aiTouches = 0;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "PlayerRed")
        {
            playerTouches++;
            if (playerTouches == 2 && aiTouches < 3)
            {
                scoreScript.Decrement(ScoreScript.Score.PlayerScore); 
                Debug.Log("Player loses a point!");
                ResetTouches();
            }
        }
        else if (collision.gameObject.name == "PlayerBlue")
        {
            aiTouches++;
            if (aiTouches == 2 && playerTouches < 3)
            {

                scoreScript.Decrement(ScoreScript.Score.AIScore);
                Debug.Log("AI loses a point!");
                ResetTouches();
            }
        }
    }

    private void ResetTouches()
    {
        playerTouches = 0;
        aiTouches = 0;
    }
}




