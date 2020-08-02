using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIGame : MonoBehaviour
{
    public Player player;
    public GameManager manager;
    public TextMeshProUGUI lives;
    public TextMeshProUGUI time;
    public TextMeshProUGUI score;
    void Update()
    {
        lives.text = "LIVES: " + player.GetLives().ToString();
        time.text = ((int)manager.GetTimer()).ToString();
        score.text = manager.GetScore().ToString();
    }
}
