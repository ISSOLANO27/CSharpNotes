using static System.Console;
class LetterDemo
{
    static void Main()
    {
        // create a regular letter object (base class)
        Letter regularLetter = new Letter();
        regularLetter.RecipientName = "John";
        regularLetter.DateMailed = "11/16/2025";

        CertifiedLetter certified = new CertifiedLetter();
        certified.RecipientName = "Jane Smith";
        certified.DateMailed = "11/17/2025";
        certified.TrackingNumber = "ABC123";

        // Display the objects
        WriteLine(regularLetter);
        WriteLine();
        WriteLine(certified);

        Console.ReadLine();
    }
}

// Base class: Letter
// Used by the company to keep track of letters mailed to clients.
class Letter
{
    // Auto-implemented property: name of the recipient
    public string? RecipientName { get; set; }

    // Auto-implemented property: date the letter was mailed
    // Using string keeps it simple for this exercise.
    public string? DateMailed { get; set; }

    // Override Object.ToString()
    // This gives a useful text representation of a Letter.
    public override string ToString()
    {
        // GetType() returns the runtime type (Letter or CertifiedLetter)
        // This helps show inheritance in action.
        return $"{GetType().Name} | Recipient: {RecipientName}, Date Mailed: {DateMailed}";
    }
}

// Derived class: CertifiedLetter
// Inherits all fields/properties from Letter and adds tracking info.
class CertifiedLetter : Letter
{
    // Extra info only certified letters have: tracking number
    public string? TrackingNumber { get; set; }

    // Override ToString() again to include the new property
    public override string ToString()
    {
        // Call base.ToString() to reuse the formatting from Letter
        // Then add the tracking number.
        return base.ToString() + $", Tracking #: {TrackingNumber}";
    }
}