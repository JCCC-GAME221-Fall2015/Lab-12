using UnityEngine;
using System.Collections;
using System.Threading;

public class movement : MonoBehaviour {

    GameObject sphere;
    health healthScript;

	// Use this for initialization
	void Start () {
        sphere = GameObject.Find("HealthObject").gameObject;
        healthScript = sphere.GetComponent<health>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, sphere.transform.position, 1);
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Detected Collision");
        if(other.gameObject.name == "HealthObject")
        {
            Debug.Log("Removing health");
            RemoveHealth();
        }
    }

    void RemoveHealth()
    {
        healthScript.healthAmount = healthScript.healthAmount - 1;
    }


}
