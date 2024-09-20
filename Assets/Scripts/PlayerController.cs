using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float maxSpeed = 5.0f;
    [SerializeField] private float movementRadius = 1.5f;
    [SerializeField] private float fireRate = 0.1f;
    [SerializeField] private GameObject bullet;
    [SerializeField] GameObject damageBoost;
    [SerializeField] GameObject scoreBoost;
    [SerializeField] PowerUpManager powerUpManager;

    private float currentSpeed;
    private float timeCounter;

    private void Start(){
        InvokeRepeating("ShootBullet", 00.01f, fireRate);
    }

    private void Update(){
        HandleMovement();
        HandleRotation();
    }
    private IEnumerator DamagePowerTimer()
    {
        yield return new WaitForSeconds(10.0f);
        powerUpManager.DamageBoostActive = false;
    }

    private IEnumerator ScorePowerTimer()
    {
        yield return new WaitForSeconds(10.0f);
        powerUpManager.ScoreBoostActive = false;
    }

    private void HandleMovement(){
        // Get the player input to determine the diretion of the movement
        float movementInput = Input.GetAxis("Horizontal");
        currentSpeed = movementInput * Time.deltaTime * maxSpeed;
        timeCounter += currentSpeed;

        // Circular motion based on the movement radius
        float x = Mathf.Cos(timeCounter) * movementRadius;
        float y = Mathf.Sin(timeCounter) * movementRadius;

        transform.position = new Vector2(x,y);
    }

    private void HandleRotation(){
        // Define a quaternion that will make the player face outwards of the circle
        Quaternion newRotation = Quaternion.LookRotation(-transform.position, Vector3.forward);
        // Disregard rotation in the x and y since we are working on 2D space
        newRotation.x = 0;
        newRotation.y = 0;
        transform.rotation = newRotation;
    }

    private void ShootBullet(){
        GameObject bullet = ObjectPoolManager.Instance.GetPooledObject("Bullet");
        if(bullet != null){
            bullet.transform.SetPositionAndRotation(transform.position, transform.rotation);
            bullet.gameObject.SetActive(true);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DamageBoost")
        {
            if (!powerUpManager.ScoreBoostActive)
            {
                // Activate power-up effects
                powerUpManager.DamageBoostActive = true;

                collision.gameObject.SetActive(false);
                StartCoroutine(DamagePowerTimer());
            }
        }

        if (collision.gameObject.tag == "ScoreBoost")
        {
            if(!powerUpManager.DamageBoostActive)
            {
                // Activate power-up effects
                powerUpManager.ScoreBoostActive = true;

                collision.gameObject.SetActive(false);
                StartCoroutine(ScorePowerTimer());
            }
        }
    }
}
