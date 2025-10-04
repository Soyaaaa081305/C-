using System;
using System.Diagnostics.Metrics;
using System.Linq;

class Program
{

    static void Main(string[] args)
    {
        int numstudents = 0;

        // getting hm students and validation
        while (true)
        {
            Console.Write("Enter how many students (3-69): ");
            if (Int32.TryParse(Console.ReadLine(), out numstudents) && numstudents >= 3 && numstudents <= 69)
                break;
            Console.WriteLine("Invalid input. Please enter a integer ranging from 3-69 digits");
        }
        // initlaization of lists and also validation again for the score and also adding sa ararays
        string[] studentNames = new string[numstudents];
        int[] studentScores = new int[numstudents];
        for (int i = 0; i < numstudents; i++)
        {
            int scoreloop;
            while (true)
            {
                Console.Write($"Enter name for student {i + 1}: ");
                studentNames[i] = Console.ReadLine()!;
                Console.Write($"Enter score for {studentNames[i]} (0-100): ");
                if (Int32.TryParse(Console.ReadLine(), out scoreloop) && scoreloop >= 0 && scoreloop <= 100)
                {
                    studentScores[i] = scoreloop;
                    break;
                }
                Console.WriteLine("Invalid Input. Enter digits 0-100 only");
            }
        }
            // main loop and switch
        while (true)
        {
            MENUGUISOMETHING();
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine()!;
            switch (choice)
            {
                case "0":
                    Console.WriteLine("Exiting the program... bbye");
                    return;
                case "1":
                    ListAll(studentNames, studentScores);
                    break;
                case "2":
                    caseno2(studentScores, studentNames);
                    Console.Write(caseno2(studentScores, studentNames));
                    break;
                case "3":
                    Console.Write("Enter name to search: ");
                    string query = Console.ReadLine()!;
                    int index = IndexOfName(studentNames, query);

                    if (index != -1)
                    {
                        Console.WriteLine($"Student found: {studentNames[index]}");
                        Console.WriteLine($"Score: {studentScores[index]}");
                    }
                    else
                    {
                        Console.WriteLine("No such student found!");
                    }
                    break;
                case "4":
                    Console.Write("Enter name to update: ");
                    string name = Console.ReadLine()!;
                    int newindex = IndexOfName(studentNames, name);
                    if (newindex != -1)
                    {
                        Console.WriteLine($"\nName: {studentNames[newindex]}");
                        Console.WriteLine($"Old Score: {studentScores[newindex]}");
                        UpdateScore(newindex, studentScores);
                        Console.WriteLine($"New Score: {studentScores[newindex]}");
                        Console.WriteLine("Score updated successfully");
                    }
                    else
                        Console.WriteLine("alaws student");
                    break;
                case "5":
                    SortByScoreDesc(studentNames, studentScores);
                    break;
                default:
                    Console.WriteLine("Choose from the choices");
                    break;
            }


        }
    }
// pra mas maiksi lang po yung main menu
    static void MENUGUISOMETHING()
    {
        string printthis = """ 

        Menu:
        [1] List All
        [2] Show Class Stats
        [3] Find Student by Name
        [4] Update Student Score
        [5] Sort by Score (Descending)
        [0] Exit

        """;
        Console.WriteLine(printthis);
    }
// list of all arrays
    static void ListAll(string[] names, int[] scores)
    {
        Console.WriteLine(" #   Name\tScore");
        for (int i = 0; i < names.Length; i++)
        {
            Console.WriteLine($" {i + 1,-2} {names[i],-12} {scores[i],3} ");
        }
    }
// didnt use linq just bcs
    static double ComputeAverage(int[] scores)
    {
        if (scores == null || scores.Length == 0) return 0.0;

        long total = 0;                 
        for (int h = 0; h < scores.Length; h++)
            total += scores[h];            

        return (double)total / scores.Length;
    }

    // didint use linq para mapractice po hahahha 
    static void FindMinMax(int[] scores, out int min, out int max)
    {
        min = scores[0];
        max = scores[0];

        for (int a = 0; a < scores.Length; a++)
        {
            if (scores[a] < min)
                min = scores[a];
            if (scores[a] > max)
                max = scores[a];
        }
    }
    static string caseno2(int[] scores, string[] names)
    {
        double average = ComputeAverage(scores);
        FindMinMax(scores, out int min, out int max);

        int passed = 0;
        int failedhuhu = 0;

        // idk how this works but it does
        int maxIndex = Array.IndexOf(scores, max);
        int minIndex = Array.IndexOf(scores, min);


        for (int i = 0; i < scores.Length; i++)
        {
            if (scores[i] >= 75)
                passed++;
            else
                failedhuhu++;
        }

        string computemobro = $""" 
        Average: {average}
        Highest: {max} ({names[maxIndex]})
        Lowest: {min} ({names[minIndex]})
        Passed: {passed} Failed: {failedhuhu}

        """;
        return computemobro;
    }

    //first time doing this in a long time kaya from scratch q gawin
    static int IndexOfName(string[] names, string query)
    {
        for (int n = 0; n < names.Length; n++)
        {
            if (names[n].Equals(query, StringComparison.OrdinalIgnoreCase))
            {
                return n;
            }
        }
        return -1;
    }
// update score using index from indexofname function so that same parameters as given 
    static void UpdateScore(int index, int[] scores)
    {
        int score;
        while (true)
        {
            Console.Write("Enter new score (0-100): ");
            if (int.TryParse(Console.ReadLine(), out score) && score >= 0 && score <= 100)
            {
                scores[index] = score;
                break;
            }
            else
                Console.WriteLine("Invalid score! Please enter 0-100 only");
        }
    }// i don understand this but it works 
        static void SortByScoreDesc(string[] names, int[] scores)
    {
        for (int i = 0; i < scores.Length - 1; i++)
        {
            for (int j = 0; j < scores.Length - i - 1; j++)
            {
                if (scores[j] < scores[j + 1])
                {
                
                    int tempScore = scores[j];
                    scores[j] = scores[j + 1];
                    scores[j + 1] = tempScore;

                    
                    string tempName = names[j];
                    names[j] = names[j + 1];
                    names[j + 1] = tempName;
                }
            }
        }

        Console.WriteLine("\nSorted by Score (Descending):");
        ListAll(names, scores); 
    }
}