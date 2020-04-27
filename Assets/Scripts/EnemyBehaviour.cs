using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody))]
public class EnemyBehaviour : MonoBehaviour
{
    // Enemy variables
    public float enemySpeed;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // Set Enemy velocity directed towards the Player
        if (player != null)
        {
            Rigidbody ourRigidBody = GetComponent<Rigidbody>();
            Vector3 vectorToPlayer = player.transform.position - transform.position;
            ourRigidBody.velocity = vectorToPlayer.normalized * enemySpeed;
        }
    }

}
