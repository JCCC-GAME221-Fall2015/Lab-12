// Names.cs
using UnityEngine;
using System.Collections;
using System.Threading;

public class Names : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Thread.CurrentThread.Name = "main";
		Thread worker = new Thread (Go);
		worker.Name = "worker";
		worker.Start();
		Go();
	}
	
	void Go()
	{
		Debug.Log ("Hello from " + Thread.CurrentThread.Name);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
