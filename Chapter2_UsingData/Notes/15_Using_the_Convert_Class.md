

## Selected `Convert` class methods you’ll actually use

[← Back to README](./README.md)

 
  | Method                       | Converts to | Typical input(s)               | Notes                                                                                                 |
| ---------------------------- | ----------- | ------------------------------ | ----------------------------------------------------------------------------------------------------- |
| `Convert.ToInt32(string)`    | `int`       | `"42"`, `"003"`                | Rounds from floating point (banker’s rounding) if given a `double/decimal`. Throws on invalid string. |
| `Convert.ToDouble(string)`   | `double`    | `"28.77"`, `"1,234.5"`         | Culture-aware for decimal separators; throws on invalid string.                                       |
| `Convert.ToDecimal(string)`  | `decimal`   | `"19.99"`                      | Prefer for money math before formatting.                                                              |
| `Convert.ToBoolean(string)`  | `bool`      | `"True"`, `"False"`            | Case-insensitive keywords only (not “yes/no”).                                                        |
| `Convert.ToDateTime(string)` | `DateTime`  | `"2025-09-08"`, locale formats | Culture-sensitive; for durable parsing prefer `DateTime.TryParseExact`.                               |
| `Convert.ToString(value)`    | `string`    | any primitive                  | Uses value’s `ToString()`; combine with format specifiers on numbers.                                 |

### Money best-practice

* Parse to **`decimal`** → compute → **format** with `.ToString("C")`.
  Example:

```csharp
decimal price = Convert.ToDecimal(ReadLine());
decimal tax   = price * 0.06m;
WriteLine(tax.ToString("C"));
```

---

## Formatting numbers you’ll meet right away

* `"C"` → Currency (`$1,234.56`)
* `"N"` → Number with group separators (`1,234.56`)
* `"P"` → Percent (`6.00 %`) – multiply by 100 for display only
* `"F2"` → Fixed-point with 2 decimals (`1234.50`)

> You can always combine a format specifier with a culture for deterministic output:

```csharp
using System.Globalization;
total.ToString("C", CultureInfo.GetCultureInfo("en-US"));
```

---

# Cheat Sheet

* **Flow**: `ReadLine()` → `string` → `Convert.ToXxx()` → compute → `ToString("format")` → `WriteLine`.
* **Placeholders**: `{0}`, `{1}`, `{2}` map to the args after the format string.
* **Money**: use `decimal` for math, `"C"` for display.
* **Common Convert**: `ToInt32`, `ToDouble`, `ToDecimal`, `ToBoolean`, `ToDateTime`, `ToString`.
* **Safer input**: prefer `TryParse` to avoid exceptions on bad input.
* **Culture-aware display**: `ToString("C", CultureInfo...)` for controlled currency output.

---

