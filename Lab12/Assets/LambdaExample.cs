using UnityEngine;
using System.Collections;

public class LambdaExample : MonoBehaviour {

    delegate bool isTeenager(Student student);

    void Start()
    {
        Student student1 = new Student(5);
        Student student2 = new Student(10);
        Student student3 = new Student(15);
        Student student4 = new Student(20);

        Debug.Log("Function student1 teenager? : " + funcIsATeen(student1));

        isTeenager isATeen = s => s.age > 12 && s.age < 20;

        Debug.Log("Lambda student1 teenager? : " + isATeen(student1));
    }

    bool funcIsATeen(Student currStudent)
    {
        return (currStudent.age > 12 && currStudent.age < 20);
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
            this.age = age;
        }
    }
}
