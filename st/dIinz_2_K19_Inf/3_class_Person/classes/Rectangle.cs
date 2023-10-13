using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_class_Person.classes
{
    internal class Rectangle
    {
        private double sideA, sideB;

        public Rectangle(double a, double b)
        {
            /*
            if (a <= 0 || b <= 0)
            {
                Console.WriteLine("Boki prostokąta muszą być dodatnie");
            }
            */

            sideA = a;
            sideB = b;
        }

        public double CalculateRectangleArea()
        {
            return sideA * sideB;
        }
    }
}
