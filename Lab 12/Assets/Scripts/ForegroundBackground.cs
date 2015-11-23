// ForegroundBackground.cs
using UnityEngine;
using System.Collections;
using System.Threading;

public class ForegroundBackground : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		Thread worker = new Thread (Go);
		worker.Name = "worker";
		Debug.Log ("is worker background? " + worker.IsBackground);
		worker.IsBackground = true;
		Debug.Log ("is worker background? " + worker.IsBackground);
		worker.Start ();
	}

	void Go()
	{
		Debug.Log ("Hello from " + Thread.CurrentThread.Name);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
