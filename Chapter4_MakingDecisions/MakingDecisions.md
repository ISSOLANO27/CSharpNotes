# Introduction
Upon completion of this chapter, you will be able to:
- Undertand logic-planning tools and decifion making
- Make decisions using _if_ statements
- Make decisions using _if-else_ statements
- Use compound expressions in _if_ statements
- Make decisions using switch statements
- Use the connditional operator
- Use the NOT operator
- Avoid common errors when making decisions
- Appreciate decision-making issues in GUI programs

Computer programs are powerful because of their ability to make decisions. Programs that decide which travel route will offer the best weather conditions, which website will provide the closest match to search criteria, or which recommended medical treatment has the highest probability of success all rely on the program's decision making. In this chapter you will learn to make decisions in C# programs.

# Understanding Logic-Planning Tools and Decision Making


When computer programmers write programs, they rarely just sit down at a keyboard and begin typing. Programmers must plant complex portions of programs. Programmers often use pseudocode, a tool to help them plan a program's logic by writing plain English statements. Using pseudocode requires that you write down the logic of a given task in everyday language, and not the syntax used in a programming language. (You learned the difference between logic and syntax in chapter one) In fact, a task you write into the c....our house, for example one go West on In fact, a task you write into the code does not have to be computer related. If you ever have ever written a list of directions to your house, for example,
1. Go west on Algonquid Road,
2. turn left on Rosie Road
3. enter expresway heading east, and so on--this is pseudocode

A flow chart is similar to pseudocode, but you write the steps in diagram form as a series of shapes connected by arrows or flow lines.

 Some programmers use a variety of shapes to represent different tasks and their flowcharts. But you can draw simple flowcharts that express very complex situation using just triangles, diamonds and connecting flow lines. You can use a rectangle to represent any process or step and a diamond to represent any decision. Think about the pseudo code that would describe a driving directions to a friend house. Most likely the directions would be linear. Follow one after the other one and use all boxes. Each box containing a specific set of directions. Are flowing in the same direction.

 Notice how the actions illustrated in a flow chart and a pseudocode statements. The figure described. Illustrates a logical structure called a sequence structure, ones that follows another unconditionally. A **sequence structure** might contain any number of steps, but one task follows another one with no chance to branch away or skip a step.

 Sometimes logical steps do not follow in an unconditional sequence. Instead of some task, or it might not occur based on the outcome of some decisions. To represent a decision flow chart,'s creators use a diamond shape to hold a question, and they draw paths to alternate courses of action emerging from the corner of the diamond. A flow chart describes directions in which the execution of some steps depend on a decision. Figure 42 shows a decision structure, one that involves choosing between alternate courses of action based on a value. The illustration in Fortune describes the same direction but with a diamond shape With the text. Is the Expressway backed up? Which could be false or true.
 New. New.


 When reduced to their most basic form, all computer decisions are true or false decisions. This is because computer circuitry consists of millions of tiny switches that are either on or off, and the result of every decision sets 1 of these switches in memory. Value true and false are boolean values. Every computer decision results in a boolean value. For example, program code that you write never includes a question like what number did the user answer? Instead, the decisions might be that the user insert one, if not, did the user enter a 2, if not, did the user enter a 3 and so on.



 ### Two truths and a lie. Understanding logic, planning tools and decision making.


 1. A sequence structure has three or more alternate logical paths. False. In a sequence structure, one step follows another unconditionally.

 2. A decision structure involves choosing between alternate courses of action based on some value within the program. True

 3. When reduced to their most basic form, all computer decisions are yes or no decisions. True


 # Making decisions using the `if` statement


 The ``if`` and ``if-else`` statements are the two most commonly used decision making statements in C#. You use an **if statement** to make a single alternative decision. In other words, you can use the ``if`` statement to determine whether an action will occur. The ``if`` statement takes the following form.
 ```cs
 if (testedExpression)
    statement;
```
In this statement, tested expression represents any C sharp expression that can be evaluated as ``true`` or ``false``. And statement represents the action that will take place if the expression evaluates as `true`. You may place the ``if`` statements evaluated expression between parentheses. You can leave a space between the keyword `if` and the open in parentheses if you think that format is easier to read.

 Usable expressions in an if statement include boolean expressions such as `amount > 5` and `month == "May"` as well as the value of ``bool`` variables such as ``isvalidIDNumber``. If the expression evaluates as true, then the statement in the expression executes; otherwise it does not. Whether the expression evaluates as `true` or `false`, the program continues with the next statement following the complete `if` statement.

 You learned about boolean expressions and the bull data type in chapter two. Table 2 - four summarizes how comparison that operators are used. 

 In the chapter Introduction to Methods you will learn to write methods that return values. A method called that returns a boolean value also can be used as the tested expression in the if statements.

 In some programming language such as C++, _nonzero_ numbers evaluate as `true` and _zero_ evaluate as `false`. However, in C sharp, only boolean expressions evaluated as `true` and `false`.

 For example, the code segment written and diagrammed in Figure 4-3 displays A and B when `number` holds a value less than 5. But `number` is 5 or greater only B is displayed. When the tested boolean expression number < 5 is false, the statement that displace a never executes.


```cs
// Figure 4-3
if(number < 5) // one diamond; true will output A, B will output when false. A/B are in parallelograms
    WriteLine("A");
WriteLine("B");
```
Although you can create a meaningful flowchart using only rectangles, diamonds and flow lines, parallelograms have traditionally been used to represent input and output statements, so they are used in Figure 43 and in other figures in this chapter.

In the code and figure 4-3, Notice there is no; at the end of the line that contains if no less than 5. The statement does not end at that point; it ends after `WriteLine("A")`: If you incorrectly insert a; at the end of if`(number < 5)`, then the code means, "If `number` is less than 5, do nothing; then, no matter what the value of `number` is, display A." Figure 4-4 Shows the flow chart logic that matches the code when a; is incorrectly placed at the end of the if expression. A
 
Although it is customary and good style to indent any statement that executes when and `if` boolean expression evaluates as `true`, the C# compiler does not pay any attention to the indentation. Each of the following `if` statements display a when `number` is less than 5. The first shows an `if` statement written on a single line. The second shows an `if` statement on two lines but with no indentation. The 3rd uses conventional indentation. All three examples execute identically.
```cs
if(number < 5) WriteLine("A")
if(number < 5)
WriteLIne("A");
if(number < 5)
    WriteLine("A");
```
When you want to execute two or more statements conditionally, you place the statements within a block. A **block** is a collection of one or more statements contained within a pair of curly braces. For example, the code sewgment written in Figure 4-5 displays both C and D when number is less than five, and the displace neither when number is not less than five. The if expression that precedes the blog is the **control statement** for the decision structure.
```cs
// Figure 4-5

if(number < 5)
{
    WriteLine("C");
    WriteLine("D");
}
```
Indenting alone does not 'cause multiple statements to depend on the evaluation of a boolean expression following an `if` control statement. For multiple statements to depend on an `if`, they must be blocked with braces. For example. In 4-6 shows two statements that are indented below the `if` expression. When you glance at the code, it might first appear that both statements depend on the `if`. However, only the 1st one does as shown in the flow chart because the statements are not blocked.
```cs
// Figure 4-6

if(number < 5)
    WriteLine("C"); // without curly braces, only the first right light statement is dependent on this decision.
    WriteLine("D");

```
When you create a block using curly braces, you do not have to place multiple statements within it. It is perfectly legal to block a single statement. Blocking a single statement can be a useful technique to help prevent future errors because when the program later is modified to include multiple statements. That depend on the `if` the braces serve as a reminder to use a block, `creating a block that contains no statement also is legal` in C#, you usually do so only when starting to write a program, as reminded to yourself to add statements later.

In C sharp it is customary to align the blocks opening and closing braces. Some programmers prefer to place the opening brace on the same line as the `if` expression instead of giving the brace its own line. This style is called the _K & R style_, named for Brian Kernighan and Dennis Ritchie, who wrote the first book on the C programming language.

You can place any number of statements within the block, including other `if` statements. `If` the second `if` statement is the only statement that depend on the 1st, then no braces are required. Figure 4-7 shows the logic for a nested `if` statement in which one decision structure is contained within another. With a nested `if` statement, a second `if` boolean expression is **nested** only when the first `If`'s boolean expression evaluates as `true`.
```cs
// Figure 4-7

if(number < LOW)
    if(number < HIGH)
        WriteLine("{0}, is between {1} and {2}",
         number, LOW, HIGH);
```
Figure 4-8 Show the program that contains the logic in figure 4-7 When a user enters a number greater than 5, the first tested expression is `true`. In the `if` statement that tests whether the number is less than 10, executes. On the second tested expression also is `true`, the `WriteLine()` statement executes. If either the first or second tested expression is `false`, no output occurs. Figure 4-9 shows the output after the program is executed three times using three different input values. Notice that when the value input by the user is not between 5 and 10, this program produces no output message.
```cs
Figure 4-8

using System;
using static System.Console;
class NestedDecision
{
    static void Main()
    {
        const int HIGH = 10, LOW = 5;
        string numberString;
        int number;
        Write("Enter an integer ");
        numberString = Readline();
        number = Convert.ToInt32(numberString);
        if(number > LOW)
            if(number < HIGH)
                WriteLine("{} is between {} and {}", number, LOW, HIGH);
    }
}
```


## A Note on Equivalency Comparisons
Often programmers mistakenly use a single = rather than the double = When nesting for equivalency. For example, the expression `number = HIGH` does not compare `number` to `HIGH`. Instead, it attempts to assign the value `HIGH` to the variable `number`. When an assignment is used between the parentheses and the if statement, as in `if (number = HIGH)`, the. assignment is illegal and the program will not compile.

The only condition under which the assignment operator would work as part of the tested expression in an if statement is when the assignment is made to a bool variable. For example, suppose that a payroll program contains a pool variable named. `DoesEmployerHaveDependents`? And then uses the following statements?
```cs
if(DoesEmployerHaveDependents = numDependents > 0)
```
In this case `numDependents` would be compared to zero and the result `true` or `false`. Would be assigned to `DoesEmployerHaveDependents`? Then the decision would be made based on the assigned value. This is not recommended way to make a comparison because it looks confusing. If your intention was to assign a value to `DoesEmployerHaveDependents` and to make a decision based on the value, then your intentions would be clearer with the following code:
```cs
DoesEmployerHaveDependents = numDependents > 0;
if(DoesEmployerHaveDependents)
```
Notice the difference in the following statement that uses two equal signs within the parentheses in the `if` statement:
```cs

if(DoesEmployerHaveDependents == numDependents > 0)
```
This statement compares `DoesEmployerHaveDependents` to the result of comparing `numDependents` to 0, but does not change the value of `DoesEmployerHaveDependents`

One of the many advantages of using the Visual Studio IDE to write programs is that if you use an assignment operator in place of an equivalency operator in a boolean expression, your mistake will be flagged as an error immediately.

### Two truths and one lie. Making decisions using the `if` statements.



1. In C sharp you must place an if statements evaluated expression between parentheses. `True`
2. In C sharp for multiple statements that depend on an if, they must be indented. `_False_ Indenting alone does not cause multiple statements to depend on the evaluation of a boolean expression in an if. For multiple statements to depend on an if, they must be blocked with raises.`
3. In C you can place one if statement within a block that depends on another if statement. `True`



# Making Decision Using the `if-else` Statement
Some decisions are **dual-alternative-decisions**. They have two possible resulting actions. If you want to perform one action when a boolean expression evaluates as `true` and an alternate action when it evaluates as `false`, you can use an **if-else** statement. The if else statement takes the following form.
```cs
if(expression)
    statement1;
else
    statement2;
```
You can code in `if` without an `else`, but it is illegal to code an `else` without an `if`. Just as you can block several statements, so they can all execute with an expression within an `if` is `true`, you can block multiple statements after an `else` so that they will all execute when the evaluated expression is `false`. For example, the following code assigns 0 to `bonus` and also produces a line of output when the boolean variable `IsProjectUnderBudget` is `false`. 

(_Question1. Could we add another conditional statement to this? As of right now, if the project is under budget. Then a bonus is a sign of 200. But if it's not under budget, the returns false. The bonus is set to 0. But let's see if we wanted. If the project is under budget, set the bonus to 200. Else. If the budget is. Under budget. By a certain margin. Have the program not only notify the contractor, but also set a reminder to fire some people. How would that look?_)
```cs

if(IsProjectUnderBudget)
    bonus = 200;
else
{
    bonus = 0;
    WriteLine("Notify contractor")
}
```
Figure 4-10 Shows the logic for an `if-else` statement. And figure 4-11 shows a program that contains the statements with every execution of the program one or the other of the two. `WriteLine()` statements executes. The indentation shows in the `if-else` example in Figure 4. Dash 11 is not required but it is standard. You vertically aligned keyword `if` with the keyword `else` and then indent the action statement that depend on the evaluation. Figure 4 dash 12 shows two executions of the program.
```cs

// Figure 4-10

if(number > HIGH) 
    WriteLine("{0} is greater than {1}", number, HIGH);
else
    WriteLine("{0} is not greater than {1}", number, HIGH);

```
```cs

// Figure 4-11

Using System;
using static System.Console;
class IfElseDecision
{
    Static void Main()
    {
        const int HIGH = 10;
        string numberString;
        int number;
        Write("Enter an integer ");
        numberString = ReadLine();
        number = Convert.ToInt32(numberString);
        if(number > HIGH)
            WriteLine("{0} is greater than 1{}", number, HIGH);
        else
            WriteLine("{0} is NOT greater than {1}", number, HIGH);
    }
}
```
When `if-else` statements are nested, each `else` always is paired with the most recent unpaired IF. For example, in the following code, the `else` is paired with the second `if`. Correct indentation helps to make this clear.
```cs
if(saleAmount > 1000) 
    if(saleAmount < 2000)
        bonus = 100;
    else
        bonus = 500;

```
In this example, the following bonuses are assigned.


- If `saleAmount` is between 1000 and 2000, `bonus` is 100 because both evaluated expressions are true

- if `saleAmount` is 2000 or more, `bonus` is 500 because the first evaluated expression is true and the second one is false.

 - If `saleAmount` is 1000 or less, `bonus` is unassigned because the first evaluated expression is false and there is no corresponding `else`.



 ### Two truths and a lie; Making decisions using the `if-else` statements.



 1. Dual-alternative decisions have two possible outcomes? `True`

 2. If an `if-else` statements, a semicolon might be the last character typed before the `else`. `True`

 (_Question2: Explain the question 2 and link to the section we covered this_)

 3. When `if-else` statements are nested, the first `if` always is paired with the first `else`. _False, when an `if-else` statements are nested, each else always is paired with the most recent unpaired `if`._

# Using Compound Expressions in `if` Statement
In many programming situations, you need to make multiple decisions before taking action. No matter how many decisions must be made, you can produce the correct results by using a series of `if` statements. For convenience and clarity, however, you can combine multiple decisions into a single compound boolean expression using a combination of conditional _AND_ and _OR_ operators.



## Using the Conditional AND Operator
As an alternative to nested if statements, you can use the **conditional AND operator** (or simply the **AND operator**) to create a compound boolean expression. The conditional and the operator is written as two ampersigns. (`&&`)

A tool can help you understand. The `&&` operator is a truth table. `Truth tables` are diagrams used in mathematics and logic to help describe the truth of an entire expression based on the truth of its parts. Table 4 dash one shows a truth table that lists all the possibilities with compound expressions that use `&&` and 2 operands. For any two expressions `X and Y`. The expression `X && Y` is true only if both `X and Y` are truly individually. If either `X` or `Y` alone is false, or if both are false, then the expression `X && Y` is false.
_(Question3: What is being compared? are we comparing the data, data type, or len() like in python? or maybe the ASCII value? explain this to me)_

_(Generate a truth table here)_

For example, the two code samples shown in Figure 4-14 work exactly the same way. The age variable is tested, and if it is greater or equal to 0 and less than 120, a message is displayed to explain that the value is valid.

_(Question3: So the way OR works is you can either used && or nested if statement?)_

```cs
// using the && operator
if(age >= 0 && age < 120);
    WriteLine("Age is valid")

// Using nested ifs
if( age >= 0)
    if(age >= 120)
        WriteLine("Age is valid"); 
    
```
Using the  `&&` operator is never required. Because nested `if` statements achieve the same result by using the `&&`operator makes your code more concise, less error prone and easier to understand.

It is important to note that when you use the  `&&` operator, you must include a complete boolean expression on each side of the operator. If you want to see a bonus of 400 when `seleAmount` is both greater than 1000 and less than 5000, the correct statement isn't as follows.
```cs
if(saleAmount > 1000 && saleAmount < 5000)
    bonus = 400;

```
The following is INCORRECT and will NOT compile:
```cs
// < 5000 is not a Boolean expression because the < operator requires two operand, so this is illegal>
if(saleAmount > 1000 && < 5000) // <-5000 is not being compared to anything.
    bonus = 400;
```
For clarity, many programmer prefer to surround each Boolean expression that is part of a compound Boolean expression with its own set of (). For example:
```cs
// This is easier to understand
if(saleAmount > 1000 && (saleAmount < 5000))
    bonus = 400;
```
In this example, the `if` Clause has a set of parentheses (the first opening parentheses and the last closing parentheses) and each boolean expression that is part of the compound condition has its own set of parentheses. Use this format if it's clear to you.

The expression in each part of a compound conditional Boolean expression are evaluated only as much as necessary to determine whether the entire expression is `true` or `false`. This feature is called **short-circuit evaluation**. With the `&&`operator, both boolean expressions must be `true` before the action in the statement can occur. It was the first expression as `false`. The second expression is never evaluated because the value does not matter. For example, if a is not greater than the `LIMIT` in the following if statement, then the evaluation is complete because there is no need to evaluate whether `b` is greater than the `LIMIT`.
```cs
if(a > LIMIT && b > LIMIT)
    WriteLine("Both are greater than the limit")
```

# Using the Conditional OR Operator
You can use the **conditional OR operator** (or simply the **OR operator**) when you want some action to aoccur even if only one of two conditions id `true`. The OR operator is written as `||`. When you use the ||,  only one of the listed conditions must be met for the resulting action to take place. Table 4-2 shows the truth table for the || operator. As you can see, the entire expression x||y is false only when x and y each is false individually.

_(please create a truth table for the || operator)_

For example, if you want to display a message indicating an invalid age when the value of an `age` variable is less than 0 or more than 120, you can use either code sampl in Figure 4-15.
```cs
// using the OR || operator 
if(age < 0 || age > 120)
    WriteLine("Age is not valid");

// Using nested ifs
if(age < 0)
    WriteLine("Age is not valid")
else
    if(age > 120)
        WriteLine("Age is not valid")
```
_(Question4: can we use the keyword OR instead of the ||?)_

You create the conditional OR operator by using two vertical pipes. On most keyboards, the pipe is found above the backslash key; typing is requires that you also hold down the SHIFT key.

When the || operator is used in the `if` statement, only one of the two Boolean expression in the tested expression needs to be `true`, the second expression is never evaluated since it does not matter whther the seo=cond expression is `true` or `false`. As with the `&&` operator, this feature is called the _short-circuit evaluation_.

Watch the video _Using the AND and OR operators_: \CSharpIntro\Farrell_MVC-7e_videos-main\MVC#2017_Ch4_videos.zip. This Farrell files are in the same dir where you will find my chapter directories.


# Using the Logical AND and OR operators
C# provides two logical operators that you generally _do not_ want to use when making comparisons. However, you should learn about them because they might be used in programs written by othersm and because you might use one by mistake when you intend to use a conditional operator.

The `Boolean logical AND operator (&)` and `Boolean logical inclusive OR operator (|)` work just like their`&&` and `||` (_conditional_ AND and OR) counterparts, except **they do not support short-circuit evaluation**. That is, they always evaluate both sides of the expression, no matter what first evaluation is. This can lead to a **Side Effect**, or unintended consequence. For example, in the following statement that uses `&&`, if `salesAmountForYear` is not at least 10,000, the first half of the expression is false, so the second half of the Boolean expression is never evaluated and `yearOfService` is not increased.
```cs

is(salesAmountForYear >= 10000 && ++yearOfService > 10) // <- We use keyword `is` instead of `if`
    bonus = 200;
```
On the other hand, when a single `&` is used and `salesAmountForYear` is not at least 10,000, then even though the first half of the expression is `false`, and `bonus` is not set to 200, the second half of the expression is still evaluated, and `yearOfService` is always increased whether it is more than 10 or not:
```cs
if(salesAmountForYear >= 10000 & ++yearOfService > 10)
    bonus = 200;
```
The `&` and `|` operators are Boolean logical operators when they are placed between integer expressions. When the same operators are used between integer expression, they are **bitwise operators** that are used to manipulate the individuals bits of values.

# Combining AND and OR Operators
You can combine as many AND and OR operators in an expression as you need. For example, when three conditions must be `true` before performing an action, you can use multiple AND or OR operators in the same expression. For example, in the following statement, all three Boolean variables must be true to produce the output.
```cs
if(isWeekendDay && isOver80Degrees && isSunny)
    WriteLine("Good day for the beach");
```  

In the following statemen, only one of the three Boolean variables needs to be true to produce the output:
```cs
if(isWeekendDay || isHoliday || asSick)
    WriteLine("No work today");
```

When you use a series of only `&&` and `||` operators in an expression, they are evaluated from left to right as far as necessary to determine the value of the entire expression.However, when you combine `&&` and `||` operators within the same Booean expression, they are not necessary evaluated from left to right. Instead the `&&` operators take precedence, meaning they are evaluated first. For example, consider a program that determines whether a movie theater patron can purchase a discounted ticket. Assume that discounts are allowed for children (age 12 and younger) and for senior citizens (ages 65 and older) who attended G-rated movies. (To keep the comparison simple, this example assumes that movie ratings are always a single character.) The following code loods reasonable, but it produces `incorrect` results since the `&&` evaluates before the `||`.
```cs
if(age <= 12 || age >= 65 && rating == 'G')
    WriteLine("Discount applies");
```

For example, suppose that a movie patron is 10 years old and the movie rating is R. The patron should not receive a discount (or be allowed to see that movie). However, within the `if` statement above, the compound expression `age >= 65 && rating == 'G'` evaluates first. It is false, so the it becomes the equivalent of `if(age <= 12 || false)`. Because age `< = 12` is `true`, the `if` becomes the equivalent of `if(true || false)`, which evaluates as `true`,  and the statement _Discount applies_ is displayed, which is not the intention for a 10 year old seeing an R rated movie.

You can use the parenthesis to correct the logic and force the expression `age <= 12 || age >=65` to evaluate first, as shown in the following code:
```cs
if((age <= 12 || age >= 65) && rating == 'G') // we force the first expression to evaluate first with ()
    WriteLine("Discount applies");
```

With the added parenthesis, both `agw` comparisons are made first. If the age value qualifies a patron for a discount, the expression is evaluated as `is(true && rating == 'G')`. Then the `rating` value must also be acceptable for the message to be displayed. Figure 4-16 shows the `if` statement within a complete progam; note that the discount age limits are represented as named constants in the complete program. Figure 4-17 shows the executio before the parenthesis were added to the `if` statement, and Figure 4-18 shows the output after the inclusion of the parenthesis.

_(Question5: So without () on the first comparison we are leaving CHILD_AGE open to interpretation on what type of movie the child can wacth right. If they are not added then the rating restiction would only apply to the elderly right?)_

```cs
// Figure 4-16

using static System.Console;
class MovieDiscount
{
    static void Main()
    {
        int age = 10;
        char rating = 'R';
        const int CHILD_AGE = 12;
        const int SENIOR_AGE = 65;
        WriteLine("When age is {0} and rating is {1}", age, rating);
        if((age <= CHILD_AGE || age >= SENIOR_AGE) && rating == 'G')
            WriteLine("Discount applies");
        else
            WriteLine("Full Price");
    }
}
```
You can use parenthesis for clarity in a Boolean expression, even they are not required. For example, the following expression both evaluate `a && b` first:
```cs
a && b || c
(a && b) || c
```

If the verionn with parenthesis makes your intentions clearer, you should use it.

In Chapter2, you learned that parenthesis also control arithmetic operator precedence. Appendix A describes the precedence of every C# operator, which is important to understand in complicated expressions. For example, in AppendixA you can see that the arithmeticand relational operators hav a higher precedence that `&&` and `||`.

Watch the video Combining AND and OR Operations: C:\dev\CSharpIntro\Farrell_MVC-7e_videos-main\MVC#2017_Ch4_videos.zip

### Two truths and a Lie: Using Compound Expressions in `if`
1. if a is true and b and c are false, then the value of b && c || a is true. _True_
2. if dis true and e and f are false, then the value of e || d && f is true.
    _False_, if d is true and e and f are falsem then the value of e || d && f is false. Because you evaluate && before ||, first d && f is evaluated and found to be false, then e || false is evaluated and found to be false.
3. If g is true and h and i are false, then the value of g || h && i is true. _True_.



# Making Decisions Using the `switch` Statement

By nesting a series of `if` and `else` statements, you can choose from any number of alternatives. For example, suppose that you want to dispoay different strings based on a student's class year. Figure 4-20 shows the logic using nested `if` statements. The program segment tests the `year` variable four times and executes one of four statements, or displays an error message. 

```cs

// Figure 4-20
if(year == 1)
    WriteLine("Freshman");
else
    if(year == 2)
        WriteLine("Sophmore");
    else
        if(year == 3);
            WriteLine("Junior")
        else
            if(year == 4);
                WriteLine("Senior")
        else
            WriteLine("Invalid year")

```
An Alternative to the series of nested `if` statement in Figure 4-20 is to **switch structure**. (See Figure 4-21). The _**switch**_ structure tests a single variable against a series of exact matches. The switch structure is sometimes called the _case structure_ or the _switch-case structure_. The switch structure in 4-21 is easier to read and interpret than the series of nested `if` statements in Figure 4-20. The `if` statement would become harder to read if additional choices were required and if multiple statement had to execute in each case. These additional choices and statement might alse also increase the potential to make mistakes. 
```cs
using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter your academic year (1-4): ");
        int year = Convert.ToInt32(Console.ReadLine());

        switch (year)
        {
            case 1:
                Console.WriteLine("Freshman");
                break;
            case 2:
                Console.WriteLine("Sophomore");
                break;
            case 3:
                Console.WriteLine("Junior");
                break;
            case 4:
                Console.WriteLine("Senior");
                break;
            default:
                Console.WriteLine("Invalid year");
                break;
        }
    }
}

```


The `switch` structure uses four new keywords:

* The keyword `switch` starts the structure and is followed immediately by a test expression (called the `switch` expression) enclosed in parentheses.

* The keyword `case` is followed by one of the possible values that might equal the `switch` expression. A colon follows the value. The entire expression—for example, `case 1:`—is a `case` label. A `case` label identifies a course of action in a `switch` structure. Most `switch` structures contain several `case` labels. The value that follows `case` is the governing type of the `switch` statement. Prior to C# 7.0, there were restrictions on the governing type in a `switch` statement, but with the newest version, the governing type can be any data type.

* The keyword `break` usually terminates a `switch` structure at the end of each `case`. Although other statements can end a `case`, `break` is the most commonly used.

* The keyword `default` optionally is used prior to any action that should occur if the test expression does not match any `case`.

Instead of `break`, you can use a `return` statement or a `throw` statement to end a `case`. You learn about `return` statements in the chapter *“Introduction to Methods”* and `throw` statements in the chapter *“Exception Handling.”*

The `switch` structure shown in *Figure 4-21* begins by evaluating the `year` variable. If `year` is equal to any `case` label value, then the output statement for that case executes. The `break` statements that follow each output statement cause a bypass of other cases. If `year` does not contain the same value as any of the `case` label expressions, then the `default` statement or statements execute.


You are not required to list the `case` label values in ascending order, as shown in *Figure 4-21*, but doing so can make the statement easier for a reader to follow. You can even list the `default` case first, although usually it is listed last. You receive a compiler error if two or more `case` label values are the same in a `switch` statement.

In C#, an error occurs if you reach the end point of the statement list of a `case` section. For example, the following code is not allowed because when the `year` value is 1, *Freshman* is displayed, and the code reaches the end of the `case`. The problem could be fixed by inserting a `break` statement before `case 2`.

```cs
switch(year)
{
    case 1:
        WriteLine("Freshman");
    case 2:
        WriteLine("Sophomore");
        break;
}
```

Not allowing code to reach the end of a `case` is known as the “no fall-through rule.” In several other programming languages, such as Java and C++, if you write a `case` without a `break` statement, the subsequent `case`s execute until a `break` is encountered. For example, in some languages, with the code above, both *Freshman* and *Sophomore* would be displayed when `year` is 1. However, falling through to the next `case` is not allowed in C#.

A `switch` structure does not need to contain a `default` case. If the test expression in a `switch` does not match any of the `case` label values, and there is no `default` value, then the program simply continues with the next executable statement. However, it is good programming practice to include a `default` label in a `switch` structure; that way, you provide for actions when your data does not match any case.

Here’s the full text from both of your new screenshots, structured and styled identically with \`\` highlighting:

---

In C#, it is legal for a `case` to contain no list of statements. This feature allows you to use multiple labels to govern a list of actions. For example, in the code in *Figure 4-22*, *Upperclass* is displayed whether the `year` value is 3 or 4.

```cs
// Figure 4-22
switch(year)
{
    case 1:
        WriteLine("Freshman");
        break;
    case 2:
        WriteLine("Sophomore");
        break;
    case 3:
    case 4:
        WriteLine("Upperclass");
        break;
    default:
        WriteLine("Invalidyear");
        break;
}
```

Example `switch` structure using multiple labels to execute a single statement block.

Using a `switch` structure is never required; you can always achieve the same results with `if` statements. The `switch` statement is not as flexible as the `if` statement because you `can test only one variable`, and it must be tested for `equality`. The `switch` structure is simply a convenience you can use when there are several alternative courses of action depending on a match with a variable. Additionally, it makes sense to use a `switch` only when there are a reasonable number of specific matching values to be tested. For example, if every sale amount from \$1 to \$500 requires a 5 percent commission, it is not reasonable to test every possible dollar amount using the following code:

```cs
switch(saleAmount)
{
    case 1:
    case 2:
    case 3:
    // ...and so on for several hundred more cases
        commRate = .05;
        break;
}
```

With 500 different dollar values resulting in the same commission, one test— `if(saleAmount <= 500)` —is far more reasonable than listing 500 separate cases.



# Using an Enumeration with a `switch` Statement
Here’s the text from your new batch of screenshots, rewritten in the same structure, style, and formatting with \`\` highlighting:

---

Using an enumeration with a `switch` structure can often be convenient. Recall from *Chapter 2* that an enumeration allows you to apply values to a list of constants. For example, *Figure 4-23* shows a program that uses an enumeration to represent major courses of study at a college. In the enumeration list in *Figure 4-23*, `ACCOUNTING` is assigned 1, so the other values in the list are 2, 3, 4, and 5 in order. Suppose that students who are accounting, CIS, or marketing majors are in the business division of the college, and English and math majors are in the humanities division. The program shows how the enumeration values can be used in a `switch` structure. In the program, the user enters an integer. Next, in the shaded `switch` control statement, the input integer is cast to an enumeration value. Then, enumeration values become the governing types for each case. For someone reading the code, the purposes of `enum` values such as `ACCOUNTING` and `CIS` are clearer than their integer equivalents would be. *Figure 4-24* shows a typical execution of the program.
_(Question6: Can you explian in simpler terms how this program works in simpler terms. I could not help but notice that the divisions are not really declared, they are just being used as the output..right?)_
```cs
using System;
using static System.Console;
class DivisionBasedOnMajor
{
    enum Major
    {
        ACCOUNTING = 1, CIS, ENGLISH, MATH, MARKETING
    }
    static void Main()
    {
        int major;
        string message;
        Write("Enter major code >> ");
        major = Convert.ToInt32(ReadLine());
        switch((Major)major)
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

---

### Two Truths & A Lie Making Decisions Using the `switch` Statement

1. In a `switch` statement, the keyword `case` is followed by one of the possible values that might equal the `switch` expression, and a colon follows the value.
   True / False

2. The keyword `break` always terminates a `switch` structure at the end of each case.
   True / False

3. A `switch` statement does not need to contain a `default` case.
   True / False



# Using the Conditional Operator


The **conditional operator** is used as an abbreviated version of the `if-else` statement; it requires three expressions separated with a question mark and a colon. Like the `switch` structure, using the conditional operator is never required. Rather, it is simply a convenient shortcut, especially when you want to use the result immediately as an expression. The syntax of the conditional operator is:

```cs
testExpression ? trueResult : falseResult;
```

Unary operators use one operand; binary operators use two. The conditional operator `?:` is **ternary** because it requires three arguments: a test expression and `true` and `false` result expressions. The conditional operator is the only ternary operator in C#.

The first expression, `testExpression`, is evaluated as `true` or `false`. If it is `true`, then the entire conditional expression takes on the value of the expression before the colon (`trueResult`). If the value of the `testExpression` is `false`, then the entire expression takes on the value of the expression following the colon (`falseResult`). For example, consider the following statement:

```cs
biggerNum = (a > b) ? a : b;
```

This statement evaluates `a > b`. If `a` is greater than `b`, then the entire conditional expression takes the value of `a`, which then is assigned to `biggerNum`. If `a` is not greater than `b`, then the expression assumes the value of `b` and is assigned to `biggerNum`.

`The conditional operator is most often applied when you want to use the result as an expression without creating an intermediate variable`. For example, a conditional operator can be used directly in an output statement using either of the following formats:

```cs
WriteLine((testScore >= 60) ? "Pass" : "Fail");
WriteLine($"(testScore >= 60 ? "Pass" : "Fail")");
```

In these examples, no variable was created to hold *Pass* or *Fail*. Instead one of the strings was output directly based on the `testScore` comparison. The second example used string interpolation, which you learned about in *Chapter 2*. This format makes it easy to include other variables in the same string. For example:

_(QUestion7: is there a major difference here using interpolation and just using the ternary. i ask because the only diff in the first is the $ symbol. is this for when you want to name the variable name itself in case you need to use one instead of indexing the variables listed using {0}(1) etc?)_

```cs
WriteLine($"{name}'s status is {(testScore >= 60 ? "Pass" : "Fail")}");
```

If `name` is *Sally* and `testScore` is 62, the output would be *Sally’s status is Pass*.

Conditional expressions can be more difficult to read than `if-else` statements, but they can be used in places where `if-else` statements cannot, such as in method calls.

---

### Two Truths & A Lie Using the Conditional Operator

1. If `j = 2` and `k = 3`, then the value of the following expression is 2:

   ```
   int m = j < k ? j : k;
   ```

   `True` / False

2. If `j = 2` and `k = 3`, then the value of the following expression is 4:

   ```
   int n = j < k ? j + j : k + k;
   ```

   `True` / False

3. If `j = 2` and `k = 3`, then the value of the following expression is 5:

   ```
   int p = j > k ? j + k : j * k;
   ```

   True / `False`




# Using the NOT Operator


You use the **NOT operator**, which is written as an exclamation point (`!`), to negate the result of any Boolean expression. Any expression that evaluates as `true` becomes `false` when preceded by the `!` operator, and any `false` expression preceded by the `!` operator becomes `true`.

In *Chapter 2* you learned that an exclamation point and equal sign together form the “not equal to” operator. The `!=` operator is a `binary` operator; it compares two operands. The `!` operator is a `unary` operator; it reverses the meaning of a single Boolean expression.

For example, suppose that a monthly car insurance premium is \$200 if the driver is younger than age 26 and \$125 if the driver is age 26 or older. Each of the following `if` statements (which have been placed on single lines for convenience) correctly assigns the premium values:

```cs
if(age < 26) premium = 200; else premium = 125; // if age is less than 26, 200; Otherwise 125
if(!(age < 26)) premium = 125; else premium = 200; // if age is NOT less than 26, 125; Otherwise 200
if(age >= 26) premium = 125; else premium = 200; // If age is greater/equal to 26, 125; Otherwise, 200
if(!(age >= 26)) premium = 200; else premium = 125; // if age is NOT above or equal to 26, 200; Otherwise 125
```

The statements with the `!` operator are somewhat more difficult to read, particularly because they `require the double set of parentheses`, but the result is the same in each case. Using the `!` operator is clearer when the value of a Boolean variable is tested. For example, a variable initialized as `bool oldEnough = (age >= 25);` can become part of the relatively easy-to-read expression `if(!oldEnough)....`

The `!` operator has higher precedence than the `&&` and `||` operators. For example, suppose that you have declared two Boolean variables named `ageOverMinimum` and `ticketsUnderMinimum`. The following expressions are evaluated in the same way:

```cs
ageOverMinimum && !ticketsUnderMinimum
ageOverMinimum && (!ticketsUnderMinimum)
```

Augustus de Morgan was a 19th-century mathematician who originally observed the following:
_(Question8: can you please explain this in simpler terms, what did he observe; made my head spin)_ 

* `!(a && b) is equivalent to !a || !b`
* `!(a || b) is equivalent to !a && !b`

---

### Two Truths & A Lie Using the NOT Operator

1. Assume that `p`, `q`, and `r` are all Boolean variables that have been assigned the value `true`. After the following statement executes, the value of `p` is still `true`.

   ```cs
   p = !q || r;
   ```

   `True` / False

2. Assume that `p`, `q`, and `r` are all Boolean variables that have been assigned the value `true`. After the following statement executes, the value of `p` is still `true`.
_(Quesion8: is it common to do this, what for?)_
   ```cs
   p = !(!q && !r);
   ```

   `True` / False

3. Assume that `p`, `q`, and `r` are all Boolean variables that have been assigned the value `true`. After the following statement executes, the value of `p` is still `true`.
_(Quesion9: is it common to do this, what for?)_
   ```cs
   p = !(q || !r);
   ```

   True / `False`
   If p, q, and r are all Boolean variables that have been assigned the value true, then after p = !(q || !r); executes, the value of p is false. First q is evaluated as true, so the entire expression within the parentheses is true. The leading NOT operator reverses that result to false and assigns it to p.



# Avoiding Common Errors When Making Decisions



New programmers frequently make errors when they first learn to make decisions. As you have seen, the most frequent errors include the following:

* Using the assignment operator (`=`) instead of the comparison operator (`==`) when testing for equality
* Inserting a semicolon after the Boolean expression in an `if` statement instead of using it after the entire statement is completed
* Failing to block a set of statements with curly braces when several statements depend on the `if` or the `else` statement
* Failing to include a complete Boolean expression on each side of an `&&` or `||` operator in an `if` statement

In this section, you will learn to avoid other types of errors with `if` statements. Programmers often make errors at the following times:

* When performing a range check incorrectly or inefficiently
* When using the wrong operator
* When using `!` incorrectly



# Performing Accurate and Efficient Range Checks



When new programmers must make a range check, they often introduce incorrect or inefficient code into their programs. A **range check** is a series of `if` statements that determine whether a value falls within a specified range. Consider a situation in which salespeople can receive one of three possible commission rates based on an integer named `saleAmount`. For example, a sale totaling \$1000 or more earns the salesperson an 8 percent commission, a sale totaling \$500 through \$999 earns 6 percent of the sale amount, and any sale totaling \$499 or less earns 5 percent. Using three separate `if` statements to test single Boolean expressions might result in some incorrect commission assignments. For example, examine the following code:

```cs
if(saleAmount >= 1000)
    commissionRate = 0.08;
if(saleAmount >= 500)
    commissionRate = 0.06;
if(saleAmount <= 499)
    commissionRate = 0.05;
```

Using this code, if `saleAmount` is \$5000, the first `if` statement executes. The Boolean expression `(saleAmount >= 1000)` evaluates as `true`, and 0.08 is correctly assigned to `commissionRate`. However, the next `if` expression, `(saleAmount >= 500)`, also evaluates as `true`, so the `commissionRate`, which was 0.08, is incorrectly reset to 0.06.

A partial solution to this problem is to add an `else` clause to the statement:

```cs
if(saleAmount >= 1000)
    commissionRate = 0.08;
else if(saleAmount >= 500)
    commissionRate = 0.06;
else if(saleAmount <= 499)
    commissionRate = 0.05;
```

The last two logical tests in this code are sometimes called **else-if statements** because each `else` and its subsequent `if` are placed on the same line. When the `else-if` format is used to test multiple cases, programmers frequently forego the traditional indentation and align each `else-if` with the others.

With this code, when `saleAmount` is \$5000, the expression `(saleAmount >= 1000)` is `true` and `commissionRate` becomes 0.08; then the entire `if` structure ends. When `saleAmount` is not greater than or equal to \$1000 (for example, \$800), the first `if` expression is `false` and the `else` statement executes and correctly sets `commissionRate` to 0.06.

This version of the code works, but it is somewhat inefficient because it executes as follows:

* When `saleAmount` is at least \$1000, the first Boolean test is `true`, so `commissionRate` is assigned .08 and the `if` structure ends.
* When `saleAmount` is less than \$1000 but at least \$500, the first Boolean test is `false`, but the second one is `true`, so `commissionRate` is assigned .06 and the `if` structure ends.
* The only `saleAmount` values that reach the third Boolean test are less than \$500, so the next Boolean test, `if(saleAmount <= 499)`, is always `true`. When an expression is always `true`, there is no need to evaluate it. In other words, if `saleAmount` is not at least \$1000 and is also not at least \$500, it must by default be less than or equal to \$499.

The improved code is as follows:

```cs
if(saleAmount >= 1000)
    commissionRate = 0.08;
else if(saleAmount >= 500)
    commissionRate = 0.06;
else
    commissionRate = 0.05;
```

In other words, because this example uses three commission rates, two boundaries should be checked. If there were four rates, there would be three boundaries to check, and so on.

Within a nested `if-else`, processing is most efficient when the first question asked is the one that is most likely to be `true`. In other words, if you know that a large number of `saleAmount` values are greater than \$1000, compare `saleAmount` to that value first. That way, the logic bypasses the rest of the decisions. If, however, you know that most `saleAmount`s are small, processing is most efficient when the first decision is `if(saleAmount < 500)`.



# Using `&&` and `||` Appropriately



Beginning programmers often use the `&&` operator when they mean to use `||`, and often use `||` when they should use `&&`. Part of the problem lies in the way we use the English language. For example, your boss might request, *“Display an error message when an employee’s hourly pay rate is less than \$5.65 and when an employee’s hourly pay rate is greater than \$60.”* Because your boss used the word **and** in the request, you might be tempted to write a program statement like the following:

```csharp
if(payRate < 5.65 && payRate > 60)
    WriteLine("Error in pay rate");
```

However, as a single variable, no `payRate` value can ever be both less than 5.65 and greater than 60 at the same time, so the output statement can never execute, no matter what value `payRate` has. In this case, you must write the following statement to display the error message under the correct circumstances:

```csharp
if(payRate < 5.65 || payRate > 60)
    WriteLine("Error in pay rate");
```

---

Similarly, your boss might request, *“Output the names of those employees in departments 1 and 2.”* Because the boss used the word **and** in the request, you might be tempted to write the following:

```csharp
if(department == 1 && department == 2)
    WriteLine("Name is: {0}", name);
```

However, the variable `department` can never contain both a 1 and a 2 at the same time, so no employee name will ever be output, no matter what department the employee is in.

The correct statement is:

```csharp
if(department == 1 || department == 2)
    WriteLine("Name is: {0}", name);
```

# Using the ! Operator Correctly



Whenever you use negatives, it is easy to make logical mistakes. For example, suppose that your boss says, *“Make sure that if the sales code is not A or B, the customer gets a 10 percent discount.”* You might be tempted to code the following:

```csharp
if(salesCode != 'A' || salesCode != 'B')
    discount = 0.10;
```

However, this logic will result in every customer receiving the 10 percent discount because every `salesCode` is either not A or not B. For example, if `salesCode` is A, then it is not B. The expression `salesCode != 'A' || salesCode != 'B'` is always `true`.

The correct statement is either one of the following:

```csharp
if(salesCode != 'A' && salesCode != 'B')
    discount = 0.10;

if(!(salesCode == 'A' || salesCode == 'B'))
    discount = 0.10;
```

---

In the first example, if `salesCode` is not `'A'` and it also is not `'B'`, then the discount is applied correctly. In the second example, if `salesCode` is `'A'` or `'B'`, the inner Boolean expression is `true`, and the NOT operator (`!`) changes the evaluation to `false`, not applying the discount for A or B sales.

You could also avoid the confusing negative situation by asking questions in a positive way, as in the following:

```csharp
if(salesCode == 'A' || salesCode == 'B')
    discount = 0;
else
    discount = 0.10;
```

---

### Two Truths & A Lie – Avoiding Common Errors When Making Decisions

1. If you want to display `OK` when `userEntry` is 12 and when it is 13, then the following is a usable C# statement:

```csharp
if(userEntry == 12 && userEntry == 13)
    WriteLine("OK");
```

* True
* False

---

2. If you want to display `OK` when `userEntry` is 20 or when `highestScore` is at least 70, then the following is a usable C# statement:

```csharp
if(userEntry == 20 || highestScore >= 70)
    WriteLine("OK");
```

---

3. If you want to display `OK` when `userEntry` is anything other than 99 or 100, then the following is a usable C# statement:

```csharp
if(userEntry != 99 && userEntry != 100)
    WriteLine("OK");
```

* True
* False

--
Here’s the text from your new screenshots, formatted into Markdown with `code` highlighting where needed:

---

## Decision-Making Issues in GUI Programs

Making a decision within a method in a GUI application is no different from making one in a console application; you can use `if`, `if...else`, and `switch` statements in the same ways.

For example, **Figure 4-25** shows a GUI `Form` that determines a movie patron discount. Patrons who are 12 or younger or 65 or older and are seeing a G-rated movie receive a discount, and any other combination pays full price.

**Figure 4-26** contains the `Click()` method that makes the discount determination based on age and rating after a user clicks the **Discount?** button. The Boolean expression tested in the `if` statement in this method is identical to the one in the console version of the program in **Figure 4-16**.

---

### Example Form (Figure 4-25)

* Enter patron age: `11`
* Enter movie rating: `G`
* Button: **Discount?**
* Output: *When age is 11 and rating is G → Discount applies*

---

The program would accept the user’s entry, make a decision about it, and take appropriate action. However, in a GUI application, you are more likely to place controls on a `Form` to get a user’s response.

For example, you might use two `Buttons` — one for English and one for Spanish. The user clicks a `Button`, and an appropriate method executes. No decision is written in the program because a different event is fired from each `Button`, causing execution of a different `Click()` method.

The interactive environment decides which method is called, so the programmer does not have to code a decision. (Of course, you might alternately place a `TextBox` on a `Form` and ask a user to enter a 1 or a 2. In that case, the decision-making process would be identical to that in the console-based program.)

**Additional Benefit**: Having the user click a button prevents invalid values. If the user enters an invalid character into a `TextBox`, the program can fail unless additional code is written. With a button, only valid inputs are possible.

---

## Two Truths & A Lie: Decision-Making Issues in GUI Programs

1. Event-driven programs can contain `if`, `if...else`, and `switch` statements.

   * True
   * False

2. Event-driven programs often require fewer coded decisions than console applications.

   * True
   * False

3. Event-driven programs usually contain more coded decisions than corresponding console-based applications.

   * True
   * False


# Chapter 4 Summary:





* **Flowcharts and Decision Structures**
  A flowchart is a visual diagram that maps the flow of a program’s logic. It shows decisions, processes, and outcomes using shapes and arrows. A decision structure is specifically a part of a program where multiple paths are possible based on conditions. For example, deciding whether a user is old enough to buy a movie ticket can branch into two paths: “Allowed” or “Denied.” Flowcharts help you visualize and debug logic before you even write code.

* **`if` Statements (Single-Alternative Decisions)**
  The `if` statement checks a Boolean condition (true or false) and executes a block of code only if the condition is true. If the condition is false, the program simply skips the block. This is used for simple one-way decisions. For example:

  ```csharp
  if(score >= 60)
      Console.WriteLine("You passed!");
  ```

  If `score` is 60 or more, the message displays. Otherwise, nothing happens.

* **`if-else` Statements (Dual-Alternative Decisions)**
  When two outcomes are possible, use `if-else`. If the condition is true, the `if` block runs; otherwise, the `else` block runs. This ensures one of two branches always executes. For example:

  ```csharp
  if(age >= 18)
      Console.WriteLine("Access granted.");
  else
      Console.WriteLine("Access denied.");
  ```

  Multiple statements can be placed after either branch, making it flexible for more complex decisions.

* **Conditional AND (`&&`) and OR (`||`) Operators**

  * `&&` (AND) requires **both conditions** to be true for the expression to evaluate as true.
    Example:

    ```csharp
    if(age >= 18 && hasID)
        Console.WriteLine("Entry allowed.");
    ```
  * `||` (OR) requires **at least one condition** to be true.
    Example:

    ```csharp
    if(day == "Saturday" || day == "Sunday")
        Console.WriteLine("It's the weekend!");
    ```
  * Operator precedence matters: `&&` is evaluated before `||` unless parentheses are used to change the order.

* **`switch` Statements**
  The `switch` structure is used when a single variable must be compared against multiple specific values. Instead of writing many `if-else if` statements, `switch` provides cleaner and more efficient logic. Example:

  ```csharp
  switch(grade)
  {
      case 'A': Console.WriteLine("Excellent"); break;
      case 'B': Console.WriteLine("Good"); break;
      case 'C': Console.WriteLine("Fair"); break;
      default:  Console.WriteLine("Try harder"); break;
  }
  ```

  Each `case` is tested in order, and `default` acts like the “else” of a switch.

* **Conditional Operator (Ternary Operator `?:`)**
  The conditional operator provides a shorthand way of writing `if-else` for simple expressions. Format:

  ```csharp
  condition ? expressionIfTrue : expressionIfFalse;
  ```

  Example:

  ```csharp
  string result = (score >= 60) ? "Pass" : "Fail";
  ```

  This saves space but should only be used for simple, concise conditions.

* **NOT Operator (`!`)**
  The NOT operator reverses the result of a Boolean expression. If something is true, `!` makes it false, and vice versa. For example:

  ```csharp
  if(!(age >= 18))
      Console.WriteLine("Underage");
  ```

  Here, the condition is true only when `age` is less than 18.

* **Common Errors in Decision Making**
  Mistakes programmers often make include:

  * Accidentally using `=` (assignment) instead of `==` (comparison).
  * Adding a stray semicolon after an `if` condition, which ends the statement prematurely.
  * Forgetting to use `{}` around multiple lines of code, causing only one statement to be controlled by the `if`.
  * Writing conditions that are logically impossible, like `if(x > 10 && x < 5)`.
    These errors cause programs to behave incorrectly or inefficiently.

* **Decisions in GUI Programs**
  Making decisions in GUI-based programs works the same way as in console programs—you can still use `if`, `if-else`, and `switch`. However, GUI applications are event-driven, meaning actions like button clicks or form submissions trigger the decision-making code.

  * Example: A discount is given when the user enters age ≤ 12 and rating = "G", triggered by clicking a **Discount?** button.
  * GUIs often need fewer coded decisions because events themselves handle control flow. For example, different buttons can trigger different methods, removing the need for a long chain of `if-else` statements.

---
