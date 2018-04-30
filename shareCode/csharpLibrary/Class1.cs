using System;
using FsharpLibrary;
using ObjectOrientatedInFsharp;

namespace csharpLibrary
{
    public class Class1
    {
        public void UseFsharpFunction()
        {
            var added = Calculate.add(1, 6);
            var multiply = Calculate.mult(1, 6);
            var squared = Calculate.square(5);
        }

    
        public void UseFsharpOO()
        {
            var person = new Person("Bo", "Ipsen", DateTime.Today.AddYears(-33));
            
            var ageCalculator = new AgeCalculator();

            var age = ageCalculator.GetAge(person.Birthday);
        }

    }
}
