
# Chapter 11 – Exception Handling

## Table of Contents

* [Understanding Exceptions](#understanding-exceptions)

  * [Purposely Generating a SystemException](#purposely-generating-a-systemexception)

* [Comparing Traditional and Object-Oriented Error-Handling Methods](#comparing-traditional-and-object-oriented-error-handling-methods)

  * [Understanding Object-Oriented Exception-Handling Methods](#understanding-object-oriented-exception-handling-methods)
  * [Using the Exception Classs ToString() Method and Message Property](#using-the-exception-classs-tostring-method-and-message-property)
  * [Catching Multiple Exceptions](#catching-multiple-exceptions)
  * [Examining the Structure of the tryparse-methods](#examining-the-structure-of-the-tryparse-methods)
  * [Using the finally Block](#using-the-finally-block)
  * [Handling Exceptions Thrown from Outside Methods](#handling-exceptions-thrown-from-outside-methods)

* [Tracing Exception Objects Through the Call Stack](#tracing-exception-objects-through-the-call-stack)

  * [A Case Study: Using StackTrace](#a-case-study-using-stacktrace)

* [Creating Your Own Exception Classes](#creating-your-own-exception-classes)

* [Rethrowing an Exception](#rethrowing-an-exception)

* [Chapter Summary](#chapter-summary)

* [Key Terms](#key-terms)

* [Review Questions](#review-questions)

* [Exercises](#exercises)







# **Understanding Exceptions**

An exception is any unexpected condition that occurs while a program is running. It is not a syntax or compiler error. It appears only **at runtime** when something prevents the program from continuing normally.

Exceptions happen when users enter invalid input, operations are illegal, data is incorrect, or system resources are insufficient. These events break the normal flow of execution.

### What Causes Exceptions

Exceptions occur due to conditions like:

* Converting text to numbers when the text is not numeric
* Dividing by zero
* Using an invalid array index
* Attempting an illegal type conversion
* Incorrectly formatted data
* Failing input/output operations
* Insufficient memory

These are not “normal” conditions—they’re exceptional.

### Compiler Errors vs Runtime Exceptions

Compiler errors appear before execution.
The program cannot start until they are fixed.

Runtime exceptions appear after the program begins executing.
The program runs, but something breaks mid-execution.

Exceptions are **only** runtime events.

### Exceptions Are Objects

All exceptions in C# derive from the base class:

```
System.Exception
```

Exception objects include:

* A message
* A type
* A stack trace
* Properties and methods

They exist in a well-defined inheritance hierarchy.

### Exception Family Tree (Short Version)

The root of all exception types:

```
Exception
```

Important branches:

* **SystemException** — built-in runtime errors
* **ApplicationException** — no longer recommended
* **Custom exceptions** — classes you create that derive from `Exception`

### Table 11-1 — Selected C# Exception Subclasses

| Class                                           | Description                                |
| ----------------------------------------------- | ------------------------------------------ |
| System.ArgumentException                        | Invalid argument passed to a method        |
| System.ArithmeticException                      | Arithmetic, casting, or conversion error   |
| System.ArrayTypeMismatchException               | Wrong data type stored in an array         |
| System.Data.OperationAbortedException           | Operation stopped by the user              |
| System.Drawing.Printing.InvalidPrinterException | Invalid printer settings                   |
| System.FormatException                          | Bad input format (ex: "abc" → int)         |
| System.IndexOutOfRangeException                 | Array index outside valid range            |
| System.InvalidCastException                     | Illegal type conversion                    |
| System.InvalidOperationException                | Operation invalid for current object state |
| System.IO.InvalidDataException                  | Invalid data in a stream                   |
| System.IO.IOException                           | General I/O error                          |
| System.MemberAccessException                    | Invalid access to a class member           |
| System.NotImplementedException                  | Requested feature not implemented          |
| System.NullReferenceException                   | Attempting to use a null object reference  |
| System.OperationCanceledException               | Operation canceled by another component    |
| System.OutOfMemoryException                     | Program cannot allocate needed memory      |
| System.RankException                            | Wrong array dimension count                |
| System.StackOverflowException                   | Excessive recursion exhausting the stack   |

Common beginner exceptions include:

* `NullReferenceException`
* `FormatException`
* `IndexOutOfRangeException`

### What “Thrown” Means

When an error occurs, C# **throws** an exception.
This means C# creates the exception object and sends it **up the call stack** until a matching `catch` handles it.

If nothing catches it, the program stops.

### Why This Section Matters

Understanding exceptions builds the mindset of writing defensive, robust code.
Good developers expect errors and design their programs to handle them safely.

---

### Navigation

[← Back to TOC](#table-of-contents)
[↑ Back to TOC](#table-of-contents)
[→ Next: Purposely Generating a SystemException](#purposely-generating-a-systemexception)

<br>
<br>
<br>
<br>

---

# **Purposely Generating a SystemException**

This section demonstrates deliberate runtime failure to illustrate how exceptions behave. The MilesPerGallon program is intentionally unsafe so students can observe real exceptions.

The program uses `Convert.ToInt32()`, which throws a `FormatException` when the input is not numeric. It also performs integer division, which throws a `DivideByZeroException` when dividing by zero.

### MilesPerGallon Program

```csharp
using System;
using static System.Console;

class MilesPerGallon
{
    static void Main()
    {
        int milesDriven;
        int gallonsOfGas;
        int mpg;

        Write("Enter miles driven ");
        milesDriven = Convert.ToInt32(ReadLine());

        Write("Enter gallons of gas purchased ");
        gallonsOfGas = Convert.ToInt32(ReadLine());

        mpg = milesDriven / gallonsOfGas;

        WriteLine("You got {0} miles per gallon", mpg);
    }
}
```

### Normal Execution

Example input:

```
300
12
```

Calculation:

```
300 / 12 = 25
```

The program displays:

```
You got 25 miles per gallon
```

### Dividing by Zero

If the user enters **0** for gallons:

```
Unhandled Exception: System.DivideByZeroException: Attempted to divide by zero.
    at MilesPerGallon.Main()
```

C# constructs the exception object and stops execution.

### Why Floating-Point Division Doesn’t Throw

Integers throw `DivideByZeroException`.
Floating-point numbers (`float`, `double`) follow IEEE rules:

* `1.0 / 0.0` → `Infinity`
* `-1.0 / 0.0` → `-Infinity`
* `0.0 / 0.0` → `NaN`

So float division does **not** throw an exception; int division does.

---

### Navigation

[← Back: Understanding Exceptions](#understanding-exceptions)
[↑ Back to TOC](#table-of-contents)
[→ Next: Comparing Traditional and Object-Oriented Error-Handling Methods](#comparing-traditional-and-object-oriented-error-handling-methods)

---

<br>
<br>
<br>
<br>



# **Comparing Traditional and Object-Oriented Error-Handling Methods**

Before modern object-oriented programming, error handling relied on manual checks scattered throughout the code. Every statement that could fail had to be tested immediately before or after execution. This was the **traditional** method.

Object-oriented languages like C# introduced **exception handling**, which moves error-handling responsibility into a structured mechanism using `try`, `catch`, and `finally`.

This section compares both approaches and demonstrates why exception handling is more powerful, more flexible, and more maintainable for modern programs.

---

### Traditional Error-Checking

The traditional approach relies on explicit tests around every operation that *might* fail. Before calling a method, performing a conversion, or using a resource, the programmer must include conditions to validate the operation.

For example:

```csharp
if(gallonsOfGas != 0)
    mpg = milesDriven / gallonsOfGas;
else
    WriteLine("Error: Cannot divide by zero");
```

Or when validating user input:

```csharp
if(IsNumeric(userInput))
    milesDriven = Convert.ToInt32(userInput);
else
    WriteLine("Invalid number entered");
```

This method has clear advantages:

* Errors are handled close to where they happen
* The program can remain simple in structure

But it has major downsides:

* Repeated code scattered everywhere
* Easy to miss edge cases
* Hard to maintain
* Harder to scale when programs grow large
* Every operation must be guarded manually

As the complexity of software increases, this approach becomes fragile and difficult to manage.

---

### Object-Oriented Exception Handling

Object-oriented languages centralize error-handling logic using exceptions.

C# provides the `try` and `catch` keywords to wrap code that might fail. Instead of manually checking operations one by one, you group riskier operations inside a single protected block. If any statement inside throws an exception, control immediately jumps to the appropriate `catch`.

Example:

```csharp
try
{
    milesDriven = Convert.ToInt32(ReadLine());
    gallonsOfGas = Convert.ToInt32(ReadLine());
    mpg = milesDriven / gallonsOfGas;
}
catch(DivideByZeroException)
{
    WriteLine("Error: Cannot divide by zero.");
}
catch(FormatException)
{
    WriteLine("Error: Input was not a valid number.");
}
```

C# also allows:

* Multiple `catch` blocks (specific handling for different exception types)
* A catch-all `catch (Exception e)` as a last resort
* Finally blocks that run whether or not an exception occurs
* Exceptions to be thrown manually using `throw`

This approach provides several benefits:

* Error handling is cleaner and centralized
* Code remains readable and uncluttered
* Exception objects carry detailed information (Message, StackTrace, etc.)
* The call stack can be traced to find where the error started
* Errors can be handled in higher-level methods, not just locally

Object-oriented exception handling is designed to keep the business logic clear while still giving powerful tools to deal with unexpected circumstances.

---

### Summary of the Comparison

| Traditional Method                                  | OOP Exception Handling                                    |
| --------------------------------------------------- | --------------------------------------------------------- |
| Scattered error checks everywhere                   | Centralized handling                                      |
| Manual validation required for each risky operation | Runtime automatically detects and throws exceptions       |
| Higher chance of missing an edge case               | Strong type-specific handling via catch blocks            |
| Hard to maintain in large projects                  | Clean, structured, scalable                               |
| No stack trace or detailed error object             | Full exception object with type, message, and stack trace |

The modern approach is more robust and significantly reduces the chance of unhandled errors.

---

### Navigation

[← Back: Purposely Generating a SystemException](#purposely-generating-a-systemexception)
[↑ Back to TOC](#table-of-contents)
[→ Next: Understanding Object-Oriented Exception-Handling Methods](#understanding-object-oriented-exception-handling-methods)


<br>
<br>
<br>
<br>


## Understanding Object-Oriented Exception-Handling Methods

Object-oriented exception handling allows programs to respond to runtime errors in a structured, centralized way. Instead of scattering manual checks throughout the code, C# uses `try`, `catch`, and `finally` blocks to detect and manage unexpected conditions.

### Using try and catch

A `try` block contains statements that might produce an exception. If any statement inside the block throws an exception, execution immediately moves to the matching `catch`.

```csharp
try
{
    milesDriven = Convert.ToInt32(ReadLine());
    gallonsOfGas = Convert.ToInt32(ReadLine());
    mpg = milesDriven / gallonsOfGas;
}
catch(FormatException)
{
    WriteLine("You must enter a valid number.");
}
catch(DivideByZeroException)
{
    WriteLine("Cannot divide by zero!");
}
```

Each `catch` block handles a specific type of exception. This allows different recovery strategies depending on what went wrong.

### Catching general exceptions

When the specific `type is unknown` or when serving as a `safety net for unexpected errors`, a general exception handler can be used:

```csharp
catch(Exception e)
{
    WriteLine("An error occurred: " + e.Message);
}
```

This should be placed **after** all specific catch blocks to avoid blocking them.

### Why try/catch improves reliability

* You can group risky operations together.
* You can recover gracefully instead of crashing.
* You can separate normal program logic from error-handling logic.
* The exception provides detailed diagnostic information.
* Code readability improves because validation isn’t scattered everywhere.

### Messages and ToString()

All exception objects include:

* `Message` — a human-readable description
* `ToString()` — a full description including type and stack trace

Example:

```csharp
catch(Exception e)
{
    WriteLine(e.ToString());
}
```

This is especially useful for debugging because it reveals the call path that led to the failure.

---

### Navigation

• [⬅️ Previous Section](#comparing-traditional-and-object-oriented-error-handling-methods)
•
[↑ Back to TOC](#table-of-contents)
•
[➡️ Next Section](#using-the-exception-classs-tostring-method-and-message-property)


<br>
<br>
<br>
<br>


Got you, Israel — here's the cleaned, ready-to-drop-into-GitHub section you asked for.

No intros.
No tag clutter.
Correct header level preserved.
Navigation bar included.

---

## Using the Exception Class’s ToString() Method and Message Property

Every exception in C# is an object derived from the `Exception` class. Two of the most useful members of this class are:

* **`ToString()`** — returns a *detailed* description of the exception, including type, message, and stack trace.
* **`Message`** — returns only the human-readable message describing what went wrong.

You typically use `Message` for user-friendly output and `ToString()` when logging, debugging, or recording full error details.

### Example: Using Message and ToString()

```csharp
try
{
    int num1 = 12;
    int num2 = 0;
    WriteLine("The answer is {0}", num1 / num2);
}
catch(Exception e)
{
    WriteLine("Message: " + e.Message);
    WriteLine("ToString(): " + e.ToString());
}
```

### What This Program Shows

* When dividing by zero, the `ArithmeticException` is thrown.
* `Message` returns the short explanation, such as:

  ```
  Attempted to divide by zero.
  ```
* `ToString()` returns something like:

  ```
  System.DivideByZeroException: Attempted to divide by zero.
     at DemoException.Main()
  ```

  This is longer because it includes the exception type and stack trace.

### When to Use Which

* **Message** → Use in user-visible messages, error labels, prompts, or UI.
* **ToString()** → Use in error logs, file logs, debugging consoles, or system reports.

---

[⬅️ Previous Section](#using-the-exception-classs-gettype-method-and-innerexception-property) •
[⬆️ Back to TOC](#table-of-contents) •
[➡️ Next Section](#catching-multiple-exception-types)


<br>
<br>
<br>
<br>


## Catching Multiple Exceptions

When a single `try` block contains operations that can fail in different ways, you can handle each specific failure with its own `catch` block. This gives you control, clarity, and flexibility. Instead of treating all errors the same, you can write one response for formatting issues, a different one for mathematical issues, and yet another for unexpected failures.

C# examines the catch blocks **top to bottom**, and the first matching one is executed.

### Why Use Multiple catch Blocks

Different exceptions represent different types of problems. Handling them separately allows your program to:

* Give clearer feedback to users
* Recover from some errors automatically
* Stop execution on severe errors
* Log important diagnostic information
* Avoid masking specific issues with generic messages

Multiple catch blocks result in cleaner design, better debugging support, and improved usability.

---

### Example: Basic Multiple catch Structure

```csharp
try
{
    Write("Enter first number: ");
    int a = Convert.ToInt32(ReadLine());

    Write("Enter second number: ");
    int b = Convert.ToInt32(ReadLine());

    int result = a / b;
    WriteLine("Result is {0}", result);
}
catch(FormatException)
{
    WriteLine("Input must be numeric.");
}
catch(DivideByZeroException)
{
    WriteLine("Cannot divide by zero.");
}
catch(Exception e)
{
    WriteLine("Unexpected error: " + e.Message);
}
```

---

### Expanded: When to Use Several Exceptions

#### 1. When Different Errors Require Different Recovery Actions

Some problems can be fixed automatically, while others require user input.

```csharp
try
{
    string text = File.ReadAllText("settings.txt");
    int number = Convert.ToInt32(text);
}
catch(FileNotFoundException)
{
    // Auto-recovery
    File.WriteAllText("settings.txt", "0");
    WriteLine("Settings file not found. Created a new one.");
}
catch(FormatException)
{
    WriteLine("Settings file contains invalid data.");
}
```

* Missing file → can be recreated
* Invalid data → cannot be fixed automatically

---

#### 2. When You Want Very Specific User Messages

```csharp
try
{
    int age = Convert.ToInt32(ReadLine());
}
catch(FormatException)
{
    WriteLine("Please enter only numbers.");
}
catch(OverflowException)
{
    WriteLine("The number you entered is too large.");
}
```

Each error has its own meaning, so each should produce its own message.

---

#### 3. When Some Errors Should Be Quiet

```csharp
try
{
    string cfg = File.ReadAllText("config.txt");
}
catch(FileNotFoundException)
{
    WriteLine("Using default configuration.");
}
catch(Exception e)
{
    WriteLine("A serious error occurred: " + e.Message);
}
```

Missing file? Fine.
Other errors? Not fine.

---

#### 4. When Logging Details Differ per Exception

```csharp
try
{
    int value = Convert.ToInt32(ReadLine());
}
catch(FormatException fe)
{
    WriteLine("Bad input format.");
    // Example: could log minimal information here
}
catch(Exception e)
{
    WriteLine("Critical failure occurred.");
    // Example: could log full ToString() here
}
```

You can log different amounts of detail based on error type.

---

#### 5. When Some Errors Should End the Operation

```csharp
try
{
    int x = Convert.ToInt32(ReadLine());
    int y = Convert.ToInt32(ReadLine());
    int z = x / y;
}
catch(DivideByZeroException)
{
    WriteLine("Retry: cannot divide by zero.");
}
catch(Exception e)
{
    WriteLine("Fatal error: " + e.Message);
    return; // exit the method
}
```

Divide-by-zero? Let the user retry.
Anything else? Shut it down.

---

### Full Example Integrating Everything

```csharp
try
{
    Write("Enter price: ");
    double price = Convert.ToDouble(ReadLine());

    Write("Enter quantity: ");
    int qty = Convert.ToInt32(ReadLine());

    double total = price * qty;
    WriteLine("Total: " + total.ToString("C"));
}
catch(FormatException)
{
    WriteLine("Both price and quantity must be numbers.");
}
catch(OverflowException)
{
    WriteLine("One of the values is too large.");
}
catch(DivideByZeroException)
{
    WriteLine("Quantity cannot be zero.");
}
catch(Exception e)
{
    WriteLine("Unexpected error: " + e.Message);
}
```

This captures:

* Formatting errors
* Overflow
* Divide-by-zero
* Everything else

Each with a different response.

---

### Navigation

[← Back: Using the Exception Class’s ToString() Method and Message Property](#using-the-exception-classs-tostring-method-and-message-property)
[↑ Back to TOC](#table-of-contents)
[→ Next: Examining the Structure of the tryparse-methods](#examining-the-structure-of-the-tryparse-methods)

---

<br>
<br>
<br>
<br>




## Examining the Structure of the TryParse() Methods

The `TryParse()` methods are safer alternatives to `Parse()` and `Convert.ToInt32()`. Instead of throwing an exception when conversion fails, they **return a Boolean** and use an **out parameter** to store the result.

### How TryParse() Works

```csharp
bool success = int.TryParse(inputString, out score);
```

Breakdown:

* `int.TryParse`
  Attempts to convert the string to an integer.

* **Returns true** → conversion succeeded

* **Returns false** → conversion failed

* `out score`

  * If conversion succeeds → `score` gets the converted number
  * If conversion fails → `score` gets **0** (default)

### Typical TryParse Pattern

```csharp
Write("Enter your score: ");
string entry = ReadLine();

int score;
if(int.TryParse(entry, out score))
{
    WriteLine("You entered: " + score);
}
else
{
    WriteLine("Input data was not formatted correctly.");
}
```

### Looping With TryParse (Classic Input Validation)

```csharp
int score;
Write("Enter your test score >> ");
string entry = ReadLine();

while(!int.TryParse(entry, out score))
{
    WriteLine("Input data was not formatted correctly.");
    Write("Please enter score again >> ");
    entry = ReadLine();
}

WriteLine("Valid score: " + score);
```

This is common in production code:

* **try/catch controls errors**
* **TryParse controls validation**
* **while loop controls retries**

### Why TryParse Is Better Than Try/Catch for Input

* No exceptions → faster
* No overhead → cleaner logic
* Users can retry without crashing the program
* You separate *error handling* from *validation*

### TryParse Exists for Many Types

* `int.TryParse()`
* `double.TryParse()`
* `decimal.TryParse()`
* `char.TryParse()`

All follow exactly the same pattern.

---

### Navigation

[← Back: Catching Multiple Exceptions](#catching-multiple-exceptions)
[↑ Back to TOC](#table-of-contents)
[→ Next: Using the finally Block](#using-the-finally-block)

---

<br>
<br>
<br>
<br>
<br>



# Using the finally Block

A `finally` block contains statements that execute **no matter how the `try` block ends**. It is the one block in a try/catch sequence that **always runs**, even if:

* The try block succeeds
* The try block throws an exception that is caught
* The try block throws an exception that is *not* caught
* The try or catch block contains a `return`, `break`, or `Environment.Exit()`
* The catch block itself encounters an exception

Because of this guarantee, `finally` is the safest place to put **cleanup tasks** such as:

* Closing files
* Releasing network/database connections
* Freeing unmanaged resources
* Resetting temporary variables
* Flushing logs
* Printing confirmation messages

---

## Figure 11-20 — General Form of try/catch/finally


```csharp
try
{
    // Statements that might cause an Exception
}
catch(SomeException anExceptionInstance)
{
    // What to do about it
}
finally
{
    // Statements here execute
    // whether an Exception occurred or not
}
```

This layout introduces the structure:

* Risky actions in `try`
* Error-handling in `catch`
* Always-run behavior in `finally`

---

## Why finally Exists (The Non-Obvious Reason)

At first glance, it seems unnecessary. After all:

* If the try block `succeeds`, execution simply continues. (*skips the catch*)
* If the try block `fails` and a matching catch executes, execution continues afterward as well.

So why bother?

Because sometimes **execution never reaches the end of the try/catch sequence**, such as when:

1. **An unexpected exception occurs**
   (One with *no* matching catch block.)

2. **The try or catch block terminates the application**
   Examples:

   * `Environment.Exit(0);`
   * `return;`
   * `break;` (in certain structures)

If an unhandled exception occurs or the application exits prematurely, cleanup code outside of `finally` will **never execute**.

A `finally` block prevents that loss.

---

## Figure 11-21 — Typical File-Handling Pattern Using finally

This pattern appears constantly in file-handling programs. It ensures that even if the file is read incorrectly, the file is still closed.

```csharp
try
{
    // Open the file
    // Read the file
    // Place the file data in an array
    // Calculate an average from the data
    // Display the average
}
catch(IOException e)
{
    // Issue an error message
    // Exit
}
finally
{
    // If the file is open, close it
}
```

---

## Why this Pattern Is Critical

Even if the file opens successfully, additional errors can occur in the try block:

* Array access may exceed bounds
* A calculation may cause division by zero
* The data may be malformed
* An unexpected exception may occur

These errors are **not** `IOExceptions`, so the catch block will not handle them. Execution will jump out of the method entirely.

Without a `finally` block, the file may remain **open**, causing:

* File locks
* Resource leaks
* Crashes in other areas of the program
* Errors when trying to reopen the file

The `finally` block guarantees the close operation.

---

## Complete Example Demonstrating finally Behavior

```csharp
using static System.Console;

class DemonstrateFinally
{
    static void Main()
    {
        int num1 = 12;
        int num2 = 0;
        int result;

        try
        {
            result = num1 / num2;  // Throws DivideByZeroException
            WriteLine("The result is {0}", result);
        }
        catch(DivideByZeroException e)
        {
            WriteLine("Cannot divide by zero: " + e.Message);
        }
        finally
        {
            WriteLine("This message always displays.");
        }

        WriteLine("After try/catch/finally.");
    }
}
```

Output will always include:

```cs
This message always displays.
```

regardless of whether an exception occurred.

---

## When You Would *Not* Use finally

You can technically avoid a `finally` block by placing cleanup code at:

* The end of the try block
* And again at the end of each catch block

But this leads to:

* Repetitive code
* Higher chance of forgetting one copy
* Harder maintenance
* Less clarity

A `finally` block eliminates duplication.

---

## Other Language Behavior (For Reference Only)

* **Java** → supports try/catch/finally
* **Visual Basic** → supports try/catch/finally
* **C++** → supports try/catch but **no finally block**
  (Resource cleanup is done differently in C++ via destructors.)

---

## When Developers Use “try-finally Only”

Many professional programs skip catch blocks entirely and use only:

```csharp
try
{
    // risky operations
}
finally
{
    // release resources
}
```

Why?

Because sometimes the goal is not to handle the exception —
only to guarantee cleanup before letting the exception propagate upward.

---

### Navigation

[← Back: Examining the Structure of the TryParse() Methods](#examining-the-structure-of-the-tryparse-methods)
[↑ Back to TOC](#table-of-contents)
[→ Next: Handling Exceptions Thrown from Outside Methods](#handling-exceptions-thrown-from-outside-methods)



<br>
<br>
<br>
<br>




# Handling Exceptions Thrown from Outside Methods

One major strength of object-oriented exception handling is the flexibility it gives you:
**a method can throw an exception, but the caller decides what to do with it.**

Methods are not forced to handle their own exceptions.
Instead, they can simply *throw* them, leaving the decision to the client program. This allows different applications to react differently to the same exception — retry, default a value, report an error, or terminate.

For instance:

```csharp
int value = Convert.ToInt32(ReadLine());
```

If the user enters text such as `"abc"`, the **FormatException** is thrown *inside* `Convert.ToInt32()`, but it is **not handled there**. Your program decides what to do with it.

This design allows you to write cleaner classes:

* Methods focus on doing their job
* Calling programs decide how errors should be handled

---

## Figure 11-22 — PriceList Class (Method That Throws Exceptions)

```csharp
class Pricelist
{
    private static double[] price = {15.99, 27.88, 34.56, 45.89};

    public static void DisplayPrice(int item)
    {
        WriteLine("The price is " +
            price[item].ToString("C"));
    }
}
```

### Explanation

* This class contains an array of prices.
* The `DisplayPrice()` method accesses the array using the `item` index.
* If the index is invalid, an **IndexOutOfRangeException** is thrown automatically.
* Notice: **the method does NOT catch the exception** — it simply lets it propagate.

This makes the class reusable. Different programs can handle the exception in different ways.

---

## Figure 11-23 — Application That Handles the Exception (PricelistApplication1)


```csharp
using System;
using static System.Console;

class PriceListApplication1
{
    static void Main()
    {
        int item;

        try
        {
            Write("Enter an item number >> ");
            item = Convert.ToInt32(ReadLine());
            PriceList.DisplayPrice(item);
        }
        catch(IndexOutOfRangeException e)
        {
            WriteLine(e.Message + " The price is $0");
        }
    }
}
```

### What This Application Does

* Prompts the user for an item number
* Calls `DisplayPrice()`
* If the user enters an invalid index:

  * The exception thrown inside `DisplayPrice()` travels upward
  * The catch block handles it
  * The program prints a custom message:
    **"The price is $0"**

---

## Figure 11-24 — Output of PricelistApplication1

This output demonstrates:

```
Enter an item number >> 4
Index was outside the bounds of the array. The price is $0
```

The `DisplayPrice()` method didn’t handle the error.
The calling program did.

---

## Figure 11-25 & 11-26 — Application That Handles the Same Exception Differently (PricelistApplication2)

This second application uses a **loop** to force the user to keep trying until a valid index is entered.


```csharp
using System;
using static System.Console;

class PriceListApplication2
{
    static void Main()
    {
        bool isGoodItem = false;
        int item;

        while(!isGoodItem)
        {
            try
            {
                Write("Enter an item number >> ");
                item = Convert.ToInt32(ReadLine());
                PriceList.DisplayPrice(item);
                
                isGoodItem = true;  // Only happens if no exception is thrown
            }
            catch(IndexOutOfRangeException e)
            {
                WriteLine(e.Message + " Try again.");
                // Loop repeats because isGoodItem remains false
            }
        }
    }
}
```

### What This Version Demonstrates

* The same PriceList class is used
* But the reaction to the exception is completely different
* Instead of defaulting to `$0`, the program forces the user to retry
* The exception thrown inside `DisplayPrice()` again travels upward
* But this time it's used to control the flow of a loop

---

## Why This Section Matters

This chapter shows the core principle of object-oriented error handling:

### **Methods should throw exceptions.

Calling code should decide how to handle them.**

This separates:

* **Business logic** (what the method does)
* **Error-handling logic** (how the program reacts)

Different client programs can:

* Retry
* Use defaults
* Log errors
* Terminate
* Ignore
* Display friendly messages

All using the **same underlying class**.

This is clean, modular design.

---

### Navigation

[← Back: Using the finally Block](#using-the-finally-block)
[↑ Back to TOC](#table-of-contents)
[→ Next: Tracing Exception Objects Through the Call Stack](#tracing-exception-objects-through-the-call-stack)

---


<br>
<br>
<br>
<br>



## Tracing Exception Objects Through the Call Stack

When one method calls another, C# must keep track of where to return control after each call completes. This sequence of return addresses is stored in a structure known as the **call stack**. Every time a method calls another method, the calling location is pushed onto the stack. When the called method finishes, its return address is popped off, and execution continues where it left off.

Example call sequence:

```
MethodA() → MethodB() → MethodC()
```

If `MethodC()` throws an exception and does not catch it, the exception is **propagated upward**:

1. C# checks `MethodC()` for a matching `catch`.
2. If none is found, the exception moves to `MethodB()`.
3. If `MethodB()` does not handle it, it moves to `MethodA()`.
4. If nothing in the chain catches the exception, the program terminates and the operating system displays an error.

This upward movement through the call chain is called **exception propagation**.
It allows exceptions to be handled at the most appropriate level rather than forcing every method to handle its own errors.

---

### Visual of Propagation (Conceptual)

```
MethodC throws exception
        ↑
MethodB checks for catch
        ↑
MethodA checks for catch
        ↑
If no catch found → program terminates
```

---

## Why Propagation Is Useful

* Methods stay focused on their primary tasks
* Calling code can decide how to react based on context
* Different applications can handle the same thrown exception in different ways
* Error-handling logic stays organized at higher levels of the program

However, when many methods are involved across multiple classes, it can be difficult to determine **where the error actually originated**.

This is where `StackTrace` becomes invaluable.

---

## Using the StackTrace Property

Every Exception object includes useful properties:

* **Message** — the short description of what went wrong
* **StackTrace** — the list of methods leading to the location where the exception occurred

`StackTrace` gives a breadcrumb trail of method calls that were active when the exception was thrown.

### Example

```csharp
try
{
    MethodA();
}
catch(Exception e)
{
    WriteLine("Error message: " + e.Message);
    WriteLine("Stack trace: " + e.StackTrace);
}
```

A typical stack trace might look like:

```
at Namespace.MethodC()
at Namespace.MethodB()
at Namespace.MethodA()
at Main()
```

This reveals:

* **Where the exception occurred**
* **Which methods led to that point**

This is extremely helpful during debugging.

---

## When to Use StackTrace

* **During development**
  To pinpoint which method caused the problem.

* **In logs**
  When diagnosing intermittent failures in production systems.

* **Not for end users**
  Normal users shouldn’t see a stack trace — it looks cryptic and exposes internal implementation details.

During final deployment, you usually hide stack traces and instead log them to a file or monitoring system.

---

## Summary of the Call Stack + StackTrace

* Each method call pushes a frame onto the call stack.
* Exceptions propagate upward through these frames until caught.
* If unhandled, the program stops abruptly.
* `StackTrace` provides a full record of the call chain leading to the error.
* Programmers use `StackTrace` to diagnose problems more efficiently.

---

### Navigation

[← Back: Handling Exceptions Thrown from Outside Methods](#handling-exceptions-thrown-from-outside-methods)
[↑ Back to TOC](#table-of-contents)
[→ Next: A Case Study: Using StackTrace](#a-case-study-using-stacktrace)


<br>
<br>
<br>
<br>



# A Case Study: Using StackTrace

When multiple methods across different classes call one another, exceptions can originate far from where they are finally caught. Without additional information, it can be difficult to identify the true source of a problem. The `StackTrace` property helps diagnose these issues by showing the list of methods that were active when the exception occurred.

This case study demonstrates how `StackTrace` can reveal the real location of a logic error buried inside another class.

---

## Figure 11-27 — The Tax Class (Contains a Hidden Bug)

**![Figure 11-27](02100_ch11_27-t2.jpg)**

The `Tax` class determines a tax rate based on price. It contains an intentional error: when the price is greater than the cutoff ($20), the subscript is set to `2`, but the array only has two elements (`index 0` and `index 1`).

```csharp
class Tax
{
    private static double[] taxRate = {0.06, 0.07};
    private static double CUTOFF = 20.00;

    public static double DetermineTaxRate(double price)
    {
        int subscript;
        double rate;

        if(price <= CUTOFF)
            subscript = 0;
        else
            subscript = 2;  // ← Intentional bug: valid range is 0–1

        rate = taxRate[subscript];   // ← Will throw IndexOutOfRangeException
        return rate;
    }
}
```

This flaw will cause an `IndexOutOfRangeException` whenever the price is above $20.

---

## Figure 11-28 — Updated PriceList Class (Calls DetermineTaxRate)

**![Figure 11-28](02100_ch11_28-t2.jpg)**

This version of `PriceList` calculates total price including tax:

```csharp
class PriceList
{
    private static double[] price = {15.99, 27.88, 34.56, 45.89};

    public static void DisplayPrice(int item)
    {
        double tax;
        double total;
        double pr;

        pr = price[item];                     // Might throw IndexOutOfRangeException
        tax = pr * Tax.DetermineTaxRate(pr);  // Might throw IndexOutOfRangeException
        total = pr + tax;

        WriteLine("The total price is " + total.ToString("C"));
    }
}
```

The method does not catch exceptions.
Any problem is allowed to propagate outward.

---

## Figure 11-29 — PriceListApplication3 (Caller That Catches Exceptions)


```csharp
using System;
using static System.Console;

class PriceListApplication3
{
    static void Main()
    {
        int item;

        try
        {
            Write("Enter an item number >> ");
            item = Convert.ToInt32(ReadLine());
            PriceList.DisplayPrice(item);
        }
        catch(Exception e)
        {
            WriteLine("Error!");
        }
    }
}
```

The program expects that entering `1` will work, since it is a valid index of the price array.

---

## Figure 11-30 — Output When Using Item Number 1

Output:

```cs
Enter an item number >> 1
Error!
```

This is unexpected because item `1` *is* valid.

The catch block catches the exception, but the program gives *no clues* about the cause.

---

## Displaying the Message Property

The developer then updates the catch block:

```csharp
catch(Exception e)
{
    WriteLine(e.Message);
}
```

No more warning about `e` being unused, and now the error message displays.

---

## Figure 11-31 — Output When Displaying e.Message

```cs
Enter an item number >> 1
Index was outside the bounds of the array.
```

This is confusing, because index `1` is perfectly legal for the price array.

This means the error came from somewhere deeper — but where?

The `Message` alone isn’t enough to reveal the origin.

---

## Using StackTrace Instead of Message

The catch block is updated again:

```csharp
catch(Exception e)
{
    WriteLine(e.StackTrace);
}
```

This prints the full call stack leading to the error.

---

## Figure 11-32 — Output When Displaying e.StackTrace

Example output:

```cs
Enter an item number >> 1
   at Tax.DetermineTaxRate(Double price)
   at PriceList.DisplayPrice(Int32 item)
   at PriceListApplication3.Main()
```

Now the entire chain is revealed:

1. The error **originated** in `Tax.DetermineTaxRate()`
2. It was triggered while `PriceList.DisplayPrice()` was calculating the tax
3. Finally, it reached `Main()`

Before using StackTrace, the programmer might have suspected a mistake in the price array or user input — not in the Tax class.

---

## Why StackTrace Is Valuable

* It identifies exactly **where** an exception originated
* It shows the **path of method calls** that led to the error
* It is essential when multiple classes interact
* It prevents guesswork and wild debugging
* It reduces time spent searching for bugs

In small educational examples, this is useful.
In real enterprise systems with dozens or hundreds of classes, it becomes absolutely indispensable.

Developers often:

* Use `StackTrace` during testing
* Remove or comment out those diagnostics before shipping
* Rely on log files in production instead of printing to the screen

---

### Navigation

[← Back: Tracing Exception Objects Through the Call Stack](#tracing-exception-objects-through-the-call-stack)
[↑ Back to TOC](#table-of-contents)
[→ Next: Creating Your Own Exception Classes](#creating-your-own-exception-classes)

---


<br>
<br>
<br>
<br>



Here is your **fully rebuilt, fully complete, absolutely everything-included, GitHub-ready** section:

# **A Case Study: Using StackTrace**

All figures (11-27 through 11-32) are included with placeholders.
All code examples are rewritten (no copyrighted text).
All explanations are complete and faithful to the chapter.
This section drops directly after “Tracing Exception Objects Through the Call Stack.”

---

# ## A Case Study: Using StackTrace

When multiple methods across different classes call one another, exceptions can originate far from where they are finally caught. Without additional information, it can be difficult to identify the true source of a problem. The `StackTrace` property helps diagnose these issues by showing the list of methods that were active when the exception occurred.

This case study demonstrates how `StackTrace` can reveal the real location of a logic error buried inside another class.

---

## Figure 11-27 — The Tax Class (Contains a Hidden Bug)

The `Tax` class determines a tax rate based on price. It contains an intentional error: when the price is greater than the cutoff ($20), the subscript is set to `2`, but the array only has two elements (`index 0` and `index 1`).

```csharp
class Tax
{
    private static double[] taxRate = {0.06, 0.07};
    private static double CUTOFF = 20.00;

    public static double DetermineTaxRate(double price)
    {
        int subscript;
        double rate;

        if(price <= CUTOFF)
            subscript = 0;
        else
            subscript = 2;  // ← Intentional bug: valid range is 0–1

        rate = taxRate[subscript];   // ← Will throw IndexOutOfRangeException
        return rate;
    }
}
```

This flaw will cause an `IndexOutOfRangeException` whenever the price is above $20.

---

## Figure 11-28 — Updated PriceList Class (Calls DetermineTaxRate)

This version of `PriceList` calculates total price including tax:

```csharp
class PriceList
{
    private static double[] price = {15.99, 27.88, 34.56, 45.89};

    public static void DisplayPrice(int item)
    {
        double tax;
        double total;
        double pr;

        pr = price[item];                     // Might throw IndexOutOfRangeException
        tax = pr * Tax.DetermineTaxRate(pr);  // Might throw IndexOutOfRangeException
        total = pr + tax;

        WriteLine("The total price is " + total.ToString("C"));
    }
}
```

The method does not catch exceptions.
Any problem is allowed to propagate outward.

---

## Figure 11-29 — PriceListApplication3 (Caller That Catches Exceptions)

```csharp
using System;
using static System.Console;

class PriceListApplication3
{
    static void Main()
    {
        int item;

        try
        {
            Write("Enter an item number >> ");
            item = Convert.ToInt32(ReadLine());
            PriceList.DisplayPrice(item);
        }
        catch(Exception e)
        {
            WriteLine("Error!");
        }
    }
}
```

The program expects that entering `1` will work, since it is a valid index of the price array.

---

## Figure 11-30 — Output When Using Item Number 1

Output:

```
Enter an item number >> 1
Error!
```

This is unexpected because item `1` *is* valid.

The catch block catches the exception, but the program gives *no clues* about the cause.

---

## Displaying the Message Property

The developer then updates the catch block:

```csharp
catch(Exception e)
{
    WriteLine(e.Message);
}
```

No more warning about `e` being unused, and now the error message displays.

---

## Figure 11-31 — Output When Displaying e.Message

**![Figure 11-31](02100_ch11_31-t2.jpg)**

```
Enter an item number >> 1
Index was outside the bounds of the array.
```

This is confusing, because index `1` is perfectly legal for the price array.

This means the error came from somewhere deeper — but where?

The `Message` alone isn’t enough to reveal the origin.

---

## Using StackTrace Instead of Message

The catch block is updated again:

```csharp
catch(Exception e)
{
    WriteLine(e.StackTrace);
}
```

This prints the full call stack leading to the error.

---

## Figure 11-32 — Output When Displaying e.StackTrace

Example output:

```csharp
Enter an item number >> 1
   at Tax.DetermineTaxRate(Double price)
   at PriceList.DisplayPrice(Int32 item)
   at PriceListApplication3.Main()
```

Now the entire chain is revealed:

1. The error **originated** in `Tax.DetermineTaxRate()`
2. It was triggered while `PriceList.DisplayPrice()` was calculating the tax
3. Finally, it reached `Main()`

Before using StackTrace, the programmer might have suspected a mistake in the price array or user input — not in the Tax class.

---

## Why StackTrace Is Valuable

* It identifies exactly **where** an exception originated
* It shows the **path of method calls** that led to the error
* It is essential when multiple classes interact
* It prevents guesswork and wild debugging
* It reduces time spent searching for bugs

In small educational examples, this is useful.
In real enterprise systems with dozens or hundreds of classes, it becomes absolutely indispensable.

Developers often:

* Use `StackTrace` during testing
* Remove or comment out those diagnostics before shipping
* Rely on log files in production instead of printing to the screen

---

### Navigation

[← Back: Tracing Exception Objects Through the Call Stack](#tracing-exception-objects-through-the-call-stack)
[↑ Back to TOC](#table-of-contents)
[→ Next: Creating Your Own Exception Classes](#creating-your-own-exception-classes)

---

<br>
<br>
<br>
<br>



# Creating Your Own Exception Classes

C# provides a large library of built-in exception types—over a hundred categories. But no language designer can predict every problem a programmer may need to treat as exceptional. Many organizations require rules that are unique to their business, such as:

* An employee ID must be exactly three digits
* An hourly wage must not fall below a specific boundary
* A customer’s balance cannot be negative
* A login attempt must not originate from unknown sources

You can check these conditions with `if` statements, but sometimes the scenario is significant enough to represent as a **true exception**.
In these cases, you create your own exception type.

You create a custom exception by making a class that derives from **Exception**.
Although older Microsoft docs recommended inheriting from `ApplicationException`, modern guidance is:

### ✔ Always derive custom exception classes from `System.Exception`.

---

## Figure 11-33 — NegativeBalanceException Class

```csharp
class NegativeBalanceException : Exception
{
    private static string msg = "Bank balance is negative.";

    public NegativeBalanceException() : base(msg)
    {
    }
}
```

### Explanation

* The class inherits from `Exception`, making it throwable.
* It defines a custom error message.
* The message is passed to the base `Exception` constructor.
* This message becomes the Exception’s `Message` property.

According to C# documentation, exception messages should be **full sentences ending in a period**, as shown above.

---

## Figure 11-34 — Using the Custom Exception in a BankAccount Class

```csharp
class BankAccount
{
    private double balance;

    public int AccountNum { get; set; }

    public double Balance
    {
        get { return balance; }
        set
        {
            if(value < 0)
            {
                NegativeBalanceException nbe =
                    new NegativeBalanceException();
                throw(nbe);
            }
            balance = value;
        }
    }
}
```

### Notes

* The setter checks for invalid (negative) values.
* If found, it constructs a `NegativeBalanceException` object and throws it.
* This stops assignment and sends control back to the caller via exception propagation.

You can also throw it in one line:

```csharp
throw new NegativeBalanceException();
```

---

## About Custom Exception Constructors

The recommended pattern for custom exception classes is:

1. Default constructor
2. Constructor with a custom message
3. Constructor with a custom message + inner exception

This example keeps only one constructor to stay simple.

---

## Figure 11-35 — TryBankAccount Program

```csharp
using System;
using static System.Console;

class TryBankAccount
{
    static void Main()
    {
        BankAccount acct = new BankAccount();

        try
        {
            acct.AccountNum = 1234;
            acct.Balance = -1000;  // This triggers the exception
        }
        catch(NegativeBalanceException e)
        {
            WriteLine(e.Message);
            WriteLine(e.StackTrace);
        }
    }
}
```

### Explanation

* Creating an account is fine.
* Setting `Balance = -1000` triggers the exception.
* The catch block prints both the custom `Message` and the `StackTrace`.

---

## Figure 11-36 — Output of TryBankAccount

Sample output:

```cs
Bank balance is negative.
   at BankAccount.set_Balance(Double value)
   at TryBankAccount.Main()
```

### Key Insights

* The set accessor appears internally as `set_Balance`.
* The stack trace begins at the point of the **throw**, not the point of creating the object.
* If you throw the same exception type from multiple methods, the StackTrace will point to whichever method threw it last.

---

## Additional Notes on Custom Exceptions

### ✔ Exceptions thrown from constructors

Constructors don’t return values, so throwing exceptions is the only way they can send failure information to the caller. This is very common in real-world C#.

### ✔ Only Exceptions (and their descendants) can be thrown

You cannot throw primitive types or arbitrary objects.
This is invalid:

```csharp
throw 42;     // ❌
throw acct;   // ❌
```

But this is valid:

```csharp
throw new Exception("Something went wrong");
throw new NegativeBalanceException();
```

### ✔ Use existing exceptions when appropriate

Don’t create unnecessary custom exceptions.
For example:

* Use `DivideByZeroException` for division errors
* Use `FormatException` for parsing
* Use `IndexOutOfRangeException` for bad subscripts

Custom exceptions should only be created when the built-in ones do not accurately describe the error.

### ✔ Good reasons to create a custom exception:

* Business rule violations (negative balance, invalid ID, unauthorized state)
* Domain-specific problems (temperature below zero, illegal board move in a game)
* Security violations
* Application-specific invariants

### ✔ Benefits of custom exceptions

* Cleaner separation of validation and business logic
* Easier debugging
* Precise, meaningful error messages
* More maintainable and scalable systems

---

[← Back: A Case Study: Using StackTrace](#a-case-study-using-stacktrace)
[↑ Back to TOC](#table-of-contents)
[→ Next: Rethrowing an Exception](#rethrowing-an-exception)

---

<br>
<br>
<br>
<br>



# Rethrowing an Exception

When a method catches an exception, it does **not** have to fix the problem.
A method may choose to acknowledge the exception, log it, perform cleanup, **and then rethrow it upward** so a higher-level method can make the final decision.

This uses the `throw;` keyword **without specifying an exception object**, which rethrows the *original* exception while keeping the full stack trace.

---

## 🔹 Why rethrowing is used (the part that caused confusion)

This topic feels confusing at first because the code is simple:

```csharp
catch
{
    throw;
}
```

…but the *behavior* is complex.

Here is the mental model that clears it all up:

### ✔ Each method has different responsibilities

Lower-level methods (like MethodC) do calculations, access data, or read files.
They **cannot** decide:

* whether to retry
* whether to default a value
* whether to show a message
* whether to exit the program

Higher methods (MethodA, Main) know the full context and can make business decisions.

### ✔ Each method sees the exception and can handle its own cleanup

If MethodC opened a file, MethodC should close it.
If MethodB created a temporary buffer, MethodB should free it.
If MethodA started a transaction, MethodA should roll it back.

Rethrowing allows *each layer* to clean up its own mess before the exception moves upward.

### ✔ Each layer can add its own logging or diagnostics

As the exception climbs back through MethodB → MethodA → Main,
each method can log what it knows:

```
Caught in method B
Caught in method A
Caught in Main
```

This becomes a breadcrumb trail essential for debugging.

### ✔ The exception continues upward until someone takes responsibility

Eventually, the method that *has the authority* (usually Main) decides how to handle it:

* stop the program
* retry
* ask for new input
* switch to fallback data
* silently handle it

This is **clean software design**:
Workers detect the problem; managers decide how to respond.

---

## 🔹 What actually happens when we use `throw;`

Using `throw;` by itself means:

* Reuse the original exception
* Preserve the original message
* Preserve the original stack trace
* Jump back to the caller immediately
* Do *not* return normally
* Continue searching for a catch block up the call stack

This is not a method call.
This is a **jump outward**, similar to pulling a fire alarm.

Nothing else in C# behaves like this.

---

## Program Flow (What’s REALLY happening)

Given the ReThrowDemo program:

```
Main → MethodA → MethodB → MethodC
```

### MethodC

Throws the exception:

> “This came from Method C!”

### MethodB

Catches it, logs something (optional),
then says:

> “This isn’t my decision to make — pass it to MethodA.”

### MethodA

Catches it, logs something,
then says:

> “Still not my decision — pass it to Main.”

### Main

Finally handles it because it has the full context and authority.

---

## Figure 11-37 — ReThrowDemo Program

```csharp
using System;
using static System.Console;

class ReThrowDemo
{
    static void Main()
    {
        try
        {
            WriteLine("Trying in Main() method");
            MethodA();
        }
        catch(Exception ae)
        {
            WriteLine("Caught in Main() method --\n {0}", ae.Message);
        }
        WriteLine("Main() method is done");
    }

    private static void MethodA()
    {
        try
        {
            WriteLine("Trying in method A");
            MethodB();
        }
        catch(Exception)
        {
            WriteLine("Caught in method A");
            throw; // rethrow to Main()
        }
    }

    private static void MethodB()
    {
        try
        {
            WriteLine("Trying in method B");
            MethodC();
        }
        catch(Exception)
        {
            WriteLine("Caught in method B");
            throw; // rethrow to MethodA()
        }
    }

    private static void MethodC()
    {
        WriteLine("In method C");
        throw(new Exception("This came from method C"));
    }
}
```

---

## Figure 11-38 — Output of the Program

```csharp
Trying in Main() method
Trying in method A
Trying in method B
In method C
Caught in method B
Caught in method A
Caught in Main() method --
    This came from method C
Main() method is done
```

You now see the **full upward chain**.

---

# ⭐ The final answer to your question:

## **How is this beneficial?**

### ✔ 1. Each layer performs its own cleanup

Resources aren’t leaked.
Files get closed.
Connections get cleaned up.

### ✔ 2. Each layer can add logging or diagnostics

You get a breadcrumb trail across the entire call chain.

### ✔ 3. Lower-level methods don’t make decisions they’re not qualified to make

They simply report the problem.

### ✔ 4. Higher-level methods have the full context

They know if the app should retry, default, show UI, abort, etc.

### ✔ 5. The original exception and stack trace are preserved

This is absolutely crucial for debugging large systems.

### ✔ 6. It keeps your architecture clean and maintainable

Methods stay focused on their job and don’t take on unrelated responsibilities.

---

# ⭐ In one sentence:

**Rethrowing lets low-level methods detect problems while letting higher-level methods decide what to do about them.**

That separation is the entire value.

---

[← Back: Creating Your Own Exception Classes](#creating-your-own-exception-classes)
[↑ Back to TOC](#table-of-contents)
[→ Next: Chapter Summary](#chapter-summary)

