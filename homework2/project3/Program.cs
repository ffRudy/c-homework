using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aishai
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] visit = new int[105];
            for (int i = 2; i <= 100; i++)
            {
                if (visit[i] == 1) { continue; }//已经被筛掉了的不能做为筛子
                for (int j = i + 1; j <= 100; j++)
                {
                    if (j % i == 0)
                    {
                        visit[j] = 1;
                    }
                }
                Console.WriteLine(i);
            }
        }
    }
}
