using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField] HealthManager healthBar;
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
            TakeDamage(50f);
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
            Time.timeScale = 0f;
        }
    }
}
