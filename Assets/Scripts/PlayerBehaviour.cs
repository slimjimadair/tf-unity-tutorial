using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerBehaviour : MonoBehaviour
{
    // Player variables -- don't set public values here as will be overridden by Inspector
    public float playerSpeed;
    public GameObject bulletPrefab;
    public float secondsBetweenShots;

    float secondsTillShot = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        // WASD (or thumbstick) to move
        Vector3 inputVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Rigidbody ourRigidBody = GetComponent<Rigidbody>();
        if (inputVector.magnitude > 0)
        {
            ourRigidBody.velocity = inputVector * playerSpeed;
        }

        // Get camera raycast
        Ray rayFromCameraToCursor = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        playerPlane.Raycast(rayFromCameraToCursor, out float distanceFromCamera);
        Vector3 cursorPosition = rayFromCameraToCursor.GetPoint(distanceFromCamera);

        // Look in the right direction
        transform.LookAt(cursorPosition); // Face input position

        // Click to fire
        secondsTillShot -= Time.deltaTime;
        if (Input.GetButton("Fire1") && secondsTillShot <= 0)
        {
            Instantiate(bulletPrefab, transform.position + transform.forward, Quaternion.LookRotation(transform.forward));
            secondsTillShot = secondsBetweenShots;
        }
    }
}
