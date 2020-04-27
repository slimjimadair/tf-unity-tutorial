using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoreBehaviour : MonoBehaviour
{
    // Gore variables
    public float goreLifetime;
    public float goreScale;
    public float goreSpeed;

    float goreAge = 0;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        goreAge += Time.deltaTime;
        float currentScale = goreScale * (1 - (goreAge / goreLifetime));
        transform.localScale = currentScale * Vector3.one;
        if (goreAge >= goreLifetime)
        {
            Destroy(gameObject);
        }
    }
}
