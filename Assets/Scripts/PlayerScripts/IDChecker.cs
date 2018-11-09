using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDChecker : MonoBehaviour {

    [HideInInspector] public int rounds = -1;
    [HideInInspector] public int lastCheckpointId = -1;
    /*private static int lastId = 0;
    public int id;*/

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        if (rounds == RoundsManager.instance.numberOfRounds)
        {
            gameObject.AddComponent<AutoDriver>();
            Destroy(gameObject.GetComponent<naiveObjectMovement>());
            Destroy(this);
        }
	}
}
