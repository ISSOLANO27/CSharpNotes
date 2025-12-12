using System;
using System.Collections.Generic;

namespace ToStringDemo
{
    // Base Employee class
    public class Employee
    {
        public int IdNum { get; set; }
        public string Name { get; set; }

        // Custom method (must be called explicitly)
        public string GetEmployeeIdentification()
        {
            return IdNum + " " + Name;
        }

        // Override ToString() (called automatically in many contexts)
        public override string ToString()
        {
            return "Employee: " + IdNum + " " + Name;
        }
    }

    // Derived Manager class
    public class Manager : Employee
    {
        public string Department { get; set; }

        // Override ToString() differently for Manager
        public override string ToString()
        {
            return "Manager: " + IdNum + " " + Name + " (" + Department + ")";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee { IdNum = 234, Name = "Johnson" };
            Manager mgr = new Manager { IdNum = 567, Name = "Smith", Department = "IT" };

            // Using custom method
            Console.WriteLine("Custom method:");
            Console.WriteLine(emp.GetEmployeeIdentification()); // 234 Johnson

            // Using overridden ToString()
            Console.WriteLine("\nOverridden ToString():");
            Console.WriteLine(emp); // Employee: 234 Johnson
            Console.WriteLine(mgr); // Manager: 567 Smith (IT)

            // String interpolation automatically calls ToString()
            Console.WriteLine($"\nInterpolated: {emp}");
            Console.WriteLine($"Interpolated: {mgr}");

            // Collection printing
            List<Employee> staff = new List<Employee> { emp, mgr };
            Console.WriteLine("\nList output:");
            foreach (var e in staff)
            {
                Console.WriteLine(e); // Calls ToString() on each object
            }
        }
    }
}
