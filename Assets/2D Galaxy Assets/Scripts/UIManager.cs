using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEditor.UI;
using UnityEngine.SocialPlatforms.Impl;

public class UIManager : MonoBehaviour
{
    public Sprite[] lives;

    public Image livesImageDisplay;

    public GameObject startScreen;

    public Text scoreText;

    public int score;

    [SerializeField]
    private GameObject _playerPrefab;


    public void UpdateLives(int currentLives)
    {
        livesImageDisplay.sprite = lives[currentLives];
        Debug.Log("Player Lives: " + currentLives);
    }

    public void UpdateScore()
    {
        score += 10;
        scoreText.text = "Score: " + score;
    }


    public void StartGame()
    {
        startScreen.SetActive(false);
    }

    public void GameOver()
    {
        score = 0;
        scoreText.text = "Score: ";
        startScreen.SetActive(true);
    }
}


