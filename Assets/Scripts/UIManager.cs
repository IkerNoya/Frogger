using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    public GameManager manager;
    public GameObject gScreen;
    public delegate void NewLevel();
    public static event NewLevel changeLevel;
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
        changeLevel();
    }
    public void ClickOnResume()
    {
        Time.timeScale = 1;
        transform.parent.gameObject.SetActive(false);
        gScreen.SetActive(true);
    }
}
