using System;

public class Student
{
    public string Name;
    public int ID;

    public void SayHello()
    {
        Console.WriteLine("Hello " + Name);
    }
}

class Program
{
    static void Main()
    {
        Student myStudent = new Student();
        myStudent.Name = "Franceska";
        myStudent.ID = 123;

        myStudent.SayHello();
    }
}
