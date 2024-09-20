using System.Collections;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    private Transform target = null;

    private Coroutine timerCoroutine;

    public static float powerUpDuration = 5f;

    private void Start()
    {
        target = GameObject.Find("Planet").transform;
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    private void OnEnable()
    {
        LookAtTarget();

        Debug.Log("Starting coroutine");

        if (timerCoroutine == null)
        {
            timerCoroutine = StartCoroutine(TimerCoroutine());
        }
    }

    private void OnDisable()
    {
        if (timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine);
            Debug.Log("Coroutine stopped");
        }
    }

    private IEnumerator TimerCoroutine()
    {
        float timer = powerUpDuration;

        while (timer > 0)
        {
            yield return new WaitForSeconds(1f);
            timer -= 1f;
            Debug.Log($"Power-up duration remaining: {timer}");
        }

        // Deactivate the power-up
        gameObject.SetActive(false);
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

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Planet")
        {
            //  Reuse them na
            gameObject.SetActive(false);
        }
    }
}
