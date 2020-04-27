using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    // Bullet variables
    public float bulletSpeed;
    public float secondsUntilDestroyed;

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
}
