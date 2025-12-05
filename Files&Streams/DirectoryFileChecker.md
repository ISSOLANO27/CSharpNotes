```cs
/*
Developer: Israel Solano
Date: 12/25/2025
Title: Directory & File Checker
*/

using System;                  // Import base system functionality (types, exceptions, etc.)
using static System.Console;   // Allow direct use of Console methods like WriteLine() without prefix
using System.IO;               // Import file and directory handling classes

class DebugFourteen1           // Define the program class
{
    static void Main()         // Entry point of the program
    {
        string fileName;       // Variable to hold the file name entered by the user
        string directory;      // Variable to hold the directory path entered by the user
        string path;           // Variable to hold the full path (directory + file name)
        string[] files;        // Array to hold the list of files in the directory
        int x;                 // Counter variable for looping through files

        Write("Enter a directory: ");   // Prompt the user to enter a directory
        directory = ReadLine();         // Read the directory name from user input

        if (Directory.Exists(directory))   // Check if the entered directory actually exists
        {
            files = Directory.GetFiles(directory);   // Get all files inside the directory

            if (files.Length == 0)                   // If no files are found
                WriteLine("There are no files in " + directory);   // Inform the user
            else
            {
                WriteLine(directory + " contains the following files");   // Header message

                for (x = 0; x < files.Length; ++x)   // Loop through each file in the directory
                    WriteLine("  " + files[x]);      // Print the file path

                Write("\nEnter a file name: ");      // Prompt the user to enter a file name
                fileName = ReadLine();               // Read the file name
                path = Path.Combine(directory, fileName);   // Build the full path safely

                if (File.Exists(path))   // Check if the file exists at that path
                {
                    // Print confirmation with creation timestamp (exact wording expected by test)
                    WriteLine("File exists and was created " + File.GetCreationTime(path));
                }
                else
                {
                    // Inform the user the file does not exist in the given directory
                    WriteLine(fileName + " does not exist in the " + directory + " directory");
                }
            }
        }
        else
        {
            // Inform the user the directory itself does not exist
            WriteLine("Directory " + directory + " does not exist");
        }
    }
}



```
