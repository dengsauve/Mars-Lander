using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInit : MonoBehaviour {

    public int fuelReserves;

	void Start () {
        GameStats.FuelReserves = fuelReserves;
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex == 0) Time.timeScale = 0.0f;
	}
}
