using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIPanel : MonoBehaviour
{
    private bool toggle;
    public GameObject panel;
    public GameObject[] menuUI;
    public Color originalColour;
    public TextMeshProUGUI difficultyTxt;
    // Start is called before the first frame update
    

    // Update is called once per frame
    public void Panel()
    {
        toggle = !toggle;

        if (toggle == false)
        {
            panel.SetActive(false);
            
            foreach(GameObject uiElement in menuUI)
            {
                difficultyTxt.color = originalColour;
                uiElement.SetActive(true);
            }
        }

        if (toggle)
        {
            panel.SetActive(true);
            foreach (GameObject uiElement in menuUI)
            {
                uiElement.SetActive(false);
            }
        }
    }
}
