using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPause : MonoBehaviour
{
    public GameManager manager;
    public Text score;
    void Update()
    {
        score.text = manager.GetScore().ToString();
    }
}
