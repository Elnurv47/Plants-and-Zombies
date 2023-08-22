using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 10f;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider collider)
    {
        GameObject collidedObject = collider.gameObject;

        if (collidedObject.TryGetComponent(out IDamageable damageable))
        {
            Destroy(gameObject);
            damageable.TakeDamage();
        }
    }
}
