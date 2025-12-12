

[← Back to README](./README.md)

 
 # Notes: Numeric Type Conversion in C\#

## What is Numeric Type Conversion?

* In C#, when arithmetic is performed, operands may be of different data types.
* The compiler must decide which type the result should be.
* This process is called **numeric type conversion**.

---

## Implicit Conversion (Widening Conversion)

* Happens automatically when a smaller type is converted to a larger one.
* **Rule:** Smaller → Larger = safe, no precision loss (except when going to `float` or `double`, which may lose some decimal accuracy but not magnitude).
* Example:

  ```csharp
  int hoursWorked = 36;
  double payRate = 12.35;
  double grossPay = hoursWorked * payRate; 
  // int promoted to double, result is double
  ```

### Ladder of Implicit Conversions (Integral → Floating)

* `sbyte → short → int → long → float → double`
* `byte → short → ushort → int → uint → long → ulong → float → double`
* `decimal` is considered the **highest precision**, but it does not mix automatically with `float` or `double`.

---

## Explicit Conversion (Narrowing Conversion)

* Required when converting from a larger type to a smaller one.
* **Rule:** Larger → Smaller = unsafe, must use a cast.
* May cause:

  * **Loss of data** (e.g., truncating decimals).
  * **Overflow** (storing a value outside the target’s range).
* Example:

  ```csharp
  double money = 45.78;
  int dollars = (int)money; 
  // dollars = 45, decimal part lost
  ```

---

## Decimal Type Special Case

* `decimal` is used for **financial accuracy** (base-10 precision).
* C# will **not** implicitly mix `decimal` with `float` or `double` because they use binary fractions (base-2) and could distort results.
* Example:

  ```csharp
  decimal price = 10.5m;
  double discount = 0.1;
  // var result = price * discount;  // ❌ Error
  var result = price * (decimal)discount; // ✅ Explicit cast required
  ```

---

## Loss of Precision Examples

* Converting `long → double`: magnitude is preserved, but some integer precision may be lost.
* Casting down to smaller integral types:

  ```csharp
  int anOkayInt = 256;
  byte aBadByte = (byte)anOkayInt;  
  // aBadByte = 0, wraps around because byte max = 255
  ```

---

## Error Example

If you try to assign a double to an int without casting:

```csharp
double pay = 25.5;
int wage = pay;  // ❌ Error: Cannot implicitly convert double to int
int wage = (int)pay; // ✅ Explicit cast
```

---

# Cheat Sheet: Numeric Type Conversion in C\#

### Implicit (safe) ladder:

```
sbyte → short → int → long → float → double
byte  → short → ushort → int → uint → long → ulong → float → double
decimal (highest precision, doesn’t auto-mix with float/double)
```

### Rules:

* Smaller → Larger = implicit.
* Larger → Smaller = explicit `(type)` required.
* Mixing int + double = double.
* Decimal only mixes with decimal (requires cast with float/double).
* Overflow when downcasting = wraparound (e.g., 256 → (byte) = 0).
* Precision may be lost with float/double, but magnitude is preserved.

-
