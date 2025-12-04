
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






