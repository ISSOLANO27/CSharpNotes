

# Detailed Notes — `string` Data Type in C\#

[← Back to README](./README.md)

 
 ## Placeholders in `WriteLine` (Figure 2-15)

* `Console.WriteLine("compare {0} to {1}: {2}", name1, name2, name1 == name2);`
* `{0}`, `{1}`, `{2}` are **format placeholders**.

  * `{0}` → replaced by `name1`.
  * `{1}` → replaced by `name2`.
  * `{2}` → replaced by the **third argument**, here `name1 == name2` (Boolean result).

> **Q1:** `{2}` is simply another placeholder for the third argument, not something special for strings.

---

## Timing of Comparisons

* Comparisons (like `name1 == name2`) are **evaluated first**, then their results are passed into `WriteLine` to be slotted into `{2}`.

> **Q2:** Yes—the string comparison happens after variable declarations, at the point of evaluation in the `WriteLine`.

---

## Lexical (Alphabetical) Comparison

* Strings are compared **lexically**: left-to-right, character by character, using Unicode values.
* In Unicode, uppercase letters have **smaller** values than lowercase.

  * `'A'` = 65, `'a'` = 97.
  * So `'a' > 'A'`.

> **Q3:** `'a'` is greater than `'A'` because it has the larger Unicode value.

---

## Why Standard Comparison Methods Matter

* `==` is simple equality.
* Methods like `.Equals()`, `.CompareTo()`, `String.Compare()`:

  * Have **standard names**, universally understood in .NET.
  * Provide **extra functionality** (case-insensitive, culture-specific comparisons).
* Other classes adopt these names (`Equals`, `CompareTo`) so developers instantly know how they behave.

## Simple Examples of String Comparison Methods

* **Equality (`==`)**:
    ```csharp
    string a = "hello";
    string b = "hello";
    bool result = a == b;  // true
    ```

* **`.Equals()` method**:
    ```csharp
    string a = "Hello";
    string b = "hello";
    bool result = a.Equals(b);  // false (case-sensitive)
    ```

* **`.CompareTo()` method**:
    ```csharp
    string a = "apple";
    string b = "banana";
    int result = a.CompareTo(b);  // -1 (a < b)
    ```

* **`String.Compare()` static method**:
    ```csharp
    string a = "cat";
    string b = "Cat";
    int result = String.Compare(a, b);  // 1 (case-sensitive, 'c' > 'C')
  // =0 → strings are equal
  // <0 → string1 is less than string2
  // >0 → string1 is greater than string2


> **Q5:** It’s not just about naming convention—it’s about a shared contract. `CompareTo` always means “returns negative, zero, positive” → essential for sorting/searching. `Equals` always means “checks equality.” This consistency is why they’re preferred.

---

## Placeholders with Methods

* Example:

  ```csharp
  WriteLine("{0} and {1}; Equals() method gives {2}", name1, name2, name1.Equals(name2));
  ```
* `{2}` corresponds to the **third argument**, which is the method call `name1.Equals(name2)`.

> **Q6:** You nailed it. `{2}` is just printing the *result of the comparison method*.

---

## String Immutability vs. Numeric Mutability

* **Strings are immutable**:

  * `"Amy"` → memory location holds it permanently.
  * `name = "Donald";` makes `name` point to a new memory location, but `"Amy"` still exists until garbage-collected.
  * Original value is not “erased” but “orphaned.”

* **Numbers are mutable**:

  * `int x = 5; x = 10;` → the same memory slot now holds `10`.
  * Old value (`5`) is overwritten directly.

> **Q7:** With strings, the value itself never changes—just the variable’s pointer. With numbers, the actual memory cell gets updated.

---

## `Substring()` and `Length`

* `word.Length` = total number of characters.
  Example: `"water"` → `Length = 5`.

* `Substring(start, length)`:

  * `start`: starting index (0-based).
  * `length`: how many characters to take.

* `word.Substring(0, word.Length)` → `"water"` (whole string).

* `word.Substring(0, word.Length - 1)` → `"wate"` (everything except the last char).

> **Q8:** `Length - 1` works because indexes are zero-based, so the last character is at `Length - 1`. When used in `Substring()`, it tells the method “extract up to—but not past—the last index.”

---

## `StartsWith()` Method

* Checks if a string begins with a specific substring.
* Returns a `bool`.
* Example:

  ```csharp
  string word = "water";
  bool check = word.StartsWith("wa");  // true
  ```
* Yes, it’s part of the `String` class.

> **Q9:** Correct—`StartsWith()` returns a Boolean, and it lives under the `String` class.

---

# Cheat Sheet — `string` in C\#

* **Immutable**: assigning new value → new memory address.
* **Placeholders**: `{0}`, `{1}`, `{2}` → filled by arguments.
* **Comparison**:

  * `==` → basic equality.
  * `.Equals()` → Boolean equality, standard method.
  * `.CompareTo()` / `String.Compare()` → ordering: <0, 0, >0.
  * Default: `'a' > 'A'` (Unicode 97 vs 65).
* **Length**: total chars (`word.Length`).
* **Substring(start, len)**: slice of string.

  * `Substring(0, word.Length)` → full string.
  * `Substring(0, word.Length - 1)` → minus last char.
* **StartsWith/EndsWith/Contains**: return `bool`, used for quick checks.

