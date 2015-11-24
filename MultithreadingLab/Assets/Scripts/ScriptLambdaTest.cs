using UnityEngine;
using System.Collections;
using System.Threading;

// Author: Tiffany Fisher
// Modified By: Nathan Boehning
// Purpose: Demonstrate the use of lambdas within threads

public class ScriptLambdaTest : MonoBehaviour
{
    private delegate bool isTeenager(Student student);

    private void Start()
    {
        // Used to test the post lab

        // Creates two threads that debugs a string text
        string text = "t1";
        Thread t1 = new Thread(() => Debug.Log(text));

        text = "t2";
        Thread t2 = new Thread(() => Debug.Log(text));

        t1.Start();
        t2.Start();
    }

    private void Start6()
    {
        // Sets the worker thread as a background thread
        Thread worker = new Thread(Go);
        Debug.Log("is worker background? " + worker.IsBackground);
        worker.IsBackground = true;
        Debug.Log("is worker background? " + worker.IsBackground);
        worker.Start();
    }

    private void Start5()
    {
        // Renaming threads
        Thread.CurrentThread.Name = "main";
        Thread worker = new Thread(Go);
        worker.Name = "worker";
        worker.Start();
        Go();
    }

    private void Go()
    {
        Debug.Log("Hello from " + Thread.CurrentThread.Name);
    }

    private void Start4()
    {
        // Using a multi line lambda as a thread input, calling start directly on the thread declaration
        new Thread(() =>
        {
            Debug.Log("I'm running on another thread!");
            Debug.Log("I'm so cool!");
        }
            ).Start();
    }

    private void Start3()
    {
        // Loop through and debug a variable, changed from i to temp to fix
        // a capture variable error that can occur
        for (int i = 0; i < 10; i++)
        {
            int temp = i;
            new Thread(() => Debug.Log(temp)).Start();

        }
    }

    private void Start2()
    {
        // Create a thread that uses a lambda to call a function
        Thread thread = new Thread(() => DisplayMessage("Hello from the thread!"));
    }

    private void DisplayMessage(string msg)
    {
        // Debugs a message
        Debug.Log(msg);
    }

    // Use this for initialization
    private void Start1()
    {
        // Create 4 students of varying age
        Student student1 = new Student(5);
        Student student2 = new Student(10);
        Student student3 = new Student(15);
        Student student4 = new Student(20);

        // Tell whether the student is a teenager by calling a function
        Debug.Log("Function student1 teenager? : " + funcIsATeen(student1));
        Debug.Log("Function student2 teenager? : " + funcIsATeen(student2));
        Debug.Log("Function student3 teenager? : " + funcIsATeen(student3));
        Debug.Log("Function student4 teenager? : " + funcIsATeen(student4));

        // Set a delegated bool via a lambda as to whether or not the student is a teen
        isTeenager isATeen = s => s.age > 12 && s.age < 20;

        // Debugs the results of the lambda expression
        Debug.Log("Lambda student1 teenager? : " + isATeen(student1));
        Debug.Log("Lambda student2 teenager? : " + isATeen(student2));
        Debug.Log("Lambda student3 teenager? : " + isATeen(student3));
        Debug.Log("Lambda student4 teenager? : " + isATeen(student4));
    }

    // Function to determine if the student is a teen
    private bool funcIsATeen(Student curStudent)
    {
        return (curStudent.age > 12 && curStudent.age < 20);
    }

    // class that defines a student with the only variable being
    // age
    private class Student
    {
        public int age;

        public Student()
        {
            age = 10;
        }

        public Student(int age)
        {
            this.age = age;
        }
    }
}
