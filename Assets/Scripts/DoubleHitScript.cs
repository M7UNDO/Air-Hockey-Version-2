using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class DoubleHitScript : MonoBehaviour
{
    public ScoreScript scorescript;
    public int PlayerTouches;
    public int AiTouches;

    private void OnCollisionEnter2D(Collision2D coli)
    {

        if(coli.gameObject.name == "PlayerRed")
        {
            PlayerTouches++;
            AiTouches = 0;

            if (PlayerTouches > 1)
            {

                scorescript.minusPlayerScore();
                PlayerTouches = 0;
                AiTouches = 0;
            }
        }
        else if (coli.gameObject.name == "PlayerBlue")
        {
            AiTouches++;
            PlayerTouches = 0;
            if (AiTouches > 1)
            {
                scorescript.minusAIScore();
                AiTouches = 0;
                PlayerTouches = 0;
            }
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
