using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public GameObject PauseScreen;
    public GameObject VictoryScreen;
    public Player player;
    int score;
    int livesUsed;
    int gainAmmount = 150;

    // Start is called before the first frame update
    void Start()
    {
        PauseScreen.SetActive(false);
        VictoryScreen.SetActive(false);
        Player.victory += SetVictory;
        Player.pause += SetPause;
        Player.gameOver += EndGame;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null && VictoryScreen !=null && PauseScreen !=null)
            return;
        FindReferences();
    }
    public void SetPause()
    {
        if (PauseScreen.activeSelf)
        {
            PauseScreen.SetActive(false);
            player.SetIsPaused(false);
        }
        else
        {
            PauseScreen.SetActive(true);
            player.SetIsPaused(true);
        }
    }
    void EndGame()
    {
        SceneManager.LoadScene("End");
        player = null;
        PauseScreen = null;
        VictoryScreen = null;
    }
    public void SetVictory()
    {
        if (VictoryScreen.activeSelf)
        {
            VictoryScreen.SetActive(false);
            player.SetIsPaused(false);
        }
        else
        {
            VictoryScreen.SetActive(true);
            if (player.GetLives() == 3)
            {
                score += gainAmmount * 5;
                livesUsed = 0;
            }
            else if (player.GetLives() == 2)
            {
                score += gainAmmount * 2;
                livesUsed = 1;
            }
            else
            {
                score += gainAmmount;
                livesUsed = 2; 
            }
            player.SetIsPaused(true);
        }
    }
    public int GetScore()
    {
        return score;
    }
    IEnumerator FindPlayer()
    {
        yield return new WaitForSeconds(0.2f);
        player = FindObjectOfType<Player>();
        StopCoroutine(FindPlayer());
        yield return null;
    }
    IEnumerator FindScreens()
    {
        yield return new WaitForSeconds(0.2f);
        PauseScreen = GameObject.FindGameObjectWithTag("pause");
        VictoryScreen = GameObject.FindGameObjectWithTag("V_screen");
        StopCoroutine(FindScreens());
        yield return null;
    }
    public void FindReferences()
    {
        StartCoroutine(FindPlayer());
        StartCoroutine(FindScreens());
    }
    public void Restart()
    {
        player.Restart();
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
