
# Detailed Notes — Declaring Variables (2-1)

[← Back to README](./README.md)

 
 ### Constants vs Variables

* **Constant**: a value that cannot change once compiled.

  * Example: `347` → always the same literal constant.
  * Literal constant = unnamed constant (no identifier).
* **Variable**: a named memory location whose value can change during execution.

  * Example: `heatingBill` → can be 347, 200, etc.
  * Useful for reusing one program logic with different data.

---

### Data Types

* Each constant/variable has a **data type** → defines:

  * Memory size
  * Format
  * Allowed operations
* **C# intrinsic types** (aliases for .NET `System` types).
* Commonly used: `int`, `double`, `decimal`, `char`, `string`, `bool`.

**Numeric Types (no decimals):**

* `byte` → 1 byte, 0–255
* `sbyte` → 1 byte, –128–127
* `short` → 2 bytes, –32,768–32,767
* `ushort` → 2 bytes, 0–65,535
* `int` → 4 bytes, –2,147,483,648–2,147,483,647
* `uint` → 4 bytes, 0–4,294,967,295
* `long` → 8 bytes, very large range
* `ulong` → 8 bytes, 0 to very large range

**Numeric Types (with decimals):**

* `float` → 4 bytes, approx. 7 digits precision
* `double` → 8 bytes, approx. 15–16 digits precision
* `decimal` → 16 bytes, higher precision, for money

**Other Types:**

* `char` → 2 bytes, Unicode character (`0x0000` to `0xFFFF`)
* `bool` → 1 byte, `true` / `false`
* `string` → text, no fixed size, Unicode
* `object` → base type for all classes

---

### Variables and Identifiers

* Naming rules (same as classes):

  * Must start with a letter
  * No spaces
  * Not a reserved keyword
* Convention: **camelCase** for variables (e.g., `myAge`, `heatingBill`).
- [Same rules as Class identifiers](~DEV\CSharpIntro\Chapter1\Notes~\1-6._Selecting_identifiers.md)
---

### Variable Declarations

* Declaration reserves memory and defines type:

  ```csharp
  int myAge;
  ```
* Initialization assigns value at declaration:

  ```csharp
  int myAge = 25;
  ```
* Assignment changes value later:

  ```csharp
  myAge = 42;
  ```
* Assignment operator `=` means "is assigned the value of."

  * Legal: `myAge = 25;`
  * Illegal: `25 = myAge;`

---

### Type Aliases vs System Types

* `int` ↔ `System.Int32`
* Prefer alias for readability and convention.

---

### Multiple Declarations

* Same type, one line:

  ```csharp
  int myAge = 25, yourAge = 19;
  ```
* Or broken across lines (indented for readability):

  ```csharp
  int myAge = 25,
      yourAge = 19;
  ```

---

> **My Summary:**

---

# Cheat Sheet — Declaring Variables

* **Constant**: fixed, unchanging → `347`.
* **Variable**: named storage, can change → `int heatingBill = 200;`.
* **Types**:

  * int (whole number), double (floating-point), decimal (money), char (character), string (text), bool (true/false).
* **Aliases**: `int` = `System.Int32`. Use short alias.
* **Declaration**: `int x;`
* **Initialization**: `int x = 5;`
* **Assignment**: `x = 10;`
* **Multiple vars**: `int a = 1, b = 2;`
* **Naming convention**: camelCase (`myAge`).

---

To sharpen your prompt skills: next time, you can tell me *“make me notes with both examples and common mistakes”* so I include real C# code samples (like showing legal vs illegal assignments).

💡 **C# tip to stay top percentile**: Get comfortable with value types vs reference types. It’s a foundation for memory management, performance tuning, and later advanced topics like garbage collection and unsafe code. Would you like me to add a short section contrasting them here for your notes?


