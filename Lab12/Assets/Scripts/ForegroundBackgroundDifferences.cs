using UnityEngine;
using System.Collections;
using System.Threading;

public class ForegroundBackgroundDifferences : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
        Debug.Log("Foreground vs Background");
        Debug.Log("------------------------");
        Thread worker = new Thread(Go);
        worker.Name = "worker";
        Debug.Log("Is " + worker.Name + " a background thread? " + worker.IsBackground);
        worker.IsBackground = true;
        Debug.Log("Is " + worker.Name + " a background thread? " + worker.IsBackground);
        worker.Start();
	}
	
	// Update is called once per frame
	void Go() 
    {
        Debug.Log("This is here for thread functionality.");
	}
}
