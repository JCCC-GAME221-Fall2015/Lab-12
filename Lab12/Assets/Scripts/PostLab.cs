using UnityEngine;
using System.Collections;
using System.Threading;

public class PostLab : MonoBehaviour 
{
	void Start ()
    {
        string text = "t1";
        Thread t1 = new Thread(() => Debug.Log(text));

        text = "t2";
        Thread t2 = new Thread(() => Debug.Log(text));

        t1.Start();
        t2.Start();
	}
}
