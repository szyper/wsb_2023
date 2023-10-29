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

        public Rectangle(double sideA, double sideB)
        {
            this.sideA = sideA;
            this.sideB = sideB;
        }

        public double CalculateRectangleArea()
        {
            return sideA * sideB;
        }
    }
}
