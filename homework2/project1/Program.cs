using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sushu1
{
    class Program
    {

        public static void Main(String[] args)
        {
            Console.WriteLine("请输入一个数据：");
            long num = long.Parse(Console.ReadLine());
            Console.WriteLine("质因子如下：");
            Console.WriteLine(getResult(num));
        }
        public static String getResult(long num)
        {
            StringBuilder chuan = new StringBuilder();
            // 一个合数n,如果n = p * q 则  p 和 q 一个小于等于n的平方根，一个大于等于n的平方根
            //在小于Math.sqrt(num)的数中找不到它的因子，则该数本身应该为质数
            //因此循环到Math.sqrt(num)即可
            // 如 8 = 2 * 4; 10 = 2 * 5;12 = 3 * 4
            for (int i = 2; i <= Math.Sqrt(num); i++)
            {
                // i 等于偶数被整除的情况不可能出现
                // 也不可能循环到Math.sqrt(num)以上的数
                // 循环求i是不是它的质因数，直到i不是它的因数为止(i = 4能被整除的不可能出现，因为当i=2时已经被全求出来了)
                // 也就是说number % i==0的情况，只有当i为质数时才有可能出现。
                while (true)
                {
                    // 如果能整除，就求number/i的质因数
                    if (num % i == 0)
                    {
                        chuan.Append(i);
                        chuan.Append(" ");
                        num /= i;
                    }
                    else
                    {
                        break;
                    }

                }
            }
            if (num != 1)
            {
                chuan.Append(num);
                chuan.Append(" ");
            }
            return chuan.ToString();
        }
    }
}
