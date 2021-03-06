﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelSelectionMenu : MonoBehaviour
{
    public string[] scenes;

    public Text lastHighScoreText;

    public List<Image> stars;

    public System.Action OnClose = () => { };

    const string GAMEPLAY_SCENE_NAME = "Gameplay";

    private void Update()
    {
        if (Input.GetAxis("Cancel") > Mathf.Epsilon)
        {
            OnClose();
            gameObject.SetActive(false);
        }
    }

    public void GoToScene(LevelData levelData)
    {
        LevelEntity.nextLevelData = levelData;
        SceneManager.LoadScene(GAMEPLAY_SCENE_NAME);
    }

    public void OnButtonHover(LevelData levelData)
    {
        int highScore = HighScoreManager.LoadHighScore(levelData);
        if (highScore == 0)
        {
            lastHighScoreText.text = "No high score";
        }
        else
        {
            lastHighScoreText.text = "High score: " + highScore;
        }
        for (int i = 0; i < 3; i++)
        {
            stars[i].gameObject.SetActive(highScore > levelData.starThresholds[i]);
        }
    }
}
