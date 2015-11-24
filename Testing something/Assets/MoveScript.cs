using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour {

    public GameObject sphere;
    public HealthScript healthScript;

	// Use this for initialization
	void Start () {
        healthScript = sphere.GetComponent<HealthScript>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, sphere.transform.position, 1);
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Detected Collision");
        if(other.gameObject == sphere)
        {
            healthScript.health--;
        }
    }
}
