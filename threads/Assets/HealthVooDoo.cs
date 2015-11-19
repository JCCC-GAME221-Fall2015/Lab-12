using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Author: Matt Gipson
/// Contact: Deadwynn@gmail.com
/// Domain: www.livingvalkyrie.com
/// 
/// Description: HealthVooDoo 
/// </summary>
public class HealthVooDoo : MonoBehaviour {
    #region Fields

    public int health = 5;
    public Text healthText;

    #endregion
    
    void Update() {
        healthText.text = "health: " + health;
    }

}