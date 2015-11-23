// Arguments.cs
using UnityEngine;
using System.Collections;
using System.Threading;

public class Arguments : MonoBehaviour {
	
	void Start()
	{
		Thread thread = new Thread (() => DisplayMessage("Hello from the thread!"));
		thread.Start ();

		new Thread (    () =>
		            {
			Debug.Log ("I'm running on another thread!");
			Debug.Log ("This is so cool!");
		}
		).Start();

	}
	
	void DisplayMessage(string message)
	{
		Debug.Log (message);
	}
	
}
