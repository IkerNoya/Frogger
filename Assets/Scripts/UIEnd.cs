using UnityEngine;
using UnityEngine.UI;

public class UIEnd : MonoBehaviour
{
    public Text score;
    int scoreN;
    string centerText = "                     ";
    private void Start()
    {
        score.text += "\n" + centerText + scoreN;
    }
}
