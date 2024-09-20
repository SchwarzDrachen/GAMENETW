using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField] HealthManager healthBar;
    [SerializeField] Enemy enemy;
    [SerializeField] GameObject gameOverScreen;

    [SerializeField] PowerUpManager powerUpManager;

    public float currentHealth, maxHealth;

    private void Start()
    {
        maxHealth = 1000f;
        currentHealth = maxHealth;
        healthBar.UpdatePlanetHealthBar(currentHealth, maxHealth);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //  I tried making it the enemy's currentHP, nah I gave up after it didn't work the first time.
            TakeDamage(100f);
        }

        if (collision.gameObject.tag == "DamageBoost")
        {
            // Activate power-up effects
            powerUpManager.DamageBoostActive = true;

            Debug.Log("Damage Boost for 10 seconds.");
        }

        if (collision.gameObject.tag == "ScoreBoost")
        {
            // Activate power-up effects
            powerUpManager.ScoreBoostActive = true;

            Debug.Log("Score Boost for 10 seconds.");
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.UpdatePlanetHealthBar(currentHealth, maxHealth);
        if (currentHealth <= 0)
        {
            //  GAME OVER
            Debug.Log("GAME OVER");
            gameOverScreen.SetActive(true);
            //  Yeah, no. I'm not doing a whole game handler/manager. Nakakatamad typesh. Ayokong mag add rin ng Restart button.
            /*gameHandler.PauseGame;*/
            Time.timeScale = 0f;
        }
    }
}
