using System;

namespace EqualsDemo
{
    public class Employee
    {
        public int IdNum { get; set; }
        public string Name { get; set; }

        // Override Equals() from Object
        public override bool Equals(object obj)
        {
            // 1. If the argument is null, they can't be equal
            if (obj == null) return false;

            // 2. If comparing to itself, always true
            if (ReferenceEquals(this, obj)) return true;

            // 3. If types differ, not equal
            if (this.GetType() != obj.GetType()) return false;

            // 4. Safe cast to Employee (since type check passed)
            Employee other = (Employee)obj;

            // 5. Define equality based on IdNum and Name
            return this.IdNum == other.IdNum && this.Name == other.Name;
        }

        // Always override GetHashCode when overriding Equals
        public override int GetHashCode()
        {
            // Combine fields into a hash code
            return HashCode.Combine(IdNum, Name);
        }

        // Override ToString() for easy display
        public override string ToString()
        {
            return $"Employee: {IdNum} {Name}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Employee emp1 = new Employee { IdNum = 234, Name = "Johnson" };
            Employee emp2 = new Employee { IdNum = 234, Name = "Johnson" };
            Employee emp3 = emp1; // Reference to the same object

            // Default reference equality (Object.Equals)
            Console.WriteLine("Reference equality:");
            Console.WriteLine(emp1.Equals(emp3)); // True (same memory address)
            Console.WriteLine(emp1.Equals(emp2)); // True now, because we overrode Equals()

            // Without override, emp1.Equals(emp2) would be False (different addresses)

            // Null check
            Console.WriteLine("Null check:");
            Console.WriteLine(emp1.Equals(null)); // False

            // Type check
            Console.WriteLine("Type check:");
            Console.WriteLine(emp1.Equals("NotAnEmployee")); // False

            // Display objects
            Console.WriteLine("Objects:");
            Console.WriteLine(emp1); // Employee: 234 Johnson
            Console.WriteLine(emp2); // Employee: 234 Johnson
        }
    }
}
