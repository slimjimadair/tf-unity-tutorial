using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletBehaviour : MonoBehaviour
{
    // Bullet variables
    public float bulletSpeed;
    public float secondsUntilDestroyed;
    public float damage;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody ourRigidBody = GetComponent<Rigidbody>();
        ourRigidBody.velocity = transform.forward * bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // Countdown to destruction and scale down at end of life
        secondsUntilDestroyed -= Time.deltaTime;

        if (secondsUntilDestroyed < 0.3)
        {
            transform.localScale = Vector3.one * secondsUntilDestroyed;
            if (secondsUntilDestroyed < 0)
            {
                Destroy(gameObject);
            }
        }

    }

    // OnCollisionEnter is called when a collision occurs
    private void OnCollisionEnter(Collision thisCollision)
    {
        // Get collision object
        GameObject theirGameObject = thisCollision.gameObject;

        // Handle enemy being hit by bullet
        if (theirGameObject.GetComponent<HealthSystem>() != null) // Check if colliding object has health
        {
            HealthSystem theirHealthSystem = theirGameObject.GetComponent<HealthSystem>();
            theirHealthSystem.TakeDamage(damage); // Inflict damage
            Destroy(gameObject); // Destroy self
        }
    }
}
