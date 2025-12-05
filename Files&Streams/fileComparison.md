## File Comparison

This program compares the sizes of a Word document and a text file using `FileInfo`. 
It calculates the percentage ratio of the text file’s size relative to the Word file and prints both sizes along with the ratio. 
In short, it’s a utility to show how much smaller a plain text file is compared to its Word counterpart.

```cs
Developer: Israel Solano


using System;                     // Import core system functionality (basic types, exceptions, etc.)
using static System.Console;       // Allow direct use of Console methods like WriteLine() without prefix
using System.IO;                   // Import file I/O classes such as FileInfo

class FileComparison               // Define a class named FileComparison
{
   static void Main()              // Program entry point
   {
      string wordFileName = "Quote.docx";   // Store the name of the Word document file
      string textFileName = "Quote.txt";    // Store the name of the text file

      FileInfo wordFile = new FileInfo(wordFileName);   // Create a FileInfo object for the Word file
      FileInfo textFile = new FileInfo(textFileName);   // Create a FileInfo object for the text file

      long wordFileSize = wordFile.Length;  // Get the size of the Word file in bytes
      long textFileSize = textFile.Length;  // Get the size of the text file in bytes

      double ratio = (double)textFileSize / wordFileSize * 100;   // Calculate percentage size of text file vs Word file

      Console.WriteLine($"The size of the Word file is {wordFileSize} bytes");   // Print Word file size
      Console.WriteLine($"and the size of the Notepad file is {textFileSize} bytes");   // Print text file size
      Console.WriteLine($"The Notepad file is {ratio:F2} % of the size of the Word file");   // Print percentage comparison
   }
}

/* OUTPUT (example run):
The size of the Word file is 12555 bytes
and the size of the Notepad file is 27 bytes
The Notepad file is 0.22 % of the size of the Word file
*/

```
