using static System.Console;
class ArrayModel
{ static void Main()

    {
        double[] payRate = { 13.00, 17.35, 19.12, 22.45 };

        for (int x = 8; x < payRate.Length; x++)
            WriteLine("Pay rate {0} is {1}", x, payRate[x].ToString("C"));
    }
}