using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour
{
    public TextMeshProUGUI buttonTxt;
    public Color originalColor;
    public Color highlightColor;

    private void Start()
    {
        buttonTxt = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
   
    }


    public void ChangeColour()
    {
        //buttonTxt.color = buttonTxt.color;
        buttonTxt.color = highlightColor;

    }

    public void ChangeColourBack()
    {
        buttonTxt.color = originalColor;



    }
}
