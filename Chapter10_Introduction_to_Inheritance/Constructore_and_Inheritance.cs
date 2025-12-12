class Sunglasses
{
    public string FrameColor { get; set; }
    public string LensColor { get; set; }
    public Sunglasses()
    {
        FrameColor = "black";
        LensColor = "brown";
    }
}

class PrescriptionSunglasses : Sunglasses
{
    public double Diopter { get; set; }
    public PrescriptionSunglasses()
    {
        Diopter = 0.0;
    }
}

/*

if the base and child classes have parameterless constructors and both set properties, the child class constructor 
automatically calls the base class constructor first. 

Assuming that the base class requires parameters in its constructor, the child class must explicitly call the base class 
constructor using the base keyword. like this: : base(parameter1, parameter2) each one goes to the parent constructor parameter list. 
causing the properties FrameColor and LensColor to be set properly. 

What if the child requires 3 parameters of its own?






*/