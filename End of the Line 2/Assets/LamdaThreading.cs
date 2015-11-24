using UnityEngine;
using System.Collections;
using System.Threading;
using System.Diagnostics;

public class LamdaThreading : MonoBehaviour {

    Thread moveThread;
    Thread changeDirection;
    bool updated = false;
    bool running = true;
    Vector3 positionDuplicate;
    Vector3 threadReturn;
    Vector3 destination;

	// Use this for initialization
	void Start ()
    {
        float timeElapsed;
        Stopwatch timer;
        moveThread = new Thread(() =>
                                        {
                                            timer = new Stopwatch(); 
                                            while(running)
                                            {
                                                if(updated)
                                                {
                                                    timeElapsed = timer.Elapsed.Milliseconds / 1000f;
                                                    threadReturn = Vector3.Lerp(positionDuplicate, destination, timeElapsed);
                                                    timer = new Stopwatch();
                                                }
                                            }
                                        });
        changeDirection = new Thread(() =>
                                        {
                                            int timeCount = 25;
                                            int moveCount = 0;
                                            while (running)
                                            {
                                                if (timeCount == 25)
                                                {
                                                    switch(moveCount)
                                                    {
                                                        case 0:
                                                            destination = positionDuplicate + new Vector3(0, 0, 5);
                                                            moveCount += 1;
                                                            break;
                                                        case 1:
                                                            destination = positionDuplicate + new Vector3(0, 5, 0);
                                                            moveCount += 1;
                                                            break;
                                                        case 2:
                                                            destination = positionDuplicate + new Vector3(0, 0, -5);
                                                            moveCount += 1;
                                                            break;
                                                        case 3:
                                                            destination = positionDuplicate + new Vector3(0, -5, 0);
                                                            moveCount = 0;
                                                            break;
                                                    }
                                                    timeCount = 0;
                                                }
                                                Thread.Sleep(200);
                                                timeCount += 1;
                                            }
                                        });
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = threadReturn;
        positionDuplicate = threadReturn;
        updated = true;
	}

    void OnApplicationExit()
    {
        running = false;
        Thread.Sleep(250);
    }
}
