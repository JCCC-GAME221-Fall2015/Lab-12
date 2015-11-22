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
//	private float xSpeedDelta = 0.0f;
//	private float ySpeedDelta = 0.0f;
//	private float zSpeedDelta = 0.0f;
	private float changeDirectionTime = 0.0f;
	private bool threadIsWorking = false;
//	private bool doLoop = false;
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
//		xSpeedDelta = xSpeed * Time.deltaTime;
//		ySpeedDelta = ySpeed * Time.deltaTime;
//		zSpeedDelta = zSpeed * Time.deltaTime;

		xPosition = transform.position.x;
		yPosition = transform.position.y;
		zPosition = transform.position.z;
		dTime = Time.deltaTime;
//		doLoop = true;
		threadIsWorking = true;
		new Thread( ()=> CalcNewPosition(dTime)).Start();

		while (threadIsWorking) { // do stuff
			}
		transform.position = new Vector3(xPosition, yPosition, zPosition);

//		while (doLoop)
//		{
//			if (!threadIsWorking)
//			{
//				transform.position += new Vector3(xSpeedDelta, ySpeedDelta, zSpeedDelta);
//				doLoop = false;
//			}
//		}
//		transform.Translate(xSpeed * Time.deltaTime, ySpeed * Time.deltaTime, zSpeed * Time.deltaTime);
	}
	
	void CalcNewPosition(float dTime)
	{
		xPosition += xSpeed * dTime;
		yPosition += ySpeed * dTime;
		zPosition += zSpeed * dTime;

//		float xSpeedDelta = xSpeed * dTime;
//		float ySpeedDelta = ySpeed * dTime;
//		float zSpeedDelta = zSpeed * dTime;
////		SetNewPosition(xSpeed * dTime, ySpeed * dTime, zSpeed * dTime);

//		Debug.Log("xSpeed is: " + xSpeed.ToString());
//		Debug.Log("ySpeed is: " + ySpeed.ToString());
//		Debug.Log("zSpeed is: " + zSpeed.ToString());
//		Debug.Log("xSpeedDelta is: " + xSpeedDelta.ToString());
//		Debug.Log("ySpeedDelta is: " + ySpeedDelta.ToString());
//		Debug.Log("zSpeedDelta is: " + zSpeedDelta.ToString());
//		SetNewPosition(xSpeed * dTime, ySpeed * dTime, zSpeed * dTime);
		threadIsWorking = false;

//		Debug.Log("xSpeedDelta is: " + xSpeedDelta.ToString());
//		float deltaX = xSpeed * dTime;
//		Debug.Log("Calculated xSpeedDelta is: " + deltaX.ToString());
//		threadIsWorking = false;
	}
	
//	public void SetNewPosition(float xSpeedDelta, float ySpeedDelta, float zSpeedDelta)
//	{
//		Debug.Log("Hello from method 'SetNewPosition'");
////		transform.position += new Vector3(xSpeedDelta, ySpeedDelta, zSpeedDelta);
////		threadIsWorking = false;
//	}

//	void CalcPositionDeltas(float dTime)
//	{
//		Debug.Log("xSpeedDelta is: " + xSpeedDelta.ToString());
//		float deltaX = xSpeed * dTime;
//		Debug.Log("Calculated xSpeedDelta is: " + deltaX.ToString());
//		threadIsWorking = false;
//	}
} // end class MovementScript
