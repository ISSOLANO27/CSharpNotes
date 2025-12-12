using System;
using static System.Console;

class ArrayDemo2
{
    static void Main()
    {
        int[] scores = new int[8];   // array for 8 test scores
        int x;
        string inputString;
        int count;
        const int DASHES = 50;

        // Step 3: Prompt for 8 scores
        for (x = 0; x < scores.Length; ++x)
        {
            Write("Enter your score on test {0}: ", x + 1);
            inputString = ReadLine();
            scores[x] = Convert.ToInt32(inputString);
        }

        WriteLine();  // move to new line after input

        // Step 4: Print dashed line
        for (count = 0; count < DASHES; ++count)
        {
            Write("-");
        }
        WriteLine();

        // Step 5: Display original order
        WriteLine("Scores in original order:");
        for (x = 0; x < scores.Length; ++x)
        {
            Write("{0,6}", scores[x]);   // 6-character field
        }
        WriteLine();
        
        // Step 6: Sort and display
        for (count = 0; count < DASHES; ++count) Write("-");
        WriteLine();

        Array.Sort(scores);
        WriteLine("Scores in sorted order:");
        for (x = 0; x < scores.Length; ++x)
        {
            Write("{0,6}", scores[x]);
        }
        WriteLine();

        // Step 7: Reverse and display
        for (count = 0; count < DASHES; ++count) Write("-");
        WriteLine();

        Array.Reverse(scores);
        WriteLine("Scores in reverse order:");
        for (x = 0; x < scores.Length; ++x)
        {
            Write("{0,6}", scores[x]);
        }
        WriteLine();
    }
}
