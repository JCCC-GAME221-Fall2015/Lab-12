using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class health : MonoBehaviour {

    public int healthAmount = 5;
    public Text healthText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        healthText.text = healthAmount.ToString();
	}
}
