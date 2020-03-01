using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shuzu
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array1 = new int[5] { 99, 98, 92, 97, 95 };
            Console.WriteLine("最大值：" + array1.Max());
            Console.WriteLine("最小值：" + array1.Min());
            Console.WriteLine("平均值：" + array1.Average());
            Console.WriteLine("所有元素的和：" + array1.Sum());
        }
    }
}
