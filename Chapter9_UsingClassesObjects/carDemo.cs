using System;
using static System.Console;

class Car
{
    // Auto-implemented properties (public getters/setters keep it simple for this chapter)
    public string Model { get; set; }
    public double Mpg  { get; set; }

    // ctor #1: full control (model + mpg)
    public Car(string model, double mpg)
    {
        Model = model;
        Mpg = mpg;
    }

    // ctor #2 (overloaded): default MPG = 20.0 when only model is provided
    public Car(string model) : this(model, 20.0) { }

    // Overload ++ to increase MPG by 1 (prefix and postfix both use this single operator in C#)
    public static Car operator ++(Car c)
    {
        // mutate in place to keep demo straightforward
        c.Mpg += 1.0;
        return c;
    }

    // Nice display helper
    public override string ToString() => $"{Model} — {Mpg:F1} mpg";
}

class CarDemo
{
    static void Main()
    {
        // Create two cars: one with explicit MPG, one using the default-20 ctor
        Car civic = new Car("Honda Civic", 32.5);
        Car mustang = new Car("Ford Mustang"); // MPG defaults to 20.0

        WriteLine("Before increment:");
        WriteLine(civic);
        WriteLine(mustang);

        // Demonstrate the overloaded ++ operator
        ++civic;      // prefix form (increments, then returns the same reference)
        mustang++;    // postfix form (same effect on the object for our mutable design)

        WriteLine("\nAfter increment (each ++ adds 1 mpg):");
        WriteLine(civic);
        WriteLine(mustang);

        // Optional: show that ++ works repeatedly
        mustang++;
        WriteLine("\nAfter another increment to Mustang:");
        WriteLine(mustang);
    }
}


/*
using System;
using static System.Console;

class Car
{
    public string Model { get; set; }
    public double Mpg { get; set; }

    public Car(string model, double mpg)
    {
        Model = model;
        Mpg = mpg;
    }

    // Overload the ++ operator
    public static Car operator ++(Car c)
    {
        if (c == null)
            throw new ArgumentNullException(nameof(c));

        c.Mpg += 1;
        return c;
    }

    public override string ToString() => $"{Model} — {Mpg} MPG";
}

class CarDemo
{
    static void Main()
    {
        Car car1 = new Car("Toyota Corolla", 30.5);
        Car car2 = new Car("Ford Mustang", 20.0);

        WriteLine("Before increment:");
        WriteLine(car1);
        WriteLine(car2);

        // Using overloaded ++ operator
        car1++;  // postfix
        ++car2;  // prefix

        WriteLine("\nAfter increment:");
        WriteLine(car1);
        WriteLine(car2);
    }
}
*/
