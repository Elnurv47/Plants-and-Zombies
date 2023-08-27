using UnityEngine;

public class Zombie : MonoBehaviour, IDamageable
{
    private float speedForce = 120f;
    private Rigidbody rb;

    private float timer = 0;
    private float maxTimer = 1.5f;
    private bool canMove = true;

    private HealthSystem healthSystem;
    [SerializeField] private float maxHealth = 100f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        healthSystem = new HealthSystem(maxHealth);
    }

    private void Start()
    {
        healthSystem.OnDied += HealthSystem_OnDied;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > maxTimer)
        {
            timer = 0;
            canMove = true;
        }
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            rb.AddForce(Vector3.left * speedForce);
            canMove = false;
        }

        if (timer > 0.5f)
        {
            ResetVelocityAfterAddingForce();
        }
    }

    private void ResetVelocityAfterAddingForce()
    {
        if (rb.velocity.magnitude > 0)
        {
            rb.velocity = Vector3.zero;
        }
    }

    public void TakeDamage(float amount)
    {
        healthSystem.DecreaseHealth(amount);
    }

    public void HealthSystem_OnDied()
    {
        Destroy(gameObject);
    }
}
