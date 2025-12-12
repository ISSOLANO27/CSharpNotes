
# Chapter 1 — A First Program Using C#


## Table of Contents

* [The Programming Process](#the-programming-process)
* [Procedural and Object-Oriented Programming](#procedural-and-object-oriented-programming)
* [Features of Object-Oriented Programming Languages](#features-of-object-oriented-programming-languages)
* [The C# Programming Language](#the-c-programming-language)
* [Writing a C# Program That Produces Output](#writing-a-c-program-that-produces-output)
* [Selecting Identifiers](#selecting-identifiers)



- [Improving Programs by Adding Comments and Using the System Namespace](#improving-programs-by-adding-comments-and-using-the-system-namespace)
  * [Adding Program Comments](#adding-program-comments)
  * [Using the System Namespace](#using-the-system-namespace)

### **Compiling and Executing a C# Program**

* [Compiling Code from the Command Prompt](#compiling-code-from-the-command-prompt)

* [Compiling Code Using the Visual Studio IDE](#compiling-code-using-the-visual-studio-ide)

* [Noticing the Differences Between the Programs in the Text Editor and the IDE](#noticing-the-differences-between-the-programs-in-the-text-editor-and-the-ide)

* [Deciding Which Environment to Use](#deciding-which-environment-to-use)

* [Chapter Summary](#chapter-summary)

---

## Introduction

[Next: The Programming Process](#the-programming-process)

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
[Table of Contents](##table-of-contents)


---


<br>
<br>
<br>
<br>
<br>





# The Programming Process

[Previous: Introduction](#introduction)
[Next: Procedural and Object-Oriented Programming](#procedural-and-object-oriented-programming)


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

[Back to Table of Contents](#chapter-1--a-first-program-using-c)







<br>
<br>
<br>
<br>
<br>



# Procedural and Object-Oriented Programming



Two widely used approaches to writing computer programs are **procedural programming** and **object-oriented programming (OOP)**. Both aim to solve computational problems, but they differ significantly in how they structure logic and data.

---

## Procedural Programming

Procedural programming centers on **step-by-step instructions** that operate on values stored in memory. In this model, the programmer:

* Creates and names memory locations
* Writes statements that manipulate those memory locations
* Organizes repeated or related operations into **methods**

### Variables and Identifiers

A **variable** is a named memory location capable of holding values that may change as the program runs. Examples include:

* `hoursWorked`
* `pay`

Variable names follow identifier rules: they must be one word, no spaces, and must follow the language’s casing conventions.

In C#, variables conventionally use **camel casing** (lower camel case), such as:

* `hoursWorked`
* `payRate`

These names represent distinct storage locations whose values can change over time.

### Example: Procedural Payroll Logic (Conceptual)

A simple payroll program might execute steps such as:

1. Read the employee’s hours worked
2. Multiply hours by the pay rate
3. Print the resulting paycheck amount

Each step operates directly on variables.

### Grouping Logic Into Methods

To manage complexity, procedural programs group operations into **methods** (also called *procedures*, *functions*, or *subroutines* depending on the language).

Example method name:

```cs
CalculateWithholdingTax()
```

Method names in C# follow **Pascal casing** (also called upper camel case), where all words begin with uppercase letters. This casing distinguishes methods from variables.

A procedural program can grow very large, often containing:

* Hundreds of variables
* Thousands of method calls
* Long sequences of logic spread across many operations

Languages traditionally associated with procedural programming include **C** and **Logo**.

---

## Object-Oriented Programming (OOP)

Object-oriented programming extends procedural programming. It still uses variables and methods but organizes them around **objects**—entities that model real-world or conceptual things.

An **object** contains:

* **Attributes** (data it “has”)
* **Behaviors** (methods it “does”)

### Example: Paycheck as an Object

The figure you provided represents a conceptual class diagram:

```cs
Paycheck
-------------------------
payee
hoursWorked
grossPay
-------------------------
calculateAmount()
writeCheck()
cashCheck()
```

This shows how a programmer thinks in terms of **attributes** (payee, hoursWorked, grossPay) and **behaviors** (calculateAmount(), writeCheck(), cashCheck()).

### Attributes and State

The **state** of an object depends on its attribute values.
For example:

* payee → Alice Nelson
* grossPay → $400

These attribute values describe the object at a given moment.

### Behaviors (Methods)

A paycheck object may perform actions such as:

* Calculating its amount
* Writing itself
* Being cashed

These are represented as methods inside the object.

### Designing a System Using Objects

Beyond modeling a single object, OOP encourages building entire systems out of interacting objects. For example, a payroll system might include:

* Paycheck objects
* Employee objects
* TimeCard objects
* BankAccount objects

Each encapsulates its own attributes and methods.

### OO Terminology

Programmers often abbreviate:

* **OO** → object oriented
* **OOP** → object-oriented programming

Languages that support object orientation include:

* **C#**
* **Java**
* **Visual Basic**
* **C++**

While OO languages can write procedural code, *procedural languages cannot implement OO structures fully*.

---

## Why OOP Matters

Both procedural and OO approaches can produce correct solutions and reuse logic. The difference lies in how problems are **conceptualized**:

* Procedural programming focuses on **operations and data flow**.
* OOP focuses on **objects, responsibilities, and interactions**.

The OO approach is often considered more natural because humans tend to think in terms of objects

[Back to Table of Contents](#chapter-1--a-first-program-using-c)

<br>
<br>
<br>
<br>
<br>




# Features of Object-Oriented Programming Languages

[Previous: Procedural and Object-Oriented Programming](#procedural-and-object-oriented-programming)
[Next: The C# Programming Language](#the-c-programming-language)



For a programming language to be considered **object-oriented**, it must support several foundational features. These features define how data and behavior are modeled in software and how programmers structure large, maintainable systems.

The essential features of object-oriented programming (OOP) are:

* **Classes**
* **Objects**
* **Encapsulation** (and **interfaces**)
* **Inheritance**
* **Polymorphism**

Each feature plays a specific role in shaping how software is designed and how components interact.

---

## Classes

A **class** is a blueprint or template that describes:

* What **attributes** (data) an object will have
* What **behaviors** (methods) an object will be able to perform

You can think of a class as a recipe or architectural plan: it defines structure and capabilities, but it is not itself a tangible object.

### Naming Conventions

In C#, class names:

* Start with an uppercase letter
* Use **Pascal casing** for multi-word names

Examples:

* `Automobile`
* `Dog`
* `BankAccount`

---

## Objects

An **object** is an **instance** of a class—one specific, concrete example created from the blueprint.

While all objects of a class share the same **attributes**, the values of those attributes—the object’s **state**—can differ.

### Example: Automobile Class

Common attributes:

* make
* model
* year
* purchasePrice

An **Automobile object** might hold the state:

* Ford
* Taurus
* 2018
* $27,000

### Example: Dog Class

Typical attributes:

* breed
* name
* age
* vaccinationStatus

A specific Dog object might have the values:

* Labrador retriever
* Murphy
* 7
* current

When you know an object’s class, you immediately know which attributes and behaviors it possesses.

---

## Encapsulation and Interfaces

**Encapsulation** is the process of bundling an object’s attributes (data) and methods (behaviors) into a single, cohesive unit. The internal workings of an object are hidden; only the **interface**—how external code interacts with the object—is exposed.

This is often described as the **black-box principle**:

> You use the object without needing to understand its internal implementation.

### Real-world examples

* You fill a car with gasoline without understanding how the pump or the fuel injection system works.
* You read a speedometer without knowing how its internal mechanisms translate wheel rotation into displayed speed.

As long as the **interface** remains consistent, the internal mechanism can change without affecting the user.

In programming, this allows:

* Easier maintenance
* More predictable behavior
* Safer data management
* Clear separation between how a feature works and how it is used

---

## Inheritance

**Inheritance** allows a new class (child) to extend an existing class (parent), gaining its attributes and methods automatically.

The child class typically:

* **Inherits** all properties and behaviors from the parent
* Adds **new attributes or methods** that make it more specific

### Example: Dog → ShowDog

A `ShowDog` class inherits everything from `Dog`, and may define:

* A new attribute: `ribbonsWon`
* A new method: `EnterShow()`

Inheritance saves time because programmers can build new classes by extending existing, proven designs rather than starting from scratch.

Inheritance is covered more deeply in the chapter **Introduction to Inheritance**.

---

## Polymorphism

**Polymorphism** allows methods with the **same name** to behave differently depending on:

* The object calling the method
* The context in which the method is used

This capability allows OOP systems to treat different objects uniformly while still allowing appropriate behavior.

### Example: “fill” operation

* You can “fill” a Dog (with food).
* You can “fill” an Automobile (with gasoline).
* You can “fill” a ShowDog (with a specialized diet).

The same *verb*—*fill*—applies, but the behavior is context-dependent.

Older procedural languages could not distinguish between these scenarios, but OOP languages can.

---

## Encapsulation, Inheritance, and Polymorphism Together

These three features work together to provide:

* Modular design
* Reusable components
* Clear organization
* Robust and extensible systems

Modern software development—both business and academic—relies heavily on these principles, not just in GUI programming, but in every domain where structure and scale matter.

For additional study, see:

* **Using Classes and Objects**
* **Introduction to Inheritance**

---

## Two Truths & A Lie: Features of Object-Oriented Programming

Here is a correctly built version for your notes:

1. **Inheritance allows a new class to reuse and extend the attributes and behaviors of an existing class.**
2. **Encapsulation hides internal implementation details and exposes only a controlled interface.**
3. **Polymorphism requires each method name in a program to be unique.** *(Lie — polymorphism allows the **same** name to appear in multiple contexts.)*

---

[Back to Table of Contents](#chapter-1--a-first-program-using-c)

---




<br>
<br>
<br>
<br>
<br>



# The C# Programming Language

[Previous: Features of Object-Oriented Programming Languages](#features-of-object-oriented-programming-languages)
[Next: Writing a C# Program That Produces Output](#writing-a-c-program-that-produces-output)



The **C# programming language** was developed by Microsoft as both an object-oriented and component-oriented language. It is included as part of the **Visual Studio** development environment, a toolset created to build applications for Windows and, through .NET, multiple additional platforms.

C# was designed to support:

* A fully **object-oriented** approach
* A **component-oriented** architecture suitable for modern, modular software
* Consistent application of OOP principles across all data types

Because of its design, C# allows developers to build small, reusable components containing **properties**, **methods**, and **events**, which integrate easily into larger systems.

The official Microsoft C# specifications are available here:
[https://learn.microsoft.com/dotnet/csharp/language-reference/language-specification/](https://learn.microsoft.com/dotnet/csharp/language-reference/language-specification/)
(Formerly located at msdn.microsoft.com.)

---

## Design Philosophy and Versioning

C# has evolved over multiple major versions (the text references C# 7.0), each introducing new language features for clarity, safety, and expressiveness. Even early versions already established C# as a modern, structured alternative to older languages.

If you are new to programming, the differences between C# and earlier languages may not yet stand out. Experienced programmers, however, immediately see how deliberately C# was engineered to avoid many of the pitfalls of older languages.

---

## Comparisons With Other Programming Languages

### C# vs. Visual Basic

C# includes strong support for building GUI applications similar to **Visual Basic**, but the syntax of C# is considered more concise and more suitable for large, maintainable systems.

### C# vs. C++

C# was modeled after **C++**, adopting many familiar structures but intentionally removing several complex or error-prone features.

Key differences:

* **Pointers** are not used in C#, except inside a specialized `unsafe` mode.
* **Destructors** and **forward declarations** are not required.
* **#include** directives are replaced by `using` statements and namespaces.
* **Multiple inheritance** is not allowed in C#, eliminating a common source of ambiguity and runtime errors.

By removing these advanced but often hazardous features, C# becomes far easier to learn while still retaining expressive power.

### C# vs. Java

C# and **Java** share a common ancestry in C++, but C# is considered:

* More uniformly object-oriented
* More flexible in how data is passed to and from methods
* More consistent in its treatment of all data as objects

In Java:

* Primitive types (e.g., `int`, `double`) are **not** objects.
* These types do not have built-in methods.
* Data can only be passed by **value**, limiting flexibility.

In C#:

* All data types ultimately derive from `object`.
* Built-in types have associated functionality.
* Methods can accept data by value, by reference, or by output parameters.

Later chapters—**Using Methods** and **Advanced Method Concepts**—expand on these capabilities.

---

## Standardization of the Language

C# was standardized in **2002** by **Ecma International**, establishing a formal grammar and specification for the language. This ensures consistent implementation and cross-platform reliability.

The Ecma-334 standard can be accessed here:
[https://www.ecma-international.org/publications-and-standards/standards/ecma-334/](https://www.ecma-international.org/publications-and-standards/standards/ecma-334/)

---

[Back to Table of Contents](#chapter-1--a-first-program-using-c)

---




<br>
<br>
<br>
<br>
<br>



# Writing a C# Program That Produces Output


[Previous: The C# Programming Language](#the-c-programming-language)
[Next: Selecting Identifiers](#selecting-identifiers)



Even the simplest C# program contains several pieces of required syntax. The program in Figure 1-2 (reproduced below) displays a single line of text but introduces core structural rules of the language.

```csharp
class FirstClass
{
    static void Main()
    {
        System.Console.WriteLine("This is my first C# program");
    }
}
```

This program consists of:

* A **class declaration**
* A required **Main() method**
* A **WriteLine()** call that produces output

To fully understand how C# generates output, we break down each component carefully.

---

## The Core Output Statement

```csharp
System.Console.WriteLine("This is my first C# program");
```

This line performs the only action in the program—displaying a literal string on the screen.

### Key properties of this line:

* It ends with a **semicolon**.

  * All C# statements must end with a semicolon.

* `"This is my first C# program"` is a **literal string**.

  * A literal string appears exactly as typed, enclosed in double quotation marks.

* The literal string is placed inside **parentheses**.

  * Parentheses are required because the string is an **argument** passed to a method.

### What Are Arguments?

Arguments provide the information a method needs to perform its operation.

Example comparison:

```csharp
MakeAppointment("September 10", "2 p.m.");
```

Here, `"September 10"` and `"2 p.m."` are arguments specifying the details the method needs.

Different arguments → different outcomes.
Likewise, passing `"Happy Holidays"` to `WriteLine()` produces different output from `"This is my first C# program"`.

Arguments are not limited to strings—you will supply numbers, variables, objects, and more as you progress in this course.

---

## The WriteLine() Method

The method name appears here:

```csharp
WriteLine()
```

**WriteLine()** is a built-in method that:

* Displays output
* Moves the cursor to the next line

Compare to:

* **Write()** → Outputs text **without** moving to the next line
* **WriteLine()** → Outputs text **and moves** to the next line

Both methods belong to the **Console** class.

---

## The Console Class

```csharp
Console.WriteLine(...)
```

`Console` is a class designed to handle basic terminal I/O (input/output).
Its creators assumed developers would frequently display information while learning C#, so the class includes methods like:

* `Write()`
* `WriteLine()`
* `ReadLine()`

Not all classes contain these methods—only those designed for console operations.

---

## The System Namespace

```csharp
System.Console.WriteLine(...)
```

`System` is a **namespace**, which is a structure used to organize classes into logical groups.

Namespaces:

* Help avoid naming conflicts
* Group related functionality
* Can be created by programmers to organize their own code

Visual Studio languages (C#, Visual C++, Visual Basic) share many namespaces, making knowledge transferable across them.

### Dot Notation

The pattern:

```csharp
namespace.class.method
```

is called **dot notation** and will appear throughout all C# code you write.

---

# Structure of a C# Application

The program in Figure 1-2 is built around the **Main() method**, which serves as the starting point of every executable application.

```csharp
static void Main()
{
    System.Console.WriteLine("This is my first C# program");
}
```

A project may contain many classes, but only the class containing the **Main()** method is considered an *application class*. Classes without Main() cannot run by themselves; they are **supporting classes** used to model objects such as Dog, Automobile, BankAccount, etc.

---

## Method Headers and Method Bodies

Every method consists of two parts:

### 1. The Method Header

Contains:

* The **method name**
* Information about parameters and return type
* Optional modifiers such as `static`

### 2. The Method Body

Enclosed in:

```cs
{
   // statements
}
```

The body contains the statements the method executes.

---

## Curly Braces vs. Parentheses

* **Curly braces `{ }`**

  * Enclose the body of a method or class
  * Must always appear in matching pairs
  * Their exact placement is flexible (whitespace does not affect correctness)

* **Parentheses `( )`**

  * Used for method calls, arguments, and parameter lists

Using one in place of the other results in a **syntax error**.

---

## Indentation and Whitespace

Although C# ignores whitespace, developers use indentation to:

* Make code visually clear
* Show method and class nesting
* Improve maintainability

The example program indents the WriteLine() statement to show it belongs to the Main() method.

---

# Understanding the Main() Method Keywords

The header:

```csharp
static void Main()
```

contains two keywords: **static** and **void**.

| Keyword  | Meaning                                                                                                                                                |
| -------- | ------------------------------------------------------------------------------------------------------------------------------------------------------ |
| `static` | Indicates the method belongs to the class itself, not to individual objects. You do **not** need to create an object of `FirstClass` to call `Main()`. |
| `void`   | Specifies that the method returns **no value**.                                                                                                        |

### The Name: Main()

* Not a reserved keyword
* Required entry point for every C# application
* Executes first when the application starts

---

# C# Reserved Keywords (Table 1-1)

Below is Table 1-1 in Markdown table format. These keywords cannot be used as identifiers.

| Keywords |           |        |          |           |            |
| -------- | --------- | ------ | -------- | --------- | ---------- |
| abstract | float     | return | as       | for       | sbyte      |
| base     | foreach   | sealed | bool     | goto      | short      |
| break    | if        | sizeof | byte     | implicit  | stackalloc |
| case     | in        | static | catch    | int       | string     |
| char     | interface | struct | checked  | internal  | switch     |
| class    | is        | this   | const    | lock      | throw      |
| continue | long      | true   | decimal  | namespace | try        |
| default  | new       | typeof | delegate | null      | uint       |
| do       | object    | ulong  | double   | operator  | unchecked  |
| else     | out       | unsafe | enum     | override  | ushort     |
| event    | params    | using  | explicit | private   | virtual    |
| extern   | protected | void   | false    | public    | volatile   |
| finally  | readonly  | while  | fixed    | ref       |            |

---

[Back to Table of Contents](#chapter-1--a-first-program-using-c)

---




<br>
<br>
<br>
<br>
<br>



# Selecting Identifiers

[Previous: Writing a C# Program That Produces Output](#writing-a-c-program-that-produces-output)
[Next: Improving Programs by Adding Comments and Using the System Namespace](#improving-programs-by-adding-comments-and-using-the-system-namespace)



Every method you write in C# must reside inside a **class**. To define a class, you use a **class header** followed by a pair of curly braces—exactly like defining a method—but at a higher structural level.

Example:

```csharp
class AnyLegalClassName
{
    static void Main()
    {
        /*********/   // Placeholder for your statements
    }
}
```

This structure is a *shell program*, and you can replace:

* `AnyLegalClassName` with any **legal identifier**, and
* `/*********/` with the statements your program will execute.

Understanding what qualifies as a legal identifier is essential.

---

## Rules for Legal Identifiers in C#

C# identifiers include class names, variable names, method names, and more. To be valid, an identifier must follow the language’s rules:

### Identifier Rules

1. **Must begin with**:

   * A letter (`A–Z`, `a–z`)
   * An underscore (`_`)
   * The `@` character
   * A Unicode letter (e.g., `Ω`, `Π`)

2. **Can contain only**:

   * Letters
   * Digits
   * Underscores (`_`)
   * The `@` character
   * (No spaces, no punctuation)

3. **Cannot be a C# reserved keyword**
   Example: `class`, `void`, `while`, etc.

   However, a keyword can be used if it is prefixed with `@`:

   ```csharp
   int @class = 10;
   ```

   This is called a **verbatim identifier**, but you should avoid this practice in your own programs for clarity.

4. **Avoid using contextual keywords**
   These are not reserved words, but C# uses them in special contexts:

* `add`, `alias`, `get`, `global`, `partial`,
* `remove`, `set`, `value`, `where`, `yield`

Using them as identifiers can cause confusion.

---

## Naming Conventions

C# uses conventions to make code more readable and predictable:

* Class names use **Pascal casing**:
  `Employee`, `BankAccount`, `PushButtonControl`
* Variable and method parameter names use **camel casing**:
  `hoursWorked`, `monthlyBudget`

Following conventions makes your code easier for others to understand.

---

# Table 1-2 — Valid and Conventional Class Names

| Class Name        | Description                                                |
| ----------------- | ---------------------------------------------------------- |
| Employee          | Begins with uppercase letter                               |
| FirstClass        | Uppercase start; second word indicated with capital letter |
| PushButtonControl | Each word starts with uppercase letter; no spaces          |
| Budget2016        | Uppercase start; digits allowed; no spaces                 |

---

### Table 1-3 — Unconventional but Legal Class Names

| Class Name        | Description                                                |
| ----------------- | ---------------------------------------------------------- |
| employee          | Begins with lowercase (unconventional for classes)         |
| First_Class       | Legal, but underscores are not commonly used for new words |
| Pushbuttoncontrol | No uppercase letters to mark new words; hard to read       |
| BUDGET2016        | All-uppercase; unconventional for classes                  |
| Void              | Legal (capital V), but confusingly close to keyword `void` |

---

### Table 1-4 — Illegal Class Names

| Class Name          | Reason                                                |
| ------------------- | ----------------------------------------------------- |
| an employee         | Contains a space                                      |
| Push Button Control | Contains spaces                                       |
| class               | Reserved keyword                                      |
| 2016Budget          | Cannot begin with a digit                             |
| phone#              | `#` is not allowed—only letters, digits, `_`, and `@` |

---

### Understanding the Class Header

When you write:

```csharp
class FirstClass
```

* `class` → a reserved keyword that introduces a class definition
* `FirstClass` → the identifier you supply that names the class

The remainder of the class appears between a matching pair of curly braces.

---

### The Shell Program (Reusable Template)

The following reusable template is provided in Figure 1-3. You can copy this structure and replace the class name and method contents as needed:

```csharp
class AnyLegalClassName
{
    static void Main()
    {
        /*********/   // Replace with your statements
    }
}
```

This shell is especially useful when practicing:

* Writing new programs
* Testing syntax
* Learning method calls
* Verifying identifier rules

---

[Back to Table of Contents](#chapter-1--a-first-program-using-c)

---




<br>
<br>
<br>
<br>
<br>



---

# Improving Programs by Adding Comments and Using the System Namespace


[Previous: Selecting Identifiers](#selecting-identifiers)
[Next: Adding Program Comments](#adding-program-comments)


As programs grow larger, readability and organization become essential. Even small C# applications require multiple lines of syntax, and as your programs become more sophisticated, clarity becomes even more crucial.

Two immediate tools that improve the structure and maintainability of your programs are:

* **Adding comments**
* **Using the System namespace**

These techniques help you manage complexity, communicate intent, and leverage built-in C# functionality effectively.

Further subsections will break down:

* How comments work
* Why comments improve maintainability
* How to call classes and methods from the System namespace
* Why namespaces prevent naming conflicts and improve organization

You will use both of these concepts continuously throughout this course and in every professional C# program you ever write.

---

[Back to Table of Contents](#chapter-1--a-first-program-using-c)


---





<br>
<br>
<br>
<br>
<br>




# Using the System Namespace

[Previous](#selecting-identifiers)
[Next: Compiling and Executing a C# Program](#compiling-and-executing-a-c-program)



A C# program can contain as many statements as needed. Each statement ends with a semicolon, and each statement performs one action. The example below displays three lines of output using three separate statements.

```csharp
class ThreeLinesOutput
{
    static void Main()
    {
        System.Console.WriteLine("Line one");
        System.Console.WriteLine("Line two");
        System.Console.WriteLine("Line three");
    }
}
```

The output (when run in Visual Studio) appears as:

```cs
Line one
Line two
Line three
Press any key to continue . . .
```

The final line is not generated by your program—it is added automatically by Visual Studio. When executed from the command prompt, this prompt does *not* appear.

---

## Reducing Repetition with the `using` Directive

The program above repeats the full expression:

```cs
System.Console.WriteLine
```

This repetition occurs because the `Console` class belongs to the **System namespace**, and the program has not yet been told that it may reference this namespace implicitly.

To simplify your statements, you can instruct the compiler to use the **System** namespace by adding a `using` directive before your class definition:

```csharp
using System;

class ThreeLinesOutput
{
    static void Main()
    {
        Console.WriteLine("Line one");
        Console.WriteLine("Line two");
        Console.WriteLine("Line three");
    }
}
```

### What the `using System;` directive does

* Tells the compiler that when it encounters `Console`, it should look inside the **System namespace**.
* Eliminates the need to repeatedly type `System.`
* Improves readability
* Reduces boilerplate code

The output remains identical.

---

## Further Simplifying with `using static`

Modern versions of C# allow an additional refinement.

You may add:

```csharp
using static System.Console;
```

This directive imports the **static members** of the `Console` class directly into your program’s scope. When using this version, the program becomes:

```csharp
using static System.Console;

class ThreeLinesOutput
{
    static void Main()
    {
        WriteLine("Line one");
        WriteLine("Line two");
        WriteLine("Line three");
    }
}
```

This is the shortest syntax, and it is the style used throughout the remainder of the textbook.

### Why this works

* `WriteLine` and `Write` are static members of the `Console` class.
* The `static` modifier means they are accessed through the class itself rather than through an object.
* By importing them with `using static`, no class name is required.

You encountered `static` earlier in the context of the `Main()` method; later chapters further expand your understanding of static methods and fields.

---

## Key Concepts Summary

* A `namespace` is a container that groups related classes.
* The **System** namespace contains many commonly used classes, including `Console`.
* Using a `using` directive allows shorthand access to a namespace.
* Using `using static` allows even shorter access to a specific class's static members.

These tools improve readability, reduce typing, and help organize your codebase effectively.

---

## Two Truths & A Lie — Solutions

1. **Line comments start with two forward slashes ( // ) and end with two backslashes ( \ ).**
   **False** — They end at the end of the line, not with backslashes.

2. **Block comments can extend across as many lines as needed.**
   **True**

3. **You use a namespace with a using clause, or using directive, to shorten statements when you need to repeatedly use a class from the same namespace.**
   **True**

---

# You Do It — Entering a Program into an Editor

This exercise guides you through creating your first C# program manually.

### 1. Open a text editor

Use Notepad or Visual Studio’s built-in editor.

### 2. Type your `using` directive and class header

```csharp
using System;

class Hello
```

### 3. Type the opening and closing curly braces for the class

```csharp
{
}
```

(An optional good habit is to type both braces immediately to avoid missing one.)

### 4. Insert the `Main()` method header inside the class braces

```csharp
   static void Main()
```

### 5. Add the opening and closing braces for the `Main()` method

```csharp
   {
   }
```

### 6. Type your single executable statement inside `Main()`, properly indented

```csharp
      Console.WriteLine("Hello, world!");
```

Your complete file should look like this (Figure 1-9 equivalent):

```csharp
using System;

class Hello
{
   static void Main()
   {
      Console.WriteLine("Hello, world!");
   }
}
```

### 7. Save your program

* Choose a meaningful directory, such as:
  `CSharp/Chapter01/Hello.cs`

**Important:**

* The extension **must be `.cs`**.
* Avoid double extensions like `.cs.txt`.
* If using a word processor, save as *plain text*.

This prepares the file to be compiled in the next section.

---

[Back to Table of Contents](#chapter-1--a-first-program-using-c)

---







<br>
<br>
<br>
<br>
<br>




# Compiling and Executing a C# Program


[Previous: Using the System Namespace](#using-the-system-namespace)
[Next: Compiling Code from the Command Prompt](#compiling-code-from-the-command-prompt)



Writing a C# program is only the first step. Before you can see the program’s output, two additional processes must occur:

1. Your **source code** must be compiled into **Intermediate Language (IL)**.
2. The **Just-In-Time (JIT) compiler** must translate IL into **native executable code** at runtime.

Understanding this pipeline clarifies how C# programs execute and why they can run across different system architectures.

---

## Compilation to Intermediate Language (IL)

When you compile a C# program, the compiler:

* Validates syntax
* Translates your `.cs` source code into **Intermediate Language (IL)**
* Packages IL into an assembly (such as a `.exe` or `.dll`)

IL is a CPU-independent instruction set designed for the **.NET runtime**.

This architecture makes it possible for the same compiled program to run on different hardware—IL is portable until it is finally executed.

---

## Just-In-Time (JIT) Compilation

The **JIT compiler** converts IL into native machine code **at runtime**—at the exact moment it is needed.

Advantages:

* C# applications can run on any system that supports the .NET runtime.
* Only the portions of code that execute are compiled, potentially improving efficiency.
* The runtime can optimize execution dynamically based on the system architecture.

Because of this two-step process, developers often refer to C# as **“semi-compiled.”**

---

## Writing and Running Programs: Two Approaches

You can build and run C# applications in two primary ways:

### 1. Using the Command Prompt

You can write programs in any text editor (such as Notepad) and then compile and execute them using the **Developer Command Prompt for Visual Studio**.

Key terms:

* **Command line** — The line where commands are typed.
* **Command prompt** — The symbol (such as `C:\>`) that indicates the system is waiting for input.

The **Developer Command Prompt** is a specialized command prompt automatically configured with:

* Compiler paths
* Environment variables
* Tools for .NET development

Although you *can* configure a standard command prompt manually, using the developer prompt is easier and eliminates setup steps.

This method is required when you need to:

* Pass **command-line arguments**
* Use advanced build features
* Work without the IDE

### 2. Using the Integrated Development Environment (IDE)

The **Visual Studio IDE** provides a graphical environment where you can:

* Write code
* Compile with a single click
* Run programs
* View errors
* Enjoy editor tools such as:

  * Color-coded syntax
  * IntelliSense (automatic suggestions)
  * Automatic formatting
  * Project management features

Many developers prefer the IDE because:

* It behaves like typical productivity software
* It simplifies building and debugging applications
* It reduces the overhead of managing files and paths manually

Both the command line and Visual Studio produce identical compiled code—the choice depends on personal workflow and task requirements.

---

## Summary

When you run a C# program, the following occurs:

1. **C# Compiler** translates `.cs` → **IL**
2. **JIT Compiler** translates **IL** → **native executable code**
3. Your output appears based on your program’s logic

This two-stage process allows C# to deliver portability, performance, and flexibility across different systems.

---

[Back to Table of Contents](#chapter-1--a-first-program-using-c)

---




<br>
<br>
<br>
<br>
<br>



# Compiling Code from the Command Prompt

[Previous: Using the System Namespace](#using-the-system-namespace)
[Next: Compiling Code Using the Visual Studio IDE](#compiling-code-using-the-visual-studio-ide)


If you plan to write your programs entirely within the Visual Studio IDE, you may skim this section. However, knowing how to compile from the **developer command prompt** is valuable, especially when you need to test programs, pass command-line arguments, or work without Visual Studio.

Compilation from the command line involves:

1. Locating and opening the **Developer Command Prompt for Visual Studio**
2. Navigating to the folder where your `.cs` file is saved
3. Running the **C# compiler** (`csc`) with the filename

---

## Using the Developer Command Prompt

On Windows, you can search for *Developer Command Prompt* in the Start menu. If it does not appear, Visual Studio may not be installed or properly configured.

Once opened, this specialized command prompt includes environment settings that allow you to:

* Compile C# programs easily
* Access the `csc` compiler without manually setting paths

---

## Compiling a Program (Basic Command)

To compile a file named `ThreeLinesOutput.cs`, you type:

```cs
csc ThreeLinesOutput.cs
```

(Shown in your first screenshot.)

If the file is located in the current directory, the compiler runs and attempts to build an `.exe` file with the same base filename.

---

# Possible Compiler Outcomes

When you run the `csc` command, one of three things happens:

---

## 1. **Operating System Error Message**

Example (from your screenshot):

```cs
C:\>csc ThreeLinesOutput.cs
error CS2001: Source file 'C:\ThreeLinesOutput.cs' could not be found.
```

This message indicates the compiler *ran*, but the file could not be located.

### Common causes:

* Misspelled filename
* Missing `.cs` extension
* Wrong folder or path in the command prompt
* File not saved where you think it is
* Compiler not installed or not configured

In the screenshot, the user attempted to compile from the root directory `C:\`, but the file was stored elsewhere.

Solution: Use `cd` to navigate to the correct folder.

---

## 2. **Programming Language Error Message**

Example (your second screenshot):

```cs
ThreeLInesOutput.cs(8,7): error CS0103: The name 'writeLine' does not exist in the current context
```

### What this means:

* The compiler found your file
* But your code contains a **C# syntax error**
* In this case, `writeLine` was typed with a lowercase “w”
* C# is case-sensitive → correct version: `WriteLine`

You must correct the source code, save the file, and compile again.

The format of a typical compiler error:

```cs
filename.cs(lineNumber, position): error code : description
```

---

## 3. **Successful Compilation (No Errors)**

If no errors occur:

* The compiler outputs a copyright message
* No error text appears
* A new `.exe` file is created in the same folder as your `.cs` file

For example:

`ThreeLinesOutput.exe`

You can now run the program by typing:

```cs
ThreeLinesOutput
```

or

```cs
ThreeLinesOutput.exe
```

Both work; the extension is optional.

---

# Diagnosing OS Errors vs. Language Errors

| Error Type         | Starts With                    | Meaning                                               |
| ------------------ | ------------------------------ | ----------------------------------------------------- |
| **OS error**       | Does *not* start with filename | The compiler could not run or could not find the file |
| **Language error** | Begins with your filename      | Code contains syntax issues                           |
| **Success**        | No errors                      | `.exe` file created                                   |

The screenshots you provided illustrate both OS and syntax error scenarios.

---

# When the C# Compiler Is Not Recognized

If you see:

```
csc is not recognized as an internal or external command
```

This means:

* The compiler is not installed
* Or the path is not set
* Or you are not using the Developer Command Prompt

Installing Visual Studio or repairing the installation usually resolves this.

---

# Summary

To compile from the command line:

1. Open the **Developer Command Prompt**
2. Navigate to the directory containing your `.cs` file
3. Run:

```cs
csc filename.cs
```

4. Fix errors if necessary
5. Run your `.exe` file directly from the command line

This workflow gives you precise control over compilation and is essential for advanced C# topics such as:

* Command-line arguments
* Batch scripting
* Build automation
* Lightweight testing without the IDE

---


[Back to Table of Contents](#chapter-1--a-first-program-using-c)

---




<br>
<br>
<br>
<br>
<br>



# Compiling Code Using the Visual Studio IDE

[Previous: Compiling Code from the Command Prompt](#compiling-code-from-the-command-prompt)
[Next: Noticing the Differences Between the Programs in the Text Editor and the IDE](#noticing-the-differences-between-the-programs-in-the-text-editor-and-the-ide)


Instead of compiling from the command line, you can write, compile, and execute your C# program directly inside the **Visual Studio Integrated Development Environment (IDE)**. This approach is often preferred because the IDE provides:

* Automatic code generation
* Syntax coloring for readability
* Debugging assistance
* Error navigation tools
* Visual indicators of changes
* Menu-driven and shortcut-driven commands

These features help streamline the development process, especially when working on larger or more complex applications.

---

## Creating a New Project in Visual Studio

If Visual Studio is installed:

1. Open it from the Windows Start menu.
2. Select **File → New → Project**.
3. Choose **Console App** as the project type.
4. Name your project.
5. Click **OK** to create it.

Visual Studio automatically generates the necessary project structure, including:

* A namespace
* A Program class
* A Main() method
* Default using statements

Your role is to add or modify the code within this framework.

---

## Understanding Figure 1-12 (IDE Overview)

Figure 1-12 shows the `ThreeLinesOutput` program inside Visual Studio.

Here’s what the annotations indicate:

* **Project name** — Shown in the Solution Explorer as *ThreeLinesOutput*.
* **Programmer-added using statement** — The developer added `using static System.Console;` to simplify method calls.
* **Three WriteLine() statements** — Added manually to produce three lines of output.
* **Lightbulb icon** — Suggests improvements; here it indicates that unused `using` statements can be removed.
* **Vertical change bars** —

  * Green = saved changes
  * Yellow = unsaved changes

Visual Studio automatically highlights code structure and changes, making navigation and maintenance easier.

---

## Compiling the Program in Visual Studio

You can compile the program in several ways:

### Option 1 — Build Menu

Select **Build → Build Solution**.

### Option 2 — Keyboard Shortcut

Press **Ctrl + Shift + B**.

### Option 3 — Start Without Debugging

Select **Debug → Start Without Debugging**.

This option compiles the program *and then immediately executes it* if no errors are present.

---

# Handling Errors in the IDE

If your program contains a syntax mistake, Visual Studio highlights the issue and provides detailed feedback.

Figure 1-13 illustrates a misspelling error where `WriteLine` has been typed as `writeLine`:

Signs of an error include:

* **Wavy underline** beneath the incorrect code
* **Error message** in the Error List window
* **Lightbulb icon** suggesting corrections
* **File, line number, and column number** showing error location

Example message (as in your screenshot):

```cs
CS0103: The name 'writeLine' does not exist in the current context.
```

### How to fix it:

1. Correct the spelling to `WriteLine`.
2. Save the file.
3. Rebuild or run the program again.

Once fixed, the underline, lightbulb, and error message disappear.

---

## When the Program Compiles Successfully

If there are no errors:

* Visual Studio produces a compiled executable in the project’s `bin` directory.
* Running **Start Without Debugging** displays your program output in a console window.

This output is identical to the command line output shown earlier in Figure 1-6.

---

[Back to Table of Contents](#chapter-1--a-first-program-using-c)


---




<br>
<br>
<br>
<br>
<br>



# Noticing the Differences Between the Programs in the Text Editor and the IDE

[Previous: Compiling Code Using the Visual Studio IDE](#compiling-code-using-the-visual-studio-ide)
[Deciding Which Environment to Use](#deciding-which-environment-to-use)


When you compare a program typed manually in a plain text editor (for example, Notepad) to the version that Visual Studio generates automatically, you will notice several structural differences. These differences can be seen side-by-side in Figure 1-14, where the **Notepad version** on the left contains only what the programmer typed, while the **Visual Studio version** on the right includes additional elements inserted by the IDE.

These extra components do **not** change how the program behaves. They exist to support larger applications and to streamline development.

---

## Additional Using Statements (Automatically Added in IDE)

In the Visual Studio version, several `using` statements appear at the top:

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
```

Visual Studio inserts commonly used namespaces by default. For a small program like `ThreeLinesOutput`, only this one is *actually needed*:

```csharp
using static System.Console;
```

Everything else can be safely removed without affecting the program. Likewise, you can add those extra namespaces to the Notepad version and the behavior would remain identical.

---

## The Namespace Declaration

In the IDE version, Visual Studio creates a namespace that matches the project name:

```csharp
namespace ThreeLinesOutput
{
    // class goes here
}
```

Namespaces help organize related classes and prevent naming conflicts in larger systems. In small beginner examples, namespaces are optional.

You can:

* **Remove** the namespace wrapper in the IDE version
* **Add** it to the Notepad version

Either way, the program will still run.

---

## The Auto-Generated Class Name: Program

Visual Studio creates a class named `Program` by default:

```csharp
class Program
{
}
```

This is only a placeholder name. You may rename it to:

```csharp
class ThreeLinesOutput
```

or any other legal identifier, and the compiled result will be identical.

Similarly, the Notepad version can be changed to use `Program` or any other class name you prefer.

---

## The Main Method Header (With or Without Arguments)

Visual Studio inserts the following version of `Main`:

```csharp
static void Main(string[] args)
```

This form allows the program to accept command-line arguments.

However, C# permits multiple valid signatures for `Main`. Both of the following are acceptable:

```csharp
static void Main()
static void Main(string[] args)
```

The `string[] args` portion is optional and refers to an **array** of incoming arguments—something you’ll learn about later in your study of arrays.

Both versions compile and run exactly the same for this program.

---

## Summary of Differences

The two versions—Notepad and Visual Studio—produce identical results. The IDE simply provides:

* Extra namespaces in case you need them
* A namespace wrapper matching the project name
* A standard class name (`Program`)
* A version of `Main` that supports optional command-line arguments

None of these additions change program behavior. Instead, they offer structure and flexibility for building larger C# applications.

Visual Studio is essentially giving you a **head start template**, while the text editor version represents the **bare-bones minimal structure**.

---

[Back to Table of Contents](#chapter-1--a-first-program-using-c)

---




<br>
<br>
<br>
<br>
<br>




# Deciding Which Environment to Use

[Previous: Noticing the Differences Between Programs in Text Editor and IDE](#noticing-the-differences-between-the-programs-in-the-text-editor-and-the-ide)
[Next](#summary)


When working with C# programs, you have two fully valid and interchangeable development environments:

1. **A text editor + the command line (Developer Command Prompt)**
2. **The Visual Studio Integrated Development Environment (IDE)**

You will never need to use *both* for the same program. Each approach leads to the same compiled intermediate language (IL) and the same executable output. The decision comes down to workflow, convenience, and the nature of the program you’re building.

---

## When a Text Editor + Command Line Is the Better Fit

Working in a simple editor such as Notepad (or VS Code without extensions) keeps things light and minimal. Only two files are produced:

* Your **source file** (`.cs`)
* The compiled **executable** (`.exe`)

This approach is useful when:

* You want absolute simplicity
* Disk space is limited
* You prefer working with very small or quick demonstration programs
* You want full visibility into what you're typing without any auto-generation

The key characteristic of this environment is its transparency: nothing happens automatically. Every character you type is part of the program.

---

## When the Visual Studio IDE Is the Better Fit

The IDE provides a powerful set of tools that make development smoother, faster, and less error-prone:

* **IntelliSense**: Automatic statement completion

  * Type `u` → Suggestions appear, including `using`
  * Type `using s` → Suggestions include `static`

* **Color coding** for different language elements

  * Keywords (blue)
  * Strings (red)
  * Comments (green)

* **Clickable error messages**

  * Double-clicking an error moves the cursor directly to the problematic line

* **Immediate visual debugging cues**

  * Lightbulbs for suggested fixes
  * Wavy underlines for syntax errors
  * Vertical sidebars showing unsaved vs. saved edits

* **Consistency across languages**

  * The same environment supports C#, Visual Basic, and C++
  * Once you learn one, you’re comfortable in all

For GUI programming, the IDE becomes especially valuable. Windows Forms and WPF applications automatically generate large sections of required code—something nearly impossible to manage comfortably in a plain text editor.

---

## Ultimately: Both Environments Teach You the Same C# Language

Whether you choose:

* Command line
* IDE
* Or a hybrid approach (write in one, run in the other)

…every concept you learn in the upcoming chapters—**variables, input/output, decisions, loops, and arrays**—works exactly the same.

You can compile the same program using either method without changing the code.

---

## Mixing Techniques Is Also Perfectly Acceptable

C# places no restrictions on your workflow. Many developers:

* Write programs in a text editor
* Paste them into Visual Studio for execution
* Or write programs in the IDE
* Later copy them into a text environment for portability

As long as the file maintains proper `.cs` structure, both environments function identically.

---

## Learning Tip

While the command line builds foundational skills and teaches you how the compiler behaves, the IDE prepares you for professional development environments—where speed and debugging convenience matter.

Most students eventually prefer the IDE once the programs become larger and more complex.

---


[Back to Table of Contents](#chapter-1--a-first-program-using-c)

---




<br>
<br>
<br>
<br>
<br>




# Chapter Summary

[Previous: Deciding Which Environment to Use](#deciding-which-environment-to-use)

A C# program is ultimately a **set of instructions** that directs the computer to perform meaningful work. These instructions begin as **high-level source code** written by the programmer and are translated by the **C# compiler** into *intermediate language (IL)* before being executed by the **Just-In-Time (JIT) compiler** as machine code. A program behaves correctly only when both its **syntax** (grammar of the language) and **logic** (correct sequencing of operations) are sound.

Programming can be approached in two major styles:

* **Procedural programming**, which emphasizes variables and methods that act on those variables in a sequence of steps.
* **Object-oriented programming (OOP)**, which models real-world entities as **objects** that encapsulate attributes (data) and behaviors (methods).

Object-oriented languages—including C#—support three defining principles:

* **Encapsulation**, which packages data and behaviors together.
* **Inheritance**, which allows creation of specialized classes from existing ones.
* **Polymorphism**, which enables methods to behave differently based on the object using them.

C# was developed as both an **object-oriented** and **component-oriented** language, borrowing strengths from languages such as Visual Basic, C++, and Java. Its syntax is concise, and all data types are treated as objects, providing consistency throughout the language.

Producing console output in C# requires calling the `WriteLine()` method. This method belongs to the `Console` class inside the `System` namespace, and it accepts **arguments**, such as literal strings. These method calls are typically placed inside the **Main()** method, which serves as the entry point for every executable C# program.

Naming in C# follows strict rules. A valid identifier:

* Begins with a letter, underscore, or `@`
* Can contain only letters, digits, underscores, or `@`
* Cannot be a reserved C# keyword

Identifiers should also follow established naming conventions to improve readability and maintainability.

Programs become easier to understand when **comments** are added. Comments do not execute but serve to document the code or temporarily disable statements during testing. C# supports:

* **Line comments** (`//`)
* **Block comments** (`/* ... */`)
* **XML-documentation comments** (`///`)

Typing can also be reduced using **using directives**, which allow programmers to reference namespaces without repeatedly specifying their fully-qualified names.

C# programs may be created in either:

* A **simple text editor** (such as Notepad) and compiled from the **Developer Command Prompt**, or
* The **Visual Studio Integrated Development Environment (IDE)**, which provides conveniences such as color coding, IntelliSense, debugging tools, and automatic file management.

Regardless of the environment used, the process always includes:

1. Writing and saving the source file (`.cs`)
2. Compiling it into intermediate language
3. Executing the resulting program

These foundational concepts form the basis for all future C# programming tasks.

---

[Back to Table of Contents](#chapter-1--a-first-program-using-c)



---


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
