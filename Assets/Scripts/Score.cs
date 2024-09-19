using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    public float currentScore, enemyKill = 1f, bonus = 1f;

    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0f;

        scoreText.text = "Score: " + currentScore;
    }

    public void UpdateScore()
    {
        //  Do the math typesh
        enemyKill *= bonus;
        currentScore += enemyKill;

        //  Display the score typesh
        scoreText.text = "Score: " + currentScore;
    }
}
