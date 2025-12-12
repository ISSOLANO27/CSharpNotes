using System;
using static System.Console;
using System.Globalization;
class FahrenheitToCelsius
{
	static void Main()
	{
		Write("Enter temperature in Fahrenheit: ");
		double input = Convert.ToDouble(ReadLine());

		double celcius = (input - 32) * 5 / 9;
		WriteLine("{0:F1} F is {1:F1} C", input, celcius);




	}
}
