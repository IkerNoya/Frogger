﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    public GameManager manager;
    public GameObject gScreen;
    public void ClickOnGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void ClickOnCredits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void ClickOnMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void ClickOnControl()
    {
        SceneManager.LoadScene("Controls");
    }
    public void ClickOnQuit()
    {
        Application.Quit();
    }
    public void ClickOnContinue()
    {
        Time.timeScale = 1;
        manager.Restart();
    }
    public void ClickOnResume()
    {
        Time.timeScale = 1;
        transform.parent.gameObject.SetActive(false);
        gScreen.SetActive(true);
    }
}
