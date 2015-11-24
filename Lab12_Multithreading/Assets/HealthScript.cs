using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour {

	public int health = 10;
	public Text uiText;

	// Use this for initialization
	void Start () {
		UpdateUIHealth (0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void UpdateUIHealth(int dmg)
	{
		health -= dmg;
		uiText.text = health.ToString();
	}
}
