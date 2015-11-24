using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// @Author Jake Skov
/// </summary>
public class ScriptHealth : MonoBehaviour 
{
    public int health = 10;
    public Text healthText;
	
	// Update is called once per frame
	void Update () 
    {
        //Updates the UI
        healthText.text = health.ToString();
	}
}
