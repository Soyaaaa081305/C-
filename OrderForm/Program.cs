using System;
using System.Collections.Generic;

class OrderForm
{
    static void Main(string[] args)
    {
        string choice = "Y";
        while (choice.ToUpper() == "Y")
        {
            string itemID = GetString("Enter Item ID (Exactly 10 characters): ", 10, 10);
            string itemNumber = GetString("Enter Item Number (Exactly 15 characters): ", 15, 15);
            string lastName = GetString("Enter Lastname (1-30 characters): ", 1, 30);
            string firstName = GetString("Enter Firstname (1-30 characters): ", 1, 30);
            string emailAddress = GetString("Enter Email Address (Exactly 20 characters): ", 20, 20);
            string telePhone = GetString("Enter Telephone Number (Exactly 11 characters): ", 11, 11);
            string streetAddress = GetString("Enter Street Address (1-50 characters): ", 1, 50);
            string city = GetString("Enter City (1-15 characters): ", 1, 15);
            string stateProvince = GetString("Enter State/Province (1-15 characters): ", 1, 15);
            string zipPostCode = GetString("Enter Zip/Post Code (1-15 characters): ", 1, 15);
            string country = GetString("Enter Country (10-50 characters): ", 10, 50);
            
            List<string> itemCodes = new List<string>();
            List<int> quantities = new List<int>();
            List<double> prices = new List<double>();
            List<double> total = new List<double>();
            int ILANGBESESNAAAA = 1;
            double totaloftotal = 0;
            // ik nice naming
            while (true)
            {
                Console.WriteLine($"\n--- Enter Item {ILANGBESESNAAAA} (type 'done' for Item Code to finish) ---");
                string itemCode = GetString($"Enter Item Code (Exactly 5 characters): ", 5, 5);
                if (itemCode.ToLower() == "done") break;

                int quantity = GetInt("Enter Quantity (1-1000): ", 1, 1000);
                double price = GetDouble("Enter Price (10-5000): ", 10, 5000);
                double orderFee = quantity * price;

                itemCodes.Add(itemCode);
                quantities.Add(quantity);
                prices.Add(price);
                total.Add(orderFee);
                ILANGBESESNAAAA++;
                
            }


            string gui = $"""

            --------------------ORDER FORM--------------------
                                from Noda
                Item ID:                    Item Number:
                {itemID}                    {itemNumber}

                Name: {firstName} {lastName}
                Email: {emailAddress}
                Contact Number: {telePhone}
                Address: {streetAddress}, {city}, {stateProvince}, 
                {zipPostCode}, {country}

                    Item Code:  Quantity:   Price:                             
            """;

           
            Console.WriteLine(gui);
            for (int i = 0; i < itemCodes.Count(); i++)
            {
                Console.WriteLine($"    {itemCodes[i],10} {quantities[i],8} {prices[i],10:F2}");
                totaloftotal += total[i];
            }
            Console.WriteLine("             Total " + totaloftotal);
            Console.WriteLine("--------------------ORDER FORM--------------------");

            Console.WriteLine($"\nDo you still want to continue? 'Y' to continue");
            choice = Console.ReadLine().ToUpper();

        }









    }
    static string GetString(string value, int min, int max)
    {
        string input;
        while (true)
        {
            Console.Write(value);
            input = Console.ReadLine();
            if (input.ToLower() == "done")
                return "done";
            if (!string.IsNullOrEmpty(input) && input.Length >= min && input.Length <= max)
                {
                    return input;
                }
            Console.WriteLine($"Please enter from {min} to {max} values only");
        }
    }
    static int GetInt(string value, int min, int max)
    {
        int input;
        while (true)
        {
            Console.Write(value);
            if (int.TryParse(Console.ReadLine(), out input) && input >= min && input <= max)
                return input;

            Console.WriteLine($"Please enter from {min} to {max} values only");
        }
    }

    static double GetDouble(string value, int min, int max)
    {
        double input;
        while (true)
        {
            Console.Write(value);
            if (double.TryParse(Console.ReadLine(), out input) && input >= min && input <= max)
                return input;

            Console.WriteLine($"Please enter from {min} to {max} values only");
        }
    }
}





