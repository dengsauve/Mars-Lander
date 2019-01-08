using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrustAnimation : MonoBehaviour {

    /* Attr for usage of flame.png Mandatory: Credit "Matheus de Carvalho Oliveira" or "Matheus Carvalho" */
    public GameObject thrustRight;
    public GameObject thrustLeft;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey("w") || Input.GetKey("up"))
        {
            thrustRight.transform.localScale = new Vector3(0.1f, 0.1f, 1);
            //thrustRight.transform.position = new Vector3(0.111f, -0.4f, 0) + transform.position;
            thrustLeft.transform.localScale = new Vector3(0.1f, 0.1f, 1);
            //thrustLeft.transform.position = new Vector3(-0.111f, -0.4f, 0) + transform.position;
        }
        else
        {
            thrustRight.transform.localScale = new Vector3(0.05f, 0.1f, 1);
            //thrustRight.transform.position = new Vector3(0.111f, -0.3f, 0);
            thrustLeft.transform.localScale = new Vector3(0.05f, 0.1f, 1);
            //thrustLeft.transform.position = new Vector3(-0.111f, -0.3f, 0);
        }
	}
}
