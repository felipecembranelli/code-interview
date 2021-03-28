using System;

namespace Demo2
{
    // public class Program
    // {
    //     static void Main(string[] args)
    //     {
    //         Triangle obj = new Triangle();
    //         Console.WriteLine(obj.GetShape());


    //         Triangle obj2 = new Circle();

    //         Console.WriteLine(obj2.GetShape());
    //     }
    // }

    public class Triangle
    {
        public virtual string GetShape()
        {
            return "Triangle";
        }
    }

    public class Circle : Triangle
    {
        public override string GetShape()
        {
            return "Circle";
        }
    }
}