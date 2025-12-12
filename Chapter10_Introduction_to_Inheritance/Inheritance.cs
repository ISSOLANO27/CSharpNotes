using static System.Console;

class Party
{
    private int month;
    private int day;
    private int startHour;
    private int numGuests;

    public int Month { get; set; }
    public int Day { get; set; }

    public int StartHour { get; set; }
    public int NumGuests { get; set; }

    public void Invite()
    {
        WriteLine("You are invited!");
        WriteLine("Come on {0}/{1}", month, day);
        WriteLine("at {0} o'clock", startHour);
    }

}

class DinnerParty : Party
{
    public string? Entree { get; set; }

    public DinnerParty() { } // without this, we cannot use default constructor
    public DinnerParty(string entree) // on its own, it forces user to provide entree
    {
        Entree = entree;
    }


}

class TestParty
{
    static void Main()
    {
        DinnerParty anniversary = new DinnerParty(); // using default constructor
        anniversary.Month = 10;
        anniversary.Day = 15;
        anniversary.StartHour = 7;
        anniversary.NumGuests = 8;
        anniversary.Entree = "prime rib";
        anniversary.Invite();
        
    }
}

