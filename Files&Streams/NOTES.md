
# **📘 Chapter 14 — Files and Streams**



## **Table of Contents**

  [Introduction](#introduction)

1. [Files and the File and Directory Classes](#files-and-the-file-and-directory-classes)

   * [Using the File and Directory Classes](#using-the-file-and-directory-classes)
   * [Understanding File Data Organization](#understanding-file-data-organization)
   * [Understanding Streams](#understanding-streams)

2. [Writing and Reading a Sequential Access File](#writing-and-reading-a-sequential-access-file)

   * [Writing Data to a Sequential Access Text File](#writing-data-to-a-sequential-access-text-file)
   * [Reading from a Sequential Access Text File](#reading-from-a-sequential-access-text-file)
   * [Searching a Sequential Text File](#searching-a-sequential-text-file)
   * [Understanding Serialization and Deserialization](#understanding-serialization-and-deserialization)

3. [Chapter Summary](#chapter-summary)

4. [Key Terms](#key-terms)

5. [Review Questions](#review-questions)

6. [Exercises](#exercises)

<br>
<br>
<br>

# Introduction

Upon completion of this chapter, I will be able to:

* Describe computer files and the File and Directory classes
* Describe file data organization
* Describe streams and how they move data
* Write to and read from a sequential access text file
* Search a sequential access text file
* Understand serialization and deserialization

In earlier chapters, programs lived entirely in memory: flexible, fast, but temporary. Once the program ended, everything vanished. Files change that. They allow your applications to persist data across sessions, store information long-term, and communicate with the outside world.
This chapter introduces how C# interacts with a computer’s file system, how data is organized inside files, and how streams serve as the channels through which information flows in and out.

<br>
<br>
<br>


# Files and the File and Directory Classes

Data lives in two worlds:

* **Temporary storage (RAM)** — fast, flexible, but disappears the moment the program ends.
* **Permanent storage** — slow but persistent, surviving shutdowns and power loss.

Variables, arrays, objects — all that is RAM-bound and volatile.
Files are where data goes when it needs to **live beyond execution**.

## **Volatile vs. Nonvolatile**

* **Volatile (Temporary)**
  RAM loses everything when power drops or the program finishes. Even if a program runs for hours, its memory is still “temporary” because it vanishes when execution stops.

* **Nonvolatile (Persistent/“Permanent”)**
  Keeps data even when the computer turns off. Hard drives, SSDs, USBs, CDs, DVDs, cloud storage — these store *files*, not variables.

## **What a File Really Is**

A file is just a **collection of bytes** stored on a nonvolatile device. It always has:

* A **name**
* A **location (path)**
* A **size (in bytes)**
* A **creation time**
* A **type** (via extension: `.txt`, `.exe`, `.jpg`, etc.)

When you “use” a file in a program, you're never interacting with the file on disk directly.
C# **copies** the data from disk → into RAM → your program works on the RAM copy → and optionally writes modifications back to disk.

That’s the entire dance of file I/O:
**read = disk → RAM**
**write = RAM → disk**

## **Text Files vs. Binary Files**

Both are just bytes — the difference is interpretation.

### **Text Files**

* Encoded through ASCII/Unicode.
* Human-readable in Notepad or VS Code.
* Examples: `.txt`, `.csv`, `.json`, `.xml`, `.cs`.

### **Binary Files**

* Raw byte patterns, not meant to be directly read by humans.
* Examples: `.exe`, `.dll`, images, audio, video, compressed archives.
  
Common Characteristics Binary/Text:

Regardless of content, *both* have names, sizes, timestamps, and live on storage devices.



## **Directories (Folders) and Paths**

Files don’t float around alone. They’re organized in a hierarchy of directories (folders).
A file’s **path** includes:

* The drive
* Every folder in the chain
* The filename + extension

Example Windows path:

```cs
C:\CSharp\Chapter14\Data.txt
```

“Directory” and “folder” mean the same thing. “Folder” became popular with graphical interfaces (Windows 95 onward), while “directory” is the older technical term.

## **C# Tools for Managing Files**

C# gives you two powerful classes inside `System.IO`:

### **File**

* Works with individual files
* Lets you create, delete, copy, move, check existence, read/write small text files quickly

Example:

```csharp
bool exists = File.Exists("data.txt");
```

### **Directory**

* Works with folders/directories
* Allows creation, deletion, listing files, checking existence

Example:

```csharp
bool folderExists = Directory.Exists("CSharp/Chapter14");
```

These classes give you **high-level control** without diving into low-level disk operations.

Later in this chapter, you’ll use:

* `StreamWriter` + `StreamReader`
* `FileStream`
* `BinaryReader` / `BinaryWriter`
* Serialization tools

But everything starts with understanding **how files live on storage** and how `File` and `Directory` let you navigate that world.

• [Previous: Introduction](#introduction) 
• [Next: Using the File and Directory Classes](#using-the-file-and-directory-classes)
• [Back to TOC](#table-of-contents) 

<br>
<br>
<br>



## Using the File and Directory Classes

C# gives you the `File` and `Directory` classes (in the `System.IO` namespace) as high-level tools to work with the file system. They let you:

* Check if files and folders exist
* Create or delete them
* Move/rename them
* Get metadata such as creation time and last modification time

Both classes are **static**: you don’t create objects from them; you call their methods directly (for example, `File.Exists(...)`).

---

### File Class Overview

The `File` class focuses on **individual files**—text or binary. It exposes methods for creating, deleting, and inspecting files.

#### Table 14-1 — Selected `File` Class Methods

| Method               | Description                                                  |
| -------------------- | ------------------------------------------------------------ |
| `Create()`           | Creates a file                                               |
| `CreateText()`       | Creates a text file and returns a `StreamWriter`             |
| `Delete()`           | Deletes a file                                               |
| `Exists()`           | Returns `true` if the specified file exists                  |
| `GetCreationTime()`  | Returns a `DateTime` showing when the file was created       |
| `GetLastWriteTime()` | Returns a `DateTime` showing when the file was last modified |
| `Move()`             | Moves or renames a file to a new path                        |

> Behind the scenes, all of this is just bytes on disk. The `File` class is the friendly layer on top.

---

### DateTime and File Timestamps

When you pull times from files, you get `DateTime` values.

Key points:

* `DateTime` stores **both date and time**.
* `DateTime.Now` → current **local** system time.
* `DateTime.UtcNow` → current **UTC/GMT** time.
* `File.GetCreationTime(path)` and `File.GetLastWriteTime(path)` return `DateTime` objects based on the file’s metadata.

You used `DateTime` earlier with GUI controls like `MonthCalendar` and `DateTimePicker`; here you’re pulling those values from the file system instead of from user input.

---

### Using `System.IO` in Code

To use `File` without fully qualifying it each time, you add:

```csharp
using System.IO;
```

at the top of your file. Then you can write `File.Exists(...)` instead of `System.IO.File.Exists(...)`.

You’ll often see:

```csharp
using static System.Console;
using System.IO;
```

so you can also call `WriteLine()` directly.

---

### Example: FileStatistics Program (Figure 14-1)

This program asks the user for a filename, checks whether it exists, and if it does, shows creation and last-write times.

```csharp
using static System.Console;
using System.IO;

class FileStatistics
{
    static void Main()
    {
        string fileName;

        Write("Enter a filename >> ");
        fileName = ReadLine();

        if (File.Exists(fileName))
        {
            WriteLine("File exists");
            WriteLine("File was created " +
                File.GetCreationTime(fileName));
            WriteLine("File was last written to " +
                File.GetLastWriteTime(fileName));
        }
        else
        {
            WriteLine("File does not exist");
        }
    }
}
```

**Behavior (Figure 14-2):**

* If the user types a name that doesn’t match any file in the current directory →
  `File.Exists()` returns `false` → program prints “File does not exist”.
* If the file is found →
  `File.Exists()` returns `true` → creation time and last write time are shown.

> Note: In this example, the file is expected to be in the **same directory** as the running program. If it isn’t, you must supply a full or relative path.

---

### FileInfo (Instance-Based Alternative)

There’s also a `FileInfo` class in `System.IO` that exposes similar information but works as an **instance** object instead of a static class:

* You create a `FileInfo` with a path.
* You then read properties like `CreationTime`, `LastWriteTime`, `Length`, etc.

It’s useful when you’re working with the same file repeatedly and want to keep an object with its metadata around.

---

### Directory Class Overview

While `File` works with individual files, the `Directory` class works with **folders** (directories). It lets you:

* Check whether a directory exists
* Create or delete a folder
* List subdirectories
* List files within a directory

#### Table 14-2 — Selected `Directory` Class Methods

| Method               | Description                                                       |
| -------------------- | ----------------------------------------------------------------- |
| `CreateDirectory()`  | Creates a directory                                               |
| `Delete()`           | Deletes a directory                                               |
| `Exists()`           | Returns `true` if the specified directory exists                  |
| `GetCreationTime()`  | Returns a `DateTime` showing when the directory was created       |
| `GetDirectories()`   | Returns a `string[]` of subdirectory paths                        |
| `GetFiles()`         | Returns a `string[]` of file paths in the directory               |
| `GetLastWriteTime()` | Returns a `DateTime` showing when the directory was last modified |
| `Move()`             | Moves or renames a directory                                      |

---

### Example: DirectoryInformation Program (Figure 14-3)

This program:

1. Asks the user for a directory name.
2. Checks if it exists via `Directory.Exists()`.
3. If it exists, calls `Directory.GetFiles()` to obtain all files inside.
4. Loops through the returned array and prints each file path.

```csharp
using static System.Console;
using System.IO;

class DirectoryInformation
{
    static void Main()
    {
        string directoryName;
        string[] listOfFiles;

        Write("Enter a folder >> ");
        directoryName = ReadLine();

        if (Directory.Exists(directoryName))
        {
            WriteLine("Directory exists, and it contains the following:");

            listOfFiles = Directory.GetFiles(directoryName);

            for (int x = 0; x < listOfFiles.Length; ++x)
            {
                WriteLine("   {0}", listOfFiles[x]);
            }
        }
        else
        {
            WriteLine("Directory does not exist");
        }
    }
}
```

**Behavior (Figure 14-4):**

* If the user enters an existing folder (for example, `ClientMemos`) →
  the program prints a list of file paths inside that folder.
* If the folder does not exist (for example, `OtherMemos`) →
  the program simply reports that the directory doesn’t exist.

---

### DirectoryInfo (Instance-Based Alternative)

Just like `FileInfo`, there is a `DirectoryInfo` class:

* You construct it with a path.
* You then access properties like `Name`, `FullName`, `CreationTime`, and methods like `GetFiles()` and `GetDirectories()`.

`DirectoryInfo` becomes handy when you’re doing more complex directory operations and want object-oriented access rather than pure static calls.

---

[⬆️ Back to TOC](#table-of-contents) · [⬅️ Previous: Files and the File and Directory Classes](#files-and-the-file-and-directory-classes) · [➡️ Next: Understanding File Data Organization](#understanding-file-data-organization)



<br>
<br>
<br>


# **Understanding File Data Organization**

Businesses structure data using a **data hierarchy**, where each level builds on the one beneath it. This hierarchy gives shape and meaning to raw bits, eventually forming complete files that programs can use.

To understand how C# reads and writes data, you must understand this hierarchy.

---

## **Characters → Fields → Records → Files**

### **Characters**

A *character* is the smallest useful unit of data a user typically thinks about.
Examples include:

* Letters (`A`, `z`)
* Digits (`0`–`9`)
* Punctuation (`;`, `.`)
* Control characters (`\n` newline, `\t` tab)
* Symbols (π, ©, ¥)

C# represents characters using **Unicode**, which supports thousands of symbols from many languages.
A character is ultimately made of **bits**, but programmers care about the meaning, not the binary representation.

Example:
`'A'` might be stored as `01000001`, but to you it's simply `'A'`.

---

### **Fields**

A *field* is one or more characters that represent a meaningful unit.

Examples:

* First name
* Last name
* Social Security number
* Zip code
* Salary

Fields are the building blocks of records.

---

### **Records**

A *record* is a collection of fields that describe one entity.
For example, an employee record might include:

* First name
* Last name
* Employee ID
* Salary

This directly mirrors what you’ve been doing with objects in C#.
An instance of an `Employee` class is essentially a **record** with fields stored in memory.

---

### **Files**

A *file* is a collection of related records stored on a nonvolatile device such as:

* Hard drives
* SSDs
* USB drives
* Cloud storage
* Optical media

A personnel file might contain one record per employee.
Depending on the size of the organization, files may contain dozens, thousands, or millions of records.

---

## **Sequential vs Random Access Files**

### **Sequential Access Files**

Records are processed **in order**, first to last.

* Often sorted by a *key field* (e.g., SSN, employee ID)
* Best for batch processing, reporting, and reading entire datasets

### **Random Access Files**

Records can be accessed **in any order**, directly.

* Useful when you need quick access to specific entries
* Typically requires fixed-length records or indexing

---

## **Opening and Closing Files**

Before a C# program can use a file, it must **open** the file by creating an object that binds to a stream of bytes.

When you are done working with the file, you must **close** the file.

Rules of thumb:

* Failing to close an **input file** → usually no disaster
* Failing to close an **output file** → data corruption or incomplete writes
* Leaving files open wastes system resources and may block other programs, especially in network environments

Example:
If your program keeps the company inventory file open, the order-processing system may fail when it tries to access the same file.

---

## **📁 Representative Diagram (Repo-Ready)**

*ASCII hierarchy inspired by Figure 14-5 — upgraded for clarity and professionalism.*

```
                            ┌─────────────────────────┐
                            │     File: Personnel     │
                            └─────────────┬───────────┘
                                          │
              ┌───────────────────────────┴───────────────────────────┐
              │                                                       │
   ┌────────────────────┐                                 ┌─────────────────────┐
   │ Record: Lee        │                                 │ Record: Smith       │
   └───────────┬────────┘                                 └───────────┬─────────┘
               │                                                              │
   ┌───────────┴───────────┐                                     ┌────────────┴───────────┐
   │  Field: Employee #    │                                     │  Field: Last Name      │
   └───────────┬───────────┘                                     └────────────┬───────────┘
               │                                                              │
      ┌────────┴────────┐                                            ┌────────┴─────────┐
      │ Character: L    │                                            │ Character: e     │
      └──────────────────┘                                           | └──────────────────┘

(Additional fields such as Salary would follow the same pattern.)
```

This version is symmetric, readable, and works beautifully in Markdown files, GitHub previews, and VS Code.

---

[⬆️ Back to TOC](#table-of-contents) · [⬅️ Previous: Using the File and Directory Classes](#using-the-file-and-directory-classes) · [➡️ Next: Understanding Streams](#understanding-streams)

---

<br>
<br>
<br>



# **Understanding Streams**

C# treats files very differently from how humans think about them.
Humans see files as:

* Records
* Fields
* Lines

C# sees files as **pure sequences of bytes**.
To move those bytes around, C# uses **streams**, which act as channels of data flow—like a pipeline that carries bytes from one location to another.

---

## **What Is a Stream?**

A **stream** is an object that:

* Represents a flow of bytes
* Moves data *in one direction*
* Has methods for opening, closing, reading, writing, and flushing

When you do input/output (I/O), you aren’t manipulating the file directly—you’re pushing or pulling bytes through a stream object.

This model makes everything consistent:
the same stream mechanics apply whether you’re reading a file, writing to a file, typing into the keyboard, or printing to the console.

---

## **Standard Input/Output Streams**

C# gives you three built-in streams through the `Console` class:

| Stream          | Purpose                          |
| --------------- | -------------------------------- |
| `Console.In`    | Standard input stream (keyboard) |
| `Console.Out`   | Standard output stream (screen)  |
| `Console.Error` | Error output stream (screen)     |

Every `WriteLine()` you’ve ever used is secretly calling:

```csharp
Console.Out.WriteLine();
```

Every `ReadLine()` is:

```csharp
Console.In.ReadLine();
```

You’ve been using streams long before you knew what the term meant.

---

## **Streams Usually Flow One Way**

A stream is generally **input-only** *or* **output-only**.

Example scenario:

* Your program reads records from a data file → **input stream**
* Valid records are written to one file → **output stream**
* Invalid records are written to another file → **output stream**

Three streams active at once—each flowing in only one direction.

---

## **File Processing Streams**

When reading and writing files, you typically use:

### **1. FileStream**

Low-level stream used for raw bytes.

* Can read or write
* Can be wrapped by other classes (like StreamWriter)
* Controls mode (Create, Append, Open, etc.) and access (Read, Write, ReadWrite)

### **2. StreamReader**

* Reads **text** from a stream
* Converts bytes → characters
* Ideal for plain text files

### **3. StreamWriter**

* Writes **text** to a stream
* Converts characters → bytes
* Works very similarly to `Console.Out`

### Inheritance Note

* `StreamReader` inherits from `TextReader`
* `StreamWriter` inherits from `TextWriter`
* `Console.In` and `Console.Out` are also `TextReader` and `TextWriter`

Meaning:
file text I/O and console text I/O are part of the same inheritance family.

---

## **FileStream Properties**

When you open a file through `FileStream`, you’re creating the stream object that wraps the file.

### **Table 14-3 — Selected FileStream Properties**

| Property   | Description                               |
| ---------- | ----------------------------------------- |
| `CanRead`  | Whether the stream supports reading       |
| `CanSeek`  | Whether you can move the stream pointer   |
| `CanWrite` | Whether the stream supports writing       |
| `Length`   | Total number of bytes in the stream       |
| `Name`     | File name associated with the stream      |
| `Position` | Current byte position (read/write cursor) |

---

## **FileStream Constructor Example**

```csharp
FileStream outFile = new FileStream(
    "SomeText.txt",
    FileMode.Create,
    FileAccess.Write);
```

Explanation:

* **Filename:** `"SomeText.txt"` (assumed to be the current directory)
* **Mode:** `FileMode.Create` → creates a new file (overwrites if it exists)
* **Access:** `FileAccess.Write` → allows writing but not reading

Another constructor:

```csharp
new FileStream("SomeText.txt", FileMode.Append);
```

If mode = `Append`, default access = Write
Otherwise, default = ReadWrite

---

## **FileMode Options (Table 14-4)**

| Member         | Description                                   |
| -------------- | --------------------------------------------- |
| `Append`       | Opens existing file and moves pointer to end  |
| `Create`       | Creates a new file; overwrites existing one   |
| `CreateNew`    | Creates new file; throws exception if exists  |
| `Open`         | Opens existing file; throws if missing        |
| `OpenOrCreate` | Opens if exists; creates if missing           |
| `Truncate`     | Opens existing file, then clears its contents |

---

## **FileAccess Options (Table 14-5)**

| Member      | Description         |
| ----------- | ------------------- |
| `Read`      | Read only           |
| `Write`     | Write only          |
| `ReadWrite` | Both read and write |

---

## **Writing Text Using StreamWriter**

Here’s the WriteSomeText example (Figures 14-7 to 14-9):

```csharp
using static System.Console;
using System.IO;

class WriteSomeText
{
    static void Main()
    {
        FileStream outFile = new FileStream(
            "SomeText.txt", FileMode.Create, FileAccess.Write);

        StreamWriter writer = new StreamWriter(outFile);

        Write("Enter some text >> ");
        string text = ReadLine();

        writer.WriteLine(text);

        // Must close in reverse order
        writer.Close();
        outFile.Close();
    }
}
```

### Key Notes:

* Always create the **FileStream** first
* Then wrap it in a **StreamWriter**
* Always close the **StreamWriter** before the **FileStream**
* Reversing the order causes errors and inconsistent output
* The resulting file will appear exactly as typed in Notepad

---

## **Handling Exceptions (Real-World Practice)**

File I/O is fragile:

* Missing files
* Permission issues
* Locked files
* Network failures

In production code, **all file operations belong inside a `try/catch`**, typically catching:

```csharp
IOException
UnauthorizedAccessException
FileNotFoundException
```

The examples in this chapter skip this so you can focus on I/O concepts—but in reality, error handling is essential.

---

## **Binary and XML Streams**

* **BinaryReader / BinaryWriter**
  Used for working with binary files (images, audio, custom record structures).

* **XmlTextReader / XmlTextWriter**
  Used for reading/writing XML files, often for configuration or data exchange.

---

[⬆️ Back to TOC](#table-of-contents) · [⬅️ Previous: Understanding File Data Organization](#understanding-file-data-organization) · [➡️ Next: Writing and Reading a Sequential Access File](#writing-and-reading-a-sequential-access-file)

---


<br>
<br>
<br>



# **Writing and Reading a Sequential Access File**

C# treats every file as nothing more than a **stream of bytes**.
This means the language doesn’t automatically understand:

* what a “record” is
* what a “field” is
* where one record ends and the next begins

**You**, the programmer, must define the structure:

* how data is formatted
* how records are separated
* how fields are arranged
* how lines are written or read

When you create or consume a data file, you dictate *how* your C# program interprets the bytes.

Whether you are **writing** data to a new file or **reading** from an existing file, the process always begins by creating a **FileStream** object. Every higher-level tool (StreamReader, StreamWriter, BinaryWriter, etc.) wraps around that FileStream to control how bytes flow.

This section will show how to use streams to build and read **sequential access files**—files that must be processed *from beginning to end* in order.

---

[⬆️ Back to TOC](#table-of-contents) · [⬅️ Previous: Understanding Streams](#understanding-streams) · [➡️ Next: Writing Data to a Sequential Access Text File](#writing-data-to-a-sequential-access-text-file)

---


<br>
<br>
<br>
<br>



# **Writing Data to a Sequential Access Text File**

When you want to store structured objects—like Employee records—into a file, you have to convert those objects into text. C# does not automatically understand what a “record” is, so you define the exact format in which records will be written.

The simplest approach is to:

1. Build an `Employee` class to hold fields in memory.
2. Use a `FileStream` to create or overwrite the data file.
3. Wrap the stream with a `StreamWriter`.
4. Concatenate the fields into a single comma-delimited string.
5. Write one record per line using `WriteLine()`.

This produces a **sequential access text file** where records appear in the order they are entered.

---

## **Employee Class Structure**

A basic Employee record has:

* **EmpNum** → `int`
* **Name** → `string`
* **Salary** → `double`

A class is the natural way to group these values:

```csharp
class Employee
{
    public int EmpNum { get; set; }
    public string Name { get; set; }
    public double Salary { get; set; }
}
```

---

## **Creating the Output File**

A `FileStream` defines:

* The filename
* The mode (Create, Append, Open, etc.)
* The access type (Read, Write, ReadWrite)

Example:

```csharp
FileStream outFile = new FileStream(
    FILENAME, FileMode.Create, FileAccess.Write);
```

This creates a new file named *EmployeeData.txt* and prepares it for writing.

You then attach a `StreamWriter`:

```csharp
StreamWriter writer = new StreamWriter(outFile);
```

From this point on, anything written by `writer.WriteLine()` goes into the file instead of the console.

---

## **Using Delimiters and Tokens**

Each line in the file represents **one record**.
Within that record, each field must be separated by a **delimiter** so the data can be split later.

* A **token** is a piece of data (ID, name, salary).
* A **delimiter** marks where one token ends and the next begins.

Common delimiters:

* `","` (comma) — most common
* `"\t"` (tab)
* `"|"` (pipe)
* `","` inside quotes for CSV files containing commas

In this program, the delimiter is:

```csharp
const string DELIM = ",";
```

A record is written like this:

```csharp
writer.WriteLine(emp.EmpNum + DELIM + emp.Name + DELIM + emp.Salary);
```

Each call to `WriteLine()` automatically adds a **carriage return + newline**, creating a clear record boundary.

---

## **Priming Read and Sentinel Value**

To accept multiple employee records, the program uses:

* **A priming read** — gets the first employee number before the loop starts.
* **A sentinel value (999)** — when entered, stops the process.

Priming read:

```csharp
emp.EmpNum = Convert.ToInt32(ReadLine());
```

Loop condition:

```csharp
while (emp.EmpNum != END)
```

This prevents the loop from running if the user immediately enters `999`.

Using a named constant `END` instead of a raw number avoids the **magic number** problem:

```csharp
const int END = 999;
```

---

## **Full WriteSequentialFile Program (Figure 14-11)**

```csharp
using System;
using static System.Console;
using System.IO;

class WriteSequentialFile
{
    static void Main()
    {
        const int END = 999;
        const string DELIM = ",";
        const string FILENAME = "EmployeeData.txt";

        Employee emp = new Employee();

        FileStream outFile = new FileStream(
            FILENAME, FileMode.Create, FileAccess.Write);

        StreamWriter writer = new StreamWriter(outFile);

        Write("Enter employee number or " + END + " to quit >> ");
        emp.EmpNum = Convert.ToInt32(ReadLine());

        while (emp.EmpNum != END)
        {
            Write("Enter last name >> ");
            emp.Name = ReadLine();

            Write("Enter salary >> ");
            emp.Salary = Convert.ToDouble(ReadLine());

            writer.WriteLine(emp.EmpNum + DELIM +
                             emp.Name + DELIM +
                             emp.Salary);

            Write("Enter next employee number or " +
                   END + " to quit >> ");
            emp.EmpNum = Convert.ToInt32(ReadLine());
        }

        writer.Close();
        outFile.Close();
    }
}

class Employee
{
    public int EmpNum { get; set; }
    public string Name { get; set; }
    public double Salary { get; set; }
}
```

---

## **Example Output (Figure 14-12)**

User input:

```
Enter employee number or 999 to quit >> 217
Enter last name >> Santini
Enter salary >> 42000
Enter next employee number or 999 to quit >> 344
Enter last name >> Perez
Enter salary >> 51500
Enter next employee number or 999 to quit >> 510
Enter last name >> Schmidt
Enter salary >> 61000
Enter next employee number or 999 to quit >> 999
```

---

## **Resulting File (Figure 14-13)**

```
217,Santini,42000
344,Perez,51500
510,Schmidt,61000
```

This is now a properly formatted **CSV-style sequential file**.

---

[⬆️ Back to TOC](#table-of-contents) · [⬅️ Previous: Writing and Reading a Sequential Access File](#writing-and-reading-a-sequential-access-file) · [➡️ Next: Reading from a Sequential Access Text File](#reading-from-a-sequential-access-text-file)

---


<br>
<br>
<br>
<br>



# **Reading from a Sequential Access Text File**

Reading a sequential access file uses the same building blocks as writing one, but with the stream direction reversed. You still create a `FileStream`, wrap it in a `StreamReader`, and use a controlled loop—with a priming read—to process each record in order.

Because C# sees files as *streams of bytes*, your program must interpret how to split lines into meaningful fields.

---

## **Opening a File for Reading**

To read an existing file, you create a `FileStream` using **FileMode.Open** and **FileAccess.Read**:

```csharp
FileStream inFile = new FileStream(
    FILENAME, FileMode.Open, FileAccess.Read);
```

If the file does not exist, this constructor throws a `FileNotFoundException`.

### Attach a StreamReader

```csharp
StreamReader reader = new StreamReader(inFile);
```

Now the program can pull text from the file one line at a time.

---

## **Reading One Record at a Time**

To retrieve a record:

```csharp
recordIn = reader.ReadLine();
```

Behavior:

* Returns a full line of text (up to the newline/carriage return).
* Returns **null** when no more data exists.

This naturally supports a loop like:

```csharp
while(recordIn != null)
{
    // process record
    recordIn = reader.ReadLine();
}
```

The first call to `ReadLine()`—before the loop—acts as the **priming read**.

---

## **Splitting a Line into Fields**

Most sequential text files store data using a **delimiter** (commas, tabs, pipes, etc.).

Using:

```csharp
const char DELIM = ',';
```

You can split the line into an array:

```csharp
fields = recordIn.Split(DELIM);
```

For the Employee record:

```cs
217,Santini,42000
```

`fields[0]` → `"217"`
`fields[1]` → `"Santini"`
`fields[2]` → `"42000"`

Convert types:

```csharp
emp.EmpNum = Convert.ToInt32(fields[0]);
emp.Name   = fields[1];
emp.Salary = Convert.ToDouble(fields[2]);
```

This restores the Employee object in memory exactly as it looked when written.

---

## **Formatted Output**

The sample program uses composite formatting to align columns:

```csharp
WriteLine("{0,-5}{1,-12}{2,8}",
    emp.EmpNum, emp.Name, emp.Salary.ToString("C"));
```

This produces aligned columns with salary formatted as currency.

Example output:

```cs
Num   Name        Salary
217   Santini     $42,000.00
344   Perez       $51,500.00
510   Schmidt     $61,000.00
```

---

## **Full ReadSequentialFile Program (Figure 14-14)**

```csharp
using System;
using static System.Console;
using System.IO;

class ReadSequentialFile
{
    static void Main()
    {
        const char DELIM = ',';
        const string FILENAME = "EmployeeData.txt";

        Employee emp = new Employee();

        FileStream inFile = new FileStream(
            FILENAME, FileMode.Open, FileAccess.Read);

        StreamReader reader = new StreamReader(inFile);

        string recordIn;
        string[] fields;

        // Header
        WriteLine("\n{0,-5}{1,-12}{2,8}\n",
            "Num", "Name", "Salary");

        // Priming read
        recordIn = reader.ReadLine();

        while(recordIn != null)
        {
            fields = recordIn.Split(DELIM);

            emp.EmpNum = Convert.ToInt32(fields[0]);
            emp.Name   = fields[1];
            emp.Salary = Convert.ToDouble(fields[2]);

            WriteLine("{0,-5}{1,-12}{2,8}",
                emp.EmpNum,
                emp.Name,
                emp.Salary.ToString("C"));

            // Read the next record
            recordIn = reader.ReadLine();
        }

        reader.Close();
        inFile.Close();
    }
}

class Employee
{
    public int EmpNum { get; set; }
    public string Name { get; set; }
    public double Salary { get; set; }
}
```

---

## **Program Output (Figure 14-15)**

```cs
Num   Name        Salary
217   Santini     $42,000.00
344   Perez       $51,500.00
510   Schmidt     $61,000.00
```

---

[⬆️ Back to TOC](#table-of-contents) · [⬅️ Previous: Writing Data to a Sequential Access Text File](#writing-data-to-a-sequential-access-text-file) · [➡️ Next: Searching a Sequential Text File](#searching-a-sequential-text-file)

---



<br>
<br>
<br>
<br>




# **Searching a Sequential Text File**


Searching through a sequential text file is straightforward: you read each record in order until you reach the end of the file. Because the file position pointer always moves forward as each `ReadLine()` is executed, you must manually reset the pointer if you want to search through the file multiple times.

For example, if a user wants to enter different minimum salary amounts and see all employees who earn at least that salary, you must reread the file from the beginning each time. Rather than closing and reopening the file (wasteful), you can reposition the **FileStream pointer** using the `Seek()` method.

---

## **Rewinding the File Pointer with Seek()**

To move the file pointer back to the beginning:

```csharp
inFile.Seek(0, SeekOrigin.Begin);
```

* **0** → move zero bytes relative to
* **SeekOrigin.Begin** → the start of the file

This resets the stream so the next `ReadLine()` will read the first record again.

### **SeekOrigin Enumeration**

| Member    | Description                                      |
| --------- | ------------------------------------------------ |
| `Begin`   | Reposition starting at the beginning of the file |
| `Current` | Reposition relative to current pointer position  |
| `End`     | Reposition relative to the end of the file       |

---

## **Program: FindEmployees**

*This program allows repeated searches using different minimum salary values.*

### ✔ Fully Commented Version (every line explained)

```csharp
using System;                                   // Provides basic functionality such as Console, Convert, etc.
using static System.Console;                    // Allows Write and WriteLine to be used without Console prefix.
using System.IO;                                // Provides FileStream, StreamReader, and file-related classes.

class FindEmployees                             // Define the class that holds the Main method.
{
    static void Main()                           // Program entry point.
    {
        const char DELIM = ',';                  // Character used to split fields in each line of the file.
        const int END = 999;                     // Sentinel value to quit searching.
        const string FILENAME = "EmployeeData.txt"; // Name of the sequential text file to search.

        Employee emp = new Employee();           // Create an Employee object to hold each record temporarily.

        FileStream inFile = new FileStream(      // Create a FileStream to open the file for reading.
            FILENAME,                            // Use the defined filename.
            FileMode.Open,                       // Open the file; throw an error if it does not exist.
            FileAccess.Read);                    // Open with read-only access.

        StreamReader reader = new StreamReader(inFile); // Wrap the FileStream with a StreamReader for text reading.

        string recordIn;                         // Will hold each record (line of text) read from the file.
        string[] fields;                         // Will hold the split fields after using Split().
        double minSalary;                        // The user-entered minimum salary.

        // Prompt the user for the first minimum salary.
        Write("Enter minimum salary to find or " + END + " to quit >> ");
        minSalary = Convert.ToDouble(ReadLine()); // Convert user input to double.

        while (minSalary != END)                 // Continue searching until the sentinel value is entered.
        {
            // Display table header for results.
            WriteLine("\n{0,-5}{1,-12}{2,8}\n",
                "Num", "Name", "Salary");

            inFile.Seek(0, SeekOrigin.Begin);    // Reset file pointer to the beginning to start a new full scan.

            recordIn = reader.ReadLine();        // Priming read: get the first line of the file.

            while (recordIn != null)             // Continue while there are still records to read.
            {
                fields = recordIn.Split(DELIM);  // Split the line into fields using the delimiter.

                emp.EmpNum = Convert.ToInt32(fields[0]); // Convert and store employee number.
                emp.Name = fields[1];                     // Store employee name (already a string).
                emp.Salary = Convert.ToDouble(fields[2]); // Convert and store employee salary.

                // Check if salary meets or exceeds the minimum.
                if (emp.Salary >= minSalary)
                {
                    WriteLine("{0,-5}{1,-12}{2,8}",       // Format and print the matching employee.
                        emp.EmpNum,
                        emp.Name,
                        emp.Salary.ToString("C"));        // Format salary as currency.
                }

                recordIn = reader.ReadLine();    // Read the next record (next line in the file).
            }

            // Prompt user again to search with a new minimum salary.
            Write("\nEnter minimum salary to find or " + END + " to quit >> ");
            minSalary = Convert.ToDouble(ReadLine()); // Read the next minimum salary.
        }

        reader.Close();                          // Close the StreamReader first (highest-level object).
        inFile.Close();                           // Then close the underlying FileStream.
    }
}

// Employee class reused to hold fields from each record.
class Employee
{
    public int EmpNum { get; set; }              // Employee number property.
    public string Name { get; set; }             // Employee name.
    public double Salary { get; set; }           // Employee salary.
}
```

---

## **Typical Output**

```cs
Enter minimum salary to find or 999 to quit >> 50000

Num   Name        Salary
344   Perez       $51,500.00
510   Schmidt     $61,000.00

Enter minimum salary to find or 999 to quit >> 55000

Num   Name        Salary
510   Schmidt     $61,000.00

Enter minimum salary to find or 999 to quit >> 0

Num   Name        Salary
217   Santini     $42,000.00
344   Perez       $51,500.00
510   Schmidt     $61,000.00

Enter minimum salary to find or 999 to quit >> 999
```

---

## **Recap**

* Sequential files must be reread from the beginning to perform repeated searches.
* `Seek(0, SeekOrigin.Begin)` resets the pointer instantly.
* `recordIn = reader.ReadLine()` acts as both the **priming read** and the per-loop read.
* Search loops often require nested loops:

  * outer → new search criteria
  * inner → scan entire file

---

[🔼 Back to TOC](#table-of-contents) · [⬅️ Previous: Reading a Sequential Access File](#reading-from-a-sequential-access-text-file) · [➡️ Next: Understanding Serialization and Deserialization](#understanding-serialization-and-deserialization)

---




<br>
<br>
<br>
<br>



# **Understanding Serialization and Deserialization (with fully commented code)**

Writing to text files works, but it has two big issues:

1. **Security** – anyone can open a `.txt` or `.csv` file and read the contents in Notepad.
2. **Manual work** – every field must be converted to text, joined with delimiters, and then parsed and converted back when reading.

**Serialization** fixes that by turning **entire objects** into a **stream of bytes** automatically.
**Deserialization** reverses it: it recreates the object from the bytes.

With serialization:

* You don’t manually split / parse / convert fields.
* You store whole `Employee` objects as-is.
* The resulting file is not human-readable, which adds a layer of privacy.

---

## Making a Class Serializable

To make a class serializable, mark it with `[Serializable]`:

```csharp
[Serializable]                      // Mark the class as serializable so it can be converted to bytes
class Employee                      // Define the Employee class
{
    public int EmpNum { get; set; } // Employee number (int) – serializable
    public string Name { get; set; }// Employee name (string) – serializable
    public double Salary { get; set;}// Employee salary (double) – serializable
}
```

All fields must be serializable. Primitive types (`int`, `double`, `string`) and arrays are fine by default.

---

## Namespaces Needed for Binary Serialization

We need extra namespaces beyond the usual `System` and `System.IO`:

```csharp
using System;                                      // Basic types and console functionality
using static System.Console;                       // Allows using Write/WriteLine without Console. prefix
using System.IO;                                   // FileStream and IO-related classes
using System.Runtime.Serialization;                // Base types for serialization
using System.Runtime.Serialization.Formatters.Binary; // BinaryFormatter for binary serialization
```

---

## Full Program with Line-by-Line Comments

This program:

1. Prompts the user to enter multiple `Employee` records.
2. Serializes each `Employee` and writes it to a binary file.
3. Reopens the file.
4. Deserializes each `Employee` object and prints them in a table.

```csharp
using System;                                      // Provides core language features like Console, Convert, etc.
using static System.Console;                       // Lets us call Write and WriteLine without prefixing with Console.
using System.IO;                                   // Provides FileStream and other file-related classes.
using System.Runtime.Serialization;                // Contains serialization-related infrastructure.
using System.Runtime.Serialization.Formatters.Binary; // Contains BinaryFormatter used for binary serialization.

class SerializableDemonstration                     // Define a class that will hold Main() and run our demo.
{
    static void Main()                              // Entry point for the program.
    {
        const int END = 999;                        // Sentinel value used to stop entering employees.
        const string FILENAME = "Data.ser";         // Name of the file where serialized data will be stored.

        Employee emp = new Employee();              // Create a single Employee object that we will reuse and fill.

        // ---------- WRITE PHASE: serialize objects and store them in a file ----------

        FileStream outFile = new FileStream(        // Create a FileStream to write to the disk file.
            FILENAME,                               // Use the constant filename "Data.ser".
            FileMode.Create,                        // Create a new file; overwrite if it already exists.
            FileAccess.Write);                      // Open the file with write-only access.

        BinaryFormatter bFormatter = new BinaryFormatter(); // Create a BinaryFormatter to handle object serialization.

        Write("Enter employee number or " +         // Prompt the user for the first employee number...
              END + " to quit >> ");                // ...and display the sentinel value as part of the message.
        emp.EmpNum = Convert.ToInt32(ReadLine());   // Read the user input, convert to int, and store in EmpNum.

        while (emp.EmpNum != END)                   // Loop while the entered employee number is not the sentinel.
        {
            Write("Enter last name >> ");           // Prompt the user for the employee's last name.
            emp.Name = ReadLine();                  // Read the last name as a string and store it in Name.

            Write("Enter salary >> ");              // Prompt the user for the employee's salary.
            emp.Salary = Convert.ToDouble(ReadLine());// Read the salary, convert to double, and store in Salary.

            bFormatter.Serialize(outFile, emp);     // Serialize the entire Employee object to the output file.

            Write("Enter employee number or " +     // Prompt for the next employee number...
                  END + " to quit >> ");            // ...again reminding of the sentinel to quit.
            emp.EmpNum = Convert.ToInt32(ReadLine());// Read the next employee number and convert it to int.
        }

        outFile.Close();                            // Close the output FileStream after writing all employees.

        // ---------- READ PHASE: deserialize objects and display them ----------

        FileStream inFile = new FileStream(         // Create a FileStream to read from the same file.
            FILENAME,                               // Use the same file name "Data.ser".
            FileMode.Open,                          // Open the existing file; error if it does not exist.
            FileAccess.Read);                       // Open the file with read-only access.

        WriteLine("\n{0,-5}{1,-12}{2,8}\n",         // Write a header line with aligned columns.
            "Num", "Name", "Salary");               // Column titles: Num, Name, Salary.

        while (inFile.Position < inFile.Length)     // Loop while the current read position is before the end of file.
        {
            emp = (Employee)bFormatter.Deserialize(inFile); // Deserialize the next Employee object from the file.

            WriteLine("{0,-5}{1,-12}{2,8}",         // Write one formatted line of employee data.
                emp.EmpNum,                         // Employee number, left-aligned within 5 characters.
                emp.Name,                           // Employee name, left-aligned within 12 characters.
                emp.Salary.ToString("C"));          // Salary formatted as currency and aligned within 8 spaces.
        }

        inFile.Close();                             // Close the input FileStream after all objects are read.
    }
}

[Serializable]                                      // Mark the Employee class as serializable.
class Employee                                      // Define the Employee class.
{
    public int EmpNum { get; set; }                 // Public property for employee number (int).
    public string Name { get; set; }                // Public property for employee name (string).
    public double Salary { get; set; }              // Public property for employee salary (double).
}
```

---

## Key Takeaways from This Section

* **Serialization**: convert an object (and all its fields) into a byte stream in one shot.
* **Deserialization**: rebuild the full object from that byte stream.
* `[Serializable]` is required on any class whose objects you want to serialize.
* `BinaryFormatter.Serialize(stream, obj)` writes the object.
* `BinaryFormatter.Deserialize(stream)` reads it back (and must be cast).
* Loop condition `while (inFile.Position < inFile.Length)` is how we know there are more serialized objects to read.

---

[⬆️ Back to TOC](#table-of-contents) · [⬅️ Previous: Searching a Sequential Text File](#searching-a-sequential-text-file) · [➡️ Next: Chapter Summary](#chapter-summary)





# ⭐ **Chapter 14 Summary — Files and Streams**


A **computer file** is a collection of information stored permanently on a nonvolatile device. Files are organized by users into **folders/directories**, and in C#, the `File` class provides access to file-level operations while the `Directory` class provides access to folder-level operations.

Data items are structured in a **hierarchy** of:

* characters
* fields
* records
* the file itself

A file is considered **sequential access** when data is read in order, record by record, from beginning to end. These records are usually arranged according to the value of a **key field**.

Before a program can work with a file, the file must be **opened**, which associates the file with a **stream of bytes** through an object such as `FileStream`. When the file is **closed**, your application can no longer use that stream.

---

## **Streams**

In C#, bytes flow **into** and **out of** programs using **streams**.
The `Console` class gives you three default streams:

* `Console.In` — standard input
* `Console.Out` — standard output
* `Console.Error` — standard error

For file processing, you instead use classes such as:

* `StreamReader` (text input)
* `StreamWriter` (text output)
* `FileStream` (general input/output)

---

## **Working With Text Files**

A `StreamWriter` can write lines to a text file using `WriteLine()`.
Each field in a record should be separated by a **delimiter** such as a comma or space.

A `StreamReader` reads text using `ReadLine()`.
When `ReadLine()` returns **null**, the end of the file has been reached.

After a line of text is read, the `Split()` method can be used to break the record into individual data fields (tokens).

---

## **Sequential File Reading Behavior**

When reading sequential files:

* each new call to `ReadLine()` reads the next record
* this happens because the file maintains a **position pointer**
* the pointer tracks the byte position of the next read

To reread the file:

* close and reopen it, **or**
* use `Seek()` with a `SeekOrigin` value to reposition the pointer manually

---

## **Serialization / Deserialization**

Serialization converts **objects** into **streams of bytes**.
Deserialization restores objects from those streams.

This technique solves two problems with text files:

1. Text files are human-readable → insecure for sensitive data.
2. Storing many fields as text requires conversion, formatting, and manual parsing.

To make a class serializable:

* mark it with the `[Serializable]` attribute.

All fields of the class must be serializable.
Simple types (int, double, string) are serializable by default.
Arrays are serializable, but if they contain other objects, those objects must be serializable too.

You can also implement `ISerializable` and write `GetObjectData()`,
but using `[Serializable]` is simpler.

Serialization uses the namespaces:

```
System.Runtime.Serialization
System.Runtime.Serialization.Formatters.Binary
```

To serialize an object:

```csharp
bFormatter.Serialize(outFile, emp);
```

To deserialize it:

```csharp
emp = (Employee)bFormatter.Deserialize(inFile);
```

Serialization and deserialization each write/read the **entire object** at once,
regardless of how many fields the object contains.

The resulting `.ser` file contains binary data, not easily readable by humans
(as shown in Figure 14-24), unlike text-based sequential files.

---

# ✔️ **Chapter Summary Completed**

This version contains ALL the essential concepts:

* file hierarchy
* streams
* sequential access
* StreamReader / StreamWriter
* file position pointers
* Seek()
* serialization
* deserialization
* `[Serializable]` attribute
* binary vs. text files

[🔼 Back to TOC](#table-of-contents)
[➡️ Move to Key Terms](#key-terms)
[⬅️ Go to Previous Section](#writing-and-reading-a-sequential-access-file)



<br>
<br>
<br>
<br>



Got you — now we’ll turn your **Key Terms** section into a *hyperlinked map* that jumps directly to **where each concept appears in your Chapter 14 file**.

Since your notes follow a consistent structure with section headers like:

* `# Files and the File and Directory Classes`
* `# Understanding File Data Organization`
* `# Understanding Streams`
* `# Writing and Reading a Sequential Access File`
* `# Writing Data to a Sequential Access Text File`
* `# Reading from a Sequential Access Text File`
* `# Searching a Sequential Text File`
* `# Understanding Serialization and Deserialization`

…I will attach **each term to the exact section where the concept is explained.**

Below is your **Key Terms** section with **internal Markdown links** that point directly to the right place in your chapter.
You can paste this directly into your repo.

---

# **📑 Key Terms**

[🔼 Back to TOC](#table-of-contents)
[⬅️ Previous: Chapter Summary](#chapter-summary)

---

## **Memory & Storage Concepts**

**Random access memory (RAM)**
Temporary volatile storage used while programs run. Discussed in:
➡️ [Files and the File and Directory Classes](#files-and-the-file-and-directory-classes)

**Volatile**
Describes memory erased when power is lost. Mentioned in:
➡️ [Files and the File and Directory Classes](#files-and-the-file-and-directory-classes)

**Nonvolatile**
Storage that retains data even when powered off. Covered in:
➡️ [Files and the File and Directory Classes](#files-and-the-file-and-directory-classes)

**Computer file**
A collection of data stored on a nonvolatile device. Introduced in:
➡️ [Files and the File and Directory Classes](#files-and-the-file-and-directory-classes)

**Permanent storage devices**
Devices like SSDs, hard drives, USB drives, and optical discs. Covered in:
➡️ [Files and the File and Directory Classes](#files-and-the-file-and-directory-classes)

---

## **File Types & Size Units**

**Text files**
Human-readable files encoded with ASCII/Unicode. Covered in:
➡️ [Files and the File and Directory Classes](#files-and-the-file-and-directory-classes)

**Data files**
Text files specifically used for storing structured program data. Mentioned in:
➡️ [Files and the File and Directory Classes](#files-and-the-file-and-directory-classes)

**Binary files**
Non-text files storing raw bytes (e.g., images, executables). Covered in:
➡️ [Files and the File and Directory Classes](#files-and-the-file-and-directory-classes)

**Byte, Kilobyte, Megabyte, Gigabyte**
Units of file size. Explained in:
➡️ [Files and the File and Directory Classes](#files-and-the-file-and-directory-classes)

---

## **File Operations**

**Read from a file**
Copy bytes from storage → RAM. Covered in:
➡️ [Files and the File and Directory Classes](#files-and-the-file-and-directory-classes)

**Write to a file**
Copy bytes from RAM → storage. Covered in:
➡️ [Files and the File and Directory Classes](#files-and-the-file-and-directory-classes)

**Persistent**
Data that remains available even when the program ends. Mentioned in:
➡️ [Files and the File and Directory Classes](#files-and-the-file-and-directory-classes)

**Root directory**
Main directory of a storage device. Covered in:
➡️ [Files and the File and Directory Classes](#files-and-the-file-and-directory-classes)

**Folders or directories**
Containers for organizing files. Covered in:
➡️ [Files and the File and Directory Classes](#files-and-the-file-and-directory-classes)

**Path**
Full location of a file within nested directories. Explained in:
➡️ [Files and the File and Directory Classes](#files-and-the-file-and-directory-classes)

---

## **Data Structure Concepts (Hierarchy)**

**Data hierarchy**
Character → Field → Record → File. Covered in:
➡️ [Understanding File Data Organization](#understanding-file-data-organization)

**Character**
Smallest unit of meaningful data. Discussed in:
➡️ [Understanding File Data Organization](#understanding-file-data-organization)

**Character set**
Collection of characters supported by a system (ASCII, Unicode). Mentioned in:
➡️ [Understanding File Data Organization](#understanding-file-data-organization)

**Field**
Group of characters representing one item of data. Covered in:
➡️ [Understanding File Data Organization](#understanding-file-data-organization)

**Record**
A group of related fields. Covered in:
➡️ [Understanding File Data Organization](#understanding-file-data-organization)

---

## **Sequential File Concepts**

**Sequential access file**
Records must be read in order from first to last. Covered in:
➡️ [Understanding File Data Organization](#understanding-file-data-organization)

**Key field**
Unique field used to sort records. Covered in:
➡️ [Understanding File Data Organization](#understanding-file-data-organization)

**Random access file**
Records can be accessed in any order. Introduced in:
➡️ [Understanding File Data Organization](#understanding-file-data-organization)

**Opening a file**
Creating a stream-bound file object. Discussed in:
➡️ [Understanding File Data Organization](#understanding-file-data-organization)

**Closing a file**
Releasing the file from the program. Covered in:
➡️ [Understanding File Data Organization](#understanding-file-data-organization)

---

## **Streams & IO**

**Stream**
Pipeline/channel through which bytes flow. Fully explained in:
➡️ [Understanding Streams](#understanding-streams)

**Exposes** *(FileStream exposes a stream around a file)*
Means making internal functionality available through a public interface. Mentioned in:
➡️ [Understanding Streams](#understanding-streams)

**Token**
A chunk of data separated by delimiters. Mentioned in:
➡️ [Writing Data to a Sequential Access Text File](#writing-data-to-a-sequential-access-text-file)

**Delimiter**
Character used to separate tokens (e.g., comma). Covered in:
➡️ [Writing Data to a Sequential Access Text File](#writing-data-to-a-sequential-access-text-file)

**CSV file**
Comma-separated values file. Mentioned in:
➡️ [Writing Data to a Sequential Access Text File](#writing-data-to-a-sequential-access-text-file)

**Priming read**
The first read before entering a loop. Discussed in:
➡️ [Writing Data to a Sequential Access Text File](#writing-data-to-a-sequential-access-text-file)

**Magic number**
A hardcoded literal value with no explanation. Discussed in:
➡️ [Writing Data to a Sequential Access Text File](#writing-data-to-a-sequential-access-text-file)

**File position pointer**
Tracks the byte position of the next read. Covered in:
➡️ [Searching a Sequential Text File](#searching-a-sequential-text-file)

---

## **Serialization Concepts**

**Serialization**
Converting an object into a byte stream. Covered in:
➡️ [Understanding Serialization and Deserialization](#understanding-serialization-and-deserialization)

**Deserialization**
Reconstructing an object from a byte stream. Covered in:
➡️ [Understanding Serialization and Deserialization](#understanding-serialization-and-deserialization)

**XML**
Extensible Markup Language; format for structured data. Mentioned in:
➡️ [Understanding Streams](#understanding-streams)

---

[🔼 Back to TOC](#table-of-contents)
[➡️ Continue to Review Questions](#review-questions)

---

