using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    [SerializeField] PowerUpManager powerUpManager;

    public float currentScore, enemyKill = 1f;

    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0f;

        scoreText.text = "Score: " + currentScore;
    }
    
    public void UpdateScore()
    {
        if (powerUpManager.ScoreBoostActive)
        {
            currentScore += enemyKill * powerUpManager.scoreBonus;
        }
        else
        {
            currentScore += enemyKill;
        }
        scoreText.text = "Score: " + currentScore;
    }
}
