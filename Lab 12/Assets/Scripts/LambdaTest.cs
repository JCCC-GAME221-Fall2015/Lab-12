// LambdaTest.cs
using UnityEngine;
using System.Collections;

public class LambdaTest : MonoBehaviour {

	delegate bool isTeenager(Student student);

	// Use this for initialization
	void Start () {

		Student student1 = new Student (5);
		Student student2 = new Student (10);
		Student student3 = new Student (15);
		Student student4 = new Student (20);
		
		Debug.Log ("Function student1 teenager? : " + funcIsATeen (student1));
		Debug.Log ("Function student2 teenager? : " + funcIsATeen (student2));
		Debug.Log ("Function student3 teenager? : " + funcIsATeen (student3));
		Debug.Log ("Function student4 teenager? : " + funcIsATeen (student4));
		
		isTeenager isATeen = s => s.age > 12 && s.age < 20;
		
		Debug.Log ("Lambda student1 teenager? : " + isATeen (student1));
		Debug.Log ("Lambda student2 teenager? : " + isATeen (student2));
		Debug.Log ("Lambda student3 teenager? : " + isATeen (student3));
		Debug.Log ("Lambda student4 teenager? : " + isATeen (student4));

	}

	bool funcIsATeen(Student currStudent)
	{
		return (currStudent.age > 12 && currStudent.age < 20);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	class Student
	{
		public int age;

		public Student()
		{
			age = 10;
		}

		public Student(int age)
		{
			this.age =age;
		}
	}
}
