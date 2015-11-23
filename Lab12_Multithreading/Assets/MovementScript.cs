using UnityEngine;
using System.Collections;
using System.Threading;
using System;

public class MovementScript : MonoBehaviour {

	public enum Directions
	{
		NORTH,
		EAST,
		SOUTH,
		WEST
	};

	public int damage = 1;

	public float moveSpeed = 1f;
	float moveX = 0;
	float moveZ = 0;

	public Directions direction = 0;

	public float directionChangeTime = 5f;

	Vector3 positionHold;
	Vector3 startPos;
	Vector3 endPos;
	float startTime;
	float timeDelta;
	bool hasUpdated = true;
    bool isRunning = true;

	ThreadStart moveThread;
	Thread thread;

	// Use this for initialization
	void Start () {
		startPos = transform.position;

		InvokeRepeating ("DirectionChange", 0f, directionChangeTime);
		
		moveThread = new ThreadStart (MoveObject);

		thread = new Thread (moveThread);

		thread.Start ();
	}

	// Update is called once per frame
	void Update () {
		timeDelta = Time.time;
		transform.position = positionHold;
		hasUpdated = true;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			other.GetComponent<HealthScript>().UpdateUIHealth(damage);
		}
	}

	void MoveObject()
	{
		while (isRunning) 
		{
			if(hasUpdated)
			{
				float capturedDelta = (timeDelta - startTime)/ directionChangeTime;
				positionHold = Vector3.Lerp(startPos, endPos, capturedDelta * moveSpeed);
				hasUpdated = false;
			}
		}
	}

	void DirectionChange()
	{
		int enumMax = Enum.GetValues (typeof(Directions)).Length;
		int next = UnityEngine.Random.Range (0, enumMax);

		if (direction == (Directions)next) {
			next = (next + 1) % enumMax;
		}

		moveX = moveZ = 0;

		switch ((Directions)next) {
			case Directions.NORTH:
				moveX += moveSpeed;
				break;
			case Directions.EAST:
				moveZ += moveSpeed;
				break;
			case Directions.SOUTH:
				moveX -= moveSpeed;
				break;
			case Directions.WEST:
				moveZ -= moveSpeed;
				break;
			default:
				break;
		}

		startPos = transform.position;
		startTime = timeDelta = Time.time;
		endPos = startPos + new Vector3 (moveX, 0, moveZ);
		hasUpdated = true;
	}

	void OnApplicationQuit()
	{
        isRunning = false;

        if (thread != null) {
			thread.Abort ();
				Debug.Log ("Thread aborted.");
		}

	}
}
