using UnityEngine;
using System.Collections;
using System.Threading;

/// <summary>
/// Author: Matt Gipson
/// Contact: Deadwynn@gmail.com
/// Domain: www.livingvalkyrie.com
/// 
/// Description: Lab12ThreadVooDoo 
/// </summary>
public class Lab12ThreadVooDoo : MonoBehaviour {
    #region Fields

    #endregion

    void Start() {
        Start6();
    }

    void Start6() {
        
        Thread worker = new Thread(Go);
        print("is worker background? " + worker.IsBackground);
        worker.IsBackground = true;
        print("is worker background? " + worker.IsBackground);
        worker.Start();
    }

    void Start5() {
        Thread.CurrentThread.Name = "main";
        Thread worker = new Thread(Go);
        worker.Name = "worker";
        worker.Start();
        Go();
    }

    void Go() {
        print("hello from " + Thread.CurrentThread.Name);
    }

    void Start4() {
        for (int i = 0; i < 10; i++) {
            int temp = i;
            new Thread(() => print(temp)).Start();
        }
    }

    void Start3() {
        for (int i = 0; i < 10; i++) {
            new Thread(() => Debug.Log(i)).Start();
        }
    }

    void Start2() {
        new Thread(() => {
                       print("Im running from another thread");
                       print("this is so cool!");
                   }).Start();
    }

    void Start1() {
        Thread thread = new Thread(() => DisplayMessage("Hello from the thread!"));
        thread.Start();
    }

    void DisplayMessage(string toPrint) {
        print(toPrint);
    }

    void Update() {}

}