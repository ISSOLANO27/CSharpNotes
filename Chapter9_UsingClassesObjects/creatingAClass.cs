class HouseSittingContract
{
    private string client;
    private int days;

    public void SetDays(int numDays)
    {
        const int MAX = 7;
        if (numDays > MAX)
            days = MAX;
        else
            days = numDays;
    }

    public void GetDays()
    {
        return days; // access to private data
    }



    public static void Main()
    {
        HouseSittingContract con1 = new HouseSittingContract();
        con1.SetDays(4);
        Console.WriteLine(con1.GetDays());
    }

}





