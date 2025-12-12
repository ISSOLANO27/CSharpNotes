# Chapter 5 — Looping (C#)

*A working manual with syntax tracker, cross-references, pitfalls, and practice targets.*

---

## Table of Contents

* [Syntax Inventory (Quick Scan)](#syntax-inventory-quick-scan)
* [5.1 `while` — Entry-Controlled Loop](#51-while--entrycontrolled-loop)
* [5.2 `for` — Counted/Definite Loop](#52-for--counteddefinite-loop)
* [5.3 `do` — Posttest/At-Least-Once Loop](#53-do--posttestatleastonce-loop)
* [5.4 Nested Loops (Deep Dive)](#54-nested-loops-deep-dive)
* [5.5 Accumulating Totals (Running Sums)](#55-accumulating-totals-running-sums)
* [5.6 Improving Loop Performance](#56-improving-loop-performance)
* [5.7 Looping Issues in GUI Programs](#57-looping-issues-in-gui-programs)
* [Chapter Summary (Clean bullets)](#chapter-summary-clean-bullets)
* [Key Terms (Practical definitions)](#key-terms-practical-definitions)
* [Common Pitfalls](#common-pitfalls)
* [Program Checklist — What you should be able to build](#program-checklist--what-you-should-be-able-to-build)
* [Cross-Reference Map](#crossreference-map)
* [Key Term Lifecycle Map](#key-term-lifecycle-map)
* [Appendix: Measuring & Monitoring](#appendix-measuring--monitoring)

---

## Syntax Inventory (Quick Scan)

```csharp
// while: pretest loop
while (BooleanExpression)
{
    // body
}

// for: init ; test ; update  (pretest loop)
for (init; test; update)
{
    // body
}

// do: posttest loop (always runs body at least once)
do
{
    // body
} while (BooleanExpression);

// counting helpers
i = i + 1;   i += 1;   ++i;   i--;   i -= step;

// accumulator pattern
total = 0;
while (keepGoing) total += value;

// sentinel example
while (input != 0) { /* ... */ }
```

**New operators/classes used this chapter:** `++i`, `i++`, `+=`, `System.Diagnostics.Stopwatch`.

[Back to TOC](#table-of-contents)

---

## 5.1 `while` — Entry-Controlled Loop

**Idea.** Test first; run body while the condition is `true`. Each repetition is an *iteration*.
**Pattern.**

```csharp
initialize controlVar;
while (conditionUsing(controlVar))
{
    // work
    update controlVar;
}
```

**Infinite loop note.** “Runs as long as memory/hardware allow” = it will continue until you stop it (e.g., Ctrl+C), the OS kills it, or the process/machine fails. If your body allocates growing data, RAM will eventually run out.

**Braces matter.** Without `{}`, only the very next statement is in the loop:

```csharp
while (number < LIMIT)
    WriteLine("Hello");  // in loop
number = number + 1;     // OUTSIDE → number never changes → infinite loop
```

**Bank balance (excerpt).**

```csharp
double bankBal = 1000;               // numeric
const double INT_RATE = 0.04;

while (response == 'Y')
{
    WriteLine("Bank balance is {0}", bankBal.ToString("C")); // string *display* only
    bankBal = bankBal + bankBal * INT_RATE;                  // numeric update
    // reprompt...
}
```

* `bankBal.ToString("C")` formats a **copy** for display. `bankBal` stays `double`.

**Q\&A (from study):**

* *Why did it compile?* `bankBal` is declared/initialized before use.
* *How do I watch impact?* Use Task Manager → **Performance** tab (CPU/RAM).
  [Back to TOC](#table-of-contents)

---

## 5.2 `for` — Counted/Definite Loop

**Use when** you know or control the number of iterations.
**Pattern.**

```csharp
for (int i = 1; i <= LIMIT; ++i) { /* body */ }
```

* `init` runs once, `test` runs each iteration before the body, `update` runs after the body.

**Equivalence with `while`.**

```csharp
int x = 1;
while (x <= LIMIT) { /* ... */ ++x; }

for (int x2 = 1; x2 <= LIMIT; ++x2) { /* ... */ }
```

**Scope.** Variables declared in the `for` header (e.g., `int k = 0`) are **in scope** only inside the loop.

**Multiple parts.**

```csharp
for (g = 0, h = 1; g < 3 && h > 0; ++g, --h) { /* ... */ }
```

**Braces reminder.**

```csharp
for (int i = 0; i < 4; ++i)
    WriteLine("Hello");
WriteLine("Goodbye"); // runs once after loop
```

[Back to TOC](#table-of-contents)

---

## 5.3 `do` — Posttest/At-Least-Once Loop

**Use when** the body must run **once before** you check.
**Pattern.**

```csharp
do { /* body */ } while (condition);
```

**Common uses.** Menus, input validation, “show once then ask to continue”, one-turn simulations.

**Equivalent without `do`.** “Unconditional first run + `while`”:

```csharp
// first run
/* body */
while (condition) { /* body again */ }
```

`do` avoids duplicating the body.

[Back to TOC](#table-of-contents)

---

## 5.4 Nested Loops (Deep Dive)

**Rule.** Loops can be nested, never overlapped: the inner loop is **entirely contained** within the outer loop’s braces.

**When to nest.** If your spec has *two “each”s*:
“for **each rate**, for **each year** …” → nested loop.

**Two canonical orders (same 50 combinations, different grouping):**

```csharp
// A) Group by rate
for (double rate = 0.04; rate <= 0.08; rate += 0.02) {
    double bal = 1000;                // reset per *rate* block
    for (int year = 1; year <= 5; ++year) {
        bal += bal * rate;
        WriteLine($"rate={rate:P0}, year={year}, bal={bal:C}");
    }
}

// B) Group by year
double baseStart = 1000;
for (int year = 1; year <= 5; ++year) {
    for (double rate = 0.04; rate <= 0.08; rate += 0.02) {
        double bal = baseStart;       // reset per *year* row
        for (int y = 1; y <= year; ++y) bal += bal * rate;
        WriteLine($"year={year}, rate={rate:P0}, bal={bal:C}");
    }
}
```

* **Reset location** controls what each block/row compares:
  A) compare *years within a rate*, B) compare *rates within a year*.

**Mental model.** Write a 2D grid (rows = outer, columns = inner). Trace visit order to predict output grouping.

[Back to TOC](#table-of-contents)

---

## 5.5 Accumulating Totals (Running Sums)

**Accumulator pattern.**

```csharp
double total = 0;          // identity for sum
const double QUIT = 0;

double purchase;           // assigned before use via input
// first read...
while (purchase != QUIT)   // sentinel
{
    total += purchase;
    // next read...
}
WriteLine($"Your total is {total:C}");
```

* Initialize accumulators to the **identity** (`0` for sums, `1` for products, `""` for strings).
* Sentinel value cleanly ends indefinite loops.

[Back to TOC](#table-of-contents)

---

## 5.6 Improving Loop Performance

> Optimize only where it matters; prefer clarity. When it does matter:

**A. Remove unnecessary work**

```csharp
// Before: recompute constant sum each time
while (x < a + b) { /* ... */ }

// After: hoist invariant
int sum = a + b;
while (x < sum) { /* ... */ }
```

**B. Short-circuit order**

* `if (likelyTrue || other)` → put the more often **true** test first for `||`.
* `if (likelyFalse && other)` → put the more often **false** test first for `&&`.

**C. Loop fusion** (only when independent)

```csharp
for (int i = 0; i < N; ++i) { method1(); method2(); }
```

**D. Prefix increment for counters**

```csharp
for (int i = 0; i < N; ++i) { /* ... */ }  // `++i` is a micro-win vs `i++`
```

**E. Don’t redeclare temps inside tight loops**

```csharp
int temp;                     // outside is cheaper than re-create each iteration
while (x < LIMIT) {
    temp = a + b;
    // ...
}
```

**F. Measure it**

```csharp
using System.Diagnostics;
var sw = Stopwatch.StartNew();
// code under test
sw.Stop();
WriteLine($"Time used: {sw.Elapsed.TotalMilliseconds} ms");
```

[Back to TOC](#table-of-contents)

---

## 5.7 Looping Issues in GUI Programs

* **Console apps**: linear flow; your loop “owns” the thread.
* **GUI apps** (WinForms/WPF/MAUI): event-driven; the UI thread runs a **message loop**. A long, blocking loop on the UI thread freezes the window (Not Responding).
* Typical mitigations:

  * Disable/enable buttons around long operations.
  * Use timers or async/await/background workers to keep UI responsive.
  * Avoid tight polling loops on the UI thread.

**Student note (context).** Our course skipped the GUI chapter; these topics assume Chapter 3 (controls, events, threading basics). This section is a preview; we’ll cross-link when GUI content is officially covered.

[Back to TOC](#table-of-contents)

---

## Chapter Summary (Clean bullets)

* `while`: pretest; loop while condition is `true`. Body = single statement or `{ }`.
* `for`: concise counted loop; `init ; test ; update` in one header.
* `do`: posttest; body runs at least once, then condition checked.
* Loops can be nested in any combination; inner loop fully contained in outer (no overlap).
* Totals are often accumulated incrementally in loops (running sums).
* Performance wins: remove redundant work, exploit short-circuit order, consider loop fusion, prefer prefix increment, compare to zero where sensible, measure with `Stopwatch`.
* Same loop concepts apply in console and GUI; GUI is event-driven, so avoid blocking the UI thread.

[Back to TOC](#table-of-contents)

---

## Key Terms (Practical definitions)

* **loop / iteration / loop body** — repetition structure / one pass / the statements that repeat.
* **`while` loop** — pretest loop.
* **infinite loop** — condition never becomes false; runs until stopped externally.
* **loop control variable** — value that the condition reads and the body updates.
* **empty body** — a loop with nothing to do (often from a stray semicolon).
* **incrementing / decrementing** — increasing/decreasing the control variable.
* **definite (counted) loop** — known number of iterations.
* **indefinite loop** — repeats until a condition/sentinel ends it.
* **sentinel value** — special input that ends the loop (e.g., `0`, `'N'`).
* **step value** — amount the control variable changes per iteration.
* **scope / out of scope** — where a variable is accessible / no longer accessible.
* **`do` loop** — posttest loop (at least one iteration).
* **pretest / posttest** — condition checked before / after the body.
* **inner loop / outer loop** — nested loop inside / surrounding loop.
* **accumulated** — built up piece by piece (e.g., running total).
* **garbage** — uninitialized local value (C# blocks use).
* **loop fusion** — combine two loops with same bounds into one.

[Back to TOC](#table-of-contents)

---

## Common Pitfalls

* Omitting `{ }` so only the first statement is in the loop.
* Placing a stray `;` after `while`/`for` → empty loop.
* Forgetting to update the control variable → infinite loop.
* Using variables before assignment (compiler error) or assuming a default value.
* Declaring a control variable in a `for` header and expecting to use it **after** the loop (out of scope).
* Blocking the UI thread with long loops in GUI apps.
* Recomputing invariants (`a + b`) every iteration when they never change.
* Relying on `i++` vs `++i` semantics inside expressions; prefer stand-alone increments in loop headers.

[Back to TOC](#table-of-contents)

---

## Program Checklist — What you should be able to build

* Print 1..N with `while`, `for`, and `do` variants.
* Input-validate with a `do` loop (menu or constrained numeric entry).
* Running-total cashier: sentinel-controlled sum with currency formatting.
* Multiplication table (nested loops) with row/column headers.
* Interest growth simulator showing:

  * A) all years for each rate, and B) all rates for each year.
* Performance demo measuring two loop variants with `Stopwatch`.
* GUI-friendly loop (e.g., progress via timer or async task) that doesn’t freeze the UI.

[Back to TOC](#table-of-contents)

---

## Cross-Reference Map

* **Boolean expressions & short-circuiting** → Chapter 4 (used in all loop conditions).
* **Increment operators (`++i`, `i++`)** → Chapter 2 refresher; used heavily in counters.
* **Formatting (`ToString("C" | "P")`)** → Chapter 2 string formatting; used in outputs.
* **GUI events/message loop** → Chapter 3 (prereq for “Looping issues in GUI programs”).

[Back to TOC](#table-of-contents)

---

## Key Term Lifecycle Map

* **Loop control variable** → introduced as a counter → updated with `++`/`--` → scoped in `for` header → reset strategy in nested loops.
* **Accumulator** → starts at identity (`0`) → updated with `+=` → formatted for display → extended with sentinel control.
* **Sentinel value** → basic console stopping rule → later becomes GUI button/state signal.
* **Pretest/Posttest** → `while`/`for` vs `do` → impacts input-prompt placement and first-display logic.
* **Performance concerns** → harmless in tiny loops → meaningful inside nested or GUI-sensitive code → profiled with `Stopwatch`.

[Back to TOC](#table-of-contents)

---

## Appendix: Measuring & Monitoring

**Stopwatch template**

```csharp
using System.Diagnostics;

var sw = Stopwatch.StartNew();
// code to measure
sw.Stop();
Console.WriteLine($"Time used: {sw.Elapsed.TotalMilliseconds} ms");
```

**Watch CPU/RAM while looping (Windows)**

* `Ctrl` + `Shift` + `Esc` → **Task Manager** → **Performance** tab.
* **Details** tab: find `dotnet.exe` (Console C#) or your exe; watch Memory and CPU.

[Back to TOC](#table-of-contents)
