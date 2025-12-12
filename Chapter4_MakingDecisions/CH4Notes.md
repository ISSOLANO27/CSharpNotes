# Chapter 4 — Decision Making in C# (Study Notes)

> These notes reorganize your chapter into a **complete, exam-ready** reference with navigation, fixed code, truth tables, answered questions, and a definitions section for every **bold** term.

---

## Table of Contents

* [Introduction](#introduction)
* [Understanding Logic-Planning Tools and Decision Making](#understanding-logic-planning-tools-and-decision-making)
* [Making Decisions Using the `if` Statement](#making-decisions-using-the-if-statement)

  * [A Note on Equivalency Comparisons](#a-note-on-equivalency-comparisons)
* [Making Decisions Using the `if-else` Statement](#making-decisions-using-the-if-else-statement)
* [Using Compound Expressions in `if` Statements](#using-compound-expressions-in-if-statements)

  * [Conditional AND `&&`](#using-the-conditional-and-operator)
  * [Conditional OR `||`](#using-the-conditional-or-operator)
  * [Combining `&&` and `||` (precedence)](#combining-and-and-or-operators)
* [Making Decisions Using the `switch` Statement](#making-decisions-using-the-switch-statement)

  * [Using an `enum` with `switch`](#using-an-enumeration-with-a-switch-statement)
* [Using the Conditional Operator `?:`](#using-the-conditional-operator)
* [Using the NOT Operator `!`](#using-the-not-operator)
* [Avoiding Common Errors When Making Decisions](#avoiding-common-errors-when-making-decisions)

  * [Accurate & Efficient Range Checks](#performing-accurate-and-efficient-range-checks)
  * [Using `&&` vs `||` Appropriately](#using--and--appropriately)
  * [Using `!` Correctly](#using-the--operator-correctly)
* [Decision-Making in GUI Programs](#decision-making-issues-in-gui-programs)
* [Chapter Summary](#chapter-4-summary)
* [Definitions (bold terms)](#definitions-bold-terms)

---

## Introduction

Upon completion of this chapter, you will be able to:

* **Understand logic-planning tools and decision making**
* Make decisions using *if* statements
* Make decisions using *if-else* statements
* Use compound expressions in *if* statements
* Make decisions using `switch` statements
* Use the conditional operator
* Use the NOT operator
* Avoid common errors when making decisions
* Appreciate decision-making issues in GUI programs

Programs are powerful because they **make decisions**. In this chapter, you’ll implement decisions in C#.

[↩ Back to TOC](#table-of-contents)

---

## Understanding Logic-Planning Tools and Decision Making

Programmers **plan** before they code. Two core tools:

* **Pseudocode** — plain-English steps describing logic (no C# syntax).
  Example (directions to a house):

  1. Go west on Algonquin Road → 2) Turn left on Rosie Road → 3) Enter expressway heading east.

* **Flowchart** — diagram of steps with shapes:

  * Rectangle = process/step
  * Diamond = decision (True/False branches)
  * Arrows = flow

A **sequence structure** runs steps unconditionally, one after another. Decisions break linearity: a diamond asks a yes/no question and branches to different paths. At hardware level, **all decisions reduce to Boolean** (True/False) because circuits are on/off.

### Two Truths and a Lie — Logic, Planning, Decision Making

1. A sequence structure has three or more alternate logical paths. **False** — it’s linear.
2. A decision structure chooses between alternatives based on program values. **True**.
3. All computer decisions reduce to yes/no. **True**.

[↩ Back to TOC](#table-of-contents)

---

## Making Decisions Using the `if` Statement

Use an **if statement** for a single-alternative decision.

```csharp
if (testedExpression)
    statement;
```

* `testedExpression` must evaluate to `true`/`false` (Boolean).
  Examples: `amount > 5`, `month == "May"`, or a `bool` variable like `isValidIdNumber`.
* If `true` → run `statement`; otherwise skip it; then continue.

> C# does **not** treat nonzero as true and zero as false (unlike C/C++). Only `bool` expressions are valid.

Example (Figure 4-3 behavior):

```csharp
if (number < 5)
    Console.WriteLine("A");
Console.WriteLine("B");
```

* If `number < 5` is true → prints **A** then **B**.
* Otherwise → prints **B** only.

**Common gotcha:** do **not** put a semicolon after the `if ( ... )`.
`if (number < 5);` means “do nothing if true,” and **A** prints unconditionally if you wrote `Console.WriteLine("A");` after it.

**Indentation** is for humans; the compiler uses **braces** `{}`. To make multiple lines depend on the `if`, wrap them in a **block**:

```csharp
if (number < 5)
{
    Console.WriteLine("C");
    Console.WriteLine("D");
}
```

Without braces, only the very next statement is controlled:

```csharp
if (number < 5)
    Console.WriteLine("C");
Console.WriteLine("D"); // always runs
```

**Nested `if`** (one decision inside another) runs the inner test only if the outer test was true:

```csharp
if (number > LOW)
    if (number < HIGH)
        Console.WriteLine("{0} is between {1} and {2}", number, LOW, HIGH);
```

Minimal program (fixed typos from the raw text):

```csharp
using System;
using static System.Console;

class NestedDecision
{
    static void Main()
    {
        const int HIGH = 10, LOW = 5;
        Write("Enter an integer: ");
        int number = Convert.ToInt32(ReadLine());

        if (number > LOW)
            if (number < HIGH)
                WriteLine("{0} is between {1} and {2}", number, LOW, HIGH);
    }
}
```

### A Note on Equivalency Comparisons

* `=` assigns; `==` compares. `if (number = HIGH)` is illegal (wrong type) unless you assign to a `bool`.
* The confusing but legal pattern:

```csharp
if (hasDependents = numDependents > 0) { /* ... */ }  // assigns then uses result
```

Better:

```csharp
hasDependents = (numDependents > 0);
if (hasDependents) { /* ... */ }
```

And this **compares** two booleans (no assignment):

```csharp
if (hasDependents == (numDependents > 0)) { /* ... */ }
```

### Two Truths and a Lie — `if` Statements

1. In C#, the `if` expression must be in parentheses. **True**.
2. Multiple statements depend on an `if` if they’re indented. **False** — they must be **braced**.
3. You can nest an `if` inside another `if`. **True**.

[↩ Back to TOC](#table-of-contents)

---

## Making Decisions Using the `if-else` Statement

Use **dual-alternative** `if-else` when you need either action A or action B.

```csharp
if (expression)
    statement1;
else
    statement2;
```

You can block multiple statements in either branch.

```csharp
if (isProjectUnderBudget)
    bonus = 200;
else
{
    bonus = 0;
    Console.WriteLine("Notify contractor");
}
```

**Pairing rule:** each `else` pairs with the **most recent unmatched** `if`:

```csharp
if (saleAmount > 1000)
    if (saleAmount < 2000)
        bonus = 100;
    else
        bonus = 500;
```

* 1000–1999 → bonus 100
* ≥ 2000 → bonus 500
* ≤ 1000 → **no assignment** (bug!) — real code should handle this.

**Question 1 (extension of the budget example):**
*Add an extra condition: if under budget by a certain margin, also notify and set a reminder to take action.*

```csharp
bool isProjectUnderBudget = /* ... */;
decimal budgetVariance = /* negative means under budget by amount */;
const decimal MAJOR_SAVINGS = -5000m; // “under by at least $5k”

if (isProjectUnderBudget)
{
    bonus = 200;
}
else if (budgetVariance <= MAJOR_SAVINGS) // under by a big margin (negative)
{
    bonus = 200;
    Console.WriteLine("Notify contractor (major savings).");
    Console.WriteLine("Create reminder: review staffing plan.");
    // In real apps, call a scheduler/API here.
}
else
{
    bonus = 0;
    Console.WriteLine("Notify contractor");
}
```

### Two Truths and a Lie — `if-else`

1. Dual-alternative decisions have two outcomes. **True**.
2. In an `if-else` statement, a semicolon might be the last character typed **before** `else`. **True** — the statement **before** `else` still ends with `;` (e.g., `WriteLine(...);`), but **do not** end the `if ( ... )` line with `;`.
3. First `if` always pairs with first `else`. **False** — it pairs with the most recent unmatched `if`.

[↩ Back to TOC](#table-of-contents)

---

## Using Compound Expressions in `if` Statements

You can combine conditions with **conditional AND** `&&` and **conditional OR** `||` to keep logic concise.

### Using the Conditional AND Operator

`X && Y` is **true only if both** `X` and `Y` are true.

**Question 3a:** *What is being compared — data, data type, length, ASCII?*

* The **comparison** depends on the operator you use inside each sub-expression.

  * Relational: `<, <=, >, >=` compare numeric values (for strings, you generally **don’t** use these; use methods or equality).
  * Equality: `==` compares **values** (for strings, value equality; for reference types, operator overload may differ).
* `&&` then combines the **Boolean results** of those comparisons. It does **not** compare types/length/ASCII by itself.

**Truth table — `&&`**

| X     | Y     | X && Y |
| ----- | ----- | ------ |
| true  | true  | true   |
| true  | false | false  |
| false | true  | false  |
| false | false | false  |

**Short-circuit:** if the left side of `&&` is `false`, the right side is **not evaluated**.

**Equivalent nested `if` vs `&&`:**

```csharp
// Using &&
if (age >= 0 && age < 120)
    Console.WriteLine("Age is valid");

// Using nested if
if (age >= 0)
    if (age < 120)
        Console.WriteLine("Age is valid");
```

> **Question 3b:** *So the way OR works is you can either use `&&` or nested `if`?*
> Not OR; rather, **`&&` is equivalent to nested `if`s where the inner runs only if the outer was true**. For OR, see below.

**Each side must be a complete Boolean expression:**

```csharp
if (saleAmount > 1000 && saleAmount < 5000) { /* ok */ }
// ❌ if (saleAmount > 1000 && < 5000)  // invalid
```

Add parentheses for readability:

```csharp
if ((saleAmount > 1000) && (saleAmount < 5000)) { /* ... */ }
```

[↩ Back to TOC](#table-of-contents)

---

### Using the Conditional OR Operator

`X || Y` is **true if either** is true (or both).

**Truth table — `||`**

| X     | Y     | X \|\| Y |
| ----- | ----- | -------- |
| true  | true  | true     |
| true  | false | true     |
| false | true  | true     |
| false | false | false    |

Short-circuit: if the left side is `true`, the right side is not evaluated.

```csharp
if (age < 0 || age > 120)
    Console.WriteLine("Age is not valid");
```

**Question 4:** *Can we write `OR` instead of `||`?*
No. C# uses the **operator tokens** `&&` and `||`. The word `or` is not an operator.

[↩ Back to TOC](#table-of-contents)

---

## Combining AND and OR Operators

You can chain many conditions, but **precedence** matters: `&&` binds **tighter** than `||`.

```csharp
// Misleading without parentheses:
if (age <= 12 || age >= 65 && rating == 'G') { /* ... */ }

// Correct logic: discount only if (child OR senior) AND movie is G
if ((age <= 12 || age >= 65) && rating == 'G') { /* ... */ }
```

**Question 5 (interpretation):**
*Without parentheses, are we letting children get discounts regardless of rating, while rating restriction applies only to the elderly?*
Close: because `&&` has higher precedence, `age >= 65 && rating == 'G'` is grouped first. That means: “child of any rating **or** senior seeing G.” So yes, the rating restriction effectively applied only to seniors in that buggy expression. Parentheses fix it.

> Tip: Add parentheses even when not required if it clarifies intent.

[↩ Back to TOC](#table-of-contents)

---

## Making Decisions Using the `switch` Statement

A `switch` compares **one** expression to many **exact match** cases. Cleaner than long `else if` chains when you’re checking specific values.

```csharp
switch (year)
{
    case 1: Console.WriteLine("Freshman"); break;
    case 2: Console.WriteLine("Sophomore"); break;
    case 3: Console.WriteLine("Junior");    break;
    case 4: Console.WriteLine("Senior");    break;
    default: Console.WriteLine("Invalid year"); break;
}
```

Key points:

* `switch (expr)` — expr is the **switch expression**.
* `case <value>:` — a **case label**; must be unique for that `switch`.
* `break` ends the case (C# has a **no fall-through** rule).
* `default:` optional but recommended.

A case may have **no statements** to group multiple labels:

```csharp
switch (year)
{
    case 3:
    case 4:
        Console.WriteLine("Upperclass");
        break;
}
```

Use `switch` only when:

* You test one expression for **equality** against a **reasonable set** of discrete values.

### Two Truths & A Lie — `switch`

1. `case` is followed by a possible match and a colon. **True**.
2. `break` always terminates a case. **True** (other terminators exist like `return`/`throw`, but *a* terminator is required).
3. A `switch` doesn’t need a `default`. **True** (but it’s good practice to include one).

[↩ Back to TOC](#table-of-contents)

---

## Using an Enumeration with a `switch` Statement

Enums give meaningful names to constants and pair perfectly with `switch`.

```csharp
using System;
using static System.Console;

class DivisionBasedOnMajor
{
    enum Major { ACCOUNTING = 1, CIS, ENGLISH, MATH, MARKETING }

    static void Main()
    {
        Write("Enter major code >> ");
        int code = Convert.ToInt32(ReadLine());

        string message;
        switch ((Major)code)
        {
            case Major.ACCOUNTING:
            case Major.CIS:
            case Major.MARKETING:
                message = "Major is in the business division";
                break;
            case Major.ENGLISH:
            case Major.MATH:
                message = "Major is in the humanities division";
                break;
            default:
                message = "Department number is invalid";
                break;
        }
        WriteLine(message);
    }
}
```

**Question 6 (in simpler terms):**

* The user types a number (1–5).
* We **cast** that number to the enum `Major`.
* The `switch` groups some majors as “business” and others as “humanities.”
* “Divisions” are not declared types here; they’re just **output strings** indicating categories.

[↩ Back to TOC](#table-of-contents)

---

## Using the Conditional Operator

The **conditional (ternary) operator** is a compact `if-else` that returns a value:

```csharp
// syntax:  test ? valueIfTrue : valueIfFalse
int bigger = (a > b) ? a : b;
```

Great inside expressions—including interpolated strings:

```csharp
Console.WriteLine((testScore >= 60) ? "Pass" : "Fail");
Console.WriteLine($"{name}'s status is {(testScore >= 60 ? "Pass" : "Fail")}");
```

**Question 7:** *Is there a major difference between the non-interpolated and interpolated versions?*

* The **ternary** `?:` is the same either way.
* The leading `$"..."` enables **string interpolation**, letting you embed expressions like `{name}` or `{score}` directly. It replaces older `{0}` formatting with clearer inline expressions.

### Two Truths & A Lie — Conditional Operator

1. `int m = j < k ? j : k;` with `j=2,k=3` → `m=2`. **True**.
2. `int n = j < k ? j + j : k + k;` → `n=4`. **True**.
3. `int p = j > k ? j + k : j * k;` → `p=5`. **False** — `2*3=6`.

[↩ Back to TOC](#table-of-contents)

---

## Using the NOT Operator

`!` negates a Boolean expression.

```csharp
if (age < 26) premium = 200; else premium = 125;
if (!(age < 26)) premium = 125; else premium = 200;
if (age >= 26) premium = 125; else premium = 200;
if (!(age >= 26)) premium = 200; else premium = 125;
```

Readable pattern with a `bool`:

```csharp
bool oldEnough = (age >= 26);
if (!oldEnough) premium = 200; else premium = 125;
```

Precedence: `!` binds tighter than `&&` or `||`:

```csharp
ageOverMinimum && !ticketsUnderMinimum  // == ageOverMinimum && (!ticketsUnderMinimum)
```

**De Morgan’s Laws** (intuition):

* “Not (A and B)” means “not A **or** not B”:  `!(A && B) == (!A || !B)`
* “Not (A or B)” means “not A **and** not B”: `!(A || B) == (!A && !B)`
  They’re just the algebra of negation over groups—handy for flipping conditions cleanly.

### Two Truths & A Lie — NOT Operator

1. With `p=q=r=true`, `p = !q || r;` → `p = (!true) || true = false || true = true`. **True**.
2. With `p=q=r=true`, `p = !(!q && !r);` → `!(!true && !true) = !(false && false) = !false = true`. **True**.
   *Is this common? (Q8)* Yes—this is a textbook **De Morgan** transformation used to simplify or invert grouped conditions.
3. With `p=q=r=true`, `p = !(q || !r);` → `!(true || !true) = !(true || false) = !true = false`. **False** (the claim “still true” is false).
   *Is this common? (Q9)* You’ll see patterns like this when validating “none of these are true” or when negating complex guards; it’s common in parsing and input validation.

[↩ Back to TOC](#table-of-contents)

---

## Avoiding Common Errors When Making Decisions

Frequent mistakes:

* Using `=` instead of `==` in conditions.
* Stray semicolon after `if ( ... )`.
* Missing braces `{}` for multi-line branches.
* Incomplete expressions on either side of `&&` / `||`.

### Performing Accurate and Efficient Range Checks

Buggy approach (overwrites earlier assignment):

```csharp
if (saleAmount >= 1000) commissionRate = 0.08;
if (saleAmount >= 500)  commissionRate = 0.06;  // runs too!
if (saleAmount <= 499)  commissionRate = 0.05;
```

Better chain:

```csharp
if      (saleAmount >= 1000) commissionRate = 0.08;
else if (saleAmount >= 500)  commissionRate = 0.06;
else                         commissionRate = 0.05; // last case implied
```

Efficiency tip: order tests by most likely to be true to short-circuit earlier.

### Using `&&` and `||` Appropriately

Natural language can mislead you:

```csharp
// Boss says “less than 5.65 and greater than 60” — that’s impossible for one value
if (payRate < 5.65 || payRate > 60) Console.WriteLine("Error in pay rate");
```

```csharp
// Boss says “departments 1 and 2” — means “either”
if (department == 1 || department == 2) Console.WriteLine($"Name is: {name}");
```

### Using the `!` Operator Correctly

Don’t write a condition that’s **always true**:

```csharp
// Always true: every code is not 'A' OR not 'B'
if (salesCode != 'A' || salesCode != 'B') discount = 0.10;

// Correct:
if (salesCode != 'A' && salesCode != 'B') discount = 0.10;
// or
if (!(salesCode == 'A' || salesCode == 'B')) discount = 0.10;
```

### Two Truths & A Lie — Avoiding Errors

1. `if (userEntry == 12 && userEntry == 13)` … **False** — impossible.
2. `if (userEntry == 20 || highestScore >= 70)` … **True** — either condition works.
3. `if (userEntry != 99 && userEntry != 100)` … **True** — accept anything except 99 or 100.

[↩ Back to TOC](#table-of-contents)

---

## Decision-Making Issues in GUI Programs

Same decision tools (`if`, `if…else`, `switch`) inside event handlers. GUI apps are **event-driven**: the user’s click determines which method runs—often eliminating some explicit branching. Buttons also constrain input, reducing invalid entries that text boxes might allow.

### Two Truths & A Lie — GUI Decisions

1. Event-driven programs can use `if`, `if…else`, and `switch`. **True**.
2. They often require **fewer** coded decisions than console programs. **True** (events handle routing).
3. They usually contain **more** coded decisions. **False**.

[↩ Back to TOC](#table-of-contents)

---

## Chapter 4 Summary

* **Plan first** with **pseudocode** or **flowcharts** (sequence vs decision structures).
* Use `if` for **single** alternative; `if-else` for **dual** alternatives; **brace** multi-line blocks.
* Combine conditions with `&&` and `||`; remember **precedence** (`&&` before `||`) and **short-circuiting**.
* Use `switch` for many **exact** matches on **one** expression; remember **no fall-through**.
* The **conditional operator** `?:` embeds tiny `if-else` decisions in expressions.
* The **NOT** operator `!` negates conditions; **De Morgan’s Laws** help flip grouped logic.
* Avoid classic pitfalls: `=` vs `==`, stray semicolons, missing braces, impossible conditions.
* In GUIs, events often replace coded branching.

[↩ Back to TOC](#table-of-contents)

---

## Definitions (bold terms)

* **sequence structure** — A linear flow of steps with **no** branching; each statement executes unconditionally in order.
* **if statement** — A decision that executes its following statement/block **only if** its Boolean condition is `true`.
* **block** — A group of one or more statements wrapped in `{}` that execute together under the same control flow.
* **control statement** — A statement (e.g., `if`, `else`, `switch`) that directs the program’s flow based on conditions.
* **conditional AND operator** — `&&`; a compound Boolean operator that is `true` only when **both** operands are `true`. Supports **short-circuit** evaluation.
* **conditional OR operator** — `||`; a compound Boolean operator that is `true` when **either** operand is `true`. Supports **short-circuit** evaluation.
* **short-circuit evaluation** — Skipping evaluation of the right-hand side when the left-hand side already determines the result (`&&` with `false`, `||` with `true`).
* **switch** — A multi-way selection statement that compares one expression to many **exact** matches (cases).
* **case label** — A `case <value>:` marker inside a `switch` that matches a specific value of the switch expression.
* **default** — The optional `default:` label in a `switch` that runs when no `case` matches.
* **conditional operator** — The ternary `?:` operator that selects between two expressions based on a Boolean test.
* **NOT operator** — `!`; inverts a Boolean expression (`true` ↔ `false`).
* **range check** — Testing whether a value lies within certain boundaries (e.g., `x >= low && x <= high`).

[↩ Back to TOC](#table-of-contents)

---

### Bonus WOW (mental model)

* Think of `&&` as **gatekeepers in series**: all gates must be open.
* Think of `||` as **parallel doors**: any open door lets you through.
* `!` flips the sign on the whole sentence; **De Morgan** tells you how to flip the punctuation inside too.

Want me to add a **one-page cheat sheet** (operators, precedence, patterns, pitfalls) at the end for rapid review?
