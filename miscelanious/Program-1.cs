using System;

namespace code_interview
{
    // class Program
    // {
    //     static void Main(string[] args)
    //     {
    //         clsSingleton.Hit();

    //         Console.WriteLine(clsSingleton.GetTotalHits());

    //         Console.WriteLine("Hello World!");
    //     }
    // }

    public class clsSingleton {
        public static int counter;
        private clsSingleton() {}

        public static void Hit() {
            counter++;
        }

        public static int GetTotalHits() {
            return counter;
        }
    }
}