using UnityEngine;
using System.Collections;
using System.Threading;

public class ScriptThreading : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
    {
        //IN LAB CODE
        Thread worker = new Thread(Go);
        Debug.Log("Is worker in the Background" + worker.IsBackground);
        worker.IsBackground = true;
        Debug.Log("Is worker in the Background" + worker.IsBackground);
        worker.Start();
        Go();
        //END IN LAB CODE

        //LAB REPORT TEST CODE
        string text = "t1";
        Thread t1 = new Thread(() => Debug.Log(text));
        text = "t2";
        Thread t2 = new Thread(() => Debug.Log(text));

        t1.Start();
        t2.Start();
        //END TEST CODE
	}

    void Go()
    {
        Debug.Log("Greetings from " + Thread.CurrentThread.Name);
    }
}
