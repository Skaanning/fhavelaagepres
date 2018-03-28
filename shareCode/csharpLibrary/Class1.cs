using FsharpLibrary;

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

    }
}
