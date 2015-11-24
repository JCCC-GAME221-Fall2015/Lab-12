using UnityEngine;
using System.Collections;
using System.Threading;

/// <summary>
/// @Author Jake Skov
/// </summary>
public class ScriptMovement : MonoBehaviour 
{
    float time;
	// Use this for initialization
	void Start () 
    {
        //Lerps Movement
        Thread lerp = new Thread(() => Vector3.Lerp(transform.position, 
            new Vector3(Random.Range(-2, 3), Random.Range(-2, 3), 0), 1f * time));

        //Starts thread
        lerp.Start();
	}
	
	// Update is called once per frame
	void Update () 
    {
        //Updates the time variable
        time = Time.deltaTime;
	}

    //Collisions
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Lost")
        {
            other.GetComponent<ScriptHealth>().health--;
        }
    }
}
