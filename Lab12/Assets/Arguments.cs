using UnityEngine;
using System.Threading;
using System.Collections;

public class Arguments : MonoBehaviour {

    
    void Start()
    {
        Thread worker = new Thread(Go);
        Debug.Log("is worker background? " + worker.IsBackground);
        worker.IsBackground = true;
        Debug.Log("is worker background? " + worker.IsBackground);
        worker.Start();
    }

    void Start5()
    {
        Thread.CurrentThread.Name = "main";
        Thread worker = new Thread(Go);
        worker.Name = "worker";
        worker.Start();
        Go();
    }

    void Go()
    {
        Debug.Log("Hello from " + Thread.CurrentThread.Name);
    }

    void Start4()
    {
        for(int i = 0; i <10; i++)
        {
            int temp = i;
            new Thread(() => Debug.Log(temp)).Start();
        }
    }

    void Start3()
    {
        for(int i = 0; i < 10; i++)
        {
            new Thread(() => Debug.Log(i)).Start();
        }
    }

	// Use this for initialization
	void Start1 ()
    {
        Thread thread = new Thread(() => DisplayMessage("Hello from the thread!"));
        thread.Start();
	}

    void Start2()
    {
        new Thread(() =>
           {
               Debug.Log("I'm running on another thread!");
               Debug.Log("This is so cool!");
           }
        ).Start();
    }
	
	void DisplayMessage (string message)
    {
        Debug.Log(message);
	}
}
