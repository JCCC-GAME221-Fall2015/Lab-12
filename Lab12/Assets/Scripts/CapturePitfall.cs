using UnityEngine;
using System.Collections;
using System.Threading;

public class CapturePitfall : MonoBehaviour 
{
	// Use this for initialization
	void Start () 
    {
        Debug.Log("Variable Capturing");
        Debug.Log("------------------");
	    for(int i = 1; i <= 10; i++)
        {
            int temp = i;
            // With no temp variable declared, Debug.Log calls a constantly changing variable
            new Thread(() => Debug.Log(temp)).Start();
        }
	}
}
