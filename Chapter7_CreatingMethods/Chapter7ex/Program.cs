using static System.Console;
using System;
class SalesLetter
{
    static void Main()
    {
        Console.WriteLine("Welcome to MyBiz Solutions!");
        Console.WriteLine("We offer top-tier consulting for small businesses.");
        DisplayContactInfo();

        Console.WriteLine("\nOur services include marketing, tech support, and more.");
        DisplayContactInfo();

        Console.WriteLine("\nLet’s grow your business together!");
        DisplayContactInfo();
    }

    static void DisplayContactInfo()
    {
        Console.WriteLine("Phone: 555-1234");
        Console.WriteLine("Cell: 555-5678");
        Console.WriteLine("Email: info@mybiz.com");
    }
}
