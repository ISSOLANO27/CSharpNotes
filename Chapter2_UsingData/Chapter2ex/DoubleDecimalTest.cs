// DoubleDecimalTest.cs
// Chapter 2: numeric types, literals, ranges, and compile-time errors.
using System;
using static System.Console;

class DoubleDecimalTest
{
    static void Main()
    {
        // A gigantic constant value.
        // For double, scientific notation is allowed and the range is ~±1.7E308, so this is fine:
        double bigAsDouble = 1e300;   // ✅ legal for double

        WriteLine($"double ok: {bigAsDouble}");

        // For decimal, the max is ~±7.9228E28. To *prove* the limit, use a decimal literal (M)
        // that exceeds decimal.MaxValue by 1. This will cause a *compile-time* error if not commented.
        //
        // decimal tooBig = 79228162514264337593543950336M; // ❌ CS0031: value is outside range of 'decimal'
        //
        // Uncomment the line above to observe the compiler error. Then re-comment to build successfully.

        // Optional: the correct way to show a decimal limit without failing to compile.
        decimal nearMax = decimal.MaxValue; // built-in constant (Chapter 2: constants & types)
        WriteLine($"decimal max: {nearMax}"); // If we add even one, it will overflow at runtime.
    }
}
