using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    public Transform car;
    private Vector3 offset;
    float rotationX;
	// Use this for initializatio
	void Start()
    {
        rotationX = transform.rotation.x;
        offset = transform.position - car.position;
    }
    
	// Update is called once per frame
	void LateUpdate () {
        transform.eulerAngles = new Vector3(rotationX, car.eulerAngles.y,0);
        transform.position = car.position + offset;
	}
}
