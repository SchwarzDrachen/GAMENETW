using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2.0f;

    float currentHealth, maxHealth;

    private Transform target = null;

    [SerializeField] HealthManager healthBar;

    private void Awake()
    {
        healthBar = GetComponentInChildren<HealthManager>();
    }

    private void Start()
    {
        //  I set maxHealth to random (DELETE ME)
        maxHealth = Random.Range(1f, 4f);
        currentHealth = maxHealth;
        healthBar.UpdateHealthBar(currentHealth, maxHealth);
        target = GameObject.Find("Player").transform;
    }

    private void OnEnable(){
        LookAtTarget();
    }

    public void SetTarget(Transform target){
        this.target = target;
    }

    private void Update(){
        Move();

        //  If gameObject collides with prefab "playerBullet", take damage
        if (Physics2D.Raycast(transform.position, Vector2.zero, 0.5f, LayerMask.GetMask("PlayerBullet")))
        {
            TakeDamage(10f);
        }
    }
    
    private void LookAtTarget(){
        Quaternion newRotation;
        Vector3 targetDirection = target == null ? transform.position : transform.position - target.transform.position;
        newRotation = Quaternion.LookRotation(targetDirection, Vector3.forward);
        newRotation.x = 0;
        newRotation.y = 0;
        transform.rotation = newRotation;
    }

    private void Move(){
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
    }

    //  Enemy takes damage from bullet function (DELETE ME)
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
