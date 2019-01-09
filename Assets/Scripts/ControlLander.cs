using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlLander : MonoBehaviour {

    private Rigidbody2D rb;
    private Scene scene;
    private int currentSceneIndex;

    public float thrustPower;
    private int thrust = 0;
    private float lastSpeed;

    private int rotate = 0;
    public float rotateMod;

    public int maxLandSpeed;

    public int fuelReserve;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        scene = SceneManager.GetActiveScene();
        Debug.Log(scene.buildIndex.ToString() + " has loaded");
        currentSceneIndex = scene.buildIndex;
	}
	
	// Update is called once per frame
	void Update () {
		// Get Input
        if(Input.GetKey("w") || Input.GetKey("up") || Input.GetKey("space")) thrust = 1;
        if (Input.GetKey("d") || Input.GetKey("right")) rotate = -1;
        if (Input.GetKey("a") || Input.GetKey("left")) rotate = 1;
    }

    void FixedUpdate()
    {
        // Apply Physics
        RotateLander();
        ThrustLander();
        
        // Store last y velocity
        lastSpeed = rb.velocity.y;

        // Reset Controls
        thrust = 0;
        rotate = 0;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Lander collided with object. Y speed: " + lastSpeed);
        if (Mathf.Abs(lastSpeed) > maxLandSpeed || Mathf.Abs(rb.rotation) > 5)
        {
            //Destroy(gameObject);
            SceneManager.LoadScene(0);
        }
        else if(col.gameObject.tag == "Obstacle")
        {
            SceneManager.LoadScene(scene.buildIndex);
        }
        else if(col.gameObject.tag == "Finish")
        {
            // Calculate Score

            // Load Next Level
            if (SceneManager.GetSceneByBuildIndex(currentSceneIndex + 1) != null)
            {
                SceneManager.LoadScene(currentSceneIndex + 1);
            }
        }
    }

    void RotateLander()
    {
        // Apply Rotational Physics
        if (rb.rotation <= 90 && rb.rotation >= -90)
        {
            rb.MoveRotation(rb.rotation + rotate * rotateMod);
        }
        if (rb.rotation > 90) rb.MoveRotation(90);
        if (rb.rotation < -90) rb.MoveRotation(-90);
    }

    void ThrustLander()
    {
        // Apply Thrust Physics
        if (fuelReserve > 0)
        {
            // Figure angle thrust
            float x = -1 * thrust * thrustPower * Mathf.Sin(transform.rotation.eulerAngles.z / 180.0f * Mathf.PI);
            float y = thrust * thrustPower * Mathf.Cos(transform.rotation.eulerAngles.z / 180.0f * Mathf.PI);
            
            // Create and add force
            Vector2 movement = new Vector2(x, y);
            rb.AddForce(movement);
            
            // Subtract 1 whole fuel
            if(thrust == 1) fuelReserve -= 1;
        }
    }
}
