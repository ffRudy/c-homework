using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入第一个数字：");
            int num1 = int.Parse(Console.ReadLine());
            Console.WriteLine("请输入第二个数字？");
            int num2 = int.Parse(Console.ReadLine());
            Console.WriteLine("请输入运算符？");
            char myOperator = char.Parse(Console.ReadLine());
            int result;
            switch (myOperator)//用switch进行响应的分支操作
            {
                case '+'://加号
                    result = num1 + num2;
                    Console.WriteLine("运算结果为："+result);
                    break;
                case '-'://减号
                    result = num1 - num2;
                    Console.WriteLine("运算结果为：" + result);
                    break;
                case '*'://乘号
                    result = num1 * num2;
                    Console.WriteLine("运算结果为：" + result);
                    break;
                case '/'://除号
                    if (num2 == 0)//除数为0报错
                    {
                        Console.WriteLine("除数不能为“0”！");
                    }
                    else
                    {
                        result = num1 / num2;
                        Console.WriteLine(result);
                    }
                    break;
            }
        }
    }
}
