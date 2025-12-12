You’re right—no numbering. Here’s the exact TOC and scaffold that matches your screenshot’s titles, with working anchors plus “Back to parent” and “Back to TOC” links.

---

# Chapter 10 — Introduction to Inheritance

## Table of Contents

* [Chapter Introduction](#chapter-introduction)
* [Understanding Inheritance](#understanding-inheritance)

  * [Understanding Inheritance Terminology](#understanding-inheritance-terminology)
  * [Extending Classes](#extending-classes)
  * [Using the protected Access Specifier](#using-the-protected-access-specifier)
* [Overriding Base Class Members](#overriding-base-class-members)

  * [Accessing Base Class Methods and Properties from a Derived Class](#accessing-base-class-methods-and-properties-from-a-derived-class)
  * [Understanding Implicit Reference Conversions](#understanding-implicit-reference-conversions)
* [Using the Object Class](#using-the-object-class)

  * [Using the Object Class’s GetType() Method](#using-the-object-classs-gettype-method)
  * [Using the Object Class’s ToString() Method](#using-the-object-classs-tostring-method)
  * [Using the Object Class’s Equals() Method](#using-the-object-classs-equals-method)
  * [Using the Object Class’s GetHashCode() Method](#using-the-object-classs-gethashcode-method)
* [Working with Base Class Constructors](#working-with-base-class-constructors)

  * [Using Base Class Constructors That Require Arguments](#using-base-class-constructors-that-require-arguments)
* [Creating and Using Abstract Classes](#creating-and-using-abstract-classes)
* [Creating and Using Interfaces](#creating-and-using-interfaces)
* [Using Extension Methods](#using-extension-methods)
* [Recognizing Inheritance in GUI Applications](#recognizing-inheritance-in-gui-applications)
* [Chapter Summary](#chapter-summary)
* [Key Terms](#key-terms)
* [Review Questions](#review-questions)
* [Exercises](#exercises)

---

## Chapter Introduction

Upon completion of this chapter, you will be able to:

- Describe inheritance
- Extend classes
- Use the protected access specifier
- Override base class members
- Describe how a derived class object “is an” instance of the base class
- Understand the Object class
- Work with base class constructors
- Create and use abstract classes
- Create and use interfaces
- Use extension methods
- Recognize inheritance in GUI applications

Understanding classes helps you organize objects. Understanding inheritance helps you organize them more precisely. If you have never heard of a Braford, for example, you would have a hard time forming a picture of one in your mind. When you learn that a Braford is an animal, you gain some understanding of what it must be like. That understanding grows when you learn it is a mammal, and the understanding is almost complete when you learn it is a cow. When you learn that a Braford is a cow, you understand it has many characteristics that are common to all cows. To identify a Braford, you must learn only relatively minor details—its color or markings, for example. Most of a Braford’s characteristics, however, derive from its membership in a particular hierarchy of classes: animal, mammal, and cow.

All object-oriented programming languages make use of inheritance for the same reasons—to organize the objects used by programs, and to make new objects easier to understand based on your knowledge about their inherited traits. In this chapter, you will learn to make use of inheritance with your C# objects.

[Back to TOC](#table-of-contents)

---












## Understanding Inheritance

**Inheritance** is the principle that you can apply your knowledge of a general category to more specific objects. You are familiar with the concept of inheritance from all sorts of situations. When you use the term inheritance, you might think of genetic inheritance. You know from biology that your blood type and eye color are the products of inherited genes. You can say that many other facts about you (your attributes) are inherited. Similarly, you often can attribute your behaviors to inheritance; for example, the way you handle money might be similar to the way your grandmother handles it, and your gait might be the same as your father’s—so your methods are inherited, too.

You also might choose to own plants and animals based on their inherited attributes. You plant impatiens next to your house because they thrive in the shade; you adopt a poodle because you know poodles don’t shed. Every plant and pet has slightly different characteristics, but within a species, you can count on many consistent inherited attributes and behaviors. In other words, you can reuse the knowledge you gain about general categories and apply it to more specific categories. Similarly, the classes you create in object-oriented programming languages can inherit data and methods from existing classes. When you create a class by making it inherit from another class, you are provided with data fields and methods automatically; you can reuse fields and methods that are already written and tested.

You already know how to create classes and how to instantiate objects from those classes. For example, consider the `Employee` class in Figure 10-1. The class contains a field for the `employee`’s `salary` as well as two properties, `IdNum` and `Salary`. The `IdNum` property is an _auto-implemented_ property, but the `Salary` property is not auto-implemented—it is created manually to ensure that an `Employee` ’s `salary` cannot be less than a specified limit. The class also contains a method that creates an `Employee` greeting.

```cs
// Figure 10-1
// The `Employee` class

// Represents an Employee in the system
class Employee
{
    // Private field to store salary internally
    // Encapsulation: we hide direct access to salary
    private double salary;

    // Public property for employee ID
    // Auto-implemented property: compiler generates backing field
    public int IdNum { get; set; }

    // Public property for Salary with custom logic
    public double Salary
    {
        get
        {
            // Getter: exposes the private salary field
            return salary;
        }
        set
        {
            // Business rule: enforce a minimum salary
            const double MIN = 15_000;

            // If someone tries to set below MIN, clamp it
            if (value < MIN)
                salary = MIN;
            else
                salary = value;
        }
    }

    // Method that returns a greeting string
    public string GetGreeting()
    {
        // Combines static text with dynamic employee ID
        string greeting = "Hello. I am employee #" + IdNum;
        return greeting;
    }
}
```

After you create the `Employee` class, you can create specific `Employee` objects, as in the following:

```cs
Employee receptionist = new Employee();
Employee deliveryPerson = new Employee();
```

These `Employee` objects can eventually possess different numbers and salaries, but because they are `Employee` objects, you know that each possesses some ID number and `salary`.

Suppose that you hire a new type of `Employee` who earns a commission as well as a `salary`. You can create a class with a name such as `CommissionEmployee`, and provide this class with three properties (`IdNum`, `Salary`, and `CommissionRate`) and a greeting method. However, this work would duplicate much of the work that you already have done for the `Employee` class. The wise and efficient alternative is to create the class Commission`Employee` so it inherits all the attributes and methods of `Employee`. Then, you can add just the new property that is an addition within Commission`Employee` objects.

When you use inheritance to create the `CommissionEmployee` class, you acquire the following **benefits**:

- You save time, because you need not re-create any fields, properties, or methods already defined in the `Employee` class.

- You reduce the chance of errors, because the `Employee` properties and method have already been used and tested.

- You make it easier for anyone who has used the `Employee` class to understand the `CommissionEmployee` class because such users can concentrate on the new features only.

The ability to use inheritance makes programs easier to write, easier to understand, and less prone to errors. Imagine that besides Commission`Employee`, you want to create several other specific `Employee` classes (perhaps PartTime`Employee`, including a property for hours worked, or `DismissedEmployee`, including a reason for dismissal). By using inheritance, you can develop each new class correctly and more quickly.

In part, the concept of class inheritance is useful because it makes class code reusable and development faster. However, you do not use inheritance simply to save work. When properly used, inheritance always involves a general-to-specific relationship.

[Back to TOC](#table-of-contents)






### Understanding Inheritance Terminology

**📚 Base vs. Derived Classes**

A class that is used as a basis for inheritance, such as `Employee`, is called a base class. When you create a class that inherits from a **base class** (such as `CommissionEmployee`), it is a **derived** class or **extended** class. When presented with two classes that have a parent-child relationship, you can tell which class is the base class and which is the derived class by using the two classes in a sentence with the phrase “is a.” A derived class always “is a” case or instance of the more general base class. For example, a `Tree` class might be a base class to an `Evergreen` class. Every `Evergreen` “is a” `Tree`; however, it is not true that every `Tree` is an `Evergreen`. Thus, `Tree` is the **base class**, and `Evergreen` is the derived class. Similarly, a `CommissionEmployee` “is an” `Employee`—not always the other way around—so `Employee` is the base class and `CommissionEmployee` is derived.

🧩 **Naming Logic & Order**

You can use the terms `superclass` and `subclass` as synonyms for base class and derived class. Thus, `Evergreen` can be called a subclass of the `Tree` superclass. You also can use the terms **parent** class and **child** class. A `CommissionEmployee` is a child to the `Employee` parent. Use the pair of terms with which you are most comfortable; all of these terms will be used interchangeably in this book.

As an alternative way to discover which of two classes is the base class and which is the derived class, you can try saying the two class names together (although this technique might not work with every superclass-subclass pair). When people say their names together in the English language, they state the more specific name before the all-encompassing family name, such as Ginny Kroening. Similarly, with classes, the order that “makes more sense” is the child-parent order. Thus, because _Evergreen Tree_ makes more sense than _Tree Evergreen_, you can deduce that `Evergreen` is the child class. It also is convenient to think of a derived class as building upon its base class by providing the “adjectives” or additional descriptive terms for the “noun.” Frequently, the names of derived classes are formed in this way, as in `CommissionEmployee`.

📏 **Size & Content of Classes**

Finally, you usually can distinguish base classes from their derived classes by **size**. `A derived class is larger than a base class, in the sense that it usually has additional fields, properties, and methods`. A derived class description might look small, but any subclass contains all the fields, properties, and methods of its superclass as well as its own more specific ones. Do not think of a subclass as a “subset” of another class—in other words, possessing only parts of its superclass. In fact, a derived class contains everything in the superclass, plus any new attributes and methods.

A derived class can be extended further. In other words, a subclass can have a child of its own. For example, after you create a `Tree` class and derive `Evergreen`, you might derive a `Spruce` class from `Evergreen`. Similarly, a Poo`d`le class might derive from `Dog`, `Dog` from `DomesticPet`, and `DomesticPet` from `Animal`. **_The entire list of parent classes from which a child class is derived constitutes the ancestors of the subclass._**

After you create the `Spruce` class, you might be ready to create `Spruce` objects. For example, you might create the `TreeInMyBackYard`, or you might create an array of 1000 `Spruce` objects for a tree farm. Similarly, one `Poodle` object might be `myPetDogFifi`.

Inheritance is transitive, which means a `child inherits all the members of all its ancestors`. In other words, when you declare a `Spruce` object, it contains all the attributes and methods of both an `Evergreen` and a `Tree`. As you work with C#, you will encounter many examples of such transitive chains of inheritance.

When you create your own transitive inheritance chains, you want to `place fields and methods at their most general level`. In other words, a method named `Grow()` rightfully belongs in a `Tree` class, whereas `LeavesTurnColor()` does not, because the method applies to only some of the `Tree` child classes. Similarly, a `LeavesTurnColor()` method would be better located in a `Deciduous` class than separately within the `Oak` or `Maple` child class.

[Back to parent](#understanding-inheritance) • [Back to TOC](#table-of-contents)





### Extending Classes

When you create a class that is an extension or child of another class, you use a single colon between the derived class name and its base class name. For example, the following class header creates a subclass-superclass relationship between CommissionEmployee and Employee.

```cs
class CommissionEmployee : Employee
```

Each `CommissionEmployee` object automatically contains all the fields, properties, and methods of the base class; you then can add new components to the new, derived class. Figure 10-2 shows a `CommissionEmployee` class.

```cs
/*
Figure 10-2
The `CommissionEmployee` class
*/

class CommissionEmployee : Employee
{
    public double CommissionRate {get; set;}
}
```

Although you see only one property defined in the `CommissionEmployee` class in Figure 10-3, it contains three properties: `IdNum` and `Salary`, inherited from `Employee`, and `CommissionRate`, which is defined within the `CommissionEmployee` class. Similarly, although you do not see any fields or methods in the `CommissionEmployee` class, it inherits the salary field and greeting method of Employee.

```cs
/*
Figure 10-3
The DemoEmployees program that declares Employee and `CommissionEmployee` objects
*/
// Shows how base and derived classes can be instantiated and extended with unique properties.

using static System.Console;

class DemoEmployees
{
    static void Main()
    {
        // --- Create base class objects ---
        Employee accountant = new Employee();
        Employee programmer = new Employee();

        // --- Create derived class objects ---
        CommissionEmployee salesperson1 = new CommissionEmployee();
        CommissionEmployee salesperson2 = new CommissionEmployee();

        // --- Assign properties for Employee objects ---
        accountant.IdNum = 123;
        accountant.Salary = 30_000.00;

        programmer.IdNum = 234;
        programmer.Salary = 300_000;   // Note: salary rules enforced by Employee class

        // --- Assign properties for CommissionEmployee objects ---
        salesperson1.IdNum = 345;
        salesperson1.Salary = 22_500.00;
        salesperson1.CommissionRate = 0.07;   // 7% commission

        salesperson2.IdNum = 456;
        salesperson2.Salary = 229_500.00;
        salesperson2.CommissionRate = 0.04;   // 4% commission

        // --- Output greetings and salary info ---
        WriteLine("\n" + accountant.GetGreeting());
        WriteLine("  Accountant #{0} salary: {1} per year",
            accountant.IdNum, accountant.Salary.ToString("C"));

        WriteLine("\n" + programmer.GetGreeting());
        WriteLine("  Programmer #{0} salary: {1} per year",
            programmer.IdNum, programmer.Salary.ToString("C"));

        WriteLine("\n" + salesperson1.GetGreeting());
        WriteLine("  Salesperson 1 #{0} salary: {1} per year",
            salesperson1.IdNum, salesperson1.Salary.ToString("C"));
        WriteLine("...plus {0} commission on all sales",
            salesperson1.CommissionRate.ToString("P"));

        WriteLine("\n" + salesperson2.GetGreeting());
        WriteLine("  Salesperson 2 #{0} salary: {1} per year",
            salesperson2.IdNum, salesperson2.Salary.ToString("C"));
        WriteLine("...plus {0} commission on all sales",
            salesperson2.CommissionRate.ToString("P"));
    }
}
/*

Figure 10-3 shows a program with a Main() method that declares several Employee and `CommissionEmployee` objects and shows all the properties and methods that can be used with each. Figure 10-4 shows the program output. Notice that the salary limit is enforced for both object types.

Figure 10-4: Output of the DemoEmployees program

Hello. I am employee #123
    Accountant #123 salary: $30,000.00 per year

Hello. I am employee #234
    Programmer #234 salary: %15,000.00 per year

Hello. I am employee # 345
    Salesperson 1 # 345 salary: $22,500.00 per year
...pllus 7.00 % commission on all sales

Hello. I am employee #456 
    Salesperson 2 #456 salary: $15,000.00 per yeat
...plus 4.00% commission on all sales
*/
```
**Inheritance Works Only in One Direction**

A child inherits from a parent—not the other way around. If a program instantiates an `Employee` object as in the following statement, the `Employee` object does not have access to the `CommissionEmployee` properties or methods.

```cs
// DO NOT DO THIS!: This statement is invalid because Employee objects don't have a Commission rates.
Employee clerk = new Employee();
clerk.CommissionRate = 0.01

```

`Employee` is the parent class, and `clerk` is an object of the parent class. It makes sense that a parent class object does not have access to its child’s data and methods. When you create the parent class, you do not know how many future child classes might be created, or what their data or methods might look like. In addition, child classes are more specific. A `HeartSurgeon` class and an `Obstetrician` class are **children** of a `Doctor` class. You do not expect all members of the general parent class `Doctor` to have the `HeartSurgeon`’s `RepairValve()` method or the `Obstetrician`’s `DeliverBaby()` method. However, `HeartSurgeon` and `Obstetrician` objects have access to the more general `Doctor` methods `TakeBloodPressure()` and `BillPatients()`. As with doctors, it is convenient to think of derived classes as specialists. That is, their **_fields and methods are more specialized than those of the base class_**.

Watch the video Inheritance.

``` cs
// You Do It:

// Allows use of WriteLine() without prefixing Console.
using static System.Console;

class Loan
{
    // Auto-implemented properties for Loan data.
    public int LoanNumber { get; set; }       // Unique loan identifier
    public string LastName { get; set; }      // Borrower's last name
    public double LoanAmount { get; set; }    // Total amount borrowed
}

// CarLoan extends Loan, inheriting all Loan properties and adding new ones.
class CarLoan : Loan
{
    public int Year { get; set; }             // Year of the car
    public string Make { get; set; }          // Make of the car (Ford, Honda, etc.)
}

class DemoCarLoan
{
    static void Main()
    {
        // Create a Loan object
        Loan aLoan = new Loan();                      // Base Loan object
        aLoan.LoanNumber = 2239;                      // Loan number assignment
        aLoan.LastName = "Mitchell";                  // Borrower name assignment
        aLoan.LoanAmount = 1000;                      // Amount borrowed

        // Display Loan data using composite formatting
        WriteLine("Loan #{0} for {1} is for {2}", 
            aLoan.LoanNumber, 
            aLoan.LastName, 
            aLoan.LoanAmount.ToString("C2"));         // "C2" formats as currency

        // Create a CarLoan object (inherits from Loan)
        CarLoan aCarLoan = new CarLoan();              // Derived class object
        aCarLoan.LoanNumber = 3358;                   // Inherited property from Loan
        aCarLoan.LastName = "Janssen";                // Inherited property from Loan
        aCarLoan.LoanAmount = 20000;                  // Inherited property from Loan
        aCarLoan.Make = "Ford";                       // Property unique to CarLoan
        aCarLoan.Year = 2007;                         // Property unique to CarLoan

        // Display CarLoan data using same composite formatting style
        WriteLine("Loan #{0} for {1} is for {2}", 
            aCarLoan.LoanNumber, 
            aCarLoan.LastName, 
            aCarLoan.LoanAmount.ToString("C2"));

        WriteLine("Automobile: {0} {1}", 
            aCarLoan.Year, 
            aCarLoan.Make);
    }
}


```

[Back to parent](#understanding-inheritance) • [Back to TOC](#table-of-contents)

### Using the `protected` Access Specifier

🔒 **“Keep Out! Private Property”**

In typical C# classes, data fields are `private`, and properties and methods are `public`. In the chapter “**Using Classes and Objects**,” you learned that this scheme provides for information hiding—protecting your `private` data from alteration by methods outside the data’s own class. When a program is a client of the `Employee` class in Figure 10-1 (that is, it instantiates an `Employee` object), the client cannot alter the data in the `private salary` field directly. For example, when you write a `Main()` method that creates an `Employee` named `clerk`, you cannot change the `Employee`’s `salary` directly using a statement such as `clerk.salary = 20_000;`. Instead, you must use the `public Salary` property.

🛡️ **“Guardians of Data Integrity”**

When you use _information hiding_, you are assured that your **_data will be altered only by the properties and methods you choose and only in ways that you can control_**. If outside classes could alter an `Employee`’s `private` fields, then the fields could be assigned values that the `Employee` class couldn’t control. In such a case, the principle of information hiding would be destroyed, causing the behavior of the object to be unpredictable.

👶 **“Children Still Have Rules”**

Any derived class you create, such as `CommissionEmployee`, inherits all the data and methods of its base class. However, even though a child of `Employee` has `idNum` (implicitly) and `salary` (explicitly) fields, the `CommissionEmployee` methods cannot alter or use those private fields directly. If a new class could simply extend your `Employee` class and “get to” its data fields without “going through the proper channels,” then information hiding would not be operating.

**_On some occasions, you do want to access parent class data from a child class._**

For example, assume that a `CommissionEmployee` draws commission only and no regular salary; that is, when you set a `CommissionEmployee`’s `commissionRate` field, the `salary` should become 0. You could write the `CommissionEmployee` class `CommissionRate` property set accessor as follows:

```cs

set
{
    commissionRate = value;
    Salary = 0;
/*This will not work because the Salary properrty setter we have for the Employee class restricts anything less than 15,000*/
}

```

Using this implementation, when you create a `CommissionEmployee` object and set its `CommissionRate`, 0 is sent to the `Employee` class `Salary` property. Because the value of the `salary` is less than 15000, the `Salary` property code forces the `salary` to 15000, `even though you want it to be 0`.

A possible alternative would be to rewrite the set accessor for the CommissionRate property in the Commission`Employee` class using the field salary instead of the property Salary, as follows:

```cs
set
{
    commissionRate = value;
    salary = 0; // will also get an error; field is private in other classes, even a child class
}
```

In this set accessor, you bypass the parent class’s `Salary` set accessor and directly use the `salary` field. However, when you include this accessor in a program and compile it, you receive an error message: `Employee.salary is inaccessible due to its protection level`. In other words, `Employee.salary` is `private`, and **_no other class can access it, even a child class_** of `Employee`.

So, in summary:

- Using the `public set` accessor in the parent class does not work because of the `minimum salary requirement`.

- Using the private field in the parent class does not work because it is `inaccessible`.

- Making the parent class field `public` would work, but doing so `would violate the principle of information hiding`.

Fortunately, there is a **fourth** option. The solution is to create the `salary` field with **protected access**, which provides you with an intermediate level of security between `public` and `private` access. **_A protected data field or method can be used within its own class or in any classes extended from that class, but it cannot be used by “outside” classes_**. In other words, `protected` members can be used “_within the family_”—by a class and its descendants.

Some sources say that `private`, `public`, and `protected` are access specifiers, while other class designations, such as `static`, are _access modifiers_. However, Microsoft developers, who created C#, use the terms interchangeably in their documentation.

Figure 10-7 shows how you can declare `salary` as `protected` within the `Employee` class so that it becomes legal to access it directly within the `CommissionRate` set accessor of the `CommissionEmployee` derived class. Figure 10-8 contains a `CommissionEmployee` class that inherits from the new `Employee` class and uses the protected field. Figure 10-9 shows a program that instantiates a `CommissionEmployee` object, and Figure 10-10 shows the output. Notice that the `CommissionEmployee`’s `salary` initially is set to 20_000 in the program, but the `salary` becomes 0 when the `CommissionRate` is set later.

```cs
/*
Figure 10-7
The Employee class with a protected field
*/

class Employee
{
    protected double salary; // protected salary
    public int value IdNum {get; set;}
    public double Salary
    {
        get
        {
            return salary;
        }
        set
        {
            const double MIN = 15_000;
            if(value < MIN)
                salary = MIN;
            else
                salary = value;
        }
    }
    public string GetGreeting()
    {
        string greeting = "Hello. I am employee #" + IdNum;
        return greeting;
    }
}


/*
Figure 10-8

Details
The CommissionEmployee class that uses its parent’s protected field
*/

class CommisionEmployee : Employee
{
    private double commissionRate;
    public double CommisionRate;
    {
        get
        {
            return commissionRate;
        }
        set
        {
            commissionRate = value;
            salary = 0; // CommissionEmployee can now use Employee;s protected salary field
        }
    }
}

/*
Figure 10-9
Open Image Viewer.
Details
The DemoCommissionEmployee program
*/

using static System.Console;
class DemoCommissionEmployee
{
    static void Main()
    {
        CommissionEmployee salesperson = new CommissionEmployee();
        salesperson.IdNum = 567;
        salesperson.Salary = 20_000.00; // we are using the base class setter
        salesperson.CommissionRate = 0.06; // this will desfault our salary to 0. we could initialize this first
        WriteLine("   Salesperson #{0} salary: {1} per year", salesperson.IdNum, salesperson.Salary.ToString("C"));
        WriteLine("...plus {0} commission on all sales", salesperson.CommissionRate.ToString("P"));
    }
}

/*
Figure 10-10

Details
Output of the DemoCommissionEmployee program

    Salesperson #567 salary: $0.00 per year
...plus 6.00 % commission on all sales
*/
```

If you set the salesperson’s `CommissionRate` first in the `DemoCommissionEmployee` program, then set `Salary` to a nonzero value, the commissioned employee’s `salary` will not be reduced to 0. If your intention is to always create CommissionEmployees with salaries of 0, then the `Salary` property should also be overridden in the derived class. You will learn about overriding parent class members in the next section.

Order matters:

If you set Salary first → salary becomes 20,000 (because the base class setter logic runs).

Then set CommissionRate → the derived class setter runs and forces salary = 0.

If you reverse the order (CommissionRate first, then Salary) → the base class setter overwrites the zero with 20,000.


Using the `protected` access specifier for a field can be convenient, and it also slightly improves program performance by using a field directly instead of “going through” property accessors. Also, using the `protected` access specifier is occasionally necessary. However, `protected` data members should be used sparingly. Whenever possible, the principle of information hiding should be observed, and **_even child classes should have to go through accessors to “get to” their parent’s private data_**. When child classes are allowed direct access to a parent’s fields, the likelihood of future errors increases. Classes that depend on field names from parent classes are said to be fragile because they are prone to errors—that is, they are easy to “break.”

[Back to parent](#understanding-inheritance) • [Back to TOC](#table-of-contents)

---

## Overriding Base Class Members

When you create a derived class by extending an existing class, the new derived class contains properties and methods that were defined in the original base class. Sometimes, the superclass features are not entirely appropriate for the subclass objects. `Using the same method or property name to indicate different implementations is called` **polymorphism**. You first learned the term polymorphism in Chapter 1; it means “many forms.” In programming, it means that many forms of action take place, even though you use the same method name. The specific method executed depends on the object.

Everyday cases provide many examples of **polymorphism**:

- Although both are musical instruments and have a `Play()` method, a guitar is played differently than a drum.

- Although both are vehicles and have an `Operate()` method, a bicycle is operated differently than a truck.

- Although both are schools and have a `SatisfyGraduationRequirements()` method, a preschool’s requirements are different from those of a college.

You understand each of these methods based on the context in which it is used. In a similar way, C# understands your use of the same method name based on the type of object associated with it.

For example, suppose that you have created a `Student` class as shown in Figure 10-11. `Students` have `names`, `credits` for which they are enrolled, and `tuition` amounts. You can set a `Student’s` `name` and `credits` by using the `set` accessors in the `Name` and `Credits` properties, but you cannot set a `Student’s` `tuition` directly because the `Tuition` property has no set accessor. Instead, `tuition` is calculated based on a standard `RATE` (of $55.75) for each credit that the `Student` takes. (In Figure 10-11, the `Student` fields that hold `credits` and `tuition` are declared as protected because a child class will use them.)`

```cs
/*
Figure 10-11
The Student class
*/

class Student
{
    // Tuition rate per credit (constant and private to this class)
    private const double RATE = 55.75;

    // Shared data that derived classes may need to adjust
    protected int credits;
    protected double tuition;

    // Public auto-implemented property for the student's name
    public string Name { get; set; }

    // Virtual property: derived classes can override how credits affect tuition
    public virtual int Credits
    {
        get
        {
            return credits;
        }
        set
        {
            credits = value;
            tuition = credits * RATE; // Default behavior: tuition based on RATE per credit
        }
    }

    // Read-only property: tuition is derived, not set directly
    public double Tuition
    {
        get
        {
            return tuition;
        }
    }
}


```

In Figure 10-11, `Credits` is declared to be `virtual` (see shading).**_ A virtual method (or property) is one that can be overridden by a method with the same signature in a child class_**. In Chapter 9, you learned that when a method overrides another, it takes precedence over the method.

Suppose that you derive a subclass from Student called `ScholarshipStudent`, as shown in Figure 10-12. A ``ScholarshipStudent`` has a `name`, `credits`, and `tuition`, but the tuition is not calculated in the same way as it is for a `Student`; instead, tuition for a `ScholarshipStudent` should be set to 0. You want to use the `Credits` property to set a `ScholarshipStudent`’s `credits`, but you want the property to behave differently than the parent class `Student’s` `Credits` property. As a child of `Student`, a `ScholarshipStudent` possesses all the attributes, properties, and methods of a `Student`, but its Credits property behaves differently.

```cs
// ScholarshipStudent.cs
// Derived class that overrides how credits affect tuition (polymorphism).
// Scholarship students pay no tuition regardless of credits.

class ScholarshipStudent : Student
{
    public override int Credits
    {
        // Optional getter for completeness — still returns the protected backing field
        get
        {
            return credits;
        }
        set
        {
            credits = value;
            tuition = 0; // Override base behavior: tuition is always zero. This ispossible due to protected access in the base class
        }
    }
}
```


In C#, you can use either new or override when defining a derived class member that has the same name as a base class member, but you cannot use both together. When you write a statement such as ScholarshipStudent s1 = new ScholarshipStudent();, you won’t notice the difference. However, if you use new when defining the derived class Credits property and write a statement such as Student s2 = new ScholarshipStudent(); (using Student as the type), then s2.Credits accesses the base class property. On the other hand, if you use override when defining Credits in the derived class, then s2.Credits uses the derived class property.

In the child ScholarshipStudent class in Figure 10-12, the Credits property is declared with the override modifier (see shading) because it has the same header (that is, the same signature—the same name and parameter list) as a property in its parent class. The Credits property overrides and hide its counterpart in the parent class. (You could do the same thing with methods.) If you omit override, the program still will operate correctly, but you will receive a warning that you are hiding an inherited member with the same name in the base class. Using the keyword override eliminates the warning and makes your intentions clear. When you use the Name property with a ScholarshipStudent object, a program uses the parent class property Name; it is not hidden. However, when you use Credits to set a value for a ScholarshipStudent object, the program uses the new, overriding property from its own class.

Clip
If credits and tuition had been declared as private within the Student class, then ScholarshipStudent would not be able to use them.

You are not required to override a virtual method or property in a derived class; a derived class can simply use the base class version. A base class member that is not hidden by the derived class is visible in the derived class.

Figure 10-13 shows a program that uses Student and ScholarshipStudent objects. Even though each object assigns the Credits property with the same number of credit hours (in the two shaded statements), the calculated tuition values are different because each object uses a different version of the Credits property. Figure 10-14 shows the execution of the program.

```cs
// DemoStudents.cs
// Demonstrates polymorphism: base class computes tuition; derived class overrides to zero.

using static System.Console;

class DemoStudents
{
    static void Main()
    {
        // Base class student: tuition calculated as credits * RATE
        Student payingStudent = new Student();
        payingStudent.Name = "Megan";
        payingStudent.Credits = 15;

        // Derived class student: tuition overridden to zero
        ScholarshipStudent freeStudent = new ScholarshipStudent();
        freeStudent.Name = "Luke";
        freeStudent.Credits = 15;

        WriteLine("{0}'s tuition for {1} credits is {2}",
            payingStudent.Name, payingStudent.Credits,
            payingStudent.Tuition.ToString("C"));

        WriteLine("{0}'s tuition for {1} credits is {2}",
            freeStudent.Name, freeStudent.Credits,
            freeStudent.Tuition.ToString("C"));
    }
}

```
If a base class and a derived class have methods with the same names but different parameter lists, then the derived class method does not override the base class method; instead, it overloads the base class method. For example, if a base class contains a method with the header `public void Display()`, and its child contains a method with the header `public void Display(string s)`, then the child class would have access to both methods. (You learned about overloading methods in the chapter “Advanced Method Concepts.”)

Perfect, Israel 😎 — let’s wrap everything we’ve covered on **overwriting base class members** into one clear, structured explanation. Think of this as your “cheat sheet” for the whole page.

---

🧩 1. Inheritance Basics
- A **derived (child) class** inherits all accessible members from its **base (parent) class**:
  - Public members → always visible to outside code and children.
  - Protected members → visible only inside the parent and its children.
  - Private members → visible only inside the parent itself.
- The child can either **use** the parent’s members as-is, or **customize** them.

---

🔄 **2. Virtual + Override = Polymorphism**
- **Virtual** (in base class) → marks a method/property as replaceable.  
- **Override** (in child class) → replaces the parent’s version with new behavior.  
- This is **true polymorphism**:  
  - Same name, same signature.  
  - Which version runs depends on the actual object type at runtime.  
- Example:

  ```csharp
  class Student
  {
      public virtual int Credits { get; set; }
  }

  class ScholarshipStudent : Student
  {
      public override int Credits
      {
          set { credits = value; tuition = 0; }
      }
  }
  ```

---

🆕 **3. The `new` Keyword (Hiding**)
- If you use `new` instead of `override`:
  - The child defines a member with the same name, but it **hides** the parent’s version.  
  - If the variable is declared as the parent type, the parent’s version runs.  
  - If the variable is declared as the child type, the child’s version runs.  
- This is **not polymorphism** — it’s just hiding.

---

🧠 **4. Declared Type vs. Actual Object Type**
- Declared type = the type written before the variable name.  
- Actual object type = the class used after `new`.  
- Example:
  ```csharp
  Student s2 = new ScholarshipStudent();
  ```
  - Declared type = `Student`.  
  - Actual object type = `ScholarshipStudent`.  
- With `override` → child’s version runs even though declared type is `Student`.  
- With `new` → parent’s version runs because declared type is `Student`.

---

➕ **5. Overloading vs. Overriding**
- **Overriding** → same name, same signature, replaces parent’s behavior.  
- **Overloading** → same name, different parameter list, both versions coexist.  
- Example:
  ```csharp
  class Base { public void Display() { } }
  class Child : Base { public void Display(string s) { } }
  ```
  → Child has access to both `Display()` and `Display(string)`.

---

🛡️ **6. Protected Fields and Properties**
- Protected fields (like `credits` and `tuition`) allow child classes to manipulate them directly.  
- Public properties (like `Credits`, `Tuition`) are the “channels” outside code uses.  
- No setter on `Tuition` means outside code can only **read** tuition, not set it.  
- Tuition is always updated internally when `Credits` changes.

---

✨ **7. Why Override Is Better**
- `override` makes your intention clear: you’re replacing the parent’s behavior.  
- It ensures polymorphism works consistently, even when variables are declared as the parent type.  
- `new` only hides and can cause confusion — the compiler even warns you about it.  
- Best practice: use `override` when you want different behavior, use `new` only when you truly intend to hide.

---

**🎯 Big Picture Summary**
- Inheritance gives child classes all the parent’s members.  
- Virtual + override = polymorphism (child replaces parent behavior).  
- New = hiding (child defines a separate member, parent still runs if declared type is parent).  
- Declared type vs. actual object type determines which version runs.  
- Overloading = same name, different parameters, both versions coexist.  
- Protected fields = accessible to children, private fields = not.  
- Override is the clean, consistent way to customize base class members.

---


[Back to TOC](#table-of-contents)






### Accessing Base Class Methods and Properties from a Derived Class

When a derived class contains a method or property that overrides a parent class method or property, you might have occasion to use the parent class version within the subclass. If so, you can use the keyword `base` to access the parent class method or property.

For example, recall the `GetGreeting()` method that appears in the `Employee` class in Figure 10-7. If its child, `CommissionEmployee`, also contains a `GetGreeting()` method, as shown in Figure 10-15, then within the `CommissionEmployee` class you can call `base.GetGreeting()` to access the `base` class version of the method. Figure 10-16 shows an application that uses the method with a `CommissionEmployee` object. Figure 10-17 shows the output.

```cs

// Figure 10-15
// The CommissionEmployee class with a GetGreeting() method

class CommmissionEmployee : Employee
{
    private double commissionRate;
    public double CommissionRate;
    {
        get
        {
            return commissionRate;
        }
        set
        {
            commissionRate = value;
            salary = 0;
        }
    }
    new public string GetGreeting() // Keyword new in method header eliminates compiloe warning when base class method id overridden
    {
        string greeting = base.GetGreeting(); // This statement call the parent's version method.
        greeting = += "\nI work on commission.";
        return greeting;
    }
}

// Figure 10-16
// The DemoCommissionEmployee2 program

using static System.Console;
class DemoCommissionEmployee2
{
    static void main()
    {
        CommissionEmployee salesperson = new CommissionEmployee();
        salesperson.IdNum = 345;
        WriteLine(salesperson.GetGreeting());
    }
}

// Figure 10-17
// Output of the DemoCommissionEmployee2 program

Hello, I am employee 345
I work on commission.

```

In Figure 10-15, the child class, the `GetGreeting()` method uses the keyword `new` in its header to eliminate a compiler warning. Then, within the method, the parent’s version of the GetGreeting() method is called. The returned string is stored in the greeting variable, and then an I work on commission. statement is concatenated before the complete message is returned to the calling program. By overriding the base class method in the child class, the duplicate typing to create the first part of the message is eliminated. Additionally, if the first part of the message is altered in the future, it will be altered in only one place—in the base class.

Watch the video Handling Methods and Inheritance.

Perfect, Israel 😎 — let’s break this page down with the same clarity we used before. This section is all about **using the `base` keyword** when overriding or hiding parent class members.

---

## 🧩 1. Why `base` Exists
- When a child class overrides (or hides) a parent method/property, sometimes you still want to **reuse the parent’s version** inside the child.  
- The keyword **`base`** lets you explicitly call the parent’s implementation.  
- This avoids duplicating code and ensures that if the parent logic changes, the child automatically benefits.

---

## 🔄 2. Example: Employee → CommissionEmployee
- **Employee class** has a method:
  ```csharp
  public string GetGreeting()
  {
      return "Hello. I am employee #" + IdNum;
  }
  ```
- **CommissionEmployee class** defines its own `GetGreeting()`:
  ```csharp
  new public string GetGreeting()
  {
      string greeting = base.GetGreeting(); // call parent’s version
      greeting += "\nI work on commission.";
      return greeting;
  }
  ```
- Notice:
  - The child uses `new` in the header to hide the parent’s method (avoids compiler warning).  
  - Inside, it calls `base.GetGreeting()` to reuse the parent’s message.  
  - Then it appends its own message.

---

## 🛠️ 3. Demo Program
```csharp
class DemoCommissionEmployee2
{
    static void Main()
    {
        CommissionEmployee salesperson = new CommissionEmployee();
        salesperson.IdNum = 345;
        WriteLine(salesperson.GetGreeting());
    }
}
```

### Output:
```
Hello. I am employee #345
I work on commission.
```

---

## ✨ 4. Why This Is Better
- Without `base`, you’d have to retype the entire “Hello. I am employee #…” logic in the child class.  
- With `base`, you reuse the parent’s code and just add the extra line.  
- If the parent’s message changes in the future (say, “Greetings, employee #…”), the child automatically inherits the change.  
- This keeps code **DRY** (Don’t Repeat Yourself) and easier to maintain.

---

## 🎯 5. Key Takeaways
- **`base` keyword** → lets child classes call parent implementations.  
- **`new` keyword** → hides the parent’s method, but you can still reach it with `base`.  
- **Benefit** → reuse parent logic, avoid duplication, and ensure consistency if parent code changes.  
- **Output** → child method combines parent’s message with its own.

---

So this page is teaching you:  
- How to **reuse parent methods inside child methods** using `base`.  
- Why this is cleaner and more maintainable than duplicating code.  
- How `new` + `base` work together: `new` hides, `base` retrieves.

---

``` cs
// You Do It:

// Allows use of WriteLine() without prefixing Console.
using static System.Console;

class Loan
{
    // Auto-implemented properties for Loan data.
    public int LoanNumber { get; set; }       // Unique loan identifier
    public string LastName { get; set; }      // Borrower's last name
    protected double loanAmount;               // if this was private, we would not be able to set its value in the child CarLoan.
    // you could use public for loanAmount, but the base would force 5000!
    public const double MINIMUM_LOAN = 5_000; // represents the min allowed
    public double LoanAmount
    {
        set
        {
            if(value < MINIMUM_LOAN)
                loanAmount = MINIMUM_LOAN;
            else
                loanAmount = value;
        }
        get
        {
            return loanAmount;
        }
    }
}

// CarLoan extends Loan, inheriting all Loan properties and adding new ones.
class CarLoan : Loan
{
    private const int EARLIEST_YEAR = 2008;
    private const int LOWEST_INVALID_NUM = 1000;
    public string Make { get; set; }          // Make of the car (Ford, Honda, etc.)
    public int Year
    {
        set
        {
            if(value < EARLIEST_YEAR)
            {
                year = value;
                loanAmount = 0;
            }
            else
                year = value;
        }
        get
        {
            return year;
        }
    }
}

class DemoCarLoan2
{
    static void Main()
    {
        // Create a Loan object
        Loan aLoan = new Loan();                      // Base Loan object
        aLoan.LoanNumber = 2239;                      // Loan number assignment
        aLoan.LastName = "Mitchell";                  // Borrower name assignment
        aLoan.LoanAmount = 1000;                      // Amount borrowed

        // Display Loan data using composite formatting
        WriteLine("Loan #{0} for {1} is for {2}", 
            aLoan.LoanNumber, 
            aLoan.LastName, 
            aLoan.LoanAmount.ToString("C2"));         // "C2" formats as currency

        // Create a CarLoan object (inherits from Loan)
        CarLoan aCarLoan = new CarLoan();              // Derived class object
        aCarLoan.LoanNumber = 3358;                   // Inherited property from Loan
        aCarLoan.LastName = "Janssen";                // Inherited property from Loan
        aCarLoan.LoanAmount = 20000;                  // Inherited property from Loan
        aCarLoan.Make = "Ford";                       // Property unique to CarLoan
        aCarLoan.Year = 2007;                         // Property unique to CarLoan

        // Display CarLoan data using same composite formatting style
        WriteLine("Loan #{0} for {1} is for {2}", 
            aCarLoan.LoanNumber, 
            aCarLoan.LastName, 
            aCarLoan.LoanAmount.ToString("C2"));

        WriteLine("Automobile: {0} {1}", 
            aCarLoan.Year, 
            aCarLoan.Make);
    }
}


```
[Back to parent](#overriding-base-class-members) • [Back to TOC](#table-of-contents)




### Understanding Implicit Reference Conversions

Every derived object “is a” specific instance of both the derived class and the base class. In other words, `myCar` “is a” `Car` as well as a `Vehicle`, and `myDog` “is a” `Dog` as well as a `Mammal`. You can assign a derived class object to an object of `any of its superclass types`. When you do, C# makes an **implicit conversion** from derived class to base class.

You have already learned that C# also makes implicit conversions when casting one data type to another. For example, in the statement `double money = 10;`, the integer value 10 is `implicitly converted (or cast)` to a `double`. When a derived class object is assigned to its ancestor’s data type, the conversion can more specifically be called an **implicit reference conversion**. This term is more accurate because it emphasizes the difference between numerical conversions and reference objects. **_When you assign a derived class object to a base class type, the object is treated as though it had only the characteristics defined in the base class and not those added in the child class definition_**.

For example, when a `CommissionEmployee` class inherits from `Employee`, an object of either type can be passed to a method that accepts an `Employee` parameter. In Figure 10-19, an `Employee` is passed to `DisplayGreeting()` in the first shaded statement, and a `CommissionEmployee` is passed in the second shaded statement. Each is referred to as `emp` within the method, and each is used correctly, as shown in Figure 10-20.

```cs
/*
Figure 10-19
The DemoCommissionEmployee3 program
*/

using static System.Console
class DemoCommissionEmployee3
{
    static void Main()
    {
        Employee clerk = new Employee();
        CommisionEmployee salesPerson = new CommisionEmployer();
        clerk.IdNum = 234;
        salesPerson.IdNum = 345;
        DisplayGreeting(clerk);
        DisplayGreeting(salesperson);
    }

    public static void DisplayGreeting(Employee emp) // Both an Employee and a CommissionEmployee can be passed to this method.
    {
        WriteLine("Hi there from #" + emp.IdNum);
        WriteLine(emp.GetGreeting());
    }
}

//Figure 10-20
OUTPUT
Hi there from #234
Hello. I am employee #234
Hi there from #345
Hello. I am employee # 345

```
[Back to parent](#overriding-base-class-members) • [Back to TOC](#table-of-contents)

---











## Using the Object Class

Every class you create in C# derives from a single class named `System.Object`. In other words, the **object** (or **Object**) class type in the `System` namespace is the **_ultimate base class_**, or **_root class_**, for all other types. When you create a class such as `Employee`, you usually use the header class `Employee`, which implicitly, or automatically, descends from the `Object` class. Alternatively, you could use the header class `Employee : Object` to explicitly show the name of the base class, but it would be _extremely unusual_ to see such a format in a C# program.

The keyword `object` is an alias for the `System.Object` class. You can use the lowercase and uppercase versions of the class interchangeably. The fact that object is an alias for `System.Object` should not surprise you. You already know, for example, that `int` is an alias for `Int32` and that `double` is an alias for `Double`.

Because every class descends from `Object`, every object “is an” `Object`. As proof, you can write a method that accepts an argument of type `Object`, and it `will accept arguments of any type`. Figure 10-21 shows a program that declares three objects using classes created earlier in this chapter—a `Student`, a `ScholarshipStudent`, and an `Employee`. Even though these types possess different attributes and methods (and one type, `Employee`, has nothing in common with the other two), each type can serve as an argument to the `DisplayObjectMessage()` because each type “is an” `Object`. Figure 10-22 shows the execution of the program.

```cs
// Figure 10-21
// The DiverseObjects program

using System;
using static System.Console;

class DiverseObjects
{
    static void Main()
    {
        Student payingStudent = new Student();
        ScholarshipStudent freeStudent = new ScholarshipStudent();
        Employee clerk = new Employee();

        Write("Using Student: ");
        DisplayObjectMessage(payingStudent);

        Write("Using ScholarshipStudent: ");
        DisplayObjectMessage(freeStudent);

        Write("Using Employee: ");
        DisplayObjectMessage(clerk);
    }

    public static void DisplayObjectMessage(Object o)
    {
        WriteLine("Method successfully called");
    }
}

// Example placeholder classes
class Student { }
class ScholarshipStudent { }
class Employee { }

// Figure 10-22
// Output of the DiverseObjects program

```
When you create any child class, it inherits all the methods of all of its ancestors. Because all classes inherit from the `Object` class, all classes inherit the `Object` class methods. The Object class contains a constructor, a destructor, and four `public` instance methods, as summarized in Table 10-1.

### Table 10-1: The Four Public Instance Methods of the `Object` Class

| Method       | Explanation                                                                 |
|--------------|-----------------------------------------------------------------------------|
| `Equals()`   | Determines whether two `Object` instances are equal                         |
| `GetHashCode()` | Gets a unique code for each object; useful in certain sorting and data management tasks |
| `GetType()`  | Returns the type, or class, of an object                                    |
| `ToString()` | Returns a `String` that represents the object                               |

The `Object` class contains other nonpublic and noninstance (static) methods in addition to the four methods listed in Table 10-1. The C# documentation provides more details on these methods.

[Back to TOC](#table-of-contents)





### Using the Object Class’s GetType() Method

The `GetType()` method returns an object’s type, or class. For example, if you have created an `Employee` object named `someWorker`, then the following statement displays `Employee` :

```cs
WriteLine(someWorker.GetType());
```

If an object’s class is defined in a namespace, then `GetType()` returns a string composed of the namespace, a dot, and the class name.

[Back to parent](#using-the-object-class) • [Back to TOC](#table-of-contents)





### Using the `Object` Class’s ToString() Method

The `Object` class methods are not very useful as they stand. For example, when you use the Object class’s `ToString()` method with an object you create, it `simply returns a string that holds the name of the class, just as GetType() does`. That is, if `someWorker` is an `Employee`, then the following statement displays `Employee` `:`
```cs

WriteLine(someWorker.ToString());

```
When you create a class such as `Employee`, you often want to override the `Object` class’s `ToString()` method with your own, **more useful version**—perhaps one that returns an `Employee’s` ID number, name, or combination of the two. Of course, you could create a differently named method to do the same thing—perhaps `GetEmployeeIdentification()` or `ConvertEmployeeToString()`. However, by naming your class method `ToString()`, you make the class easier for others to understand and use. Programmers know the ToString() method works with every object; when they use it with your objects, you can provide a useful set of information. A class’s `ToString()` method is often a useful debugging aid.

For example, you might create an `Employee` class `ToString()` method, as shown in Figure 10-23. This method assumes that `IdNum` and `Name` are `Employee` properties with get accessors. The returned string will have a value such as `Employee: 234 Johnson`.

```cs
// Figure 10-23
// An Employee class ToString() method

public override string ToString() // what this is doing is overriding the Object class ToString() method, instead of returning just the class name, 
// it returns a more useful string with the employee's IdNum and Name. we do this by using the return statement. inside the return statement we
// call the getType() method to get the class name, then concatenate it with the IdNum and Name properties.
{
    return(getType() + ": " + IdNum + " " + Name);
}


```


You have been using an overloaded version of the `ToString()` method since Chapter 2. There, you learned that you can format numeric output when you pass a string such as `“F3”` or `“C2”` to the `ToString()` method.

Perfect — let’s slow this down and make it crystal clear. You’re asking exactly the right questions: *where does `virtual` come in, what’s being overridden, and when is `ToString()` actually used?*  

---

🔹 **1. Why `ToString()` Can Be Overridden**

- In C#, a method must be marked `virtual` (or `abstract`) in the base class for derived classes to override it.
- In the `Object` class, **`ToString()` is declared as `public virtual string ToString()`**.
- That’s why you can write:
  ```cs
  public override string ToString()
  {
      return "Employee: " + IdNum + " " + Name;
  }
  ```
- The keyword `override` in your class says: *“I’m replacing the base class’s virtual implementation with my own.”*

So yes — the `virtual` keyword is in the `Object` class definition, not in your code. That’s what makes overriding possible.

---

🔹**2. What Is Being Overridden?**

- You’re overriding the **default implementation** of `ToString()` that comes from `Object`.
- By default, `Object.ToString()` just returns the class name (like `"Employee"`).
- Your override replaces that behavior with something more useful (like `"Employee: 234 Johnson"`).

---

🔹**3. When Is `ToString()` Used?**

Here’s the key: `ToString()` is automatically called in many situations where an object needs to be represented as text.

Examples:

**Example A: Explicit Call**

```cs
Console.WriteLine(emp.ToString());
```
Output:  
`Employee: 234 Johnson`

---

**Example B: Implicit Call in `WriteLine`**

```cs
Console.WriteLine(emp);
```
Output:  
`Employee: 234 Johnson`  
👉 `WriteLine` automatically calls `ToString()` on objects.

---

**Example C: String Interpolation**

```cs
string msg = $"Employee info: {emp}";
Console.WriteLine(msg);
```
Output:  
`Employee info: Employee: 234 Johnson`  
👉 Interpolation calls `ToString()` under the hood.

---

**Example D: Debugging**

```cs
List<Employee> staff = new List<Employee> { emp1, emp2 };
Console.WriteLine(string.Join(", ", staff));
```
Output:  
`Employee: 234 Johnson, Employee: 567 Smith`  
👉 `string.Join` calls `ToString()` on each object.

---

🔹 **4. Your Example with `GetType()`**

In your earlier code:
```cs
public override string ToString()
{
    return GetType() + ": " + IdNum + " " + Name;
}
```
- `GetType()` returns the runtime type name (`Employee`).
- Then you concatenate with `IdNum` and `Name`.
- So the output looks like:  
  `Employee: 234 Johnson`

---

✅ **Key Takeaway**

- `Object.ToString()` is **virtual**, so you can override it.  
- You’re overriding the **default behavior** (class name only).  
- It’s used whenever an object is converted to a string — explicitly or implicitly (logging, debugging, interpolation, etc.).  
- Overriding makes your objects self-describing, which is why it’s so universally useful.

---

Israel, since you’re building teaching diagrams, here’s a mental analogy:  
Think of `ToString()` as the **nametag** every object wears. By default, the nametag just says “Employee.” When you override it, you can write “Employee: 234 Johnson” — suddenly, everyone knows who that object really is without asking extra questions.


[Back to parent](#using-the-object-class) • [Back to TOC](#table-of-contents)




### Using the Object Class’s Equals() Method

The `Equals()` method compares objects for **reference equality**. Reference equality **_occurs when two reference type objects refer to the same object_**. The Equals() method returns `true` if two `Objects` have the `same memory address`—that is, **_if one object is a reference to the other and both are literally the same object_**. For example, you might write the following:

```cs
if(oneObject.Equals(anotherObject))...
```


Like the `ToString()` method, this method might not be useful to you in its original form. For example, you might prefer to think of _two_ `Employee` _objects at unique memory addresses as equal_ **_if their ID numbers or first and last names are equal_**. You might want to override the `Equals()` method for any class you create if you anticipate that class clients will want to compare objects based on any of their field values.

If you overload the `Equals()` method, it should meet the following requirements by convention:

- Its header should be as follows (you can use any identifier for the `Object` parameter):

```cs
public override bool Equals(Object o)
```



- It should return `false` if the argument is `null`.

- It should return `true` if an object is compared to itself.

- It should return `true` only if both of the following are true:

```cs
oneObject.Equals(anotherObject)
anotherObject.Equals(oneObject)
```

- If `oneObject.Equals(anotherObject)` returns `true` and `oneObject.Equals(aThirdObject)` returns `true`, then `anotherObject.Equals(aThirdObject)` should also be `true`.

You first used the `Equals()` method to compare `String` objects in Chapter 2. When you use `Equals()` with `Strings`, you use the `String` class’s `Equals()` method that compares `String` contents as opposed to `String` addresses. In other words, the Object class’s `Equals()` method has already been overridden in the `String` class.

When you create an `Equals()` method to override the one in the `Object` class, the parameter must be an Object. For example, if you consider `Employee` objects equal when their `IdNum` properties are equal, then an `Employee` class `Equals()` method might be created as follows:

```cs

public override bool Equals(Object e)
{
    bool isEqual;
    Employee temp = (Employee)e;
    if(IdNum == temp.IdNum)
        isEqual == true;
    else
        isEqual = false;
    return isEqual;
}

```


In the shaded statement in the method, the `Object` parameter is cast to an `Employee` so the `Employee’s` `IdNum` can be compared. If you did not perform the cast and tried to make the comparison with `e.IdNum`, the method would not compile because an `Object` does not have an `IdNum` property.

An even better alternative is to ensure that compared objects are the same type before making any other decisions. For example, the `Equals()` method in Figure 10-24 uses the `GetType()` method with both the `this` object and the parameter before proceeding. If compared objects are not the same type, then the `Equals()` method should return false.

```cs
// Figure 10-24
// An Equals() method for the Employee class

public override bool Equals(Object e)
{
    bool isEqual = true;
    if(this.GetType() != e.GetType())
        isEqual = false;
    else
    {
        Employee temp = (employee)e;
        if(IdNum == temp.IdNum)
            isEqual = true;
        else
            isEqual = false;
    }
    return isEqual;
    
}

```

[Back to parent](#using-the-object-class) • [Back to TOC](#table-of-contents)





### Using the `Object` Class’s `GetHashCode()` Method

When you override the `Equals()` method, you should also override the `GetHashCode()` method, because` Equals()` uses` GetHashCode()`, and **_two objects considered equal should have the same hash code_**. A **hash code** is `a number that should uniquely identify an object`; you might use hash codes in some advanced C# applications. For example, Figure 10-25 shows an application that declares two `Employees` from a class in which the `GetHashCode()` method has not been overridden. The output in Figure 10-26 shows a unique number for each object. (The number, however, is meaningless to you.) If you choose to override the `GetHashCode()` method, you should write this method so it returns a unique integer for every object—an `Employee` ID number, for example.

```cs
//Figure 10-25
//The TestHashCode program

using static System.Console;
class TestHashCode
{
    static void Main()
    {
        Employee first = new Employee();
        Employee second = new Employee();
        WriteLine("First hash code " + first.GetHashCode());
        WriteLine("Second hash code " + second.GetHashCode());
    }
}


//Figure 10-26
//Output of the TestHashCode program
First hash code 21083178
Second hash code 55530882
```


A hash code is sometimes called a _fingerprint_ for an object because it uniquely identifies the object. In C#, the default implementation of the `GetHashCode()` method does not guarantee unique return values for different objects. However, if `GetHashCode()` is explicitly implemented in a derived class, it must return a unique hash code.

In cooking, hash is a dish that is created by combining ingredients. The term hash code derives from the fact that the code is sometimes created by mixing some of an object’s data.

Although you can write an `Equals()` method for a class without overriding `GetHashCode()`, you receive a warning message. Additionally, if you overload == or != for a class, you will receive warning messages if you do not also override both the `Equals()` and `GetHashCode()` methods.


#### Breakdown on Hash Code

Perfect — these two images show exactly what’s happening in the **default `GetHashCode()` behavior** and why overriding it matters. Let’s unpack it line by line and make the connection clear.

---

🧩 **Using the `Object` Class’s `GetHashCode()` Method**

 Default behavior demonstration

```csharp
// Figure 10-25
// TestHashCode program showing default hash codes
using static System.Console;

class TestHashCode
{
    static void Main()
    {
        // Create two separate Employee objects.
        // Even though both are empty, they occupy different memory locations.
        Employee first = new Employee();
        Employee second = new Employee();

        // Display each object's hash code.
        // Since we haven't overridden GetHashCode(), these numbers
        // are automatically generated by the Object base class.
        WriteLine("First hash code  " + first.GetHashCode());
        WriteLine("Second hash code " + second.GetHashCode());
    }
}

// Empty Employee class for this example.
class Employee
{
    // No override yet — using the inherited GetHashCode() from System.Object.
}
```

 Output (Figure 10-26)

```
First hash code  21083178
Second hash code 55530882
```

Each number represents a **hash code** — a numeric “fingerprint” assigned to each object.
They’re different because:

* `first` and `second` are two separate instances in memory.
* The **default `GetHashCode()`** method simply generates an internal number tied to the object’s memory address (or runtime handle).

---

🔍 **What’s Really Happening**

Every object in C# inherits a version of `GetHashCode()` from `System.Object`.
That version does *not* guarantee uniqueness, but it’s *different enough* for the runtime to distinguish between objects during hashing operations (like in dictionaries or sets).

Think of it like a **temporary barcode** assigned by the system.
You didn’t print the barcode yourself, but it still helps the runtime identify which object is which.

---

🧠 **Why Override `GetHashCode()`**

When you override `Equals()`, you define what makes two objects *conceptually equal* —
but to maintain consistency, those equal objects must also share the *same* hash code.

If you don’t override `GetHashCode()` along with `Equals()`, you can run into strange bugs when storing your objects in collections like `Dictionary`, `HashSet`, or `List.Contains()`.

 Example: overriding both

```csharp
// Employee class with overridden Equals() and GetHashCode()
class Employee
{
    public int IdNum { get; set; }
    public string Name { get; set; }

    // Define equality logic: Employees are equal if they share the same IdNum.
    public override bool Equals(object obj)
    {
        if (obj == null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (this.GetType() != obj.GetType()) return false;

        Employee other = (Employee)obj;
        return this.IdNum == other.IdNum;
    }

    // Return the same hash code for equal IdNum values.
    // This ensures that Equals() and GetHashCode() agree.
    public override int GetHashCode()
    {
        // The HashCode.Combine() method mixes multiple fields safely.
        return HashCode.Combine(IdNum, Name);
    }
}
```

 Test program:

```csharp
class TestHashCodeOverride
{
    static void Main()
    {
        Employee e1 = new Employee { IdNum = 101, Name = "Israel" };
        Employee e2 = new Employee { IdNum = 101, Name = "Israel" };

        // Even though these are separate instances, they’re equal by our definition.
        WriteLine("e1.Equals(e2)? " + e1.Equals(e2));

        // Because we overrode GetHashCode(), they now produce the same hash value.
        WriteLine("e1.GetHashCode(): " + e1.GetHashCode());
        WriteLine("e2.GetHashCode(): " + e2.GetHashCode());
    }
}
```

 Output:

```
e1.Equals(e2)? True
e1.GetHashCode(): 202384712
e2.GetHashCode(): 202384712
```

---

💡 Key Takeaways

| Concept                  | Explanation                                                                                                  |
| ------------------------ | ------------------------------------------------------------------------------------------------------------ |
| **Hash Code**            | An integer “fingerprint” that helps identify an object in memory.                                            |
| **Default Behavior**     | Each object gets a unique number, but the number is meaningless and not guaranteed to be unique across runs. |
| **Override Requirement** | If you override `Equals()`, you *must* override `GetHashCode()` to maintain consistency.                     |
| **Good Practice**        | Use fields that define identity (like ID numbers) to calculate the hash code.                                |
| **Helper**               | `HashCode.Combine()` (C# 7.3+) safely mixes multiple fields into one hash code.                              |

---

So, in simple terms:

* Without an override: hash codes just reflect different memory slots.
* With an override: you make hash codes *meaningful*, aligning with your custom definition of equality.

Would you like me to show how `GetHashCode()` behaves differently inside a `HashSet<Employee>` before and after overriding it? It’s a great way to visualize why this rule matters.


[Back to parent](#using-the-object-class) • [Back to TOC](#table-of-contents)

---









## Working with Base Class Constructors

When you create any object, you call a constructor that has the same name as the class itself. Consider the following example:

```cs
SomeClass anObject = new SomeClass();

```

When you instantiate an object that is a member of a derived class, `the constructor for the base class executes first`, and `then the derived class constructor executes`. In other words, when you create any object, you always implicitly call the `Object` constructor because all classes are derived from `Object`. So, when you create a base class and a derived class, and instantiate a derived class object, **you call three constructors**: one from the `Object` class, one from the `base class`, and one from the `derived class`.

In the examples of inheritance you have seen so far in this chapter, each class contained only default constructors, so their executions were transparent. However, you should realize that `when you create a subclass instance, both the base and derived constructors execute`. For example, consider the abbreviated `Employee` and `CommissionEmployee` classes in Figure 10-27. `Employee` contains just two fields and a constructor; `CommissionEmployee` descends from `Employee` and contains a constructor as well. The `DemoCommissionEmployee4` program in Figure 10-28 contains just one statement; it instantiates a `CommissionEmployee`. The output in Figure 10-29 shows that this one statement causes both constructors to execute.


```cs

//Figure 10-27
//The Employee and CommissionEmployee classes with parameterless constructors

class Employee
{
    private int idNum;           // Only the Employee class can access this
    protected double salary;     // Derived classes can also access this

    public Employee()
    {
        WriteLine("Employee constructed");
    }
}

class CommissionEmployee : Employee
{
    private double commissionRate;

    public CommissionEmployee()
    {
        WriteLine("CommissionEmployee constructed");
    }
}


//Figure 10-28
//The DemoCommissionEmployee4 program

using static System.Console;

class DemoCommissionEmployee4
{
    static void Main()
    {
        // This single statement triggers a sequence of constructor calls
        CommissionEmployee salesperson = new CommissionEmployee();
    }
}


//Figure 10-29
//Output of the DemoCommissionEmployee4 program

Employee constructed
CommissionEmployee constructed


```


Of course, most constructors perform many more tasks than displaying a message to inform you that they exist. When constructors initialize variables, you usually want the base class constructor to initialize the data fields that originate in the base class. The derived class constructor needs to initialize only the data fields that are specific to the derived class.



Excellent question — and this is one of those “aha” moments every C# programmer eventually hits. You’re absolutely right that `base.id` *and* `: base(...)` both use the keyword `base`, but they serve completely different purposes.

Let’s untangle this cleanly.

---

## 🧱 Two Meanings of `base` — *Different Situations, Same Keyword*

### 1. `base.id` — **Accessing a base class member**

Used **inside a derived class’s method or property** to access something (a field, property, or method) *declared in the base class*.

Think of it like saying:

> “Hey, I want to use my parent’s version of this.”

```csharp
class Employee
{
    protected double salary = 40000;

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Base salary: {salary}");
    }
}

class CommissionEmployee : Employee
{
    private double commissionRate = 0.10;

    public override void DisplayInfo()
    {
        // Accessing a field from the base class
        Console.WriteLine($"Base salary: {base.salary}");

        // Optionally call the base class version of DisplayInfo()
        base.DisplayInfo();

        Console.WriteLine($"Commission rate: {commissionRate}");
    }
}
```

Here, `base.salary` and `base.DisplayInfo()` both mean:

> “Use the version that lives in the **Employee** class.”

---

### 2. `: base(...)` — **Calling the base class constructor**

Used **in the header of a derived class constructor** to explicitly call a *specific* base class constructor (especially one that takes parameters).

Think of it like saying:

> “Before I build my part of the object, call my parent’s constructor and pass these values to it.”

```csharp
class Employee
{
    protected int idNum;
    protected double salary;

    // Base class constructor with parameters
    public Employee(int id, double sal)
    {
        idNum = id;
        salary = sal;
        Console.WriteLine($"Employee constructed with ID {id} and salary {sal:C}");
    }
}

class CommissionEmployee : Employee
{
    private double commissionRate;

    // Derived class constructor calls the base class constructor FIRST
    public CommissionEmployee(int id, double sal, double rate)
        : base(id, sal) // 👈 this calls Employee(int, double)
    {
        commissionRate = rate;
        Console.WriteLine($"CommissionEmployee constructed with rate {rate:P}");
    }
}
```

Output:

```
Employee constructed with ID 101 and salary $50,000.00
CommissionEmployee constructed with rate 10.00%
```

So `: base(id, sal)` says:

> “Run the base class constructor first with these parameters.”

---

### 🧩 The Key Distinction

| Expression           | When You Use It                     | Purpose                                          |
| -------------------- | ----------------------------------- | ------------------------------------------------ |
| `base.id`            | Inside a derived method or property | Access base class fields, methods, or properties |
| `base.DisplayInfo()` | Inside a derived method             | Call the base version of an overridden method    |
| `: base(...)`        | In the *constructor header*         | Call a specific base class constructor           |

---

### 🧠 Think of It Like This

When your class inherits from another class:

* `base.id` → “Access something my parent *already has*.”
* `: base(...)` → “Run my parent’s constructor *before mine*.”

Both are necessary tools in inheritance, but they work at different stages:

* `: base(...)` runs **during object construction**.
* `base.id` or `base.Method()` runs **after the object exists**, inside methods.

---

Would you like me to show a small before-and-after example where forgetting to use `: base(...)` causes a base class’s data to stay uninitialized? That’s often the “why” moment that makes this click permanently.


[Back to TOC](#table-of-contents)

### Using Base Class Constructors That Require Arguments

When you create a class and do not provide a constructor, C# automatically supplies one that never requires arguments. When you write your own constructor for a class, you replace the automatically supplied version. Depending on your needs, the constructor you create for a class might require arguments. When you use a class as a base class and the class only has constructors that require arguments, you must make sure that any derived classes provide arguments so that one of the base class constructors can execute.

When all base class constructors require arguments, you must include a constructor for each derived class you create. Your derived class constructor can contain any number of statements; however, within the header of the constructor, you must provide values for any arguments required by the base class constructor that you use. Even if you have no other reason for creating a derived class constructor, you must write the derived class constructor so it can call its parent’s constructor.

The header for a derived class constructor that calls a base class constructor includes a colon, the keyword base, and a list of arguments within parentheses. The keyword base always refers to the superclass of the class in which you use it. Although it seems that you should be able to use the base class constructor name to call the base class constructor, C# does not allow you to do so—you must use the keyword base.

For example, if you create an Employee class with a constructor that requires two arguments—an integer and a string—and you create a CommissionEmployee class that is a subclass of Employee, then the following code shows a valid constructor for CommissionEmployee:

```cs
public CommissionEmployee() : base(1234, "XXXX")
{
    // other statements
}
```

In this example, the CommissionEmployee constructor requires no arguments for its own execution, but it passes two arguments to its base class constructor. Every CommissionEmployee instantiation passes 1234 and XXXX to the Employee constructor. A different CommissionEmployee constructor might accept arguments; then it could pass the appropriate arguments on to the base class constructor, as in the following example:

```cs
public CommissionEmployee(int id, string name) : base(id, name) 
{
    // other statements
}
```

Yet another CommissionEmployee constructor might require that some arguments be passed to the base class constructor and that some be used within CommissionEmployee. Consider the following example:

```cs
public CommissionEmployee(int id, string name, double rate) : base(id, name) // 2 parameters passed to base constructor
{
    CommissionRate = rate;
    // rate is used within child constructor
    // other statements go here...
}
```

Watch the video Constructors and Inheritance.

Perfect — you’re now looking at the **most important inheritance rule** in C#:
👉 *If your base class has constructors that require arguments, then every derived class must make sure those arguments get passed up the chain.*

Let’s walk through this section carefully with each example from your screenshot and unpack how it all connects.

---

## 🧩 The Rule in Plain English

If your **base class** defines constructors that take parameters, the **derived class** must explicitly call one of them using the `base(...)` keyword —
because **the compiler can’t guess** what values to pass.

If you forget to do this, you’ll get a compile-time error saying:

> “There is no argument given that corresponds to the required formal parameter...”

That’s because C# always needs to know **how to construct the base portion of the object first**.

---

## 🧱 Example 1 — Base class requires arguments

```csharp
class Employee
{
    private int idNum;
    private string name;

    // Base class constructor that requires arguments
    public Employee(int id, string empName)
    {
        idNum = id;
        name = empName;
        WriteLine($"Employee constructed with ID: {id} and Name: {empName}");
    }
}
```

This time, there’s **no parameterless constructor** in `Employee`.
That means:
➡ Any class that inherits from `Employee` must call `Employee(int, string)`.

---

## 🧩 Example 2 — Derived constructor passes fixed values to the base

```csharp
class CommissionEmployee : Employee
{
    // No arguments for this constructor, but it must call base(id, name)
    public CommissionEmployee() : base(1234, "XXXX")
    {
        // Other statements could go here
        WriteLine("CommissionEmployee constructed (default values passed to base)");
    }
}
```

### Explanation

When you create a `CommissionEmployee`:

```csharp
CommissionEmployee ce = new CommissionEmployee();
```

It triggers this hidden sequence:

```
Object() → Employee(1234, "XXXX") → CommissionEmployee()
```

**Output:**

```
Employee constructed with ID: 1234 and Name: XXXX
CommissionEmployee constructed (default values passed to base)
```

You didn’t ask the user for input or parameters — but since the base constructor *requires* values, you gave it fixed defaults (`1234`, `"XXXX"`).

This is the simplest way to satisfy the base constructor’s requirement.

---

## 🧩 Example 3 — Derived constructor receives arguments and forwards them to base

```csharp
class CommissionEmployee : Employee
{
    public CommissionEmployee(int id, string name) : base(id, name)
    {
        // Optional logic specific to CommissionEmployee
        WriteLine("CommissionEmployee constructed using base arguments");
    }
}
```

### Explanation

Now your constructor **takes the same parameters** as the base and passes them directly upward with `: base(id, name)`.

**Call:**

```csharp
CommissionEmployee ce = new CommissionEmployee(2222, "Israel");
```

**Output:**

```
Employee constructed with ID: 2222 and Name: Israel
CommissionEmployee constructed using base arguments
```

Here, the derived class acts like a middleman — it doesn’t decide the values, it just passes them along.

---

## 🧩 Example 4 — Derived constructor passes *some* arguments to base and handles its own

```csharp
class CommissionEmployee : Employee
{
    private double commissionRate;

    public CommissionEmployee(int id, string name, double rate)
        : base(id, name) // 👈 Two parameters passed to base constructor
    {
        commissionRate = rate;  // 👈 Field handled by derived class
        WriteLine($"CommissionEmployee constructed with commission rate: {rate:P}");
    }
}
```

### Explanation

You’re now building a more complete object:

* The base (`Employee`) handles **ID and name**.
* The derived (`CommissionEmployee`) handles **commission rate**.

**Call:**

```csharp
CommissionEmployee ce = new CommissionEmployee(3333, "Valeria", 0.10);
```

**Output:**

```
Employee constructed with ID: 3333 and Name: Valeria
CommissionEmployee constructed with commission rate: 10.00%
```

---

## 🧠 Why You *Must* Use `base(...)`

Notice how the book explicitly says:

> “Although it seems that you should be able to use the base class constructor name to call the base class constructor, C# does not allow you to do so—you must use the keyword `base`.”

That’s because constructors are *not inherited methods* — they’re special routines that belong to each class in the hierarchy.

So this ❌ is illegal:

```csharp
Employee(1234, "XXXX");  // Won’t compile
```

But this ✅ is correct:

```csharp
: base(1234, "XXXX")
```

The colon (`:`) syntax in the header is C#’s formal way of chaining constructors.

---

## ⚙️ What’s Really Happening Behind the Scenes

Every time you create a `CommissionEmployee`, C# constructs it layer by layer:

```
System.Object()
    ↓
Employee(int id, string name)
    ↓
CommissionEmployee(int id, string name, double rate)
```

Each class handles only what it owns.

---

## ✅ Summary

| Concept                                   | Explanation                                                            |
| ----------------------------------------- | ---------------------------------------------------------------------- |
| **Base constructors with parameters**     | Derived classes *must* call one explicitly.                            |
| **`: base(...)`**                         | Calls a specific constructor in the base class.                        |
| **Automatic calls**                       | Only happen if the base has a **parameterless constructor**.           |
| **You can pass fixed or variable values** | Either hard-coded (`1234, "XXXX"`) or received from parameters.        |
| **Rule**                                  | C# won’t compile if the base requires arguments and you don’t call it. |

---

### Final Example Summary Code

```csharp
using static System.Console;

class Employee
{
    private int idNum;
    private string name;

    public Employee(int id, string empName)
    {
        idNum = id;
        name = empName;
        WriteLine($"Employee constructed with ID: {id} and Name: {empName}");
    }
}

class CommissionEmployee : Employee
{
    private double commissionRate;

    public CommissionEmployee(int id, string name, double rate)
        : base(id, name) // call the base constructor
    {
        commissionRate = rate;
        WriteLine($"CommissionEmployee constructed with rate {rate:P}");
    }
}

class Demo
{
    static void Main()
    {
        CommissionEmployee ce = new CommissionEmployee(4001, "Israel", 0.10);
    }
}
```

**Output:**

```
Employee constructed with ID: 4001 and Name: Israel
CommissionEmployee constructed with rate 10.00%
```

---

You’ve now covered the full life cycle of constructor chaining —
from implicit `base()` calls, to explicit parameter passing, to hybrid derived initialization.
Your `WriteLine()` approach still applies here too — it’s one of the best ways to trace this invisible order of execution when learning inheritance.


[Back to parent](#working-with-base-class-constructors) • [Back to TOC](#table-of-contents)

---













## Creating and Using Abstract Classes


Creating classes can become easier after you understand the concept of inheritance. When you create a child class, it inherits all the general attributes you need; you must create only the new, more specific attributes required by the child class. For example, a Painter and a Sculptor are more specific than an Artist. They inherit all the general attributes of Artists, but you must add the attributes and methods that are specific to Painter and Sculptor.

Another way to think about a superclass is to notice that it contains the features shared by its subclasses. The derived classes are more specific examples of the base class type; they add features to the shared, general features. Conversely, when you examine a derived class, you notice that its parent is more general.

Sometimes you create a parent class to be so general that you never intend to create any specific instances of the class. For example, you might never create “just” an Artist; each Artist is more specifically a Painter, Sculptor, Illustrator, and so on. A class that is used to instantiate objects is a concrete class. A class that you create only to extend from, but not to instantiate from, is an abstract class. An abstract class is one from which you cannot create concrete objects but from which you can inherit. You use the keyword abstract when you declare an abstract class. If you attempt to instantiate an object from an abstract class, you will receive a compiler error message.

Abstract classes are like regular classes in that they can contain data fields and methods. The difference is that you cannot create instances of abstract classes by using the new operator. Rather, you create abstract classes simply to provide a base class from which other objects can be derived.

Abstract classes usually contain abstract methods, and they also can contain nonabstract methods. However, they are not required to contain any methods. Recall from Chapter 9 that an abstract method has no statements. Any class derived from a class that contains an abstract method must override the abstract method by providing a body (an implementation) for it. (Alternatively, the derived class can declare the method to be abstract; in that case, the derived class’s children must implement the method.) You can create an abstract class with no abstract methods, but you cannot create an abstract method outside of an abstract class.


A method that is declared virtual is not required to be overridden in a child class, but a method declared abstract must be overridden.

When you create an abstract method, you provide the keyword abstract and the intended method type, name, and parameters, but you do not provide statements within the method; you do not even supply curly braces. When you create a derived class that inherits an abstract method from a parent, you must use the keyword override in the method header and provide the actions, or implementation, for the inherited method within the derived class. In other words, you are required to code a derived class method to override any empty base class methods that are inherited.

For example, suppose that you want to create classes to represent different animals. You can create a generic, abstract class named Animal so you can provide generic data fields, such as the animal’s name, only once. An Animal is generic, but each specific Animal, such as Dog or Cat, makes a unique sound. If you code an abstract Speak() method in the abstract Animal class, then you require all future Animal derived classes to override the Speak() method and provide an implementation that is specific to the derived class. Figure 10-31 shows an abstract Animal class that contains a data field for the name, a constructor that assigns a name, a Name property, and an abstract Speak() method.
```cs
//Figure 10-31
//The Animal class
// -----------------------------
// Abstract base class
// -----------------------------

abstract class Animal
{
    // Private field to store the animal's name
    private string name;

    // Constructor initializes the name
    public Animal(string name)
    {
        this.name = name;
    }

    // Public property to expose the name
    public string Name
    {
        get { return name; }
    }

    // Abstract method: must be implemented by subclasses
    public abstract string Speak();
}


```

The Animal class in Figure 10-31 is declared to be abstract. (The keyword is shaded.) You cannot place a statement such as Animal myPet = new Animal("Murphy"); within a program, because the program will not compile. Because Animal is an abstract class, no Animal objects can exist.

You create an abstract class like Animal so that you can extend it. For example, you can create Dog and Cat classes as shown in Figure 10-32. Because the Animal class contains a constructor that requires a string argument, both Dog and Cat must contain constructors that provide string arguments for their base class.

```cs
// Figure 10-32
// The Dog and Cat classes

// -----------------------------
// Dog class inherits from Animal
// -----------------------------
class Dog : Animal
{
    // Pass name to base constructor
    public Dog(string name) : base(name) { }

    // Override Speak() to provide Dog-specific behavior
    public override string Speak()
    {
        return "woof";
    }
}

```

If a method that should be overridden in a child class has its own implementation, you declare the base class method to be virtual. If it does not have its own implementation, you declare the base class and the method to be abstract.

The Dog and Cat constructors perform no tasks other than passing out the name to the Animal constructor. The overriding Speak() methods within Dog and Cat are required because the abstract parent Animal class contains an abstract Speak() method. The keyword override (shaded) is required in each Speak() method header. You can code any statements you want within the Dog and Cat class Speak() methods, but the methods must exist.

Figure 10-33 shows a program that implements Dog and Cat objects. Figure 10-34 shows the output, in which Speak() operates correctly for each animal type.

```cs
//Figure 10-33
//The DemoAnimals program


// -----------------------------
// DemoAnimals: simple direct usage
// -----------------------------
class DemoAnimals
{
    static void Main()
    {
        Dog spot = new Dog("Spot");
        Cat puff = new Cat("Puff");

        // Each subclass provides its own Speak() implementation
        WriteLine(spot.Name + " says " + spot.Speak());
        WriteLine(puff.Name + " says " + puff.Speak());
    }
}

// Figure 10-34
// Output of the DemoAnimals program


// Output:
// Spot says woof
// Puff says meow

```
Figure 10-35 shows an alternate way to create the DemoAnimals program. In this version, the Dog and Cat objects are passed to a method that accepts an Animal parameter. The output is the same as in Figure 10-34. The Name property and Speak() method operate polymorphically, acting appropriately for each object type.
```cs

// Figure 10-35
// The DemoAnimals2 program

// -----------------------------
// DemoAnimals: simple direct usage
// -----------------------------
class DemoAnimals
{
    static void Main()
    {
        Dog spot = new Dog("Spot");
        Cat puff = new Cat("Puff");

        // Each subclass provides its own Speak() implementation
        WriteLine(spot.Name + " says " + spot.Speak());
        WriteLine(puff.Name + " says " + puff.Speak());

        // Output:
        // Spot says woof
        // Puff says meow

        // Demonstrating polymorphism with a helper method
        DisplayAnimal(spot);
        DisplayAnimal(puff);
    }

    // -----------------------------
    // DemoAnimals2 style: polymorphism
    // -----------------------------
    public static void DisplayAnimal(Animal creature)
    {
        // Because Speak() is abstract and overridden,
        // the correct subclass method is called automatically.
        WriteLine(creature.Name + " says " + creature.Speak());
    }
}

```
















You’ve got it: this section is teaching three tightly linked ideas—**inheritance** (child gets parent’s stuff), **abstract** (no direct instances; must be subclassed), and **polymorphism** (same call, different behavior). Here’s a clean, commented walkthrough in C#.

---

## 1) Abstract classes and abstract methods

* **abstract class** (cannot be instantiated; used only as a base).
* **abstract method** (no body; *must* be overridden in the first concrete subclass).
* **virtual method** (has a default body; *may* be overridden).

```csharp
// Abstract base: cannot new Animal(...)
// Holds shared state/behavior; forces children to implement Speak()
public abstract class Animal
{
    private readonly string name;

    // Base constructor: forces every Animal to have a name at construction
    protected Animal(string name)      // protected = usable by subclasses
    {
        this.name = name;
    }

    // Read-only property (exposes the private field safely)
    public string Name => name;

    // Abstract method (no body). Every concrete subclass MUST override this.
    public abstract string Speak();
}
```

---

## 2) Concrete subclasses must override abstract members

```csharp
public class Dog : Animal
{
    // Must chain to base constructor because Animal requires a name
    public Dog(string name) : base(name) { }

    // Required override (abstract in Animal)
    public override string Speak() => "woof";
}

public class Cat : Animal
{
    public Cat(string name) : base(name) { }

    public override string Speak() => "meow";
}
```

---

## 3) Using them (polymorphism in action)

Polymorphism (many forms) means a base-typed variable can point to any derived object, and **the overridden method chosen is based on the runtime type**, not the variable type.

```csharp
using static System.Console;

public static class DemoAnimals
{
    public static void Main()
    {
        Dog spot = new Dog("Spot");
        Cat puff = new Cat("Puff");

        // Direct calls
        WriteLine($"{spot.Name} says {spot.Speak()}");
        WriteLine($"{puff.Name} says {puff.Speak()}");

        // Polymorphic calls via a base-typed parameter
        DisplayAnimal(spot);
        DisplayAnimal(puff);

        // Polymorphism also shines with collections
        Animal[] zoo = { new Dog("Rex"), new Cat("Luna") };
        foreach (Animal a in zoo)
            WriteLine($"{a.Name} says {a.Speak()}");  // Calls the right override
    }

    // Accepts any Animal; overridden Speak() is dispatched at runtime
    public static void DisplayAnimal(Animal creature)
    {
        WriteLine($"{creature.Name} says {creature.Speak()}");
    }
}
```

**Output (typical):**

```
Spot says woof
Puff says meow
Spot says woof
Puff says meow
Rex says woof
Luna says meow
```

---

## 4) Virtual vs abstract—when to use which

* Use **abstract** when the base class **cannot** provide a sensible default (forces subclasses to implement).
* Use **virtual** when the base class **can** provide a default, but derived classes may refine it.

```csharp
public abstract class Artist
{
    public string Name { get; }
    protected Artist(string name) => Name = name;

    // Virtual: default behavior exists, can be overridden
    public virtual string Medium() => "Unknown medium";

    // Abstract: no default; must be implemented by subclasses
    public abstract string Create();
}

public class Painter : Artist
{
    public Painter(string name) : base(name) { }

    public override string Medium() => "Acrylics";  // refine default
    public override string Create() => "Paints a landscape";
}

public class Sculptor : Artist
{
    public Sculptor(string name) : base(name) { }

    public override string Medium() => "Stone";
    public override string Create() => "Carves a statue";
}
```

---

## 5) Common pitfalls (and quick fixes)

* ❌ `new Animal("X")` — **won’t compile** (abstract classes can’t be instantiated).
* ❌ Forgetting to override an abstract method — **won’t compile** until every abstract member is implemented in a concrete subclass.
* ❌ Missing `: base(name)` when the base constructor requires parameters — the derived constructor must **explicitly** call a compatible base constructor.
* ✅ Mark base members `protected` (not `private`) when subclasses must access them, or expose via properties.

---

## 6) Optional: abstract properties

Abstract members can be properties too; concrete types must implement them.

```csharp
public abstract class Vehicle
{
    public abstract int Wheels { get; }   // no body here
}

public sealed class Bike : Vehicle
{
    public override int Wheels => 2;      // implemented here
}
```

---

**Mental model:**

* **Abstract class** = blueprint you never build directly.
* **Concrete subclass** = the actual build.
* **Override** = you supply the specific behavior the blueprint demanded.
* **Polymorphism** = you can treat all builds as the blueprint type and still get the right specific behavior at runtime.

If you want to see the same example using a **virtual** `Speak()` with a default (e.g., `"..."`) and then override it only in certain animals, I can sketch that variant too.


[Back to TOC](#table-of-contents)

## Creating and Using Interfaces

Some object-oriented programming languages, notably C++, allow a subclass to inherit from more than one parent class. For example, you might create an Employee class that contains data fields pertaining to each employee in your organization. You also might create a Product class that holds information about each product your organization manufactures. When you create a Patent class for each product for which your company holds a patent, you might want to include product information as well as information about the employee who was responsible for the invention. In this situation, it would be convenient to inherit fields and methods from both the Product and Employee classes. The ability to inherit from more than one class is called multiple inheritance.

Multiple inheritance is a difficult concept, and programmers encounter many problems when they use it. For example, variables and methods in the parent classes might have identical names, creating a conflict when the child class uses one of the names. Additionally, as you already have learned, a child class constructor must call its parent class constructor. When two or more parents exist, this becomes a more complicated task: To which class should base refer when a child class has multiple parents?

For all of these reasons, multiple inheritance is prohibited in C#. However, C# does provide an alternative to multiple inheritance, known as an interface. Much like an abstract class, an interface is a collection of methods (and perhaps other members) that can be used by any class as long as the class provides a definition to override the interface’s abstract definitions. Within an abstract class, some methods can be abstract, while others need not be. Within an interface, all methods are abstract.

Clip
You first learned about interfaces in the chapter “Using Classes and Objects” when you used the IComparable interface.

You create an interface much as you create an abstract class definition, except that you use the keyword interface instead of abstract class. For example, suppose that you create an IWorkable interface as shown in Figure 10-36. For simplicity, the IWorkable interface contains a single method named Work().

Although not required, in C# it is customary to start interface names with an uppercase I. Other languages follow different conventions. Interface names frequently end with able.

When any class implements IWorkable, it also must include a Work() method that returns a string. Figure 10-37 shows two classes that implement IWorkable: the Employee class and the Animal class. Because each implements IWorkable, each must declare a Work() method. The Employee class implements Work() to return the I do my job string. The abstract Animal class defines Work() as an abstract method, meaning that descendants of Animal must implement Work(). Figure 10-37 also shows two child classes of Animal: Dog and Cat. Note how Work() is defined differently for each.

When you create a program that instantiates an Employee, a Dog, or a Cat, as in the DemoWorking program in Figure 10-38, each object type knows how to “Work()” appropriately. Figure 10-39 shows the output.

Abstract classes and interfaces are similar in that you cannot instantiate concrete objects from either one. Abstract classes differ from interfaces in that abstract classes can contain nonabstract methods, but all methods within an interface must be abstract. A class can inherit from only one base class (whether abstract or not), but it can implement any number of interfaces. For example, if you want to create a Child that inherits from a Parent class and implements two interfaces, IWorkable and IPlayable, you would define the class name and list the base class and interfaces separated by commas:


Details
You implement an existing interface because you want a class to be able to use a method that already exists in other applications. For example, suppose that you have created a Payroll application that uses the Work() method in the interface class. Also suppose that you create a new class named BusDriver. If BusDriver implements the IWorkable interface, then BusDriver objects can be used by the existing Payroll program. As another example, suppose that you have written a game program that uses an IAttackable interface with methods that determine how and when an object can attack. When you create new classes such as MarsAlien, Vampire, and CivilWarSoldier, and each implements the IAttackable interface, you must define how each one attacks and how each type of object can be added to the game. If you use these IAttackable classes, you are guaranteed that they can all determine how and when to attack.

Clip
You can think of an interface as a contract. A class that implements an interface must abide by the rules of the contract.

Beginning programmers sometimes find it difficult to decide when to create an abstract base class and when to create an interface. You can follow these guidelines:

Typically, you create an abstract class when you want to provide some data or methods that derived classes can inherit, but you want the subclasses to override some specific methods that you declare to be abstract.

You create an interface when you want derived classes to override every method.

In other words, you inherit from an abstract base class when the class you want to create “is a” subtype, and you use an interface when the class you want to create will act like the interface.

Interfaces provide you with a way to exhibit polymorphic behavior. If diverse classes implement the same interface in unique ways, then you can treat each class type in the same way using the same language. When various classes use the same interface, you know the names of the methods that are available with those classes, and C# classes adopt a more uniform functionality; this consistency helps you to understand new classes you encounter more easily. If you know, for example, the method names contained in the IWorkable interface, and you see that a class implements IWorkable, you have a head start in understanding how the class functions.

Clip
Now that you understand how to construct your own interfaces, you will benefit from rereading the section describing the IComparable interface in the chapter “Using Classes and Objects.”

Got it — let’s walk through this **interface + classes example** step by step, with code and comments so you can see exactly what’s happening.  

---

### What’s going on
- An **interface** in C# defines a contract: it specifies *what methods a class must have*, but not *how they’re implemented*.  
- Any class that implements the interface must provide its own version of the method(s).  
- In your example, the interface `IWorkable` requires a `Work()` method that returns a string.  

This lets you treat very different classes (like `Employee`, `Dog`, `Cat`) in a uniform way — because they all “promise” to implement `Work()`.

---


```csharp
using static System.Console;

// -----------------------------
// Interface defines a contract
// -----------------------------
public interface IWorkable
{
    // Any class that implements IWorkable must provide this method
    string Work();
}

// -----------------------------
// Employee class implements IWorkable
// -----------------------------
class Employee : IWorkable
{
    public Employee(string name)
    {
        Name = name;
    }

    public string Name { get; set; }

    // Implementation of Work() for Employee
    public string Work()
    {
        return "I do my job";
    }
}

// -----------------------------
// Abstract Animal class also implements IWorkable
// -----------------------------
abstract class Animal : IWorkable
{
    public Animal(string name)
    {
        Name = name;
    }

    public string Name { get; set; }

    // Abstract Work() means subclasses must override it
    public abstract string Work();
}

// -----------------------------
// Dog inherits Animal and overrides Work()
// -----------------------------
class Dog : Animal
{
    public Dog(string name) : base(name) { }

    public override string Work()
    {
        return "I watch the house";
    }
}

// -----------------------------
// Cat inherits Animal and overrides Work()
// -----------------------------
class Cat : Animal
{
    public Cat(string name) : base(name) { }

    public override string Work()
    {
        return "I catch mice";
    }
}

// -----------------------------
// Demo program
// -----------------------------
class DemoWorking
{
    static void Main()
    {
        Employee bob = new Employee("Bob");
        Dog spot = new Dog("Spot");
        Cat puff = new Cat("Puff");

        WriteLine(bob.Name + " says " + bob.Work());
        WriteLine(spot.Name + " says " + spot.Work());
        WriteLine(puff.Name + " says " + puff.Work());

        // Output:
        // Bob says I do my job
        // Spot says I watch the house
        // Puff says I catch mice
    }
}
```

---

### Key Takeaways
1. **Interface (`IWorkable`)** → defines the contract: “must have a `Work()` method.”  
2. **Employee** → implements the interface directly.  
3. **Animal** → abstract class that also implements the interface, but leaves `Work()` abstract so subclasses must define it.  
4. **Dog** and **Cat** → inherit from `Animal` and provide their own `Work()` implementations.  
5. **Polymorphism** → you can treat all these objects (`Employee`, `Dog`, `Cat`) as `IWorkable` and call `Work()` without caring what specific type they are.  

---

Think of the interface as a **job description**:  
- “If you want to be considered *workable*, you must have a `Work()` method.”  
- Each class then fills in the details of *how* they work.  

---

Israel, since you’re building teaching notes, would you like me to extend this demo to show how you can store all these objects (`Employee`, `Dog`, `Cat`) in a single `List<IWorkable>` and loop through them? That’s where interfaces really shine — treating different types uniformly.

[Back to TOC](#table-of-contents)











## Using Extension Methods

When you write a C# program, sometimes you might wish a class had an additional method that would be useful to you. If you created the original class, you have two options:

You could revise the existing class, including the new useful method.

You could derive a child class from the existing class and provide it with a new method.

Sometimes, however, classes you use were created by others, and you might not be allowed to either revise or extend them. Of course, you could create an entirely new class that includes your new method, but that would duplicate a lot of the work already done when the first class was created. In these cases, the best option is to write an extension method. Extension methods are methods you can write to add to any type. Extension methods were introduced in C# 3.0.

Clip
Programmers sometimes define classes as sealed within the class header, as in sealed class InventoryItem. A sealed class cannot be extended. For example, the built-in String class is a sealed class.

For example, you have used the prewritten Int32 class throughout this book to declare integers. Suppose that you work for a company that frequently uses customer account numbers, and that the company has decided to add an extra digit to each account number. For simplicity, assume that all account numbers are two digits and that the new, third digit should be the rightmost digit in the sum of the first two digits. You could handle this problem by creating a class named AccountNumber, including a method to produce the extra digit, and redefining every instance of a customer’s account number in your applications as an AccountNumber object. However, if you already have many applications that define the account number as an integer, you might prefer to create an extension method that extends the Int32 class.

Clip
In Chapter 2 you learned that each C# intrinsic type, such as int, is an alias for a class in the System namespace, such as Int32.

Clip
When organizations append extra digits to account numbers, the extra digits are called check digits. Check digits help assure that all the digits in account numbers and other numbers are entered correctly. Check digits are calculated using different formulas. If a digit used to calculate the check digit is incorrect, then the resulting check digit is probably incorrect as well.

Figure 10-40 contains a method that extends the Int32 class. The first parameter in an extension method specifies the type extended and must begin with the keyword this. For example, the first (and in this case, only) parameter in the AddCheckDigit() method is this int num, as shown in the shaded portion of the figure. Within the AddCheckDigit() method in Figure 10-40, the first digit is extracted from the two-digit account number by dividing by 10 and taking the resulting whole number, and the second digit is extracted by taking the remainder. Those two digits are added, and the last digit of that sum is returned from the method. For example, if 49 is passed into the method, first becomes 4, second becomes 9, and third becomes the last digit of 13, or 3. Then the original number (49) is multiplied by 10 and added to the third digit, resulting in 493.

Figure 10-40

Details
The AddCheckDigit() extension method

An extension method must be static and must be stored in a static class. For example, the DemoExtensionMethod program in Figure 10-41 shows an application that is declared static in the shaded portion of the class header and uses the extension method in the second shaded statement. The static method AddCheckDigit() is used as if it were an instance method of the Int32 class; in other words, it is attached to an Int32 object with a dot, just as instance methods are when used with objects. No arguments are passed to the AddCheckDigit() method explicitly from the DemoExtensionMethod class. The parameter in the method is implied, just as these references are always implied in instance methods. Figure 10-42 shows the execution of the program.

Figure 10-41
Open Image Viewer.
Details
The DemoExtensionMethod program

Figure 10-42

Details
Execution of the DemoExtensionMethod program

You can create extension methods for your own classes in the same way one was created for the Int32 class in this example. Just like other outside methods, and unlike ordinary class instance methods, extension methods cannot access any private members of classes they extend. Furthermore, if a class contains an instance method with the same signature as an extension method, the instance method takes priority and will be the one that executes.





Alright, let’s break this down clearly and keep it practical with code examples and comments.  

---

### What’s going on here
- Sometimes you want to add a new method to a class.  
- If you wrote the class yourself, you can either:
  1. Add the method directly to the class.  
  2. Create a child class (inheritance) and add the method there.  

- But if the class is **sealed** (cannot be inherited) or it belongs to the .NET Framework (like `String` or `Int32`), you can’t modify it.  
- Instead, you can write an **extension method**.  
- Extension methods let you “pretend” you added a new method to an existing type, without actually changing the type.  

---

### Rules of Extension Methods
1. Must be defined in a **static class**.  
2. Must be a **static method**.  
3. The first parameter must start with the keyword `this` and specify the type you’re extending.  
   Example: `public static int AddCheckDigit(this int num)` extends the `int` type.  
4. They cannot access private members of the type they extend.  
5. If the type already has a method with the same signature, the original method wins.  

---

### Example: Adding a Check Digit to an Integer
```csharp
using static System.Console;

// Static class to hold extension methods
static class AccountExtensions
{
    // Extension method for int (Int32)
    // Adds a check digit to a two-digit account number
    public static int AddCheckDigit(this int num)
    {
        // Extract the first digit (tens place)
        int first = num / 10;

        // Extract the second digit (ones place)
        int second = num % 10;

        // Calculate the check digit (last digit of the sum)
        int third = (first + second) % 10;

        // Append the check digit to the original number
        int result = num * 10 + third;

        return result;
    }
}

class DemoExtensionMethod
{
    static void Main()
    {
        int acctNum = 49;

        // Use the extension method as if it were part of int
        int revisedAcctNum = acctNum.AddCheckDigit();

        WriteLine("Original account number was {0}", acctNum);
        WriteLine("Revised account number is {0}", revisedAcctNum);

        // Output:
        // Original account number was 49
        // Revised account number is 493
    }
}
```

---

### Why this is useful
- You didn’t have to create a new `AccountNumber` class.  
- You didn’t have to rewrite all your existing code that uses `int`.  
- You simply extended `int` with a new method.  
- Now you can call `acctNum.AddCheckDigit()` anywhere, just like it was built into the language.  

---

### Two Truths & A Lie (Extension Methods Edition)
1. Extension methods must be defined in a static class.  
2. Extension methods can access private fields of the class they extend.  
3. If a class already has an instance method with the same signature, that method takes priority over the extension method.  

👉 The **lie** is #2 — extension methods cannot access private members. They only work with what’s publicly available.  

---

Israel, since you’re building reusable teaching notes, you could think of extension methods as **plug-ins**: you don’t change the original machine, but you add a new attachment that makes it more useful.  

Would you like me to also show you how to write an extension method for your own custom class (like `Employee`) so you can see how it works beyond built-in types?

[Back to TOC](#table-of-contents)

## Recognizing Inheritance in GUI Applications

Alright, let’s unpack this in a way that makes sense both conceptually and practically.  

---

### What happens when you create a Windows Forms project
- Visual Studio automatically generates a class for your form (e.g., `Form1`).  
- That class **inherits** from the built‑in `Form` class.  
- This means your form doesn’t start from scratch — it already has all the properties and behaviors of a Windows Form (like `Text`, `Visible`, event handling, etc.).  

So even before you add any controls or write any code, your `Form1` is a descendant of `Form`.

---

### The inheritance chain
The `Form` class itself is not directly derived from `Object`. It goes through several layers:

```
Object
  ↓
MarshalByRefObject
  ↓
Component
  ↓
Control
  ↓
ScrollableControl
  ↓
ContainerControl
  ↓
Form
```

Each ancestor contributes features:
- `Object` → universal methods like `ToString()`, `Equals()`.  
- `Control` → properties like `Text`, `Visible`, `Enabled`.  
- `ScrollableControl` → scrolling support.  
- `ContainerControl` → ability to host other controls.  
- `Form` → window-specific features (title bar, borders, events like `Load`).  

That’s why when you create a form, you already have a rich set of functionality without writing it yourself.

---

### Analogy: Car manufacturing
Think of inheritance like designing a new car model:
- You don’t reinvent the wheel, engine, or windshield wipers.  
- You reuse existing components and maybe add or tweak a few new features (like airbags or a bigger gas tank).  
- The new model inherits most of its functionality from previous designs.  

Similarly, in programming:
- You don’t reinvent `Text` or `Visible` properties for every control.  
- You inherit them from base classes and only add or override what’s unique.

---

### Benefits of inheritance
1. **Saves development time** → you don’t have to re‑implement common features.  
2. **Saves testing time** → base classes are already tested and reliable.  
3. **Easier learning curve** → programmers already know how the base class works.  
4. **Integrity preserved** → extending a class doesn’t modify the original source code.  

---

### Static classes note
- Some classes are declared `static` (like `System.Console`).  
- Static classes cannot be instantiated or extended.  
- They only contain static members (methods, properties).  
- Example: you can call `Console.WriteLine()`, but you can’t inherit from `Console`.

---

### Practical example
Here’s what Visual Studio generates for a new form:

```csharp
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent(); // sets up controls and properties
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // This event runs when the form loads
        }
    }
}
```

Notice:  
- `Form1` inherits from `Form`.  
- You can override or extend behavior (like handling `Load` events).  
- But you didn’t have to write all the windowing logic yourself — inheritance gave it to you.

---

✅ **Takeaway:**  
Inheritance is about reusing and extending existing functionality. In Windows Forms, every form you create is automatically part of a long inheritance chain, which is why it already has so many useful properties and methods. You only need to add or override what makes your form unique.  

---

Israel, since you’re building teaching notes, would you like me to diagram the inheritance chain visually (like a tree) so you can drop it straight into your Markdown notes? That would make the ancestry of `Form` crystal clear.

[Back to TOC](#table-of-contents)

---

## Chapter Summary

The classes you create in object-oriented programming languages can inherit data and methods from existing classes. The ability to use inheritance makes programs easier to write, easier to understand, and less prone to errors. A class that is used as a basis for inheritance is called a base class, superclass, or parent class. When you create a class that inherits from a base class, it is called a derived class, extended class, subclass, or child class.

When you create a class that is an extension or child of another class, you use a single colon between the derived class name and its base class name. The child class inherits all the methods, properties, and fields of its parent. Inheritance works only in one direction—a child inherits from a parent, but not the other way around.

If you could use private data outside of its class, the principle of information hiding would be destroyed. However, when you must access parent class data from a derived class, you declare parent class fields using the keyword protected, which provides you with an intermediate level of security between public and private access.

When you declare a child class method with the same name and parameter list as a method within its parent class, you override the parent class method and allow your class objects to exhibit polymorphic behavior. You can use the keyword new or override with the derived class method. When a derived class overrides a parent class member but you want to access the parent class version, you can use the keyword base.

Every derived class object “is a” specific instance of both the derived class and the base class. Therefore, you can assign a derived class object to an object of any of its base class types. When you do so, C# makes an implicit conversion from derived class to base class.

Every class you create in C# derives from a single class named System.Object. Because all classes inherit from the Object class, all classes inherit the four Object class public instance methods: Equals(), GetHashCode(), GetType(), and ToString().

When you instantiate an object that is a member of a subclass, the base class constructor executes first, and then the derived class constructor executes.

An abstract class is one from which you cannot create concrete objects but from which you can inherit. Usually, abstract classes contain abstract methods; an abstract method has no method statements. Any class derived from a class that contains an abstract method must override the abstract method by providing a body (an implementation) for it.

An interface provides an alternative to multiple inheritance. Much like an abstract class, an interface is a collection of methods (and perhaps other members) that can be used by any class as long as the class provides a definition to override the interface’s abstract definitions. Within an abstract class, some methods can be abstract, while others need not be. Within an interface, all methods are abstract. A class can inherit from only one abstract base class, but it can implement any number of interfaces.

Extension methods are methods you can write to add to any type. They are static methods, but they operate like instance methods. Their parameter lists begin with the keyword this and the data type being extended.

GUI classes such as Button and Form descend from several ancestors. You can create many computer programs more easily using inheritance because it saves development and testing time.

[Back to TOC](#table-of-contents)

## Key Terms



[Back to TOC](#table-of-contents)

## Review Questions



[Back to TOC](#table-of-contents)

## Exercises



[Back to TOC](#table-of-contents)

---

If you want, I can also drop this into a `CH10Notes.md` file so it sits alongside your CH8/CH9 notes with identical link behavior.
