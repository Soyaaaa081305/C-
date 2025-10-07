using System.Data.SqlTypes;


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
            Console.Write("Code: "); var code = Console.ReadLine();
            Console.Write("Title: "); var title = Console.ReadLine();
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

                Student student = new Student(id, name, gpa);
                if (!course.TryEnroll(student))
                {
                    Console.WriteLine("Roster full. Student not enrolled.");
                    break;
                }

                Console.WriteLine("Added:"); student.PrintSummary();
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
    Student[] Arraystudent = new Student[MaxStudents];
    private string _code;
    private string _title;
    private int _units;
    private int _count;

    private static int _courseCount = 0;
    public static int CourseCount
    {
        get { return _courseCount; }
    }
    public int Units
    {
        get { return _units; }
    }
    public bool IsFull
    {
        get { return _count >= MaxStudents; }
    }
      public string Code
    {
        get { return _code; }
    }
     public string title
    {
        get { return _title; }
    }
    public Course()
    {
        _code = "TBA";
        _title = "Untitled";
        _units = 3;
        _courseCount++;
    }
    public Course(string code, string title, int units)
    {
        _code = code;
        _title = title;
        _units = units;
    }



    public bool TryEnroll(Student s)
    {
        if (IsFull)
        {
            return false;
        }
        Arraystudent[_count] = s;
        _count++;
        return true;
    }

    public string Describe()
    {
        return $"{_code} - {_title} ({_units} units)";
    }
    
private void PrintRoster()
{
    for (int i = 0; i < _count; i++)
    {
        Arraystudent[i].PrintSummary();
    }
}
    public static int CatalogYear = 2025;
    
}


public class Student
{
    private string _id;
    private string _name;
    private double _gpa;

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
        get { return _name; }
        set { _name = value?.Trim(); }
    }
    public double GPA
    {
        get { return _gpa; }
        set { _gpa = (value < 0.0 || value > 4.0) ? 0.0 : value; }
    }

    public Student()
    {
        _id = "N/A";
        _name = "New Student";
        _gpa = 0.0;
    }
    public Student(string id, string name, double gpa) : this()
    {
        Id = id;
        Name = name;
        GPA = gpa;
        _count++;
    }


    public void PrintSummary()
    {
        Console.WriteLine($"[{_id}] {_name} — GPA: {_gpa:F2}");
    }
    private static int _count = 0;
    public static int Count
    {
        get { return _count; }
    }
    


     ~Student()
    {
        Console.WriteLine("Goodbye");
    }
}
 