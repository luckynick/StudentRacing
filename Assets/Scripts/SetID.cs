using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetID : MonoBehaviour {

    [HideInInspector] public float amountOfIDs;

	// Use this for initialization
	void Start () {
		for(int i = 0; i < transform.childCount;i++)
        {
            if(i == 0)
            {
                Material mat = transform.GetChild(i).GetComponent<Renderer>().material;

                Color color = Color.red * new Color(1,1,1,mat.color.a);
                mat.color = color;
            }
            transform.GetChild(i).GetComponent<Checkpoint>().id=i;
        }
        amountOfIDs = transform.childCount;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
