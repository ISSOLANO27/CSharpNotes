Perfect, let’s capture this section as Markdown notes for your repo.

---

# Detailed Notes — Using the Integral Data Types (IDT)

[← Back to README](./README.md)

 
 ### What are Integral Data Types?

* **9 C# types** that can hold **whole numbers** (no fractions).
* These map to specific `System` types in .NET.
* Even characters (`char`) and symbols can be represented numerically (e.g., `'A'` = 65 in Unicode).

### The 9 Integral Data Types

1. **`byte`** (System.Byte)

   * 1 byte (8 bits), range: 0 → 255
2. **`sbyte`** (System.SByte)

   * 1 byte, range: –128 → 127
3. **`short`** (System.Int16)

   * 2 bytes, range: –32,768 → 32,767
4. **`ushort`** (System.UInt16)

   * 2 bytes, range: 0 → 65,535
5. **`int`** (System.Int32)

   * 4 bytes, range: –2,147,483,648 → 2,147,483,647
   * **Default type** for integer literals (e.g., typing `3` or `359` makes an `int`)
6. **`uint`** (System.UInt32)

   * 4 bytes, range: 0 → 4,294,967,295
7. **`long`** (System.Int64)

   * 8 bytes, range: –9,223,372,036,854,775,808 → 9,223,372,036,854,775,807
8. **`ulong`** (System.UInt64)

   * 8 bytes, range: 0 → 18,446,744,073,709,551,615
9. **`char`** (System.Char)

   * 2 bytes, stores a single Unicode character (`'\u0000'` → `'\uFFFF'`)

---

### Notes on Usage

* **Memory conservation**:

  * Rarely an issue on PCs, but matters for small devices (like smartphones).
* **Programmer habit**:

  * Most developers default to `int` for whole numbers (balance of range + simplicity).
* **Signs**:

  * You can use `+` or `-` explicitly.
  * Example:

    ```csharp
    int annualSalary = 20000;
    int debt = -5000;
    ```
* **Digit separators** (C# 7.0+):

  * Use `_` to improve readability of large numbers.

    ```csharp
    int aLotOfMoney = 23_456_789;
    ```

---

> **My Summary (in your words spot):**

---

# Cheat Sheet — Integral Data Types

* **9 types**: `byte`, `sbyte`, `short`, `ushort`, `int`, `uint`, `long`, `ulong`, `char`.
* **int = default** for integer literals.
* **Sizes**: 1B, 2B, 4B, 8B, 2B (`char`).
* **Range**: depends on signed vs unsigned.
* **Use**:

  * `int` for most whole numbers.
  * Smaller types only when optimizing memory.
* **Digit separators**: `23_456_789`.
* **Example**:

  ```csharp
  int myNumber = 100;
  uint positiveOnly = 500u;
  char letter = 'A'; // Unicode 65
  ```

---
