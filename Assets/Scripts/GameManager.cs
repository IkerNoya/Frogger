using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SocialPlatforms.GameCenter;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public GameObject PauseScreen;
    public GameObject VictoryScreen;
    public Player player;
    public static GameManager Get()
    {
        return instance;
    }
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        PauseScreen.SetActive(false);
        VictoryScreen.SetActive(false);
        Player.victory += SetVictory;
        Player.pause += SetPause;
    }

    // Update is called once per frame
    void Update()
    {
        
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
            player.SetIsPaused(true);
        }
    }
    public void Restart()
    {
        player.Restart();
        SetVictory();
        player.SetIsPaused(false);
    }
    private void OnDisable()
    {
        Player.pause -= SetPause;
        Player.victory -= SetVictory;
    }
}
