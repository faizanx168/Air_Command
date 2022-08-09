using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scores : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int Points;

    public void Start()
    {
        Points = 0;
        scoreText.text = "Score:" + Points;
    }

    public void AddPoints(int amount)
    {
        Points = Points + amount;
        scoreText.text = "Score:" + Points;
    }
}
