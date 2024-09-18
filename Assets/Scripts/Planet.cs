using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField] PlanetHealthManager healthBar;
    [SerializeField] Enemy enemy;
    [SerializeField] GameObject gameOverScreen;

    public float currentHealth, maxHealth;

    private void Start()
    {
        maxHealth = 1000f;
        currentHealth = maxHealth;
        healthBar.UpdateHealthBar(currentHealth, maxHealth);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //  I tried making it the enemy's currentHP, nah I gave up after it didn't work the first time.
            TakeDamage(100f);
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.UpdateHealthBar(currentHealth, maxHealth);
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
