int[] array = {10, 20, 30, 30};
int max;
Console.Write("Enter an integer >> ");
max = Convert.ToInt32(Console.ReadLine());
for(int x = 0; x < max; ++x)
    Console.WriteLine("{0} --- {1}", x, array[x]);
// The last WriteLine only applying to value indexed at 3
Console.WriteLine("Division result is {0}", array[3] / max);

/*
LOOPS ARE NOT SAFETY MACHANISMS; USERS CAN BREAK THIS!

So when working with exception. This Ford loop helps explain how it's not a safety mechanism, 
it is not checking the array limits, and it is not guarding us from going out of range. 
Perspective. It looked like it did apply the arithmetic on the right one.
But what really happens is that the code breaks. 
It stops it, gives you a less index with whatever it is that you're applying to it, 
and stops immediately. This is why we saw the exception handling errors. 
We could have avoided this by using array.Length.
If that would have been the case, it would have checked, making sure it doesn't go. Beyond. 
The index values contained in the array, because right now all we're doing is iterating through 
up to whatever the user chose. Otherwise it will not save us from invalid indexing.

*/