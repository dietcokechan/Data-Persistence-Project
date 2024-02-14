using System;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class HandleData : MonoBehaviour
{
    public static HandleData Instance;
    public TMP_InputField Input;
    public string playerName;
    public int newScore;
    public bool isGameOver;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private int CheckScore(int score)
    {
        if (score < newScore)
            score = newScore;
        return score;
    }

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int score;
    }

    public void SaveInfo()
    {
        SaveData data = new SaveData
        {
            playerName = playerName,
            score = CheckScore(newScore)
        };
        
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadInfo()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerName = data.playerName;
            newScore = data.score;
        }
    }
}
