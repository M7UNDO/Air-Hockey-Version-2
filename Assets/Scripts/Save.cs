using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using UnityEngine;

public class Save : MonoBehaviour
{
    public static Save instance { get; private set; }
    // Start is called before the first frame update

    public bool[] Difficulty = new bool[3]{ false, false, false};
    public float maxMovementSpeed;
    public Difficulty difficultyScript;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        else
            instance = this;

        DontDestroyOnLoad(gameObject);
        Load();
    }


    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData_Storage data = (PlayerData_Storage)bf.Deserialize(file);

            Difficulty = data.Difficulty;
            maxMovementSpeed = data.maxMovementSpeed;
            file.Close();


            if (data.Difficulty == null)
            {
                Difficulty = new bool[3] { false, false , false,};
            }


        }

    }

    public void SaveData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
        PlayerData_Storage data = new PlayerData_Storage();

        data.Difficulty = Difficulty;
        data.maxMovementSpeed = maxMovementSpeed;
        bf.Serialize(file, data);
        file.Close();


    }

    [Serializable]
    class PlayerData_Storage
    {
        public bool[] Difficulty = new bool[3] { false, false, false };
        public float maxMovementSpeed;


    }
}
