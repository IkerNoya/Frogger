using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData instance;
    public GameManager gameManager;
    int score;
    int gameTime;
    public static GameData Get()
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
    private void Update()
    {
        score = gameManager.GetScore();
        //gameTime = gameTime.GetTime();
    }
}
