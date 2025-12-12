

[← Back to README](./README.md)

 
 # Accepting Console Input in C\#

## Interactive Programs

* Programs that accept user input are called **interactive programs**.
* Input typically comes from the keyboard.

---

## `ReadLine()` Method

* Reads **all characters** the user types until they press **Enter**.
* Returns the input as a **string**.
* Example:

  ```csharp
  string myString = ReadLine();
  ```

---

## `Read()` Method

* Reads **only one character** from the input stream.
* Difference:

  * `Read()` → 1 character
  * `ReadLine()` → entire line (until Enter)

---

## Before C# 6.0

* Needed full names:

  * `Console.ReadLine()`
  * `Console.Read()`
* Now you can simplify by adding:

  ```csharp
  using static System.Console;
  ```
* This allows shorter calls: `ReadLine()`, `Read()`.

---

## Converting Input from String to Other Types

* Input from `ReadLine()` is always a **string**.
* To use the value as another type (like `int` or `double`), you must convert it.

### Conversion Methods

1. **`Convert` class**

   ```csharp
   int age = Convert.ToInt32(ReadLine());
   ```
2. **`Parse()` method**

   ```csharp
   int age = int.Parse(ReadLine());
   ```

Both transform string input into numeric or other data types.

---

# Cheat Sheet — Console Input

* **ReadLine()** → reads entire line as `string`.
* **Read()** → reads one character.
* **Before C# 6.0** → needed `Console.ReadLine()`, now can shorten with:

  ```csharp
  using static System.Console;
  ```
* **Conversion** (string → number):

  * `Convert.ToInt32(ReadLine());`
  * `int.Parse(ReadLine());`

---

