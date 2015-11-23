using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthScript : MonoBehaviour 
{
    [Tooltip("Character Health.")]
    public int health;
    [Tooltip("Area to display character health.")]
    public Text healthDisplay;

    void Start()
    {
        healthDisplay.text = health.ToString();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals("Damager"))
            Damage();
    }

    public void Damage()
    {
        if (health > 1)
        {
            health--;
            healthDisplay.text = health.ToString();
        }
        else
        {
            healthDisplay.text = "DEAD";
        }
    }
}
