using System;

class Program()
{
    static int Validation()
    {
        while (true)
        {
            int numofstudents;

            Console.Write("Enter number of students (3-69): ");
            if (int.TryParse(Console.ReadLine(), out numofstudents))
            {
                if (numofstudents >= 3 && numofstudents <= 69)
                {
                    string [] student = new string [numofstudents];
                    int [] score = new int [numofstudents];
                    for (int h = 0; h < numofstudents; h++)
                    {
                        Console.Write($"\nEnter name for student {h+1}: ");
                        student[h] = Console.ReadLine()!;

                        while (true)
                        {
                            Console.Write($"Enter score for {student[h]} (0-100): ");

                            if (int.TryParse(Console.ReadLine(), out score[h]) && score[h] >= 0 && score[h] <= 100)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("ERROR: Please enter a valid score from 0-100 only");
                            }
                        }
                    }
                     Console.WriteLine("\n--- Student List ---");
                    for (int i = 0; i < numofstudents; i++)
                    {
                        Console.WriteLine($"{student[i]}: {score[i]}");
                    }
                    return numofstudents student score [];
                }
                else
                    Console.WriteLine("ERROR: Enter within the given range (3-69).\n");
            }
            else
                Console.WriteLine("ERROR: Please enter a valid integer.\n");
        }
    }
    static void PRINTMenuGUI()
    {
        string bastastring = """ 

        Menu
        [1] List All
        [2] Show Class Stats
        [3] Find Student by Name
        [4] Update Student Score
        [5] Sort by Score (Descending)
        [0] Exit


        """;
        Console.Write(bastastring);
    }
    static int switchchoices()
    {
        string choice = "";
        Console.Write("Please enter your choice: ");
        choice = Console.ReadLine()!;

        switch (choice)
        {
            case "1":
                Console.WriteLine("");
                break;
            case "2":
                Console.WriteLine("");
                break;
            case "3":
                Console.WriteLine("");
                break;
            case "4":
                Console.WriteLine("");
                break;
            case "5":
                Console.WriteLine("");
                break;
            case "0":
                return 1;
        }
        return 0;
    }






    static void Main(string[] args)
    {
        while (true)
        {
            int numofstudent = Validation(); // validation of numofstudents

            PRINTMenuGUI(); // printing of menu, yes,, printing lang siya

            if (switchchoices() == 1) // for exit lang to 
                break;

        }

    }
}