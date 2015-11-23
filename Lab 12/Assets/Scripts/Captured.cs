// Captured.cs
using UnityEngine;
using System.Collections;
using System.Threading;

public class Captured : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		Debug.Log("First for loop:");
		for(int i = 1; i <= 10; i++)
		{
			new Thread( ()=> Debug.Log (i)).Start();
		}

		Thread.Sleep(1000);
		Debug.Log("Second for loop:");

		for(int i = 11; i <= 20; i++)
		{
			int temp = i;
			new Thread( ()=> Debug.Log (temp)).Start();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
