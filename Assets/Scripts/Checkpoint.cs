using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

    public float radius = 1;
    [HideInInspector]public int id;

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, radius);
    }

	// Use this for initialization
	void Start () {
        transform.localScale = Vector3.one * 2 * radius;	
	}
	
    void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<IDChecker>())
        {
            var skrypt = collider.GetComponent<IDChecker>();
            if (skrypt.lastCheckpointId + 1 == id || (id==0 && collider.GetComponent<IDChecker>().lastCheckpointId == GetComponentInParent<SetID>().amountOfIDs-1))
            {
                Debug.Log("Checkpoint: " + id);
                skrypt.lastCheckpointId = id;
                if (id == 0)
                {
                    skrypt.rounds++;
                    Debug.Log("Rounds: " + skrypt.rounds);
                }
            }
        }
    }

	// Update is called once per frame
	void Update () {
		
	}

}