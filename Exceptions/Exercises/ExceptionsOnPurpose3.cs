using System;
using static System.Console;
class ExceptionOnPurpose3
{
    static void Main()
    {
        int answer;
        int result;
        int zero = 0;
        try
        {
            Write("Enter an integer >> ");
            answer = Convert.ToInt32(Console.ReadLine());
            result = answer / zero;
            WriteLine("The answer is " + answer);    
        }
        catch (FormatException ex)
        {
            WriteLine("You did not enter an integer.");
        }
        catch (DivideByZeroException e)
        {
            WriteLine("This is not your faul.");
            WriteLine("You entered the integer correctly.");
            WriteLine("The program divides by zero.");

            
        }

        
    }
}

