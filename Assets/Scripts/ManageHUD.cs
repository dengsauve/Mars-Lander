using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageHUD : MonoBehaviour {

    // HUD Labels
    public Text horizontalSpeedText;
    public Text verticalSpeedText;
    public Text rotationText;
    public string horizontalSpeedLabel;
    public string verticalSpeedLabel;
    public string rotationLabel;

    // Lander
    public GameObject lander;

    // Private Vars
    private Rigidbody2D rb;
    private float verticalSpeed;
    private float horizontalSpeed;
    private float rotation;

	// Use this for initialization
	void Start ()
    {
        // Assign RigidBody2D
        rb = lander.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        GetValues();
        UpdateHUD();
	}

    void GetValues()
    {
        // Get Speeds and Rotation
        verticalSpeed = (float)System.Math.Round(rb.velocity.x, 2);
        horizontalSpeed = (float)System.Math.Round(rb.velocity.y, 2);
        rotation = (float)System.Math.Round(rb.rotation, 2);
    }

    void UpdateHUD()
    {
        // Update HUD
        horizontalSpeedText.text = horizontalSpeedLabel + horizontalSpeed.ToString() + " m/s";
        verticalSpeedText.text = verticalSpeedLabel + verticalSpeed.ToString() + " m/s";
        rotationText.text = rotationLabel + rotation.ToString() + " deg";
    }
}
