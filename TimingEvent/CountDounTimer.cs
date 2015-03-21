using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TimingEvent
{
    public delegate void Timer(string s);

    public class CountDounTimer
    {
        public  event Timer TimeEvent;

        public CountDounTimer()
        {
            TimeEvent += delegate(string s) {  };
        }

        public void OnDounTimer(int second, string message)
        {
            Thread.Sleep(second * 1000);

            Console.WriteLine("After {0} seconds. "+message,second);

            TimeEvent(message);
        }
    }

}
