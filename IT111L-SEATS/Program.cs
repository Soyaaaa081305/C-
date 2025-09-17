using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Formats.Tar;
using System.Linq;

namespace IT111_Lab_Arrays_Collections
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("\n[1] Score Stats  [2] Seat Map  [3] Names Manager  [0] Exit");
                Console.Write("Choice: ");
                var ch = Console.ReadLine();
                switch (ch)
                {
                    case "1": ScoreStats(); break;
                    case "2": SeatMap(); break;
                    //case "3": NamesManager(); break;
                    case "0": return;
                    default: Console.WriteLine("Invalid choice."); break;
                }
            }
        }
        // --- Task 1 ---
        static void ScoreStats()
        {

            Console.Write("Enter scores (comma-separated): ");
            string line = Console.ReadLine() ?? "";
            int[] scores = ParseIntArray(line);

            if (scores.Length == 0) { Console.WriteLine("No scores."); return; }
            int min = scores.Min(), max = scores.Max(); double avg = scores.Average(); // initialization using linq

            Array.Sort(scores); // array function and auto sort na to ascending + printing
            Console.WriteLine($"Count={scores.Length}  Min={min}  Max={max}  Avg={avg:F2}");
            Console.WriteLine("Sorted: " + string.Join(" ", scores));

            Console.WriteLine("Frequency (value:count): ");
            int current = scores[0]; int count = 1;
            for (int i = 1; i < scores.Length; i++)
                if (scores[i] == current) count++;
                else { Console.WriteLine($"{current}:{count}"); current = scores[i]; count = 1; }
            Console.WriteLine($"{current}:{count}");
        }



        static int[] ParseIntArray(string csv)
        {
            string[] parts = csv.Split(',', StringSplitOptions.RemoveEmptyEntries);
            List<int> list = new List<int>();
            foreach (var p in parts)
            {
                if (int.TryParse(p.Trim(), out int v)) list.Add(v);
            }
            return list.ToArray();
        }

        // --- Task 2 ---

        static void SeatMap()
        {
            int rows = 5, cols = 6;
            int[,] seats = new int[rows, cols]; // all zeros mean empty
            while (true)
            {
                Console.Write("(B)ook (C)ancel (P)rint (Q)uit: ");
                string cmd = (Console.ReadLine() ?? "").Trim().ToUpperInvariant();
                switch (cmd)
                {
                    case "Q": return;
                    case "P": PrintSeats(seats); break;
                    case "B": ToggleSeat(seats, booking: true); break;
                    case "C": ToggleSeat(seats, booking: false); break;
                    default: Console.WriteLine("Unknown command."); break;
                }
            }
        }


        static void PrintSeats(int[,] seats)
        {
            int taken = 0, empty = 0;
            Console.WriteLine("Seats (1=taken, 0=empty)");
            for (int r = 0; r < seats.GetLength(0); r++)
            {
                Console.Write($"Row {r + 1}: ");
                for (int c = 0; c < seats.GetLength(1); c++)
                {
                    Console.Write(seats[r, c] + " ");
                    if (seats[r, c] == 1) taken++; else empty++;
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Totals - Taken: {taken}, Empty: {empty}");
        }



        static void ToggleSeat(int[,] seats, bool booking)
        {
            Console.Write("Row (1-based): ");
            if (!int.TryParse(Console.ReadLine(), out int row))
            { Console.WriteLine("Please enter an integer!"); return; }

            // just another validation to make sure na integer pinapasok at hind string. nagkakerror kasi if string.
            Console.Write("Col (1-based): ");
            if (!int.TryParse(Console.ReadLine(), out int col)) // dito na rin initialization ng col and row
            { Console.WriteLine("Please enter an integer!"); return; }

            //converted to 0 based from 1based and iniba variable name para mas madali idebug later
            int r = row - 1;
            int c = col - 1;

            if (r < 0 || r >= seats.GetLength(0) || c < 0 || c >= seats.GetLength(1))
            { Console.WriteLine("Error! Invalid Input (ayusin mo kasi beh)"); return; }

            //if true booking then if statement,, fore already taken, if false, then cancel booking automatically
            if (booking)
            {
                if (seats[r, c] == 1) Console.WriteLine("Already taken (prng sha ouch)");
                else { seats[r, c] = 1; Console.WriteLine("Booked"); }
            }
            else
            {
                if (seats[r, c] == 0) Console.WriteLine("Already empty");
                else { seats[r, c] = 0; Console.WriteLine("Canceled"); }
            }
        }
    }
}