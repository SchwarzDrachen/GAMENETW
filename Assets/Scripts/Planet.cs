using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField] EnemyHealthManager healthBar;

    public float currentHealth, maxHealth;

    private void Start()
    {
        maxHealth = 1000f;
        currentHealth = maxHealth;
        healthBar.UpdateHealthBar(currentHealth, maxHealth);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //  PlayerBullet makes contact with Enemy
        if (collision.gameObject.tag == "Bullet")
        {
            //  SHIP HAS BEEN HIT, I REPEAT, SHIP HAS BEEN HIT
            TakeDamage(10f);
        }

        if (collision.gameObject.tag == "Planet")
        {
            //  MISSION COMPLETE; DEATH TO THE PLANET
            TakeDamage(100f);
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.UpdateHealthBar(currentHealth, maxHealth);
        if (currentHealth <= 0)
        {
            //  Figure out how to kill the enemy without destroying gameobject?
            //  Use the object pooling thing?
            Debug.Log("ENEMY KILLED");
            gameObject.SetActive(false);
        }
    }
}
