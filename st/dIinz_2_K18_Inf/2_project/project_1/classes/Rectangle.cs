using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_1.classes
{
    internal class Rectangle
    {
        public double sideA; 
        public double sideB;
        
        public Rectangle(double a, double b)
        {
            if (a <= 0 || b <= 0)
            {
                Console.WriteLine("Boki prostokąta muszą być dodatnie");
                throw new ArgumentException("Wypełnij prawidłowo długość boków");
            }

            sideA = a;
            sideB = b;
        }

        public double CalculateArea()
        {
            return sideA * sideB;
        }
    }
}
