

# Chapter 6 – Using Arrays

## Table of Contents

* [Introduction](#introduction)
* [Declaring an Array and Assigning Values](#declaring-an-array-and-assigning-values)
* [Declaring an Array](#declaring-an-array)
* [Creating Arrays](#creating-arrays)
* [Array Subscripts](#array-subscripts)
* [Accessing and Assigning Values](#accessing-and-assigning-values)
* [Initializing an Array](#initializing-an-array)
* [Arrays and Strings](#arrays-and-strings)
* [Accessing Array Elements](#accessing-array-elements)
* [Using the `Length` Property](#using-the-length-property)
* [Using `foreach`](#using-foreach)
* [Searching an Array Using a Loop](#searching-an-array-using-a-loop)
* [Using a `for` Loop to Search an Array](#using-a-for-loop-to-search-an-array)
* [Using a `while` Loop to Search an Array](#using-a-while-loop-to-search-an-array)
* [Searching an Array for a Range Match](#searching-an-array-for-a-range-match)
* [Using the `BinarySearch()`, `Sort()`, and `Reverse()` Methods](#using-the-binarysearch-sort-and-reverse-methods)
* [Using Multidimensional Arrays](#using-multidimensional-arrays)
* [Using Jagged Arrays](#using-jagged-arrays)
* [Array Issues in GUI Programs](#array-issues-in-gui-programs)
* [Chapter Summary](#chapter-summary)
* [Syntax Tracker](#syntax-tracker)
* [Cross-Reference Map](#cross-reference-map)
* [Program Checklist](#program-checklist)
* [Common Pitfalls](#common-pitfalls)
* [Error Fix Notes](#error-fix-notes)
* [Mini Cheat Card](#mini-cheat-card)

---










## Introduction

Upon completion of this chapter, you will be able to:

* Declare an array and assign values to array elements
* Access array elements
* Search an array using a loop
* Use the `BinarySearch()`, `Sort()`, and `Reverse()` methods
* Use multidimensional arrays
* Appreciate array issues in GUI programs

Storing values in variables provides programs with flexibility;` a program that uses variables to replace constants can manipulate different values` each time it executes.

When you add loops to your programs, the same variable can hold different values during successive cycles through the loop within the same program execution.

Learning to use the data structure known as an `**array** offers further flexibility`. Arrays allow you to `store multiple values in adjacent memory locations` and `access them` by _varying a value that indicates_ which of the stored values to use.

In this chapter, you will learn to create and manage **C# arrays**.

**Simplified Recap**: Variables hold one item; loops reuse them; arrays let you keep entire collections at once.

[🔝 Back to TOC](#table-of-contents)

---





## Declaring an Array and Assigning Values

Sometimes, storing just one value in memory at a time isn’t adequate. For example, a sales manager supervises 20 employees and wants to determine whether each employee has produced sales above or below the average.

If you enter each employee’s sales value into a separate variable, you won’t know the average until you have entered all 20 values. Then, you would need 20 prompts, 20 inputs, 20 separate variables, and 20 addition statements.

This technique is _awkward and unwieldy_, and if the number of employees grows to 30, 40, or 10,000, the program logic becomes unworkable.

You might think of a different solution: You could create a program that prompts for a single employee’s sales, input the sales, then reuse the variable name in the loop 20 times. However, each time you enter a new input value, the old one is lost, and the variable holds only the last input value.

> When you reuse a single variable inside a loop, the variable doesn't remember previous values. It only keeps the most recent one. That means that by the time you have gone through with all customers, you only have access to the last customers data. While all the earlier values are lost.

The best solution is to create an array.

An **`array`** is a `list of data items` that all have the `same data type` and the `same name`. Each object in an array is called an **array element**. You distinguish array elements from one another with a **subscript**, or index, an integer contained within square brackets that follows the array name.

**Simplified Recap**: Without arrays, you drown in variables. Arrays are like labeled lockers: one name, many compartments, each with a number.

[🔝 Back to TOC](#table-of-contents)

---





## Declaring an Array

You declare an array variable using a data type, a set of square brackets, and an identifier.To declare an array of `double` values to `hold sales values` for salespeople:

```csharp
double[] sales;
```

⚠️ In C++ or Java, you might also write:

```csharp
double sales[];
```

But in C#, this is illegal.

When you name arrays, you should use identifiers that are **plural**, such as `sales`, or that contain a group-indicating suffix, such as `salesList`, `salesTable`, or `salesArray`.

**Simplified Recap**: Always brackets first in C#. Think “type[] name;” not the other way around.

[🔝 Back to TOC](#table-of-contents)

---





## Creating Arrays

After you declare an array variable, you still need to create the actual array since declaring an array variable and creating an array are two separate tasks.

Example (two statements):

```csharp
double[] sales;
sales = new double[20];
```

Example (single statement):

```csharp
double[] sales = new double[20];
```

The keyword `new` is an **operator** that creates an array of 20 separate `double` values.

You can reassign arrays later:

```csharp
int[] myArray;
myArray = new int[5];
myArray = new int[100];
```

Each time you reassign, a new array is created in memory. All values reset to their **default values** for that type.

**Simplified Recap**: Declaring just says “there will be an array.” `new` actually builds it in memory. Rebuilding clears all contents.

[🔝 Back to TOC](#table-of-contents)

---





## Array Subscripts
> When you instantiate an array, you cannot choose its location in memory any more than you can choose the location of any other variable. However, you do know that after the first array element, the subsequent elements will follow. Because a double takes eight bites of storage, each element of double array is stored in succession in an address that is 8 bytes higher than the previous one. 

An array subscript must be an integer. Example:

```csharp
array[x + y]
```

(where `x` and `y` are integers).

Array elements in C# are **zero-based**. That means:

* The first element has index `0`.
* The last element in a 20-element array has index `19`.

Accessing `array[20]` in that case produces an error.

**Simplified Recap**: Indexes start at zero. Always remember: last index = `Length - 1`.

[🔝 Back to TOC](#table-of-contents)

---





## Accessing and Assigning Values

Example of assigning:

```csharp
sales[0] = 2100.00;
```

Example of outputting:

```csharp
WriteLine(sales[19]); // last element of a 20-element array
```

**Simplified Recap**: Brackets are doors. You can push data in or pull it out using the right numbered key.

[🔝 Back to TOC](#table-of-contents)





---

## Initializing an Array

In C#, arrays are objects — instances of `System.Array`.

Default values:

* Numeric → `0`
* Character → `\u0000`
* Boolean → `false`

Examples:

```csharp
int[] myScores = new int[5] {100, 76, 88, 100, 90}; // explicit initialization
int[] myScores = new int[] {100, 76, 88, 100, 90};
int[] myScores = {100, 76, 88, 100, 90};
 // implicit initialization
```

⚠️ If you specify both a size and an initializer list, the size `must` equal the number of items.(explicit)

**Simplified Recap**: By default, arrays fill with zeros/false/null. Use `{}` to preload values neatly.

[🔝 Back to TOC](#table-of-contents)

---






## Arrays and Strings

An array of characters can become a string:

```csharp
char[] arrayOfLetters = {'h','e','l','l','o'};
string word = new string(arrayOfLetters);
```

Strings act like arrays when reading:

```csharp
string greeting = "Hello";
char firstChar = greeting[0]; // 'H'
```

But strings are not arrays — you cannot assign new characters directly with indexing.

**Simplified Recap**: Strings let you peek inside like arrays, but you can’t rearrange their guts this way.

[🔝 Back to TOC](#table-of-contents)

---





## Accessing Array Elements

If you declare an array of integers:

```csharp
int[] myScores = {100, 76, 88, 100, 90};
```

You might want to increase each element by 3. You could do it manually:

```csharp
myScores[0] += 3;
myScores[1] += 3;
myScores[2] += 3;
myScores[3] += 3;
myScores[4] += 3;
```

But it’s better to use a loop.

**Figure 6-2: Increasing array values with `while` loop**

```csharp
int sub = 0;
while(sub < 5)
{
    myScores[sub] += 3;
    ++sub;
}
```

**Figure 6-3: Increasing array values with `for` loop**

```csharp
for(int sub = 0; sub < 5; ++sub)
    myScores[sub] += 3;
```

**Simplified Recap**: Loops unlock arrays’ real power — one short routine can process every slot.

[🔝 Back to TOC](#table-of-contents)

---






## Using the `Length` Property

Example with hardcoding problem:

```csharp
int[] myScores = {100, 75, 88, 100, 90};
for(int sub = 0; sub < 5; ++sub)
    WriteLine("{0}", myScores[sub]);
```

If the array size changes, this code breaks. Better:
> If you hardcode a number in a for loop (like i < 5), you must manually update it everywhere if the array size changes, which risks errors. Using .Length is a safeguard—it automatically adjusts to however many “lockers” (elements) the array currently has.

**Figure 6-4: Using `Length`**

```csharp
int[] myScores = {100, 76, 88, 100, 90};
WriteLine("Array size is {0}", myScores.Length);

for(int x = 0; x < myScores.Length; ++x)
    WriteLine(myScores[x]);
```
An array's **Length** is a `Read-Only` property--aproperty you can accesss, but o which you cannot assign a new value. It is capitalized and the convertion with all C# identifiers.

**Simplified Recap**: `Length` adapts with the array. It’s safer than guessing or hardcoding numbers.

[🔝 Back to TOC](#table-of-contents)




---

## Using `foreach`

### Instead of `_for_`, use `foreach`:
You can easily navigate through arrays using a for or while loop that varies a subscript from 0 through `Array.Length - 1`. It also supports 'foreach' statement that you can use to cycle through every array element `without using a subscript`. With the 'foreach' statements, you provide a temporary `iteration variable` that automatically holds each array value in turn.

**Figure 6-5: `foreach` example**

```csharp
double[] payRates = {12.00, 17.35, 21.12, 27.45, 32.23};

foreach(double money in payRates)
    WriteLine("{0}", money.ToString("C"));
```

This prints all pay rates in currency format.

> The variable money is declared as a double within the foreach statements. During the execution of a loop, money holds each pay rates element value in turn. First payRates [0], then payRates [1], and so on. As a simple variable, `money does not require a subscript`, making it easier to work with.


### When to use:**IMPORTANT**!

- You typically use it only when you want to access `every` array element. To access only `selected array elements you must manipulate subscripts` using some other technique. For example using a for loop or a while loop.

- This type of iteration variable is read only. That is, you can access it, but you cannot assign a value to it. If you want to assign a value to array elements, you must use a different type of loop.

Arrays can hold any data type (int, double, string, etc.), but the index you use to access elements must be an integer. In the example, prices is correctly an array of doubles, but using a double variable as the loop counter (pr) made the subscript invalid.
example: 
```csharp
// indexes cannot hold values like 2.5; that index does not exist
for(double pr = 0; pr < 8; ++pr)// must be an int
    prices[pr] -= 2;
```
[example](\scripts\CreatingandUsingArrays.cs)
**Simplified Recap**: 

`foreach` is a shortcut to read every item without dealing with indexes.

[🔝 Back to TOC](#table-of-contents)

---






## Searching an Array Using a Loop


When valid numbers are sequential (like 101–110):

```csharp
if(itemOrdered >= 101 && itemOrdered <= 110)
    isValidItem = true;
```

If they’re not sequential (like 101, 108, 201…):

```csharp
if(itemOrdered == 101)
    isValidItem = true;
else if(itemOrdered == 108)
    isValidItem = true;
else if(itemOrdered == 201)
    isValidItem = true;
```

This becomes inefficient. Better: store valid numbers in an array:

```csharp
int[] validValues = {101, 108, 201, 213, 266, 304, 311, 409, 411, 412};
```

Now you can loop through values and check.

**Simplified Recap**: Instead of endless `if` ladders, put valid values into an array and search with a loop.

---

## `static` vs `readonly` with Arrays

**Arrays are reference types.**
A variable holds a *reference* (pointer) to a row of lockers in memory.

---

### `static`

* Belongs to the **class**, not to an object.
* You don’t need to create an instance (`new`) to use it.
* Does **not** make the array immutable.

```csharp
class Demo
{
    public static int[] values = { 1, 2, 3 };
}

Console.WriteLine(Demo.values[0]); // ✅ no object needed
```

---

#### `readonly`

* Protects the **reference**, not the contents.
* Once initialized, you cannot make the variable point to a new array.
* You *can* still change the elements inside the array.

```csharp
class Demo
{
    public readonly int[] values = { 1, 2, 3 };

    public Demo()
    {
        // values = new int[5];  ❌ not allowed
        values[0] = 99;         // ✅ contents can change
    }
}
```

---

#### `static readonly`

* Shared by the class (like `static`).
* Reference cannot be reassigned (like `readonly`).
* Ideal for “constant” arrays such as lookup tables.

```csharp
class Demo
{
    public static readonly int[] ValidValues = { 101, 108, 201, 213 };
}
```

Access:

```csharp
Console.WriteLine(Demo.ValidValues[0]); // ✅
```

---

### Key Takeaways

* **Array size is fixed** once created. You can’t resize, only reassign to a new array.
* **Without `readonly`**: you can reassign the variable to a new array → the old array remains in memory until garbage collected.
* **With `readonly`**: the variable is locked to the original array, but you can still edit its elements.
* **`static`**: ties the array to the class, not objects.
* **`static readonly`**: safest option for arrays that represent constants.

[Rule of thumb for Static/Readonly](static_readonly)

[🔝 Back to TOC](#table-of-contents)

---






## Using a `for` Loop to Search an Array

When you store values in an array, you can compare each value in a `for` loop.

- A `for` loop replaces the long series of if statements.

**Figure 6-6: Searching with a `for` loop**

```csharp
for(int x = 0; x < validValues.Length; ++x)
    if(itemOrdered == validValues[x])
        isValidItem = true;
```

This is called a **sequential search** because each element is checked in order.

You can use **parallel arrays** to store related info. Example:

[Parallels explained](Parallels.md)

Whats more, if the array grows in size, the for loop would not have to change since we are using .Length; we would just have to redirect the new array in the for loop.

```csharp
double[] prices = {0.89, 1.23, 3.50, 0.69, 5.79, 3.19, 0.99, 0.89, 1.26, 8.00};
```
- Prices must appear in the same order as their corresponding item numbers in the validValues array.

Here, the `x`th `validValues` item matches the `x`th price.

**Figure 6-7: Find Price with `for` Loop**

```csharp
using System;
using static System.Console;

class FindPriceWithForLoop
{
    static void Main()
    {
        int[] validValues = {101, 108, 201, 213, 266, 304, 311, 409, 411, 412};
        double[] prices = {0.89, 1.23, 3.50, 0.69, 5.79, 3.19, 0.99, 0.89, 1.26, 8.00};

        int itemOrdered;
        double itemPrice = 0;
        bool isValidItem = false;

        Write("Please enter an item: ");
        itemOrdered = Convert.ToInt32(ReadLine());

        for(int x = 0; x < validValues.Length; ++x)
        {
            if(itemOrdered == validValues[x])
            {
                isValidItem = true;
                itemPrice = prices[x];
            }
        }

        if(isValidItem)
            WriteLine("Price is {0}", itemPrice);
        else
            WriteLine("Sorry – item not found");
    }
}
```

**Sample Output**

```
Please enter an item: 266
Price is 5.79
```

```
Please enter an item: 267
Sorry – item not found
```
> Again, the values need to match and align perfectly. If you make a change to one, you have to make the change to the other one as well. they work in parallel.

**Simplified Recap**: For-loop search = one-by-one check until match. Parallel arrays = two lists linked by position.

[🔝 Back to TOC](#table-of-contents)

---

[Improving Loop Efficiency](Efficientloops.md)



## Using a `while` Loop to Search an Array

You can also search with `while`.

**Figure 6-8: Find Price with `while` Loop**

```csharp
using System;
using static System.Console;

class FindPriceWithWhileLoop
{
    static void Main()
    {
        int x;
        string inputString;
        int itemOrdered;
        double itemPrice = 0;
        bool isValidItem = false;

        int[] validValues = {101, 108, 201, 213, 266, 304, 311, 409, 411, 412};
        double[] prices = {0.89, 1.23, 3.50, 0.69, 5.79, 3.19, 0.99, 0.89, 1.26, 8.00};

        Write("Enter item number: ");
        inputString = ReadLine();
        itemOrdered = Convert.ToInt32(inputString);

        x = 0;
        while(x < validValues.Length && itemOrdered != validValues[x])
            ++x;

        if(x != validValues.Length)
        {
            isValidItem = true;
            itemPrice = prices[x];
        }

        if(isValidItem)
            WriteLine("Item {0} sells for {1}", itemOrdered, itemPrice.ToString("C"));
        else
            WriteLine("No such item as {0}", itemOrdered);
    }
}
```

**Sample Output**

```
Enter item number 409
Item 409 sells for $0.89
```

```
Enter item number 410
No such item as 410
```

**Simplified Recap**: While-loop searches keep running until you either find the item or run out of list.

[🔝 Back to TOC](#table-of-contents)

---





## Searching an Array for a Range Match

Sometimes you check ranges instead of exact values.

**Discount Example:**

| Total Quantity Ordered | Discount % |
| ---------------------- | ---------- |
| 1–12                   | 0%         |
| 13–49                  | 10%        |
| 50–99                  | 14%        |
| 100–199                | 18%        |
| 200+                   | 20%        |

Instead of listing every possible number, use arrays of range limits.

**Figure 6-9: Range Match Search**

```csharp
int[] discountRangeLowLimits = {1, 13, 50, 100, 200};
double[] discounts = {0, 0.10, 0.14, 0.18, 0.20};
double customerDiscount;

int sub = discountRangeLowLimits.Length - 1;
while(sub >= 0 && numOfItems < discountRangeLowLimits[sub])
    --sub;

customerDiscount = discounts[sub];
```

**Simplified Recap**: Instead of checking each number, use ranges to assign categories like “10% discount.”

[🔝 Back to TOC](#table-of-contents)






---

## Using the `BinarySearch()`, `Sort()`, and `Reverse()` Methods

Arrays inherit from `System.Array`, which provides methods.

### BinarySearch

Finds a value in a `sorted array.`

**Figure 6-10: BinarySearch Example**

```csharp
using System;
using static System.Console;

class BinarySearchDemo
{
    static void Main()
    {
        int[] idNumbers = {122,167, 204, 219, 345};
        string entryString;
        int entryId;
        int x;

        Write("Enter an Employee ID: ");
        entryString = ReadLine();
        entryId = Convert.ToInt32(entryString);

        x = Array.BinarySearch(idNumbers, entryId);

        if(x < 0)
            WriteLine("ID {0} not found", entryId);
        else
            WriteLine("ID {0} found at position {1}", entryId, x);
}
```




**Sample Outputs**  
```

Enter an Employee ID 219
ID 219 found at position 3

```
```

Enter an Employee ID 220
ID 220 not found

````

⚠️ Limitations:  
* Must be sorted.  
* Finds only one match.  
* Cannot be used for ranges. 


### Sort  

Orders array elements ascending.  

**Figure 6-12: Sort Example**  

```csharp
string[] names = {"Olive", "Patty", "Richard", "Ned", "Mindy"};
Array.Sort(names);

for(int x = 0; x < names.Length; ++x)
    WriteLine(names[x]);
````

**Sample Output**

```
Mindy
Ned
Olive
Patty
Richard
```

### Reverse

Flips element order.

**Figure 6-14: Reverse Example**

```csharp
int[] numbers = {1, 2, 3, 4, 5};
Array.Reverse(numbers);

foreach(int n in numbers)
    WriteLine(n);
```

**Sample Output**

```
5
4
3
2
1
```

**Simplified Recap**: `BinarySearch` is the fast finder (sorted only), `Sort` puts things in order, `Reverse` flips order.

[🔝 Back to TOC](#table-of-contents)

---






## Using Multidimensional Arrays

A two-dimensional array acts like a table (rows × columns).

**Figure 6-15: Declaring 2D Array**

```csharp
double[,] sales = new double[3, 4];
```

Assigning:

```csharp
sales[0, 0] = 14.00;
```

Initializing:

```csharp
double[,] sales =
{
    {14.00, 15.00, 16.00, 17.00},
    {21.99, 34.55, 67.88, 31.99},
    {12.03, 55.55, 32.89, 1.17}
};
```

**Figure 6-19: Rent Finder Example (2D)**

```csharp
using System;
using static System.Console;

class RentFinder
{
    static void Main()
    {
        int[,] rents =
        {
            {400, 450, 510},
            {500, 560, 630},
            {625, 676, 740},
            {1000, 1250, 1600}
        };

        int floor;
        int bedrooms;
        string inputString;

        Write("Enter the floor on which you want to live: ");
        inputString = ReadLine();
        floor = Convert.ToInt32(inputString);

        Write("Enter the number of bedrooms you need: ");
        inputString = ReadLine();
        bedrooms = Convert.ToInt32(inputString);

        WriteLine("The rent is {0}", rents[floor, bedrooms]);
    }
}
```

**Sample Output**

```
Enter the floor on which you want to live: 2
Enter the number of bedrooms you need: 1
The rent is 676
```

### Three-Dimensional Arrays

```csharp
int[,,] rents =
{
    { {400, 500}, {450, 550}, {500, 550} },
    { {510, 610}, {710, 810}, {910, 1010} },
    { {525, 625}, {725, 825}, {925, 1025} },
    { {850, 950}, {1050, 1150}, {1250, 1350} }
};
```

Example:

```csharp
int rent = rents[3, 1, 0]; // 1050
```

**Simplified Recap**: 2D = tables, 3D = cubes. Use extra dimensions for structured data.

[🔝 Back to TOC](#table-of-contents)

---

## Using Jagged Arrays

Jagged arrays = arrays of arrays (uneven row sizes).

**Figure 6-22: Jagged Array Example**

```csharp
double[][] tickets = {
    new double[] {5.50, 6.75, 7.95},
    new double[] {5.00, 6.00},
    new double[] {7.50, 9.00, 9.95, 12.00}
};
```

**Figure 6-23: Jagged Array Output Example**

```
Row 0: 5.50, 6.75, 7.95
Row 1: 5.00, 6.00
Row 2: 7.50, 9.00, 9.95, 12.00
```

**Simplified Recap**: Jagged arrays let each row be different — perfect when some lists are longer than others.

[🔝 Back to TOC](#table-of-contents)

---

## Array Issues in GUI Programs

If you declare arrays inside an event method, they reset each time. Declare them outside to persist values across clicks.

**Figure 6-24: GUI Array Example**

```csharp
int[] counts = new int[4]; // Declare outside

private void button1_Click(object sender, EventArgs e)
{
    counts[0]++;
    MessageBox.Show("Count is " + counts[0]);
}
```

If declared inside the button click, `counts` resets to zero every time.

**Simplified Recap**: GUI apps need arrays declared outside methods so values survive button clicks.

[🔝 Back to TOC](#table-of-contents)

---

## Chapter Summary

* Arrays store multiple same-type values.
* Elements are accessed by zero-based subscripts.
* Loops process arrays efficiently.
* Use `.Length` for size.
* `foreach` loops are read-only iterators.
* Sequential search = one-by-one.
* `BinarySearch()` requires sorted arrays.
* `Sort()` and `Reverse()` reorder arrays.
* Multidimensional arrays = tables/cubes.
* Jagged arrays = uneven row lengths.
* In GUI apps, declare arrays outside methods to keep data.

**Simplified Recap**: Arrays turn messy piles of variables into organized containers. Loops, searches, and built-in tools let you manage them powerfully.

[🔝 Back to TOC](#table-of-contents)

---

## Syntax Tracker

* `type[] name;` – declare an array
* `new type[size]` – create an array
* `array[index]` – access element
* `array.Length` – array size
* `foreach(type var in array)` – read-only loop
* `Array.BinarySearch(array, value)`
* `Array.Sort(array)`
* `Array.Reverse(array)`
* `[,]` – multidimensional arrays
* `[][]` – jagged arrays

[🔝 Back to TOC](#table-of-contents)

---

## Cross-Reference Map

* Arrays build on loops from Chapter 5.
* Array search logic relates to Decision Making from Chapter 4.
* Range matching parallels `switch` statements.
* GUI persistence ties back to event-driven programming.

[🔝 Back to TOC](#table-of-contents)

---

## Program Checklist

By the end of this chapter, you should be able to code:

* Average finder using arrays.
* Sequential search with a `for` loop.
* Price lookup with **parallel arrays**.
* Discount calculator with range arrays.
* Demonstration of `Array.Sort()` and `Array.Reverse()`.
* Rent finder using **2D arrays**.
* Ticket pricing system with **jagged arrays**.
* GUI counter with arrays declared outside methods.

[🔝 Back to TOC](#table-of-contents)

---

## Common Pitfalls

* Forgetting arrays are **zero-based** → `IndexOutOfRangeException`.
* Hardcoding size instead of using `.Length`.
* Trying to modify strings directly with indexing.
* Confusing jagged arrays with multidimensional arrays.
* Declaring arrays inside event handlers → resets on every click.

[🔝 Back to TOC](#table-of-contents)

---

## Error Fix Notes

* **Error: CS0029 Cannot implicitly convert type**
  *Fix:* Make sure array type and variable type match.

* **Error: CS1002 ; expected**
  *Fix:* Add a missing semicolon.

* **Error: IndexOutOfRangeException**
  *Fix:* Keep index values between `0` and `Length - 1`.

* **Error: CS0176 Member cannot be accessed with an instance reference**
  *Fix:* Call methods like `Array.Sort()` or `Array.BinarySearch()` on the class, not the array instance.

[🔝 Back to TOC](#table-of-contents)

---

## Mini Cheat Card

```csharp
// Declare and create
int[] numbers = new int[10];

// Initialize
int[] scores = {100, 90, 80};

// Access
scores[0] = 95;

// Length
int size = scores.Length;

// foreach
foreach(int n in scores) Console.WriteLine(n);

// Binary search
int pos = Array.BinarySearch(scores, 90);

// Sort and Reverse
Array.Sort(scores);
Array.Reverse(scores);

// 2D array
int[,] matrix = new int[3,3];

// Jagged array
int[][] jagged = new int[2][];
jagged[0] = new int[3];
jagged[1] = new int[5];
```

[🔝 Back to TOC](#table-of-contents)

