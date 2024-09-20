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

    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0f;

        scoreText.text = "Score: " + currentScore;
    }

    public void UpdateScore()
    {
       if(powerUpManager.ScoreBoostActive)
        {
            //  Do the math typesh
            enemyKill = 2;
        }
       if(!powerUpManager.ScoreBoostActive)
        {
            enemyKill = 1;
        }
        currentScore += enemyKill;

        //  Display the score typesh
        scoreText.text = "Score: " + currentScore;
    }
}
