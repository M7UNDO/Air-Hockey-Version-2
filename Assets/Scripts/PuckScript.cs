using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckScript : MonoBehaviour
{
    public ScoreScript ScoreScriptInstance;

    public AudioScript audioscript;
    public static bool WasGoal { get; private set; }
    private Rigidbody2D rb;
    public float MaxSpeed;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        WasGoal = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!WasGoal)
        {
            if (other.tag == "AIGoal")
            {
                ScoreScriptInstance.Increment(ScoreScript.Score.PlayerScore);
                WasGoal = true;
                StartCoroutine(ResetPuck(false));
            }
            else if (other.tag == "PlayerGoal")
            {
                ScoreScriptInstance.Increment(ScoreScript.Score.AIScore);
                WasGoal = true;
                StartCoroutine(ResetPuck(true));
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "PlayerRed" || (collision.gameObject.name == "PlayerBlue"))
        {
           audioscript.PlayPuckCollision();
        }
       
    }

    private IEnumerator ResetPuck(bool didAIScore)
    {
        yield return new WaitForSecondsRealtime(0.5f);
        WasGoal = false;
        rb.velocity = rb.position = new Vector2(0, 0);

        if(didAIScore )
        {
            rb.position = new Vector2(0f, -3.5f);
        }
        else
        {
            rb.position = new Vector2(0f, 3.5f);
        }


    }

    public void CenterPuck()
    {
        rb.position = new Vector2(0, 0);
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, MaxSpeed);
    }

}
