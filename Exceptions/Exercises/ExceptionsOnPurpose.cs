using System;
using static System.Console;
class ExceptionOnPurpose
{
    static void Main()
    {
        int answer;
        int result;
        int zero = 0;
        Write("Enter an integer >> ");
        answer = Convert.ToInt32(Console.ReadLine());
        result = answer / zero;
        WriteLine("The answer is " + answer);
    }
}
