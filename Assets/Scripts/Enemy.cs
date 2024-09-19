using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2.0f;

    public float currentHealth, maxHealth, dropRate = 100f;

    private Transform target = null;

    [SerializeField] HealthManager healthBar;
    [SerializeField] Score score;

    [SerializeField] GameObject powerUp;

    private void Awake()
    {
        healthBar = GetComponentInChildren<HealthManager>();
    }

    private void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    private void OnEnable()
    {
        LookAtTarget();

        maxHealth = Random.Range(50f, 100f);
        currentHealth = maxHealth;
        healthBar.UpdateEnemyHealthBar(currentHealth, maxHealth);

        //  Finds the Score Component. Clutch. I was losing my mind.
        score = FindObjectOfType<Score>();
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    private void Update()
    {
        Move();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //  PlayerBullet makes contact with Enemy
        if (collision.gameObject.tag == "Bullet")
        {
            //  SHIP HAS BEEN HIT, I REPEAT, SHIP HAS BEEN HIT
            //  Future reference, it's better to give the Player the Damage value and pass it through here
            //  But I realise this far too late.
            //  Not too late to salvage this though. Could just have a function in the Enemy script called CritRate or smth
            TakeDamage(10f);
        }

        if (collision.gameObject.tag == "Planet")
        {
            //  MISSION COMPLETE; DEATH TO THE PLANET
            Die();
        }
    }

    private void LookAtTarget()
    {
        Quaternion newRotation;
        Vector3 targetDirection = target == null ? transform.position : transform.position - target.transform.position;
        newRotation = Quaternion.LookRotation(targetDirection, Vector3.forward);
        newRotation.x = 0;
        newRotation.y = 0;
        transform.rotation = newRotation;
    }

    private void Move()
    {
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
    }

    //  Enemy takes damage from bullet function (DELETE ME)
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.UpdateEnemyHealthBar(currentHealth, maxHealth);
        if (currentHealth <= 0)
        {
            Debug.Log("Enemy died at " + transform.position);
            if (Random.value < 100f)
            {
                GameObject powerUp = ObjectPoolManager.Instance.GetPooledObject("PowerUp");
                if (powerUp != null)
                {
                    powerUp.transform.position = transform.position;
                    powerUp.SetActive(true);
                    Debug.Log("Power up spawned at " + powerUp.transform.position);
                }
                
            }

            //  Figure out how to kill the enemy without destroying gameobject?
            //  Use the object pooling thing?
            Debug.Log("ENEMY KILLED");
            gameObject.SetActive(false);

            //  Score increment
            score.UpdateScore();
        }
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }
}
