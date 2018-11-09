using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class naiveObjectMovement : MonoBehaviour {
    float x;
    float y;
    public float speed;
    public float steeringRate;

    void FixedUpdate()
    {
        //float x2 = x - (2.33f * y*y);
        transform.Translate(Vector3.forward * y * speed * Time.fixedDeltaTime, Space.Self);
        transform.Rotate(Vector3.up * x  * speed * steeringRate * Time.fixedDeltaTime);
    }

    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
    }
}
