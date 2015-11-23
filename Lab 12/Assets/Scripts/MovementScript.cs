// MovementScript.cs
using UnityEngine;
using System.Collections;
using System.Threading;

public class MovementScript : MonoBehaviour {
	private const float DELTA_TIME = 5.0f;

	public float xSpeed = 0.0f;
	public float ySpeed = 0.0f;
	public float zSpeed = 0.0f;

	private float xPosition = 0.0f;
	private float yPosition = 0.0f;
	private float zPosition = 0.0f;
	private float changeDirectionTime = 0.0f;
	private bool threadIsWorking = false;
	private float dTime = 0.0f;

	// Use this for initialization
	void Start ()
	{
		xPosition = transform.position.x;
		yPosition = transform.position.y;
		zPosition = transform.position.z;
		changeDirectionTime = Time.time + DELTA_TIME;
	}

	// Update is called once per frame
	void Update ()
	{
		if ((changeDirectionTime > 0.0f) && (Time.time > changeDirectionTime))
		{
			changeDirectionTime = Time.time + DELTA_TIME;
			xSpeed = Random.Range(-0.5f, 0.5f);
			ySpeed = Random.Range(-0.5f, 0.5f);
			zSpeed = Random.Range(-0.5f, 0.5f);
		}
		xPosition = transform.position.x;
		yPosition = transform.position.y;
		zPosition = transform.position.z;
		dTime = Time.deltaTime;
		threadIsWorking = true;

		new Thread( ()=> CalcNewPosition(dTime)).Start();
		while (threadIsWorking)
		{
			// wait, or do something else
		}
		transform.position = new Vector3(xPosition, yPosition, zPosition);
	} // end method Update
	
	void CalcNewPosition(float dTime)
	{
		xPosition += xSpeed * dTime;
		yPosition += ySpeed * dTime;
		zPosition += zSpeed * dTime;
		threadIsWorking = false;
	}
} // end class MovementScript
