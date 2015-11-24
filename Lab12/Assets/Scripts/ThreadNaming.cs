using UnityEngine;
using System.Collections;
using System.Threading;

public class ThreadNaming : MonoBehaviour
{
	void Start () 
    {
        Debug.Log("Thread naming");
        Debug.Log("-------------");
        //Thread.CurrentThread.Name = "main";
        //The above will only execute once; later runs are attempting to change the name
        Thread main = new Thread(Go);
        Thread worker = new Thread(Go);
        main.Name = "main";
        worker.Name = "worker";
        main.Start();
        worker.Start();
	}
	
	// Update is called once per frame
	void Go() 
    {
        Debug.Log("Hello from " + Thread.CurrentThread.Name);
	}
}
