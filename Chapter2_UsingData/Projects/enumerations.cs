using System;
using static System.Console;
using System.Globalization;
class MonthNames
{
	enum Month
	{
		JANUARY = 1, FEBRUARY = 2, MARCH,
		APRIL, MAY, JUNE, JULY, AUGUST,
		SEPTEMBER, OCTOBER, NOVEMBER,
		DECEMBER
	};

	static void Main()
	{
		Write("Enter a month number >>  ");
		int monthNumber = Convert.ToInt32(ReadLine());

		Month selectedMonth = (Month)monthNumber;
		WriteLine("The month is {0}", selectedMonth);
	}


}
