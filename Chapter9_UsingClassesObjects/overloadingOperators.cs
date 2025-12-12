using Console.System;

class Order
{
    public string Num { get; set; }
    public double Price { get; set; }
    public double Shipping { get; set; }

    public Order(string num, double price, double shipping)
    {
        Num = num;
        Price = price;
        Shipping = shipping;
    }


    public static Order operator +(Order order1, Order order2)
    {
        string num = order1.Num + "A";
        double price = order1.Price + order2.Price;
        double shipping;
        if (order1.Shipping > order2.Shipping)
            shipping = order1.Shipping;
        else shipping = order2.Shipping;
        return (new Order(num, price, shipping));
    }
    
    public static void Main()
    {
        Order may1 = new Order("245", 49.99, 5.99);
        Order may2 = new Order("276", 0.0, 0.0);
        Order combined = new Order("0", 0.0, 0.0);
        combined = may1 + may2;
    }
    



}