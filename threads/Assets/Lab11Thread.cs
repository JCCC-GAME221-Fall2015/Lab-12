using UnityEngine;
using System.Collections;
using System.Threading;

/// <summary>
/// Author: Matt Gipson
/// Contact: Deadwynn@gmail.com
/// Domain: www.livingvalkyrie.com
/// 
/// Description: Lab11Thread 
/// </summary>
public class Lab11Thread : MonoBehaviour {
    #region Fields

    bool _stopThreads = false;
    string _threadOutput = "";

    #endregion

    void Start() {
        ThreadStart firstThread = new ThreadStart(DisplayThread1);
        ThreadStart secondThread = new ThreadStart( DisplayThread2 );

        Thread thread1 = new Thread(firstThread);
        Thread thread2 = new Thread(secondThread);

        thread1.Start();
        thread2.Start();

        Invoke("StopThreads", 10);

    }

    void DisplayThread1() {
        lock (this) {
            while (_stopThreads == false) {
                print("display thread 1");
                _threadOutput = "hello thread 1";
                Thread.Sleep(1000);
                print("thread 1 output --> " + _threadOutput);
            }
        }
    }

    void DisplayThread2() {
        lock (this) {
            while (_stopThreads == false) {
                print("display thread 2");
                _threadOutput = "hello thread 2";
                Thread.Sleep(1000);
                print("thread 2 output --> " + _threadOutput);
            }
        }
    }

    void StopThreads() {
        _stopThreads = true;
    }

}