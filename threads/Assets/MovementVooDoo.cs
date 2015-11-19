using UnityEngine;
using System.Collections;
using System.Threading;

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

    #endregion

    void Start() {
        //initialize thread
        Thread thread = new Thread(Move);
        //start thread
        thread.Start();
        //start invoke repeating
        InvokeRepeating("ChangeDirection", 5, 5);
    }

    void Move() {
        transform.position = Vector3.Lerp(transform.position, moveDirection, Time.deltaTime);
    }

    void ChangeDirection() {
        print("called");
        moveDirection = new Vector3(Random.Range(0,5), Random.Range(0,5), Random.Range(0,5));
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