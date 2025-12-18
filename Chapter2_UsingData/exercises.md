
# Chapter 2 — Data Types, Arithmetic, and Input

## Exercises

---

## Programming Exercises

### 1. Numeric Expression Evaluation

Determine the numeric value of each of the following expressions as evaluated by the C# programming language.

```text
2 + 5 * 3
9 / 4 + 10
10 / 3
21 % 10
(5 – 1) * 3
37 / 5
64 % 8
5 + 2 * 4 – 3 * 4
3 * (2 + 5) / 5
28 % 5 – 2
19 / 2 / 2
28 / (2 + 4)
````

---

### 2. Boolean Expression Evaluation

Determine the value (`true` or `false`) of each Boolean expression.

```text
5 > 4
3 <= 3
2 + 4 > 5
6 == 7
2 + 4 <= 6
3 + 4 == 4 + 3
1 != 2
2 != 2
–5 == 7 – 2
3 + 9 <= 0
```

---

### 3. Selecting Appropriate Data Types

Choose the best C# data type for each scenario so that no memory storage is wasted.
For each item:

* Specify the data type
* Provide a typical value
* Explain why the type is appropriate

Scenarios:

* The number of years of school you have completed
* Your final grade in this class
* The population of China
* The number of passengers on an airline flight
* One player’s score in a Scrabble game
* The number of Electoral College votes received by a U.S. presidential candidate
* The number of days with below-freezing temperatures in a winter in Miami, Florida
* One team’s score in a Major League Baseball game

---

### 4. Double vs Decimal Range Test

Write a C# program named **`DoubleDecimalTest`** that:

* Declares one `double` variable and one `decimal` variable
* Assigns the same constant value to both variables
* Ensures the assignment to the `double` variable is valid
* Causes a compilation error for the `decimal` assignment due to range limitations

When the decimal assignment is commented out, the program should compile correctly.

---

### 5. Inches to Centimeters Conversion

Write a C# program named **`InchesToCentimeters`** that:

* Declares a named constant holding the value `2.54`
* Declares a variable representing a measurement in inches
* Displays the measurement in both inches and centimeters

Example output:

```text
3 inches is 7.62 centimeters
```

---

### 6. Inches to Centimeters (Interactive)

Convert the previous program into an interactive application named **`InchesToCentimetersInteractive`** that:

* Accepts the inches value from user input
* Displays the converted value in centimeters

---

### 7. Projected Raises

Write a C# program named **`ProjectedRaises`** that:

* Declares a named constant representing a 4% raise
* Declares variables representing the current salaries of three employees
* Displays each employee’s projected salary for next year

---

### 8. Projected Raises (Interactive)

Convert the **`ProjectedRaises`** program into an interactive application named **`ProjectedRaisesInteractive`** that:

* Accepts salary values from the user
* Displays projected salaries using the same 4% increase

---

### 9. Move Cost Estimator

Malcolm Movers charges:

* A base rate of $200
* $150 per hour
* $2 per mile

Write a program named **`MoveEstimator`** that:

* Prompts the user for estimated hours and miles
* Displays the total estimated moving cost

---

### 10. Hours and Minutes

Write a program named **`HoursAndMinutes`** that:

* Declares a variable representing minutes worked
* Converts and displays the value as hours and minutes

Example:

```text
197 minutes = 3 hours and 17 minutes
```

---

### 11. Eggs Calculation

Write a program named **`Eggs`** that:

* Declares four variables representing eggs laid by four chickens
* Sums the total number of eggs
* Displays the result in dozens and remaining eggs

Example:

```text
127 eggs = 10 dozen and 7 eggs
```

---

### 12. Eggs (Interactive)

Modify the **`Eggs`** program to create **`EggsInteractive`** that:

* Prompts the user for the number of eggs laid by each chicken

---

### 13. Make Change

Write a program named **`MakeChange`** that:

* Accepts a dollar amount
* Converts the amount into twenties, tens, fives, and ones

Example:

```text
$113 = 5 twenties, 1 ten, 0 fives, and 3 ones
```

---

### 14. Test Score Average

Write a program named **`TestsInteractive`** that:

* Prompts the user for eight test scores
* Displays the average to two decimal places

---

### 15. Fahrenheit to Celsius

Write a program named **`FahrenheitToCelsius`** that:

* Accepts a temperature in Fahrenheit from the user
* Converts it to Celsius using the formula:

```text
C = (F − 32) × 5 / 9
```

* Displays both values to one decimal place

---

### 16. Month Enumeration

Create an enumeration named **`Month`** that holds values for the months of the year, starting with `JANUARY = 1`.

Write a program named **`MonthNames`** that:

* Prompts the user for a month integer
* Converts the input to a `Month` value
* Displays the corresponding month name

---

### 17. Planet Enumeration

Create an enumeration named **`Planet`** that holds the eight planets in our solar system, from `MERCURY` through `NEPTUNE`.

Write a program named **`Planets`** that:

* Prompts the user for a numeric position
* Displays the name of the planet in that position

---

### 18. Pig Latin Converter

Write a program named **`PigLatin`** that:

* Accepts a word from the user
* Converts it to Pig Latin by:

  * Removing the first letter
  * Appending the first letter and `"ay"` to the end

Examples:

```text
dog → ogday
cat → atcay
```

---

## 19. Debugging Exercises

Each file in the `Chapter02` folder contains syntax and/or logical errors.
Fix each program and save it using the same filename preceded by `Fixed`.

Files:

* `DebugTwo1.cs`
* `DebugTwo2.cs`
* `DebugTwo3.cs`
* `DebugTwo4.cs`

Example:

```text
DebugTwo1.cs → FixedDebugTwo1.cs
```

---

## Case Problems

### 20. Greenville Revenue

Write a program named **`GreenvilleRevenue`** that:

* Prompts the user for the number of contestants from last year and this year
* Displays all input values
* Calculates expected revenue assuming a $25 entry fee per contestant
* Displays whether this year’s competition has more contestants than last year’s

---

### 21. Marshall’s Murals Revenue

Write a program named **`MarshallsRevenue`** that:

* Prompts the user for the number of interior and exterior murals scheduled
* Calculates expected revenue:

  * Interior murals cost $500 each
  * Exterior murals cost $750 each
* Displays total expected revenue
* Indicates whether more interior murals are scheduled than exterior murals

```
