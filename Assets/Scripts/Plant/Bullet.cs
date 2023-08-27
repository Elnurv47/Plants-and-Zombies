using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float damageAmount = 50f;
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
            damageable.TakeDamage(damageAmount);
        }
    }
}
