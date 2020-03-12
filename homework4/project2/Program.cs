using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace home4_2
{
    public delegate void AlarmHandler(int h,int m,int s);
    public delegate void TickHandler(int h,int m,int s);
    public class Clock
    {
        public event AlarmHandler Alarm;
        public event TickHandler Tick;
        private int hour;
        private int minute;
        private int second;
        private int alarm_hour;
        private int alarm_minute;
        private int alarm_second;
        public void Start()
        {
            this.hour = DateTime.Now.Hour;
            this.minute = DateTime.Now.Minute;
            this.second = DateTime.Now.Second;
        }
        public void ClockTick()
        {
            this.hour = DateTime.Now.Hour;
            this.minute = DateTime.Now.Minute;
            this.second = DateTime.Now.Second;
            if (this.hour == this.alarm_hour && this.minute == this.alarm_minute && this.second == this.alarm_second)
            {
                return;
            }
            else
            {
                Tick(this.hour, this.minute, this.second);
            }
        }
        public void ClockAlarm()
        {
            if (this.hour == this.alarm_hour && this.minute == this.alarm_minute && this.second == this.alarm_second){ Alarm(this.hour, this.minute, this.second); }
        }
        public void SetAlarm(int h,int m,int s)
        {
            this.alarm_hour = h;
            this.alarm_minute = m;
            this.alarm_second = s;
        }
    }
    public class Form
    {
        public Clock clock = new Clock();
        public Form()
        {
            clock.Alarm += new AlarmHandler(Clock_Alarm);
            clock.Tick += new TickHandler(Clock_Tick);
        }
        void Clock_Alarm(int h,int m,int s)
        {
            Console.WriteLine("闹钟时间到了！！！");
        }
        void Clock_Tick(int h,int m,int s)
        {
            Console.WriteLine(h + "时 " + m + "分 " + s + "秒");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Form form1 = new Form();
            form1.clock.Start();
            form1.clock.SetAlarm(23, 17, 10);
            for(int i=0; ; i++)
            {
                form1.clock.ClockTick();
                Thread.Sleep(1000);
                form1.clock.ClockAlarm();
            }
        }
    }
}
