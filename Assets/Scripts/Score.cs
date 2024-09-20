using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private PowerUpManager powerUpManager;

    public float currentScore, enemyKill = 1f;

    void Start()
    {
        currentScore = 0f;

        scoreText.text = "Score: " + currentScore;
    }

    public void UpdateScore()
    {
       if(powerUpManager.ScoreBoostActive)
        {
            enemyKill = 2;
        }
       if(!powerUpManager.ScoreBoostActive)
        {
            enemyKill = 1;
        }
        currentScore += enemyKill;

        scoreText.text = "Score: " + currentScore;
    }
}
