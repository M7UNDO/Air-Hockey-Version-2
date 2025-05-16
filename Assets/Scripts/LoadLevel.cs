using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class LoadLevel : MonoBehaviour
{
    public void LoadLevelNumber(int _index)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(_index);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
