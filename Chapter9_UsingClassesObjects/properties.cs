using static System.Console;

class Apartment
{
    private int aptNum;
    private double rent;

    public int GetAptNum()
    {
        return aptNum;
    }
    public void SetAptNum(int apt)
    {
        aptNum = apt;
    }

    public double GetRent()
    {
        return rent;
    }
    public void SetRent(double amt) // void because we are not returning a value, we are just setting the value
    {
        rent = amt;
    }

    public static void Main()
    {
            Apartment apt = new Apartment();
            apt.SetAptNum(102);
            apt.SetRent(850.00);
            Write("the rent for apt #{0}", apt.GetAptNum());
            WriteLine("is {0}", apt.GetRent());
    }

}






class ApartmentWithSetterGetter
{
    private int aptNum;
    private double rent;

    // getter/setter

    public int AptNum
    {
        get { return aptNum; }
        set { aptNum = value; } // if we use return itself, we WILL cause an infinite loop!
                                // value is a special implicit keyword in C#; compiler knows
    }

    public double Rent
    {
        get
        {
            return rent;
        }
        set
        {
            rent = value;
        }
    }

    public static void Main()
    {
        Apartment apt = new Apartment();
        apt.AptNum = 102; // we can know use the property instead of a method call
        apt.Rent = 850.00;
        Write("the rent for apt #{0}", apt.AptNum); // we can now also use the private field through the property named AptNum instead of a method call.
        WriteLine("is {0}", apt.Rent);
    }
}


class ApartmenAuto
{
    // If you use the most condensed property setup REMOVE the corresponding fields
    /*
    private int aptNum;
    private double rent;

    New fields are created internally no need to keep instance variables anymore. 
    They hold a different memory location
    */

    // getter/setter

    public int AptNum {get; set;}
    public double Rent {get; set;}

    public static void Main()
    {
        Apartment apt = new Apartment();
        apt.AptNum = 102; // we can know use the property instead of a method call
        apt.Rent = 850.00;
        Write("the rent for apt #{0}", apt.AptNum); // we can now also use the private field through the property named AptNum instead of a method call.
        WriteLine("is {0}", apt.Rent);
    }

}