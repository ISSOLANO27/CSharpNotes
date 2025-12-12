

# Notes — Shortcut Arithmetic Operators in C\#

[← Back to README](./README.md)

 
 ### Increasing Variables

* Common task: increase a variable by 1.

  ```csharp
  counter = counter + 1;
  ```
* Reads as: “Take the current value of `counter`, add 1, assign back to `counter`.”

Shortcut form:

```csharp
counter += 1;   // same as counter = counter + 1
```

---

### Add and Assign (`+=`)

* Adds right operand to left operand and assigns result to the left.
* Example:

  ```csharp
  int payRate = 20;
  payRate += 5;   // 25
  ```
* Works with expressions:

  ```csharp
  bankBal += bankBal * interestRate;
  // same as:
  bankBal = bankBal + bankBal * interestRate;
  ```

> **Clarification 1:** Yes — Python uses the same `+=` shortcut syntax, as well as `-=`, `*=`, `/=`, and `%=`. Behavior is very similar between Python and C#.

---

### Other Shortcut Operators

* `-=` subtract and assign

  ```csharp
  balanceDue -= payment; // subtracts and stores
  ```
* `*=` multiply and assign

  ```csharp
  rate *= 100; // multiplies rate by 100 and stores
  ```
* `/=` divide and assign

  ```csharp
  payment /= 12; // divides by 12 and stores new result
  ```

> **Clarification 2:** Yes — all shortcut operators (`+=`, `-=`, `*=`, `/=`) assign the result to the **left operand**. In the example `payment /= 12`, the value of `payment` is updated (stored) as the result of the division.

---

### Increment and Decrement (`++`, `--`)

* Increase or decrease by 1.
* Two forms:

  * **Prefix**: `++x` → increment, then use.
  * **Postfix**: `x++` → use, then increment.

Examples:

```csharp
int someValue = 6;
++someValue;     // prefix: now 7

int anotherValue = 56;
anotherValue++;  // postfix: still 56 here, becomes 57 next
```

* Both forms increase by 1, but timing of when the value is read vs updated differs.

---

### Prefix vs Postfix Example

```csharp
int b = 4;
int c = ++b;  // prefix: b becomes 5, then c = 5

b = 4;
c = b++;      // postfix: c = 4, then b becomes 5
```

---

### Unary Operators

* `++` and `--` are **unary** (one operand).
* Most others (`+`, `-`, `*`, `/`, `%`) are **binary** (two operands).

---

### Decrement Operator (`--`)

* Works like increment but subtracts 1.

  ```csharp
  int s = 34;
  int t = --s; // t = 33, s = 33
  ```

---

> **My Summary (in your words spot):**


---

# Cheat Sheet — Shortcut Arithmetic Operators

* `+=` add + assign

* `-=` subtract + assign

* `*=` multiply + assign

* `/=` divide + assign

* Increment/decrement:

  * `++x` prefix → increment, then use
  * `x++` postfix → use, then increment
  * `--` works the same but subtracts

Examples:

```csharp
x += 5;    // x = x + 5
y *= 10;   // y = y * 10
z--;       // z = z - 1
```

---

Would you like me to **expand this with a comparison table** (C# vs Python shortcut operators side by side) so you can instantly see if they behave the same or differently?
