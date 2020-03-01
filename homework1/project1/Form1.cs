using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        int n1, n2,res;
        string myOperator;
        public Form1()
        {
            InitializeComponent();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            n1 = int.Parse(num1.Text);
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            n2 = int.Parse(num2.Text);
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {
            myOperator = "add";//保存运算符 加号
        }

        private void button2_Click(object sender, EventArgs e)
        {
            myOperator = "sub";//保存运算符 减号
        }

        private void button3_Click(object sender, EventArgs e)
        {
            myOperator = "mul";//保存运算符 乘号
        }

        private void button4_Click(object sender, EventArgs e)
        {
            myOperator = "div";//保存运算符 除号
        }

        private void button5_Click(object sender, EventArgs e)
        {
            switch (myOperator)//用switch进行响应的分支操作
            {
                case "add"://加号
                    res = n1 + n2;
                    result.Text = res.ToString();
                    break;
                case "sub"://减号
                    res = n1 - n2;
                    result.Text = res.ToString();
                    break;
                case "mul"://乘号
                    res = n1 * n2;
                    result.Text = res.ToString();
                    break;
                case "div"://除号
                    if (n2 == 0)//除数为0报错
                    {
                        result.Text = "除数不能为“0”！";
                    }
                    else
                    {
                        res = n1 / n2;
                        result.Text = res.ToString();
                    }
                    break;
            }
        }
    }
}
