﻿using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    GameData data;

    public GameObject PauseScreen;
    public GameObject VictoryScreen;
    public GameObject GameScreen;
    public Player player;
    int score;
    float timer;
    int gainAmmount = 150;

    void Start()
    {
        data = GameData.Get();
        PauseScreen.SetActive(false);
        VictoryScreen.SetActive(false);
        Player.victory += SetVictory;
        Player.pause += SetPause;
        Player.gameOver += EndGame;
    }

    void Update()
    {
        timer += Time.deltaTime;
    }
    public void SetPause()
    {
        if (PauseScreen.activeSelf)
        {
            GameScreen.SetActive(true);
            PauseScreen.SetActive(false);
            player.SetIsPaused(false);
        }
        else
        {
            GameScreen.SetActive(false);
            PauseScreen.SetActive(true);
            player.SetIsPaused(true);
        }
    }
    void EndGame()
    {
        data.SetScore(score);
        SceneManager.LoadScene("End");
    }
    public void SetVictory()
    {
        if (VictoryScreen.activeSelf)
        {
            VictoryScreen.SetActive(false);
            player.SetIsPaused(false);
            GameScreen.SetActive(true);
        }
        else
        {
            VictoryScreen.SetActive(true);
            GameScreen.SetActive(false);
            if (player.GetLives() == 3)
            {
                score += gainAmmount * 5;
            }
            else if (player.GetLives() == 2)
            {
                score += gainAmmount * 2;
            }
            else
            {
                score += gainAmmount;
            }
            player.SetIsPaused(true);
        }
    }
    public float GetTimer()
    {
        return timer;
    }
    public void ResetTimer()
    {
        timer = 0;
    }
    public int GetScore()
    {
        return score;
    }
    public void Restart()
    {
        player.Restart();
        ResetTimer();
        SetVictory();
        player.SetIsPaused(false);
    }
    public void ResetGame()
    {
        score = 0;
    }
    private void OnDisable()
    {
        Player.gameOver -= EndGame;
        Player.pause -= SetPause;
        Player.victory -= SetVictory;
    }
}
