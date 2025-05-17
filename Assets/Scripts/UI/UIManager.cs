using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header ("Canvas")]
    public GameObject CanvasGame;
    public GameObject CanvasRestart;


    [Header("Canvas Restart")]
    public TextMeshProUGUI endTxt;
    public TextMeshProUGUI WinTxt;
    public TextMeshProUGUI LoseTxt;
    public GameObject Countdown;
    public Image background;
    public Color winColour;
    public Color loseColour;
    public string[] winDisplay;
    public string[] loseDisplay;

    [Header("Other")]
    public ScoreScript scoreScript;

    public PuckSpawn puckSpawn;
    public PlayerMovemnt playerMovemnt;
    public AIScript aiScript;
    public GameObject CountDown;


    public void ShowRestartCanvas(bool didAIWin)
    {
        CanvasGame.SetActive(false);
        CanvasRestart.SetActive(true);
        Time.timeScale = 0;

        if (didAIWin)
        {
            endTxt.text = "AI WINS";
            endTxt.enabled = true;
            background.color = loseColour;
            int i = Random.Range(0, loseDisplay.Length);
            LoseTxt.text = loseDisplay[i];
            LoseTxt.enabled = true;
            WinTxt.enabled = false;

        }
        else
        {
            endTxt.text = "PLAYER WINS!";
            endTxt.enabled = true;
            background.color = winColour;
            int i = Random.Range(0, winDisplay.Length);
            WinTxt.text = winDisplay[i];
            WinTxt.enabled = true;
            LoseTxt.enabled = false;
        }

        
    }

    public void RestartGame()
    {
        
        Time.timeScale = 0;
        CanvasGame.SetActive (true);
        CanvasRestart.SetActive (false);

        
        scoreScript.ResetScores();
        puckSpawn.SpawnPuck();
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