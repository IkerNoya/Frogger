using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    void ClickOnGame()
    {
        SceneManager.LoadScene("Game");
    }
    void ClickOnCredits()
    {
        SceneManager.LoadScene("Credits");
    }
    void ClickOnMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    void ClickOnControl()
    {
        SceneManager.LoadScene("Controls");
    }
}
