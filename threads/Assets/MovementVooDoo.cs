using UnityEngine;
using System.Collections;
using System.Threading;
using JetBrains.Annotations;

/// <summary>
/// Author: Matt Gipson
/// Contact: Deadwynn@gmail.com
/// Domain: www.livingvalkyrie.com
/// 
/// Description: MovementVooDoo 
/// </summary>
public class MovementVooDoo : MonoBehaviour {
    #region Fields

    public Vector3 moveDirection;
    public Vector3 translatingVector = Vector3.left;
    public Vector3 currPos;
    public float speed;
    public float delta;
    Thread thread;

    #endregion

    void Start() {
        thread = new Thread(Move);
        //initialize thread
        //start thread
        thread.Start();
        //start invoke repeating
        InvokeRepeating("ChangeDirection", 5, 5);
    }

    void Move() {
        while (translatingVector != currPos) {
        //print("thread running");
             translatingVector = Vector3.Lerp(translatingVector, moveDirection, delta * speed);
        }
    }

    void ChangeDirection() {
        print("called");
        moveDirection = new Vector3(Random.Range(0,5), Random.Range(0,5), Random.Range(0,5));
    }

    void Update() {
        transform.Translate(translatingVector);
        currPos = transform.position;
        delta = Time.deltaTime;
    }

    void OnTriggerEnter(Collider other) {
        //print("triggered by " + other.name);
        if (other.tag == "Enemy" ) {
           //print("in if block");
            HealthVooDoo health = GetComponent<HealthVooDoo>();
            health.health--;
        }
    }
}