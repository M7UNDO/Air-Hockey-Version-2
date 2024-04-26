using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header ("Canvas")]
    public GameObject CanvasGame;
    public GameObject CanvasRestart;

    [Header ("Canvas Restart")]
    public GameObject WinTxt;
    public GameObject LooseTxt;
    public GameObject Countdown;

    [Header("Other")]
    public ScoreScript scoreScript;

    public PuckScript puckScript;
    public PlayerMovemnt playerMovemnt;
    public AIScript aiScript;
    public GameObject CountDown;


    public void ShowRestartCanvas(bool didAIWin)
    {
        CanvasGame.SetActive(false);
        CanvasRestart.SetActive(true);

        if(didAIWin)
        {
            WinTxt.SetActive(false);
            LooseTxt.SetActive(true);

        }
        else
        {
            WinTxt.SetActive(true);
            LooseTxt.SetActive(false);
        }
    }

    public void RestartGame()
    {
        
        Time.timeScale = 0;
        CanvasGame.SetActive (true);
        CanvasRestart.SetActive (false);

        
        scoreScript.ResetScores();
        puckScript.CenterPuck();
        playerMovemnt.ResetPosition();
        aiScript.ResetPosition();


        Countdown.SetActive(true);
        StartCoroutine(StartDelay());
        
    }

    IEnumerator StartDelay()
    {
        Time.timeScale = 0;
        float pauseTime = Time.realtimeSinceStartup + 3f;
        while (Time.realtimeSinceStartup < pauseTime)
            yield return 0;
        CountDown.gameObject.SetActive(false);
        Time.timeScale = 1;
       
    }


    public void ShowMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
}