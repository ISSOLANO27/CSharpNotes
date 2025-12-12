using System;
using static System.Console;
using System.Globalization;
class TestsInteractive
{
	static void Main()
	{
		double score1, score2, score3, score4, score5, score6, score7, score8, average;
		double total;
		Write("Enter score 1: ");
		score1 = double.Parse(ReadLine(), CultureInfo.InvariantCulture);
		Write("Enter score 2: ");
		score2 = double.Parse(ReadLine(), CultureInfo.InvariantCulture);
		Write("Enter score 3: ");
		score3 = double.Parse(ReadLine(), CultureInfo.InvariantCulture);
		Write("Enter score 4: ");
		score4 = double.Parse(ReadLine(), CultureInfo.InvariantCulture);
		Write("Enter score 5: ");
		score5 = double.Parse(ReadLine(), CultureInfo.InvariantCulture);
		Write("Enter score 6: ");
		score6 = double.Parse(ReadLine(), CultureInfo.InvariantCulture);
		Write("Enter score 7: ");
		score7 = double.Parse(ReadLine(), CultureInfo.InvariantCulture);
		Write("Enter score 8: ");
		score8 = double.Parse(ReadLine(), CultureInfo.InvariantCulture);

		average = (score1 + score2 + score3 + score4 + score5 + score6 + score7 + score8) / 8.0;
		total = score1 + score2 + score3 + score4 + score5 + score6 + score7 + score8;
		WriteLine("The average test score is: {0:F2}", average);

	}
}