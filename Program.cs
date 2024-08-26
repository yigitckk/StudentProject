using System;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;


class Student
{


    private int id;
    private string name;
    private string surname;
    private List<double> grades;

    public string Name
    {

        get { return name; }
        set { name = value; }
    }

    public string Surname
    {

        get { return surname; }
        set { surname = value; }


    }

    public int Id
    {

        get { return id; }
        set { id = value; }
    }




    public Student(int id, string name, string surname)
    {

        Name = name;
        Surname = surname;
        Id = id;
        grades = new List<double>();

    }

    public void AddGrade(double grade)
    {
        if (grade == 2.0 || grade == 3.0 || grade == 3.5 || grade == 4.0 || grade == 4.5 || grade == 5.0)
        {

            grades.Add(grade);
        }
        else
            Console.WriteLine("Invalid grade. Grade must be one of the following: 2.0, 3.0, 3.5, 4.0, 4.5, 5.0");
    }

    public double CalculateAverage()
    {

        if (grades.Count == 0)
        {
            return 0.0;
        }

        double sum = 0.0;
        foreach (double grade in grades)
        {
            sum += grade;
        }
        return sum / grades.Count;
    }

    public bool PassedCourse()
    {

        return CalculateAverage() >= 3.0;
    }






}

class Group
{

    private Dictionary<int, Student> students;

    public Group()
    {
        students = new Dictionary<int, Student>();
    }

    public void AddStudent(Student student)
    {
        if (!students.ContainsKey(student.Id))
        {
            students.Add(student.Id, student);
        }
        else
        {
            Console.WriteLine($"Student with ID {student.Id} is already in the group.");
        }
    }

    public void RemoveStudent(int id)
    {
        if (students.ContainsKey(id))
        {
            students.Remove(id);
        }
        else
        {
            Console.WriteLine($"Student with ID {id} is not in the group.");
        }
    }



    public void ToString()
    {
        Console.WriteLine($"Group Info:\nAverage Group Grade: {CalculateAverageGroup()}");


        foreach (var student in students.Values)
        {
            string passStatus = student.PassedCourse() ? "Passed" : "Failed";
            Console.WriteLine($"Student's name and surname: {student.Name} {student.Surname} and ID: {student.Id}, Grade point average: {student.CalculateAverage()}, {passStatus}");

        }



    }


    public double CalculateAverageGroup()
    {

        if (students.Count == 0) return 0.0;
        double totalGrade = 0.0;
        foreach (var student in students.Values)
        {

            totalGrade += student.CalculateAverage();

        }

      
        return totalGrade / students.Count;



    }





}


class Program
{
    static void Main(string[] args)
    {
        // Creating students
        Student student1 = new Student(001, "Max", "Kolawski");
        Student student2 = new Student(002, "Yigit", "Celik");
        Student student3 = new Student(003, "Ali", "Tatar");
        Student student4 = new Student(004, "John", "Reader");


        // Adding grades
        student1.AddGrade(3.5);
        student1.AddGrade(4.0);
        student1.AddGrade(2.0);
        student1.AddGrade(2.0);
        student2.AddGrade(2.0);
        student2.AddGrade(2.0);
        student2.AddGrade(4.5);
        student2.AddGrade(5.0);
        student3.AddGrade(3.0);
        student3.AddGrade(2.0);
        student3.AddGrade(2.0);
        student3.AddGrade(3.0);
        student3.AddGrade(4.5);
        student4.AddGrade(4.0);
        student4.AddGrade(2.0);
        student4.AddGrade(5.0);
        student4.AddGrade(3.5);
        student4.AddGrade(4.0);
        student4.AddGrade(5.0);





        student1.PassedCourse();
        student2.PassedCourse();
        student3.PassedCourse();
        student4.PassedCourse();
        
        // Creating a group
        Group group = new Group();

        // Adding students to the group
        group.AddStudent(student1);
        group.AddStudent(student2);
        group.AddStudent(student3);
        group.AddStudent(student4);

        group.ToString();

        Console.WriteLine(" ");



        // Removing a student from the group
         group.RemoveStudent(001);


        Console.WriteLine(" ");
        group.ToString();

        // showing that we cannot add the same student once again
        Console.WriteLine(" ");
        Student student5 = new Student(002, "Yigit", "Celik");
         group.AddStudent(student5);

        Console.WriteLine(" ");
        group.ToString();


        // showing that we cannot remove a student with an unvalid id
        Console.WriteLine(" ");
        group.RemoveStudent(005);

    }
}






