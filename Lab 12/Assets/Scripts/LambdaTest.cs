using UnityEngine;
using System.Collections;

public class LambdaTest : MonoBehaviour {

	delegate bool isTeenager(Student student);

	// Use this for initialization
	void Start () {
	
	}

	bool funcisATeen(Student currStudent)
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
