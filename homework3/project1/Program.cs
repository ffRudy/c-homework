using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace home3_project1
{
    class Rectangle
    {
        public double width;
        public double height;
        public Rectangle(double len, double wid)  // 参数化构造函数
        {
            height = len;
            width = wid;
        }
        public double GetArea()
        {
            if (Islegal())
            {
                return height * width;
            }
            return -1;
        }
        public Boolean Islegal()
        {
            return height > 0 && width > 0;
        }
        public double Display()
        {
            if (Islegal())
            {
                Console.WriteLine("面积为:" + GetArea());
            }
            else
            {
                Console.WriteLine("不合法！");
            }
        }
    }
    class Square
    {
        public double side;
        public Square(double val)  // 参数化构造函数
        {
            side = val;
        }
        public double GetArea()
        {
            if (Islegal())
            {
                return side * side;
            }
            return -1;
        }
        public Boolean Islegal()
        {
            return side > 0;
        }
        public double Display()
        {
            if (Islegal())
            {
                Console.WriteLine("面积为:" + GetArea());
            }
            else
            {
                Console.WriteLine("不合法！");
            }
        }
    }
    class Triangle
    {
        public double side1;
        public double side2;
        public double side3;
        public ConcreteProductC(double a, double b, double c)  // 参数化构造函数
        {
            side1 = a;
            side2 = b;
            side3 = c;
        }
        public double GetArea()
        {
            if (Islegal())
            {
                double p = (side1 + side2 + side3) / 2;
                double s = Math.Sqrt(p * (p - side1) * (p - side2) * (p - side3));
                return s;
            }
            return -1;
        }
        public Boolean Islegal()
        {
            return side1 + side2 > side3 && side1 + side3 > side2 && side2 + side3 > side1 && side1 > 0 && side2 > 0 && side3 > 0;
        }
        public double Display()
        {
            if (Islegal())
            {
                Console.WriteLine("面积为:" + GetArea());
            }
            else
            {
                Console.WriteLine("不合法！");
            }
        }
    }
    class Client
    {
        public static void Main(String[] args)
        {
            rectangle = new Rectangle(1,5);
            square    = new Square(2);
            triangle  = new Triangle(3, 4, 5);
            rectangle.display();
            square.display();
            triangle.display();
        }
    }
}
