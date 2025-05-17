using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalCollision : MonoBehaviour
{
    public bool playerGoal;
    //public bool GoalScored = false;
    public ScoreScript scoreScript;
    public PuckSpawn puckSpawn;

    private void OnTriggerEnter2D(Collider2D coli)
    {
        if (coli.gameObject.CompareTag("Puck") && playerGoal)
        {
            print("Goal");
            scoreScript.Increment(ScoreScript.Score.PlayerScore);
            Destroy(coli.gameObject);
            puckSpawn.RespawnPuckPlayer();
            
        }
        else if (coli.gameObject.CompareTag("Puck") && !playerGoal)
        {
            print("Goal");
            scoreScript.Increment(ScoreScript.Score.AIScore);
            Destroy(coli.gameObject);
            puckSpawn.RespawnPuckAI();

        }
    }

    /*private void OnTriggerEnter2D(Collider2D coli)
    {
        //GoalScored = true;
        if (coli.gameObject.CompareTag("Puck") && playerGoal)
        {
            scoreScript.Increment(ScoreScript.Score.PlayerScore);
            Destroy(coli.gameObject);
            puckSpawn.RespawnPuckPlayer();
            print("Goal");
        }
        else if (coli.gameObject.CompareTag("Puck") && !playerGoal)
        {
            scoreScript.Increment(ScoreScript.Score.AIScore);
            Destroy(coli.gameObject);
            puckSpawn.RespawnPuckAI();
            print("Goal");
        }

    }
    */
}
