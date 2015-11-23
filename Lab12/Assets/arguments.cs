using UnityEngine;
using System.Collections;
using System.Threading;

public class arguments : MonoBehaviour {

	// Use this for initialization
	void Start () {

        //Thread thread = new Thread(() => DisplayMessage("Hello from the thread"));

        //new Thread(() =>
        //    {
        //        Debug.Log("I'm running on another thread");
        //        Debug.Log("This is cool");
        //    }
        //).Start();

        //for(int i = 0; i < 10; i++)
        //{
        //    new Thread(() => Debug.Log(i)).Start();
        //}

        //for(int i = 0; i < 10; i++)
        //{
        //    int temp = i;
        //    new Thread(() => Debug.Log(temp)).Start();
        //}

        //Thread.CurrentThread.Name = "main";
        //Thread worker = new Thread(Go);
        //worker.Name = "worker";
        //worker.Start();
        //Go();

        //Thread worker = new Thread(Go);
        //Debug.Log("is worker background? " + worker.IsBackground);
        //worker.IsBackground = true;
        //Debug.Log("is worker background? " + worker.IsBackground);
        //worker.Start();

        string text = "t1";
        Thread t1 = new Thread(() => Debug.Log(text));

        text = "t2";
        Thread t2 = new Thread(() => Debug.Log(text));

        t1.Start();
        t2.Start();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void DisplayMessage(string message)
    {
        Debug.Log(message);
    }

    void Go()
    {
        Debug.Log("Hello from " + Thread.CurrentThread.Name);
    }
}
