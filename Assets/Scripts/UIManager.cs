using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
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
}
