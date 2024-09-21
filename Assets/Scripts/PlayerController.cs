using Photon.Pun;
using UnityEngine;

public class PlayerController : MonoBehaviourPunCallbacks
{
    [SerializeField] private float maxSpeed = 5.0f;
    [SerializeField] private float movementRadius = 1.5f;
    [SerializeField] private float fireRate = 0.1f;
    [SerializeField] private GameObject bullet;

    private float currentSpeed;
    private float timeCounter;

    public override void OnEnable()
    {
        base.OnEnable();
        if (!photonView.IsMine) return;
        InvokeRepeating("ShootBullet", 00.01f, fireRate);
    }

    private void Update()
    {
        if (!photonView.IsMine) return;
        HandleMovement();
        HandleRotation();
    }

    private void HandleMovement()
    {
        // Get the player input to determine the diretion of the movement
        float movementInput = Input.GetAxis("Horizontal");
        currentSpeed = movementInput * Time.deltaTime * maxSpeed;
        timeCounter += currentSpeed;

        // Circular motion based on the movement radius
        float x = Mathf.Cos(timeCounter) * movementRadius;
        float y = Mathf.Sin(timeCounter) * movementRadius;

        transform.position = new Vector2(x, y);
    }

    private void HandleRotation()
    {
        // Define a quaternion that will make the player face outwards of the circle
        Quaternion newRotation = Quaternion.LookRotation(-transform.position, Vector3.forward);
        // Disregard rotation in the x and y since we are working on 2D space
        newRotation.x = 0;
        newRotation.y = 0;
        transform.rotation = newRotation;
    }

    private void ShootBullet()
    {
        //Instantiate(bullet, transform.position, transform.rotation);
        GameObject bullet = ObjectPoolManager.Instance.GetPooledObject("Bullet");
        if (bullet != null)
        {
            bullet.transform.SetPositionAndRotation(transform.position, transform.rotation);
            bullet.gameObject.SetActive(true);
        }
    }
}
