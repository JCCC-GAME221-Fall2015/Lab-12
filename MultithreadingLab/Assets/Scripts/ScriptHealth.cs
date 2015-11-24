using UnityEngine;
using System.Collections;
using UnityEngine.UI;


// Author: Nathan Boehning
// Purpose: Updates the spheres health

public class ScriptHealth : MonoBehaviour
{
	Text healthText; // displays the spheres health
	public int health = 5;  // Stores spheres health

	// Use this for initialization
	void Start ()
	{
		// Finds and sets the intitial health text field 
		healthText = GameObject.Find("HealthText").GetComponent<Text>();
		SetHealthText();
	}

	// Function that can be called to remove health
	public void RemoveHealth(int toRemove)
	{
		health -= toRemove;
		SetHealthText();
		
	}

	// Updates the health text on screen
	void SetHealthText()
	{
		healthText.text = "Sphere Health: " + health;
	}
}
