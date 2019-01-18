using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageHUD : MonoBehaviour {

    // HUD Labels
    public Text horizontalSpeedText;
    public Text verticalSpeedText;
    public Text rotationText;
    public Text fuelReserveText;
    public Text scoreText;
    public Text lowFuelText;
    public string horizontalSpeedLabel;
    public string verticalSpeedLabel;
    public string rotationLabel;
    public string fuelReserveLabel;
    public string scoreLabel;

    // Lander
    public GameObject lander;

    // Private Vars
    private Rigidbody2D rb;
    private ControlLander cl;
    private float verticalSpeed;
    private float horizontalSpeed;
    private float rotation;

    // Start Menu
    public GameObject startMenu;
    private Button startButton;

    // Pause Menu
    public GameObject pauseMenu;
    private Button restartButton;

    // Low Fuel Warning
    public GameObject lowFuelWarning;

	// Use this for initialization
	void Start ()
    {
        // Assign RigidBody2D
        rb = lander.GetComponent<Rigidbody2D>();
        cl = lander.GetComponent<ControlLander>();
        restartButton = pauseMenu.GetComponent<Button>();
        startButton = startMenu.GetComponent<Button>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown("escape") || Input.GetKeyDown("p")) TogglePauseMenu();
	}

    void FixedUpdate()
    {
        GetValues();
        UpdateHUD();
        UpdateWarning();
    }

    void GetValues()
    {
        // Get Speeds and Rotation
        verticalSpeed = (float)System.Math.Round(rb.velocity.y, 2);
        horizontalSpeed = (float)System.Math.Round(rb.velocity.x, 2);
        rotation = (float)System.Math.Round(rb.rotation, 2);
    }

    void UpdateHUD()
    {
        // Update HUD
        horizontalSpeedText.text = horizontalSpeed.ToString() + " m/s : " + horizontalSpeedLabel;
        verticalSpeedText.text = verticalSpeed.ToString() + " m/s : " + verticalSpeedLabel;
        rotationText.text = rotation.ToString() + " deg : " + rotationLabel;
        fuelReserveText.text = fuelReserveLabel + ": " + GameStats.FuelReserves.ToString() + " L";
    }

    void UpdateWarning()
    {
        if (GameStats.FuelReserves < 200 && lowFuelWarning.activeSelf == false)
        {
            lowFuelWarning.SetActive(true);
        }
        else if(GameStats.FuelReserves < 200 && lowFuelWarning.activeSelf == true)
        {
            lowFuelText.text = GameStats.FuelReserves.ToString() + " L";
        }
        else if(lowFuelWarning.activeSelf == true && GameStats.FuelReserves >= 200)
        {
            lowFuelWarning.SetActive(false);
        }
    }

    void TogglePauseMenu()
    {
        Debug.Log("Pause Menu Called");
        if(pauseMenu.activeSelf)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1.0f;
        }
        else
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

    //Reloads the Level
    public void Reload()
    {
        TogglePauseMenu();
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    // Starts Game
    public void StartGame()
    {
        Time.timeScale = 1.0f;
        startMenu.SetActive(false);
    }
}
