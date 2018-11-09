using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDriver : MonoBehaviour {

    Transform Checkpoints;
    int i;
    int j;
    float x;
    private float speed = 30;
    private float steeringRate = 3;
    // Use this for initialization
    void Start () {
        i = 0;
        Checkpoints = GameObject.Find("Checkpointy").transform;
	}

    /*IEnumerator Skret()
    {
        while()
        yield return null;
    }*/

    void FixedUpdate()
    {
        //float x2 = x - (2.33f * y*y);
        transform.Translate(Vector3.forward * speed * Time.fixedDeltaTime, Space.Self);
        transform.Rotate(Vector3.up * x * speed * steeringRate * Time.fixedDeltaTime);
    }

    // Update is called once per frame
    void Update () {
        transform.position = Vector3.MoveTowards(transform.position,Checkpoints.GetChild(i).position, 30 * Time.deltaTime);
        if (transform.position == Checkpoints.GetChild(i).position)
            i++;
        i = (i >= Checkpoints.GetComponent<SetID>().amountOfIDs) ? 0 : i;
        
        transform.LookAt(Checkpoints.GetChild(i));
      
        /*
        x = Input.GetAxis("Horizontal");
        i = (i >= Checkpoints.GetComponent<SetID>().amountOfIDs) ? 0 : i;
        Vector3 currentCheck = Checkpoints.GetChild(i).position;
        j = i++;
        j = (j >= Checkpoints.GetComponent<SetID>().amountOfIDs) ? 0 : j;
        Vector3 carPosition = transform.position;
        Vector3 carRotation = transform.rotation.eulerAngles;
        Debug.Log("Car rotation: " + carRotation.x);
        Vector3 targetCheck = Checkpoints.GetChild(j).position;
        */
    }
}
