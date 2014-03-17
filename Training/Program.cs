using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training
{
    class FirstAttribute : Attribute
    {
         public FirstAttribute(string message)
         {
             Message = message;
         }

         public string Message { get; set; }
    }

    class SecondAttribute : Attribute
    {
        public SecondAttribute(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }

    abstract class Base
    {
        public abstract int Method(int x, int y);
    }

    class A : Base
    {
        [First("Этот метод складывает два числа")]
        public override int Method(int x, int y)
        {
            return x + y;
        }
    }

    class B : Base
    {
        [Second("Этот метод перемножает два числа")]
        public override int Method(int x, int y)
        {
            return x * y;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Base a = new A();
            Base b = new B();
            var attrs = a.GetType().GetMethod("Method").GetCustomAttributes(false);
            foreach (var attr in attrs)
            {
                Console.WriteLine(attr.GetType().GetProperty("Message").GetMethod.Invoke(attr, null));
            }

            attrs = b.GetType().GetMethod("Method").GetCustomAttributes(false);
            foreach (var attr in attrs)
            {
                Console.WriteLine(attr.GetType().GetProperty("Message").GetMethod.Invoke(attr, null));
            }

            Console.ReadKey();
        }
    }
}
