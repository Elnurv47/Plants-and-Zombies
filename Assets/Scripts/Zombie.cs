using UnityEngine;

public class Zombie : MonoBehaviour
{
    private float speedForce = 80f;
    private Rigidbody rigidBody;

    private float timer = 0;
    private float maxTimer = 1.5f;
    private bool canMove = true;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
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
            rigidBody.AddForce(Vector3.left * speedForce);
            canMove = false;
        }

        if (timer > 0.5f)
        {
            ResetVelocityAfterAddingForce();
        }
    }

    private void ResetVelocityAfterAddingForce()
    {
        if (rigidBody.velocity.magnitude > 0)
        {
            rigidBody.velocity = Vector3.zero;
        }
    }
}
