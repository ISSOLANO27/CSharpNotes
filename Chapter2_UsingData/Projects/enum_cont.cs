using System;
using static System.Console;
using System.Globalization;
class Planets
{
	enum Planet { MERCURY=1, VENUS, EARTH, MARS, JUPITER, SATURN, URANUS, NEPTUNE };
	static void Main()
	{
		Write("Enter a planet number (1-8): ");
		int input = Convert.ToInt32(ReadLine());

		Planet selectedPlanet = (Planet)input;
		WriteLine($"{selectedPlanet} is {input} planet(s) from the sun");


	}
}