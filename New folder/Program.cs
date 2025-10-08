using System;
using System.Collections.Generic;
public class Program
{
static void Main()
    {
        Console.WriteLine("IT111 Module 2 Lab — Class Structure (Solution + Arrays)");


        var courses = new List<Course>();
        Console.WriteLine($"Students before: {Student.Count}");

        bool addingCourses = true;
        while (addingCourses)
        {
            Console.WriteLine();
            Console.WriteLine("Add a Course");
            Console.Write("Code: "); var codeInput = Console.ReadLine();
            var code = string.IsNullOrWhiteSpace(codeInput) ? "TBA" : codeInput;
            Console.Write("Title: "); var titleInput = Console.ReadLine();
            var title = string.IsNullOrWhiteSpace(titleInput) ? "Untitled" : titleInput;
            Console.Write("Units (1-3): "); var unitsText = Console.ReadLine();
            int units = int.TryParse(unitsText, out var u) ? u : 3;

            Course course = new Course(code, title, units);
            courses.Add(course);
            Console.WriteLine($"Added course: {course.Describe()} (Capacity {Course.MaxStudents})");

            bool addingStudents = true;
            while (addingStudents)
            {
                if (course.IsFull)
                {
                    Console.WriteLine("Roster is full for this course. Returning to course menu.");
                    break;
                }

                Console.WriteLine();
                Console.WriteLine($"Add a Student to {course.Code}");
                Console.Write("Id: "); var id = Console.ReadLine();
                Console.Write("Name: "); var name = Console.ReadLine();
                Console.Write("Gpa (0.00-4.00): "); var gpaText = Console.ReadLine();
                double gpa = double.TryParse(gpaText, out var g) ? g : 0.0;
                Student stu = new Student(id, name, gpa);
                if (!course.TryEnroll(stu))
                {
                    Console.WriteLine("Roster full. Student not enrolled.");
                    break;
                }

                Console.WriteLine("Added:"); stu.PrintSummary();
                Console.Write("Add another student (Y) or back to courses (B)? ");
                var choice = (Console.ReadLine() ?? "").Trim().ToUpperInvariant();
                addingStudents = choice == "Y";
            }

            Console.Write("Add another course (Y) or Print summary & Exit (N)? ");
            var addCourseChoice = (Console.ReadLine() ?? "").Trim().ToUpperInvariant();
            addingCourses = addCourseChoice == "Y";
        }

        Console.WriteLine();
        Console.WriteLine("=== SUMMARY ===");
        Console.WriteLine($"Total students created: {Student.Count}");
        Console.WriteLine("Done.");
    }
}
public class Course
    {
    public const int MaxStudents = 30;
    private Student[] arrayStudent = new Student [MaxStudents];
    private int _count = 0;
    private string _code = "TBA";
    private string _title = "Untitled";
    private double _units;
    private bool _isFull;

    public  string? Code { get; set; }
    public  string? Title { get; set; }
    public double Units { get; set; }
    public bool IsFull;
        

        public Course()
    {
        _code = "TBA";
        _title = "Untitled";
        _units = 3;
    }

        public Course(string code, string title, double units)
        {
            Code = code;
            Title = title;
            Units = units;
        }
        public string Describe()
        {
            return $"{Code} - {Title} ({CatalogYear})";
        }
        public bool TryEnroll(Student s)
        {
            if (_count < MaxStudents)
            {
                arrayStudent[_count] = s;
                _count++;
                return true;
            }
            else
            {
                _isFull = true;
                return false;
            }
        }

        public void PrintRoster()
        {
            for (int i = 0; i < _count; i++)
            {
                arrayStudent[i].PrintSummary();
            }
        }

        public static int CatalogYear = 2025;
    }
 
public class Student
{
    private string _id = "N/A";
    private string? _name;
    private double _gpa;
    private static int _count = 0;

    public static int Count { get { return _count; } }
    public string Id
    {
        get { return _id; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                _id = "UNKNOWN";
            }
            else
            {
                _id = value;
            }
        }
    }
    public string Name
    {
        get { return _name?? "UNKONWN"; }
        set
        {
            if (value == null)
            {
                _name = null;
            }
            else
            {
                _name = value.Trim();
            }
        }
    }
    public double Gpa
    {
        get { return _gpa; }
        set
        {
            if (value < 0.0)
            {
                _gpa = 0.0;
            }
            else if (value > 4.0)
            {
                _gpa = 4.0;
            }
            else
            {
                _gpa = value;
            }
        }
    }

    public Student()
    {
        _id = "N/A";
        _name = "New Student";
        _gpa = 0.0;
        _count++;
    }
    public Student(string id, string name, double gpa)
    {
        Id = id;
        Name = name;
        Gpa = gpa;
        _count++;
    }

    public void PrintSummary()
    {
        Console.WriteLine($"[{Id}] {Name} — GPA: {Gpa:F2}");
    }
 
 
 
   ~Student()
   {
    Console.WriteLine("Goodbye");
   }
}