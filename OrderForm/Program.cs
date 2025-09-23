using System;

class OrderForm
{
    static void Main(string[] args)
    {
        while (true)
        {
            string itemID = GetString("Item ID", 10, 10);
            string ItemNumber = GetString("Item ID", 15, 15);
            string Lastname = GetString("Item ID", 1, 30);
            string Firstname = GetString("Item ID", 1, 30);
            string Email = GetString("Item ID", 20, 20);
            string Telephone = GetString("Item ID", 11, 11);
            string Street = GetString("Item ID", 1, 50);
            string City = GetString("Item ID", 1, 15);
            string State = GetString("Item ID", 1, 15);
            string Zip = GetString("Item ID", 4, 4);
            string Country = GetString("Item ID", 10, 50);
            string Item = GetString("Item ID", 5, 5);
            string Quantity = GetString("Item ID", 1, 1000);
            string Price = GetString("Item ID", 10, 5000);

            Console.WriteLine($"Item ID: {itemID}");
            Console.WriteLine($"Item Number:{ItemNumber} ");
            Console.WriteLine($"Lastname: {Lastname}");
            Console.WriteLine($"Firstname: {Firstname}");
            Console.WriteLine($"Email Address: {Email}");
            Console.WriteLine($"Telephone: {Telephone}");
            Console.WriteLine($"Street Address: {Street}");
            Console.WriteLine($"City: {City}");
            Console.WriteLine($"State/Province: {State}");
            Console.WriteLine($"Zip/Post Code: {Zip}");
            Console.WriteLine($"Country: {Country}");
            Console.WriteLine($"Item Code: {Item}");
            Console.WriteLine($"Quantity: {Quantity}");
            Console.WriteLine($"Price: {Price}");

            Console.WriteLine("Do you want to continue?");
            Console.WriteLine("'y' for yes, 'n' for no");
            string choice = Console.ReadLine().Trim().ToLower();
            if (choice == "n")
            {
                break;
            }



        }
    }

    static string GetString(string field, int min, int ma)
    {
        string input = Console.ReadLine();
        return input;
    }
}