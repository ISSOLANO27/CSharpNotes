

# Detailed Notes — Formatting Floating-Point Values

[← Back to README](./README.md)

 
 ### Default Behavior

* By default, C# displays floating-point numbers in the **shortest form** that still preserves the correct value.
* Example:

  ```csharp
  double myMoney = 14.00;
  Console.WriteLine("The amount is {0}", myMoney); // Output: The amount is 14
  ```
* Trailing zeros after the decimal are omitted (they add no mathematical info).

---

### Standard Numeric Format Strings

* Special codes for formatting numeric output inside `.ToString()` or interpolation.
* Form: `"Xn"` where **X** = format character, **n** = precision specifier (decimal places or digits).

#### Common Specifiers (Table 2-2)

* **C/c** → Currency → `$XX,XXX.XX`
* **D/d** → Decimal (integer, no decimals)
* **E/e** → Exponential (scientific notation, e.g., `1.23E+05`)
* **F/f** → Fixed-point (e.g., `123.45`)
* **G/g** → General (chooses shortest: fixed-point or scientific)
* **N/n** → Number with commas and decimals → `1,234.56`
* **P/p** → Percent (multiplies by 100, adds `%`)
* **R/r** → Round-trip (ensures the value converts back to the same number)
* **X/x** → Hexadecimal

---

### Using `.ToString()` with Format Specifiers

* Example with **Fixed Point**:

  ```csharp
  double someMoney = 123;
  Console.WriteLine(someMoney.ToString("F"));   // 123.00
  Console.WriteLine(someMoney.ToString("F3"));  // 123.000
  ```

* Example with **Currency**:

  ```csharp
  double moneyValue = 456789;
  Console.WriteLine(moneyValue.ToString("C"));  // $456,789.00
  ```

* You can skip making a string variable — format directly inside `WriteLine`.

  ```csharp
  double payAmount = 12345;
  Console.WriteLine(payAmount.ToString("C"));   // $12,345.00
  ```

---

### Culture and Localization

* Currency/number formats depend on **culture settings**.

  * US English: `$12,345.00`
  * Other cultures may use commas, spaces, or different currency symbols.
* The `.NET CultureInfo` class (System.Globalization) lets you control these formats.
* Example: switch culture to French → `12 345,00 €`.

---

### Key Takeaways

* Use format specifiers to control decimals, grouping, and representation.
* Currency, percent, and scientific notation are built-in options.
* Culture settings can change output globally.

---

> **My Summary (in your words spot):**

---

# Cheat Sheet — Formatting Floating-Point Values

* **Default**: `14.00` → prints `14`.
* **Format: "Xn"** → X = specifier, n = precision.

Specifiers:

* `C` = Currency → `$1,234.56`
* `D` = Decimal integer → `1234`
* `E` = Exponential → `1.23E+05`
* `F` = Fixed point → `1234.56`
* `G` = General (shortest)
* `N` = Number → `1,234.56`
* `P` = Percent → `12.34%`
* `R` = Round-trip (exact same value back)
* `X` = Hexadecimal

Examples:

```csharp
double x = 12345.6789;
Console.WriteLine(x.ToString("F2"));  // 12345.68
Console.WriteLine(x.ToString("C"));   // $12,345.68
Console.WriteLine(x.ToString("E3"));  // 1.235E+04
Console.WriteLine(x.ToString("N"));   // 12,345.68
```

