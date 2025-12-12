using System;

class Program
{
    static void Main()
    {
        Teeshirt tshirt = new Teeshirt();
        tshirt.Color = "blue";
        tshirt.Price = 10.00;
        Console.WriteLine(tshirt.ApplyDiscount().ToString("C"));

        SloganTeeShirt sts = new SloganTeeShirt();
        sts.Color = "orange";
        sts.Price = 10.00;
        sts.Slogan = "Tigers";
        Console.WriteLine(sts.ApplyDiscount().ToString("C"));
    }
}

class Teeshirt
{
    public string? Color { get; set; }
    public double Price { get; set; }

    public double ApplyDiscount()
    {
        const double DISCOUNT = 0.10;
        return Price - (Price * DISCOUNT);
    }
}

class SloganTeeShirt : Teeshirt
{
    public string? Slogan { get; set; }

    public new double ApplyDiscount() // Hides/Overrides the parent method
    // public double ApplyDiscount(string s) // Overloads the parent method
    // place virtual in parent and override here to override properly
    {
        const double DISCOUNT = 0.20;
        return Price - (Price * DISCOUNT);
    }

    public double ApplyDiscount(string s) // Overloads the parent method
    {
        const double DISCOUNT = 0.20;
        return Price - (Price * DISCOUNT);
    }

    public double ApplyDiscount(double promotion) // Overloads the base method
    {
        doble price = base.ApplyDiscount(); // calls the base class method
        price -= promotion;
        return price;
    }
}

/*
when you overload a child method, both the parent and child methods coexist. 
The child class has access to both methods, and which one gets called depends on the parameters passed during the method call.
In the example above, the overloaded method in the child class takes a string as a parameter. 
If you call ApplyDiscount() without any parameters on an instance of SloganTeeShirt, it will invoke the parent class's ApplyDiscount() method. 
If you call ApplyDiscount("some string"), it will invoke the child class's overloaded method.

Keep in mind that when you use the WriteLine method, you do not have to use string interpolation or concatenation to include the result of a method call in the output.
like this: Console.WriteLine(sts.ApplyDiscount().ToString("C")); or if want the overloaded one: Console.WriteLine(sts.ApplyDiscount("some string").ToString("C"));

The reason we can do this is that the WriteLine method can take any expression that evaluates to a string (or can be converted to a string) as an argument. 
When you call sts.ApplyDiscount(), it returns a double value, which we then convert to a formatted string using the ToString("C") method. when we use 
the overloaded method, we pass a string argument to it. In this case the sts.Slogan property that is already set to "Tigers".

QUICK RECAP:
if you intend to override it, make sure to use the virtual keyword on the parent class method and override in the child class method.
This is the recommended approach for polymorphism in C#. You can overload a method as many times as you want with different parameter lists, 
but overriding is specifically for replacing the behavior of a parent class method in a child class.
*/
