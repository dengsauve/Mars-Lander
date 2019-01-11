using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrustAnimation : MonoBehaviour {

    /* Attr for usage of flame.png Mandatory: Credit "Matheus de Carvalho Oliveira" or "Matheus Carvalho" */
    public GameObject thrustRight;
    public GameObject thrustLeft;
	
	// Update is called once per frame
	void Update () {
        if (thrustLeft != null && thrustRight != null)
        {
            if (Input.GetKey("w") || Input.GetKey("up"))
            {
                thrustRight.transform.localScale = new Vector3(0.1f, 0.1f, 1);
                thrustLeft.transform.localScale = new Vector3(0.1f, 0.1f, 1);
            }
            else
            {
                thrustRight.transform.localScale = new Vector3(0.05f, 0.1f, 1);
                thrustLeft.transform.localScale = new Vector3(0.05f, 0.1f, 1);
            }
        }
	}
}
