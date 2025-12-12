class ClubMember
{
    private string firstname;
    private double duesOwed;

    public ClubMember(string name, double dues) //here it is implicit
    {
        this.firstname = name;
        this.duesOwed = dues;
    }

    public void DisplayBill() // (this) is also implicit
    {
        WiriteLine("Member {0}: You  owe {1}", this.firstname, this.duesOwed.ToString("C"));
    }

    // declares a Club member object
    ClubMember mem1 = new ClubMember(this, "Ann", 5.50);
    ClubMember mem2 = new ClubMember(this, "Joe", 6.75);


}

/*

You cannot name the parameters in a method the same as the field being 
passed as the argument. if you do, it will assign the parameters to itself,
and the fields in the class NEVER get set.

UNLESS you explicitly use this.firstName = firstName. 

*/

