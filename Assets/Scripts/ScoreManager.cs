using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int score;
    [SerializeField] private Text scoreText;


    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = score.ToString();
    }

}
