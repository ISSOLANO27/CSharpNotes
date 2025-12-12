

# Detailed Notes — Defining Named Constants in C\#

[← Back to README](./README.md)

 
 ## What is a Constant?

* A **constant** is like a variable whose value **cannot change** after it is defined.
* Declared with the keyword `const` before the data type.
* Example:

  ```csharp
  const double TAX_RATE = 0.06;
  ```

---

## Naming Conventions

* Many programmers use **all uppercase letters with underscores** for constants (e.g., `TAX_RATE`, `INCHES_IN_A_FOOT`).
* This is sometimes called **SCREAMING CAPS**.
* Purpose: Makes constants easy to spot and harder to confuse with regular variables.
* Style may vary; follow your team/organization’s conventions.

---

## Rules for Constants

* Must be assigned a value **at the time of declaration**.

  * Example: `const int MAX_SCORE = 100;`
* Cannot be reassigned later (immutable).
* Must use the same data type as declared.
* Used like regular variables in calculations, display, etc., but **never modified**.

---

## Why Use Constants?

* Makes code **clearer and self-documenting**.

* Prevents accidental changes to values that should remain fixed.

* Example:

  ```csharp
  const int INCHES_IN_A_FOOT = 12;
  lengthInInches = lengthInFeet * INCHES_IN_A_FOOT;
  ```

  * Easier to understand than `lengthInInches = lengthInFeet * 12;`.

* Helps future maintainability: if the value changes, update it once in the constant definition.

---

## Self-Documenting Code

* Using named constants makes programs easier to read even without comments.
* Example:

  * With constant: `TAX = amount * TAX_RATE;` → clear what’s happening.
  * Without: `TAX = amount * 0.06;` → less obvious meaning of `0.06`.

---

# Cheat Sheet — Named Constants in C\#

* **Keyword**: `const`
* **Syntax**: `const <type> NAME = value;`
* **Rules**:

  * Must be initialized when declared.
  * Cannot be reassigned.
* **Naming**: Often ALL\_CAPS\_WITH\_UNDERSCORES.
* **Purpose**: Immutable, improves readability, avoids “magic numbers.”
* **Example**:

  ```csharp
  const int INCHES_IN_A_FOOT = 12;
  const double TAX_RATE = 0.06;
  ```
