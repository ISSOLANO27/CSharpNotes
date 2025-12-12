
# Chapter 1 — A First Program Using C#

# Introduction

[Table of Contents](#table-of-content)

Upon completion of this chapter, you will be able to:

* Describe the **programming process**.
* Differentiate between **procedural programming** and **object-oriented programming (OOP)**.
* Describe the **features of object-oriented programming languages**.
* Describe the **C# programming language** and its role in modern development.
* Write a basic **C# program that produces output**.
* Select appropriate **identifiers** for variables, classes, and methods.
* Improve programs by adding **comments** and using the **System namespace**.
* **Compile and execute** a C# program using both the command prompt and the Visual Studio IDE.

---

## Overview

Programming a computer is both a technical and creative discipline. You are required to think carefully, design solutions step-by-step, and express those solutions with precision in a programming language. At the same time, programming rewards experimentation, problem-solving, and logical thinking.

As you progress through this book and this documentation, you will learn:

* How programmers **plan program logic**, often before writing any code.
* How different programming languages—such as **Visual Basic**, **Java**, **C++**, and **C#**—provide different tools for expressing solutions.
* How **C#**, a modern, object-oriented language developed by Microsoft, supports structured, maintainable, and scalable software development.

For beginners, this chapter introduces new ways of analyzing problems and approaching solutions. For experienced programmers new to C#, this chapter highlights the language's design philosophy and strengths.

---

## Why This Chapter Matters

This introductory chapter provides the foundation for everything that follows. It places C# within the broader history of programming and guides you through writing and executing your **first working program**.

By the end of Chapter 1, you will not only understand what C# code *looks like*—you will understand **why** it looks that way and how the language is structured to support professional software development.

---

## Example: A First C# Program

Although later sections break this down in detail, the following short program illustrates the core ideas introduced in this chapter:

```csharp
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("My first C# program!");
    }
}
```

This chapter explains:

* Why the program must include a **Main()** method
* What a **namespace** is
* Why **Console.WriteLine()** produces output
* How the compiler translates this source code into executable instructions

---

This chapter provides background, context, and vocabulary essential for navigating the rest of the course. Once these foundations are clear, you will build progressively more powerful programs using C# and the .NET environment.

---

[Next: The Programming Process](#the-programming-process)

---




## Table of Contents

* [The Programming Process](#the-programming-process)
* [Procedural and Object-Oriented Programming](#procedural-and-object-oriented-programming)
* [Features of Object-Oriented Programming Languages](#features-of-object-oriented-programming-languages)
* [The C# Programming Language](#the-c-programming-language)
* [Writing a C# Program That Produces Output](#writing-a-c-program-that-produces-output)
* [Selecting Identifiers](#selecting-identifiers)

### **Improving Programs by Adding Comments and Using the System Namespace**

* [Adding Program Comments](#adding-program-comments)
* [Using the System Namespace](#using-the-system-namespace)

### **Compiling and Executing a C# Program**

* [Compiling Code from the Command Prompt](#compiling-code-from-the-command-prompt)

* [Compiling Code Using the Visual Studio IDE](#compiling-code-using-the-visual-studio-ide)

* [Noticing the Differences Between the Programs in the Text Editor and the IDE](#noticing-the-differences-between-the-programs-in-the-text-editor-and-the-ide)

* [Deciding Which Environment to Use](#deciding-which-environment-to-use)

* [Chapter Summary](#chapter-summary)

---

<br>
<br>
<br>
<br>
<br>





# The Programming Process

[Back to Table of Contents](#chapter-1--a-first-program-using-c)

A **computer program** is a structured set of instructions that tells a computer how to perform a specific task. These sets of instructions are known collectively as **software**, which falls into two broad categories.

---

## System Software

**System software** operates and manages the fundamental functions of a computer system.
Examples include:

* **Microsoft Windows**
* **macOS**
* **Linux**

This category governs hardware interactions, resource allocation, file systems, and the foundations on which all other programs run.

---

## Application Software

**Application software** enables users to perform meaningful tasks such as:

* Creating documents
* Calculating payroll
* Playing games
* Managing databases

These programs are often called **apps**, especially in consumer software environments.

---

## Hardware and Machine Language

The **hardware** of a computer consists of its physical components. Internally, hardware is built from circuitry composed of microscopic on/off switches. These switches are controlled using the lowest-level programming form available to a machine: **machine language**.

Machine language uses:

* `1` → Switch is on
* `0` → Switch is off

Programming directly in machine language would require memorizing and maintaining enormous sequences of 1s and 0s. Such an approach is:

* Hard to read
* Hard to modify
* Error-prone
* Hardware-specific

Each computer architecture arranges switches differently. This means a machine-language program written for one device would likely need restructuring to run on another.

---

## High-Level Programming Languages

To make programming more practical, **high-level languages** were created. These languages allow programmers to use:

* Human-friendly **keywords**
* Named memory locations (**identifiers**)
* Structured commands rather than raw binary

Examples of general keywords across languages include *read*, *write*, and *add*—terms far easier to reason about than binary operations.

### Keywords and Identifiers

* A **keyword** is a reserved word with a predefined meaning in the language.
* An **identifier** is the programmer-defined name for memory locations, methods, classes, and other program elements.

Instead of remembering memory addresses, programmers can assign names such as:

* `hoursWorked`
* `payRate`

These names follow **camel casing** (lower camel case), where the identifier begins lowercase and uses uppercase letters to indicate internal word boundaries.

### Case Sensitivity

C# is **case sensitive**, meaning:

* `payRate`
* `PayRate`
* `payrate`

are all distinct identifiers.

---

## Syntax and Compilation

Every programming language defines a **syntax**, which consists of its rules and structure.
Examples:

* One language may print using `print`
* C# prints using `Console.WriteLine()`

A **compiler** translates high-level source code into machine code. During compilation:

* If a **syntax error** occurs, translation stops
* The programmer must correct the error and recompile
* Only when all syntax errors are resolved can translation succeed

To master any programming language—including **C#**, **C++**, **Java**, and **Visual Basic**—you must learn both its vocabulary and its syntax rules.

---

## Other Types of Language Translators

Not all languages use compilers. Others use:

* **Interpreters** → Translate and execute one statement at a time (e.g., older BASIC).
* **Assemblers** → Convert assembly language mnemonics into machine code.

Regardless of the tool, the ultimate purpose remains the same:

> Convert human-readable instructions into machine-executable operations.

---

## Programming Logic

Knowing syntax is not enough. A programmer must also understand **logic**: the correct sequence of operations required to produce the intended result.

Logical errors occur when statements are correctly written syntactically but placed or designed incorrectly, such as:

* Multiplying values when the task requires division
* Attempting to compute results before gathering necessary data
* Arranging instructions in the wrong order

Different languages may express logic differently, but the underlying problem-solving structure remains constant.

A helpful analogy:
Just as a musician can play notes perfectly but still produce poor music if the notes are played in the wrong order, a programmer can write syntactically correct statements and still produce incorrect results.

---

## Bugs and Debugging

The term **bug** has long been used to describe malfunctions in electrical systems. The famous story of the 1945 Harvard Mark II moth trapped inside a relay popularized the term among programmers, but the word existed earlier to describe electrical defects during Thomas Edison’s era.

The act of locating and correcting program errors is known as **debugging**. Debugging is an essential and ongoing part of the programming process, regardless of language or experience level.

---

[Previous: Introduction](#introduction)
[Next: Procedural and Object-Oriented Programming](#procedural-and-object-oriented-programming)






<br>
<br>
<br>
<br>
<br>




<br>
<br>
<br>
<br>
<br>





<br>
<br>
<br>
<br>
<br>





<br>
<br>
<br>
<br>
<br>





<br>
<br>
<br>
<br>
<br>





<br>
<br>
<br>
<br>
<br>





<br>
<br>
<br>
<br>
<br>





<br>
<br>
<br>
<br>
<br>





<br>
<br>
<br>
<br>
<br>





<br>
<br>
<br>
<br>
<br>





<br>
<br>
<br>
<br>
<br>





<br>
<br>
<br>
<br>
<br>





<br>
<br>
<br>
<br>
<br>





<br>
<br>
<br>
<br>
<br>





<br>
<br>
<br>
<br>
<br>





Just tell me **which section you want to start writing** and we’ll build it out in full like Chapter 10 and Chapter 8.
