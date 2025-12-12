

[← Back to README](./README.md)

 
 # Detailed Notes: The `char` Data Type in C\#

## What is `char`?

* `char` is used to hold a **single character**.
* Characters are enclosed in **single quotes** (`'D'`, `'9'`, `'A'`).
* Internally, a `char` is stored as a numeric code (Unicode, 16-bit).

### Example:

```csharp
char initial = 'D';
char aCharValue = '9';
```

---

## Digits as Characters

* `'9'` stored as a `char` is **not the same** as the numeric `9`.
* `'9'` cannot be used directly in arithmetic because it’s a character, not a number.
* If you need arithmetic, store as `int` instead.

---

## Difference Between `char` and `string`

* `char`: holds **one** character.
* `string`: holds a **sequence** of characters (literal written in **double quotes**).

---

## Escape Sequences

* Special characters (non-printing ones like tab, newline, etc.) are stored in `char` using escape sequences.
* Escape sequences begin with a backslash `\`.

### Common Escape Sequences:

| Escape | Character       |
| ------ | --------------- |
| `\'`   | Single quote    |
| `\"`   | Double quote    |
| `\\`   | Backslash       |
| `\0`   | Null            |
| `\a`   | Alert (beep)    |
| `\b`   | Backspace       |
| `\f`   | Form feed       |
| `\n`   | Newline         |
| `\r`   | Carriage return |
| `\t`   | Tab             |
| `\v`   | Vertical tab    |

Example:

```csharp
char aBackspaceChar = '\b';
char aTabChar = '\t';
```

---

## Unicode and Hexadecimal

* C# stores characters using **Unicode** (16-bit, covers global alphabets and symbols).
* Example: `'A'` is stored as binary `0000 0000 0100 0001` (hexadecimal `0041`).
* Unicode shorthand: `\u` followed by four hex digits.

### Example:

```csharp
char letter = 'A';
char letterHex = '\u0041';  // equivalent to 'A'
```

---

## Unicode Applications

* Can represent letters from other alphabets (Greek, Hebrew, Chinese, etc.).
* Can represent mathematical symbols, currency symbols, and more.
* Example: `'\u0007'` represents a beep sound.

---

# Cheat Sheet: `char` in C\#

* `char` = single character, use `' '`.
* `string` = sequence of characters, use `" "`.
* `'9'` ≠ `9` (character vs integer).
* Escape sequences: `\n` (newline), `\t` (tab), `\\` (backslash), `\'` (single quote), `\"` (double quote), etc.
* Unicode format: `\u####` (4 hex digits).
  Example: `\u0041` = `'A'`.

