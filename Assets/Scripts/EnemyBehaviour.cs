using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    // Enemy variables
    public float enemySpeed;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Set Enemy velocity directed towards the Player
        Rigidbody ourRigidBody = GetComponent<Rigidbody>();
        Vector3 vectorToPlayer = player.transform.position - transform.position;
        ourRigidBody.velocity = vectorToPlayer.normalized * enemySpeed;
    }

    // OnCollisionEnter is called when a collision occurs
    private void OnCollisionEnter(Collision thisCollision)
    {
        // Get collision object
        GameObject theirGameObject = thisCollision.gameObject;

        // Handle enemy being hit by bullet
        if (theirGameObject.GetComponent<BulletBehaviour>() != null) // Check if colliding object is a bullet
        {
            Destroy(theirGameObject); // Destroy bullet
            Destroy(gameObject); // Destroy enemy
        }
    }
}
