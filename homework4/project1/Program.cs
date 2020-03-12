using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace home4_1
{ // 链表节点
    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Data { get; set; }

        public Node(T t)
        {
            Next = null;
            Data = t;
        }
    }

    //泛型链表类
    public class GenericList<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public GenericList()
        {
            tail = head = null;
        }

        public Node<T> Head
        {
            get => head;
        }

        public void Add(T t)
        {
            Node<T> n = new Node<T>(t);
            if (tail == null)
            {
                head = tail = n;
            }
            else
            {
                tail.Next = n;
                tail = n;
            }
        }
        public void ForEach(Action<T> action)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            Node<T> head = Head;
            while (head != null)
            {
                action(head.Data);
                head = head.Next;
                if (head == null)
                {
                    break;
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 整型List
            GenericList<int> intlist = new GenericList<int>();
            for (int x = 0; x < 10; x++)
            {
                intlist.Add(x);
            }
            for (Node<int> node = intlist.Head;
                  node != null; node = node.Next)
            {
                Console.WriteLine(node.Data);
            }

            // 字符串型List
            GenericList<string> strList = new GenericList<string>();
            for (int x = 0; x < 10; x++)
            {
                strList.Add("str" + x);
            }
            for (Node<string> node = strList.Head;
                    node != null; node = node.Next)
            {
                Console.WriteLine(node.Data);
            }
            int max = -1000000;
            int min = 1000000;
            int sum = 0;
            intlist.ForEach((x) =>
            {
                if (x > max) { max = x; }
                if (x < min) { min = x; }
                sum += x;
                Console.WriteLine("目前最大值为：" + max);
                Console.WriteLine("目前最小值为：" + min);
                Console.WriteLine("目前和为：" + sum);
            });

        }

    }
}
