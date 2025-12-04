using System;
using static System.Console;
using System.Globalization;
class FindSquareRoot
{
	static void Main() 
	{
		Write("Enter a number: ");
		string userInput = ReadLine();

		double number;
		double sqrt = 0;

		try
        {
            if (!double.TryParse(userInput, out number))
            {
                WriteLine("Error: Value must be numeric.");
				throw new ApplicationException("Invalid numeric format.");
            }

			if (number < 0)
            {
                throw new ApplicationException("Number can't be negative.");
            }

			sqrt = Math.Sqrt(number);
        }
		catch (ApplicationException ex)
        {
            WriteLine("Error: " + ex.Message);
			sqrt = 0;
        }

		WriteLine($"Square root is {sqrt}");
		
	}
}