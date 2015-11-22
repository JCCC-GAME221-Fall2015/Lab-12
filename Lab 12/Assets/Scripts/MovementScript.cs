// using System;
using UnityEngine;
using System.Collections;
using System.Threading;

public class MovementScript : MonoBehaviour {
	private const float DELTA_TIME = 5.0f;

	public float xSpeed = 0.0f;
	public float ySpeed = 0.0f;
	public float zSpeed = 0.0f;

	private float xSpeedDelta = 0.0f;
	private float ySpeedDelta = 0.0f;
	private float zSpeedDelta = 0.0f;
	private float changeDirectionTime = 0.0f;
	private bool threadIsWorking = false;
	private bool doLoop = false;

	// Use this for initialization
	void Start ()
	{
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
//			xSpeedPrivate = Convert.ToSingle(rand.NextDouble());
//			ySpeedPrivate = Convert.ToSingle(rand.NextDouble());
//			zSpeedPrivate = Convert.ToSingle(rand.NextDouble());
		}
		xSpeedDelta = xSpeed * Time.deltaTime;
		ySpeedDelta = ySpeed * Time.deltaTime;
		zSpeedDelta = zSpeed * Time.deltaTime;

		float dTime = Time.deltaTime;
		doLoop = true;
		threadIsWorking = true;
		new Thread( ()=> CalcPositionDeltas(dTime)).Start();

		while (doLoop)
		{
			if (!threadIsWorking)
			{
				transform.position += new Vector3(xSpeedDelta, ySpeedDelta, zSpeedDelta);
				doLoop = false;
			}
		}
//		transform.Translate(xSpeed * Time.deltaTime, ySpeed * Time.deltaTime, zSpeed * Time.deltaTime);
	}

	void CalcPositionDeltas(float dTime)
	{
		Debug.Log("xSpeedDelta is: " + xSpeedDelta.ToString());
		float deltaX = xSpeed * dTime;
		Debug.Log("Calculated xSpeedDelta is: " + deltaX.ToString());
		threadIsWorking = false;
	}
} // end class MovementScript
