using UnityEngine;
using System.Collections;
using System.Threading;

public class ThreadedLambda : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
    {
        //Thread thread = new Thread(() => DisplayMessage("Hello from the thread!"));
        //thread.Start();
        Debug.Log("Lambda Threading");
        Debug.Log("----------------");
        new Thread(     () =>
                        {
                            Debug.Log("This is on another thread.");
                            Debug.Log("As is this!");
                        }
                  ).Start();
	}
	
	// Update is called once per frame
	void DisplayMessage(string message) 
    {
        Debug.Log(message);
	}
}
