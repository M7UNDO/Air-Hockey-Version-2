using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckScript : MonoBehaviour
{

    public ScoreScript ScoreScriptInstance;
    public bool WasGoal;
    public Rigidbody2D rb;

    [Header("Puck Settings")]
    public float MaxSpeed;
    public AudioSource puckHitSfx;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        puckHitSfx = rb.GetComponent<AudioSource>();
        WasGoal = false;
    }

    /*private void OnTriggerEnter2D(Collider2D coli)
    {
        if (!WasGoal)
        {
            if (coli.CompareTag("AIGoal"))
            {
                ScoreScriptInstance.Increment(ScoreScript.Score.PlayerScore);
                WasGoal = true;
                Destroy(gameObject);
                StartCoroutine(ResetPuck(false));
            }
            else if (coli.CompareTag("PlayerGoal"))
            {
                ScoreScriptInstance.Increment(ScoreScript.Score.AIScore);
                WasGoal = true;
                Destroy(gameObject);
                StartCoroutine(ResetPuck(true));
            }
        }
    }
    */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerRed") || collision.gameObject.CompareTag("PlayerBlue"))
        {
            puckHitSfx.Play();
        }
       
    }

    /*
    private IEnumerator ResetPuck(bool didAIScore)
    {
        yield return new WaitForSecondsRealtime(0.1f);
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
    */
    private void FixedUpdate()
    {
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, MaxSpeed);
    }

}
