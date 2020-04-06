using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homework7
{
    public partial class Form1 : Form
    {
        int n1=10,leng1=50;
        double per1=0.6;
        double per2=0.7;
        private Graphics graphics;
        int thr=30, thl=20;
        double th1 = 30 * Math.PI / 180;
        double th2 = 20 * Math.PI / 180;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (graphics == null) graphics = this.panel1.CreateGraphics();
            graphics.Clear(this.panel1.BackColor);
            drawCayleyTree1(n1, 350,400, leng1, -Math.PI / 2);
        }
        void drawCayleyTree1(int n,double x0,double y0,double leng,double th)
        {
            if (n == 0) return;
            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);
            drawLine(x0, y0, x1, y1);
            drawCayleyTree1(n - 1, x1, y1, per1 * leng, th + th1);
            drawCayleyTree1(n - 1, x1, y1, per2 * leng, th - th2);
        }
        void drawLine(double x0, double y0, double x1, double y1)
        {
            if ((string)comboBox1.SelectedItem == "红")
            {
                graphics.DrawLine(Pens.Red, (int)x0, (int)y0, (int)x1, (int)y1);
            }
            if ((string)comboBox1.SelectedItem == "橙")
            {
                graphics.DrawLine(Pens.Orange, (int)x0, (int)y0, (int)x1, (int)y1);
            }
            if ((string)comboBox1.SelectedItem == "黄")
            {
                graphics.DrawLine(Pens.Yellow, (int)x0, (int)y0, (int)x1, (int)y1);
            }
            if ((string)comboBox1.SelectedItem == "绿")
            {
                graphics.DrawLine(Pens.Green, (int)x0, (int)y0, (int)x1, (int)y1);
            }
            if ((string)comboBox1.SelectedItem == "蓝")
            {
                graphics.DrawLine(Pens.Blue, (int)x0, (int)y0, (int)x1, (int)y1);
            }
            if ((string)comboBox1.SelectedItem == "紫")
            {
                graphics.DrawLine(Pens.Purple, (int)x0, (int)y0, (int)x1, (int)y1);
            }

        }
        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            int i = Convert.ToInt16(this.numericUpDown6.Value);
            thr = i;
            th1 = thr * Math.PI / 180;
        }
        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            int i = Convert.ToInt16(this.numericUpDown5.Value);
            thl = i;
            th2 = thl * Math.PI / 180;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            per2 = Convert.ToDouble(textBox2.Text.Trim() == "" ? "0" : textBox2.Text.Trim());
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            per1 = Convert.ToDouble(textBox3.Text.Trim() == "" ? "0" : textBox3.Text.Trim());
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            leng1 = Convert.ToInt32(textBox1.Text.Trim() == "" ? "0" : textBox1.Text.Trim());
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
           int i = Convert.ToInt16(this.numericUpDown1.Value);
            n1 = i;
        }
    }

}
