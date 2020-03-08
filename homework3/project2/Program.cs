using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace home3_project1
{
    class Product
    {
        public void MethodSame() { }
        public void MethodDiff() { }
        public double GetArea()  { return 0; }
    }
    class ConcreteProductA : Product
    {
        public double width;
        public double height;
        public ConcreteProductA(double len, double wid)  // 参数化构造函数
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
    }
    class ConcreteProductB : Product
    {
        //实现业务方法
        public double side;
        public ConcreteProductB(double val)  // 参数化构造函数
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
    }
    class ConcreteProductC : Product
    {
        //实现业务方法
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
    }
    class Factory
    {
        //静态工厂方法
        public static Product GetProduct(String arg)
        {
            Product product = null;
            if (arg=="A")
            {
                Random ran1 = new Random();
                int n = ran1.Next(10);
                Random ran2 = new Random();
                int m = ran2.Next(10);
                product = new ConcreteProductA(n, m);
                //初始化设置product
            }
            else if (arg == "B")
            {
                Random ran1 = new Random();
                int n = ran1.Next(10);
                product = new ConcreteProductB(n);
                //初始化设置product
            }
            else if (arg == "C")
            {
                Random ran1 = new Random();
                int n = ran1.Next(10);
                Random ran2 = new Random();
                int m = ran2.Next(10);
                Random ran3 = new Random();
                int l = ran3.Next(10);
                product = new ConcreteProductC(n, m, l);
                //初始化设置product
            }
            return product;
        }
    }
    class Client
    {
        public static void Main(String[] args)
        {
            double area=0;
            for (int i = 0; i < 10; i++)
            {
                Random ran = new Random();
                int n = ran.Next(100);
                Thread.Sleep(12);
                if (n % 3 == 0)
                {
                    ConcreteProductA product;
                    product = (ConcreteProductA)Factory.GetProduct("A");
                    Console.WriteLine("产生了一个长方形，面积为" + product.GetArea());
                    area += product.GetArea();
                }
                if (n % 3 == 1)
                {
                    ConcreteProductB product;
                    product = (ConcreteProductB)Factory.GetProduct("B");
                    Console.WriteLine("产生了一个正方形，面积为" + product.GetArea());
                    area += product.GetArea();
                }
                if (n % 3 == 2)
                {
                    ConcreteProductC product;
                    product = (ConcreteProductC)Factory.GetProduct("C");
                    Console.WriteLine("产生了一个三角形，面积为" + product.GetArea());
                    area += product.GetArea();
                }
            }
            Console.WriteLine("总面积为：" + area);
        }
    }
}
