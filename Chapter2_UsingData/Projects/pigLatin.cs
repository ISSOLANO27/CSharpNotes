using System;
using static System.Console;
using System.Globalization;
class PigLatin
{
    static void Main()
    {
        Write("Enter a line of text: ");
        string word = ReadLine();

        char firstletter = word[0];
        string restofword = word.Substring(1);

        string PigLatin = restofword + firstletter + "ay";
        WriteLine("In Pig Latin: {0}", PigLatin);
    }
} 

/* We are breaking apart the word being passed by the user and piecing it back together to our choosing.

1. First we give user instructions using WriteLine
2. We store the user input in the 'word' variable.
3. We store the first char from the 'word' variable using [0] as the argument using dot notation touse 'word'
variable on the 'Substring' method.
4. We create a sting for the restofword variable. Line 12, is storing everything after index position (1)
5. Line 15, we concatenate in the order PigLatin works. */