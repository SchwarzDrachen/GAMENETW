using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    private Transform target = null;

    private void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    private void OnEnable()
    {
        LookAtTarget();

        Debug.Log("I really spawned at " + transform.position);
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

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Activate power-up effects
            Debug.Log("Power-up collected!");
            Destroy(gameObject);
        }
    }
}