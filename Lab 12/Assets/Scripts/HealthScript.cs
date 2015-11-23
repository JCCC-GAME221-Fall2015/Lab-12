// HealthScript.cs
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthScript : MonoBehaviour {
	private const int STARTING_HEALTH = 5;

	public int health;
	public Text healthDisplay;

	// Use this for initialization
	void Start ()
	{
		health = STARTING_HEALTH;
		healthDisplay.text = "Health: " + health.ToString();
	}
	
	void OnTriggerEnter(Collider hitter)
	{
		health--;
		healthDisplay.text = "Health: " + health.ToString();
	}
} // end class HealthScript
