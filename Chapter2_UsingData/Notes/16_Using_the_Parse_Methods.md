
[← Back to README](./README.md)
# Detailed Notes — Using the `Parse()` Methods

### Purpose of `Parse()`

* `Parse()` is a **static method** that converts a `string` into the equivalent data type.
* Example: turning `"123"` into an `int` or `"3.14"` into a `double`.
* Works directly on system type names (`int`, `double`, `bool`, `DateTime`) or their .NET class equivalents (`Int32`, `Double`, `Boolean`, `DateTime`).

---

### Examples

```csharp
// Using simple type
double price = double.Parse("19.99");

// Using system type class
double priceAlt = Double.Parse("19.99");

// Direct from Console input
int score = int.Parse(Console.ReadLine());
int score2 = Int32.Parse(Console.ReadLine());
```

Both versions are valid. One uses the **alias name** (`int`, `double`), the other uses the **system type name** (`Int32`, `Double`).

---

### Relationship with `Convert`

* `Convert.ToInt32("123")` and `int.Parse("123")` do similar things.
* **Difference**:

  * `Convert.ToInt32(null)` → returns `0`.
  * `int.Parse(null)` → throws `ArgumentNullException`.
* Performance differences exist but are small; follow course/instructor preference for now.

---

### Supported Data Types

* **Numeric**: `int.Parse`, `double.Parse`, `decimal.Parse`, etc.
* **Boolean**: `bool.Parse("true")` → `true`.
* **DateTime**: `DateTime.Parse("2025-09-15")`.

---

### Exceptions to Watch

* **FormatException** → input string is not in the correct form.
* **OverflowException** → input string represents a number too big/small.
* **ArgumentNullException** → input is `null`.

---

### Alternative: `TryParse()`

* Safer method for user input.
* Does not throw exceptions; returns a `bool` for success/failure.

```csharp
if (int.TryParse(Console.ReadLine(), out int score))
{
    Console.WriteLine($"Parsed: {score}");
}
else
{
    Console.WriteLine("Invalid input.");
}
```

---

### Term: *Parse*

* “Parsing” means **breaking into components**.
* In C#, parsing a string means analyzing it and converting it to its numeric (or other) representation.

---

# Cheat Sheet — Parse Methods

* `int.Parse("123")` → 123
* `double.Parse("3.14")` → 3.14
* `bool.Parse("true")` → true
* `DateTime.Parse("2025-09-15")` → DateTime object
* Use `.TryParse()` for safer input (returns true/false).
* `Convert` handles nulls → safer for defaulting.
* Exceptions: `FormatException`, `OverflowException`, `ArgumentNullException`.

---

⚡ C# market tip: In competitive back-end jobs, you’ll often deal with **data validation** pipelines (from JSON, APIs, user input). Employers look for developers who know how to **gracefully handle parsing errors**. Master `TryParse` and pair it with **input validation** techniques (like Regex checks) to show production-ready coding skills.

---
