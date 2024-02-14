using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    public TMP_Text highscore;

    private void Start()
    {
        HandleData.Instance.LoadInfo();
        highscore.text = "HighScore: " + HandleData.Instance.newScore + "   By: " + HandleData.Instance.playerName;
    }

    public void StartGame()
    {
        HandleData.Instance.SaveInfo();
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
