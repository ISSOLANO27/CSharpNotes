

# Detailed Notes — Arithmetic Operators in C\#

[← Back to README](./README.md)

 
 ### Overview

* Arithmetic operators let you manipulate numeric values.
* The values they work on are called **operands**.
* These are **binary operators** (they use two operands: left + right).

---

### The Five Binary Arithmetic Operators

| Operator | Description    | Example  | Result                |
| -------- | -------------- | -------- | --------------------- |
| `+`      | Addition       | `45 + 2` | 47                    |
| `-`      | Subtraction    | `45 - 2` | 43                    |
| `*`      | Multiplication | `45 * 2` | 90                    |
| `/`      | Division       | `45 / 2` | 22 (integer division) |
| `%`      | Remainder      | `45 % 2` | 1                     |

---

### Special Considerations: `/` and `%`

* If at least `one operand` is floating-point → result is floating-point.

  ```csharp
  45.0 / 2   // 22.5
  ```
* If both operands are integers → result is integer; fractional part is truncated.

  ```csharp
  45 / 2     // 22
  ```

> **Clarification 1:** Yes — the “special consideration” is that integer division **drops the fractional part**. It isn’t stored or displayed.

* `integer constants` vs `integer variables`:

  * **Constants** = fixed literal values like `45` or `2`.
  * **Variables** = identifiers storing integers.
  * Both behave the same way in division.

> **Clarification 2:** A constant is not a global variable.
>
> ```csharp
> const int DaysInWeek = 7;
> ```
>
> Constants never change. A *global variable* is just a variable declared outside of methods — but it can still change.

---

### The Remainder Operator `%`

* `%` with integers = remainder after division.

  ```csharp
  45 % 2   // 1
  ```
* `%` with floating-points = **unreliable**, because floats only approximate decimals in binary.

> **Clarification 3:** Floats can’t precisely store values like 0.1. When `%` is applied, small rounding errors make results unpredictable.

* **Remainder vs Modulus**:

  * **Remainder** = sign of dividend (C# behavior).
  * **Modulus** = sign of divisor (pure math).
  * Example:

    ```csharp
    -7 % 3   // -1 in C#
    ```

> **Clarification 4:** C# uses the **remainder operator**, not a true modulus operator.

---

### Division, Floats, and Casting

* If both operands are integers → result is integer.
* If one operand is float → result is float.
* Python behaves differently: `/` always gives a float.

> **Clarification 5:** Yes — in C#, at least one operand must be float for a float result. Python always returns float with `/`.

* **Casting**: converting one type to another.

  ```csharp
  double d = (double)7 / 2; // 3.5
  int x = (int)3.99;        // 3
  ```

> **Quick glimpse:** Casting tells the compiler, “treat this as another type” — useful for keeping fractions or forcing truncation.

---

### Operator Precedence and Associativity

* Precedence = the priority/order of operations.

* Associativity = how operators of the same precedence group.

* Example:

  ```csharp
  int result = 2 + 3 * 4;    // 14
  int result2 = (2 + 3) * 4; // 20
  ```

> **Clarification 6:** Yes — precedence is like **PEMDAS**: parentheses, multiplication/division/remainder, then addition/subtraction.

* Precedence order for arithmetic operators:

  1. Parentheses `()`
  2. Multiplication `*`, Division `/`, Remainder `%` (left-to-right)
  3. Addition `+`, Subtraction `-` (left-to-right)

> **Clarification 7:** Appendix lists all precedence + associativity. Precedence = rank. Associativity = left-to-right or right-to-left when ranks tie.

---

### Why Floating-Point Can’t Represent 0.1 Exactly

* **Decimal (base 10):** we can split into tenths. 0.1 = 1/10 exactly.
* **Binary (base 2):** computers split only into halves → 1/2, 1/4, 1/8, etc.
* 0.1 in decimal becomes an **infinite repeating binary fraction**:

  ```
  0.1 = 0.0001100110011… (binary, infinite)
  ```
* Computers store finite bits → they cut it off, so 0.1 is only an approximation.

#### Pizza Analogy 🍕

* Decimal Land: pizza cut into 10 slices → 0.1 = 1 slice.
* Binary Land: pizza can only be halved → 1/2, 1/4, 1/8, etc.
* You’ll never slice exactly 1/10 with just halves. You can only approximate.

This explains why:

```csharp
Console.WriteLine(0.1 + 0.2 == 0.3); // False
```

The internal binary values don’t add up to exactly 0.3.

---

> **My Summary (in your words spot):**

---

# Cheat Sheet — Arithmetic Operators

* **Operators**: `+ - * / %`
* **Division**:

  * Int ÷ Int → int (fraction dropped)
  * Float involved → float
* **Remainder `%`**: remainder operator (sign = dividend)
* **Casting**: `(double)7 / 2` → 3.5
* **Precedence**:

  * `()`
  * `* / %`
  * `+ -`
* **Associativity**: left-to-right for arithmetic operators.
* **Float issue**: 0.1 can’t be stored exactly → approximations.

---

### Prompt to Add to Chat Instructions

Here’s the reusable prompt you wanted:

> **“Whenever I take notes, include my clarifying questions as sub-sections under the relevant note topic. Use `>` to capture the clarification so I can see it tied directly to the explanation.”**

---

Would you like me to also **append a full operator precedence/associativity table** (from unary `++` to `??` null-coalescing) so your notes are future-proof?
