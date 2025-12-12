using System;
using static System.Console;
using System.Globalization;
class MakeChange
{
	static void Main()
	{
		// Declare variables
		int One = 1;
		int Five = 5;
		int Ten = 10;
		int Twenty = 20;
        
        // Get user input
        WriteLine("Enter an dollar amount: ");
		int amount = Convert.ToInt32(ReadLine());

        // Calculate the number of each bill
        int twenties = amount / Twenty;
		int remainder = amount % Twenty;

		int tens = remainder / Ten;
		remainder %= Ten;

		int fives = remainder / Five
;		remainder %= Five;

		int ones = remainder / One; // This will never leave a remainder

		// Get US culture info
		var us = CultureInfo.GetCultureInfo("en-US");

		WriteLine("twenties: {0} tens: {1} fives: {2} ones: {3}", twenties.ToString(us), tens.ToString(us),
			fives.ToString(us), ones.ToString(us));


}
}
