# Type Conversions

C# performs **automatic conversions** (also called **implicit conversions**) **when you pass an argument to a method, assign values between compatible types, or do arithmetic** involving mixed numeric types — *as long as there’s no risk of losing information*.

Let’s break it down clearly using what your figure shows.

---

### ⚙️ 1. What “automatic conversion” means

When you call a method and the type of the **argument** doesn’t exactly match the **parameter**, C# checks if it can *safely promote* the argument to that parameter type.

For example:

```csharp
private static void DisplaySalesTax(double saleAmount)
{
    Console.WriteLine($"Sales tax on {saleAmount} is {saleAmount * 0.08}");
}
```

If you call:

```csharp
DisplaySalesTax(25);   // 25 is an int
```

C# automatically converts the `int` value `25` into a `double` (`25.0`) before passing it to the method — because `int → double` is a **safe conversion** (no data loss).

---

### 🧠 2. When implicit conversions happen

Implicit conversions occur in three main situations:

#### (a) **When passing arguments to methods**

```csharp
void ShowDouble(double x) { Console.WriteLine(x); }

int value = 10;
ShowDouble(value);  // int → double automatically
```

C# promotes the `int` to `double` automatically.

#### (b) **When assigning values**

```csharp
int a = 5;
double b = a; // automatic conversion, int → double
```

#### (c) **When evaluating expressions**

```csharp
int x = 3;
float y = 2.5F;
double z = x + y; // int promoted to float, then to double
```

C# always converts “upward” in precision to avoid losing data.

---

### 📊 3. How the hierarchy works (your figure’s chart)

You can think of it like a ladder of **numeric widening conversions** —
C# automatically promotes smaller or less precise types to larger or more precise ones.

Example of the widening path:

`sbyte → short → int → long → float → double → decimal`

You can go *up* automatically, but not *down*.

---

### ❌ 4. When it doesn’t happen automatically

If the conversion could **lose data** or **cause overflow**, C# does **not** do it implicitly — you have to **cast it explicitly**.

Example:

```csharp
double big = 123.456;
int small = big;  // ❌ error: possible loss of data
int small = (int)big; // ✅ explicit cast, result = 123
```

---

### 💡 5. The key idea

> C# performs automatic conversions only when it’s safe and obvious what you mean.

So yes — in your image, the method:

```csharp
private static void DisplaySalesTax(double saleAmount)
```

can accept integers, floats, bytes, etc.,
because all of those can automatically be *promoted* to a `double`.

---

### 🔍 In one sentence

> **Automatic conversions in C# happen whenever you pass, assign, or combine numeric values in a way that preserves precision without risk — most commonly when passing arguments to methods with wider parameter types.**



Would you like me to show the reverse — what happens when you *can’t* convert automatically, and how to fix it with explicit casting?
