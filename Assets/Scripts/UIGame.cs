using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIGame : MonoBehaviour
{
    public Player player;
    public TextMeshProUGUI lives;
    void Update()
    {
        lives.text = "LIVES: " + player.GetLives().ToString(); 
    }
}
