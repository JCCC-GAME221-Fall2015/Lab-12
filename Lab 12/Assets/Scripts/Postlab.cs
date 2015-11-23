// Postlab.cs
using UnityEngine;
using System.Collections;
using System.Threading;

public class Postlab : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		string text = "t1";
		Thread t1 = new Thread( () => Debug.Log (text));
		
		text = "t2";
		Thread t2 = new Thread (() => Debug.Log (text));
		
		t1.Start ();
		t2.Start ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
