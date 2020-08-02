using UnityEngine;
using UnityEngine.UI;

public class UIEnd : MonoBehaviour
{
    public Text score;
    GameManager manager;
    string centerText = "                     ";
    private void Start()
    {
        manager = GameManager.Get();
        score.text += "\n" + centerText + manager.GetScore().ToString();
    }
}
