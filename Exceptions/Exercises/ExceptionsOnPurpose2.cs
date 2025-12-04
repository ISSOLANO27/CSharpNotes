using System;
using static System.Console;
class ExceptionOnPurpose2
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
        catch (Exception ex)
        {
            WriteLine("Exception caught: " + ex.Message);
        }

        
    }
}
