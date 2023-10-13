using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_class.classes
{
    internal class Rectangle
    {
        private double sideA, sideB;

        public Rectangle(double sideA, double sideB)
        {
            this.sideA = sideA;
            this.sideB = sideB;
        }

        public double CalculateRectangleArea()
        {
            return sideA * sideB;
        }

        public void DrawRectangle()
        {
            Console.WriteLine($"\nProstokąt o szerokości: {sideA} i wysokości: {sideB}\n\n");
        }
    }
}
