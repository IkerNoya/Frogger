using UnityEngine;
using UnityEngine.UI;

public class UIEnd : MonoBehaviour
{
    public Text score;
    GameData data;
    int scoreN;
    string centerText = "                       ";
    private void Start()
    {
        data = GameData.Get();
        score.text += "\n" + centerText + data.GetScore();
    }
}
