using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficulty : MonoBehaviour
{
    public AIScript aiScript;
    public float easySpeed;
    public float normalSpeed;
    public float hardSpeed;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Save.instance.maxMovementSpeed = 0;
            Save.instance.Difficulty[0] = false;
            Save.instance.Difficulty[1] = false;
            Save.instance.Difficulty[2] = false;
        }

        if (Save.instance.maxMovementSpeed == 0)
        {
            EasyDifficulty();
            Save.instance.SaveData();
        }

        if (Save.instance.Difficulty[0] == true)
        {
            Save.instance.maxMovementSpeed = easySpeed;
            Save.instance.SaveData();
        }
        else if(Save.instance.Difficulty[1] == true)
        {
            Save.instance.maxMovementSpeed = normalSpeed;
            Save.instance.SaveData();
        }
        else if(Save.instance.Difficulty[2] == true)
        {
            Save.instance.maxMovementSpeed = hardSpeed;
            Save.instance.SaveData();
        }
    }

    public void EasyDifficulty()
    {
        Save.instance.Difficulty[0] = true;
        Save.instance.Difficulty[1] = false;
        Save.instance.Difficulty[2] = false;
        Save.instance.SaveData();
    }

    public void NormalDifficulty()
    {
        Save.instance.Difficulty[1] = true;
        Save.instance.Difficulty[0] = false;
        Save.instance.Difficulty[2] = false;
        Save.instance.SaveData();
        print("Test");
    }

    public void LegendaryDifficulty()
    {
        Save.instance.Difficulty[2] = true;
        Save.instance.Difficulty[0] = false;
        Save.instance.Difficulty[1] = false;
        Save.instance.SaveData();

    }

}
