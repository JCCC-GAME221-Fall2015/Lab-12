using UnityEngine;
using System.Collections;
using System.Threading;

// Author: nathan Boehning
// Purpose: Move cubes around the screen
// Couldn't figure out transform.translate using threads.
public class ScriptMovement : MonoBehaviour
{
	private Vector2 moveDir;
	public float moveSpeed = 0.25f;
	private Thread moveThread;

	// Use this for initialization
	void Start ()
	{
		//moveThread = new Thread(MoveObject);
		//moveThread = new Thread(Update);
		//moveThread.Name = "Main";

		// Change the direction every 5 seconds
		InvokeRepeating("UpdateDirection", 0.0f, 5.0f);
		//moveThread.Start();
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Translate the object
		transform.Translate(moveDir * Time.deltaTime * moveSpeed);
	}

	void MoveObject()
	{
		//transform.Translate(moveDir * Time.deltaTime * moveSpeed);
	}

	// Randomly change the direction the cube moves
	void UpdateDirection()
	{
		moveDir = new Vector2(Random.Range(-1, 1), Random.Range(-1, 1));
	}

	void OnCollisionEnter(Collision other)
	{
		Debug.Log(other.transform.tag);
		if (other.transform.tag == "Player")
		{
			Debug.Log("Gets to collision");
			other.gameObject.GetComponent<ScriptHealth>().RemoveHealth(1);
		}
	}
}
