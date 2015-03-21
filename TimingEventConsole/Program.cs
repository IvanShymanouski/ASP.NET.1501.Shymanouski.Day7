using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimingEvent;

namespace TimingEventConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            CountDounTimer timer = new CountDounTimer();
            timer.TimeEvent += delegate(string s)
            {
                if (s == "Who wants to go to the theater?")
                    Console.WriteLine("I am a happy subscriber number 1.");
                else Console.WriteLine("No, thanks. I am sad subcriber number 1. I wants to go to the theater.");
            };


            timer.TimeEvent += Subscriber;

            timer.TimeEvent += (string s) =>
            {
                if (s == "Who wants to go for a cup of coffe?")
                    Console.WriteLine("I am a happy subscriber number 2.");
                else Console.WriteLine("No, thanks. I am sad subcriber number 2. I wants to go for a cup of coffe.");
            };

            CarefreeMan man = new CarefreeMan(timer);

            timer.OnDounTimer(3, "Who wants to go to the theater?");
            Console.WriteLine();
            timer.OnDounTimer(4, "Who wants to go for a cup of coffe?");
            Console.WriteLine();
            timer.OnDounTimer(2, "Who wants to go to tennis?");


            timer.TimeEvent -= Subscriber;

            Console.WriteLine();
            timer.OnDounTimer(1, "Who wants to go for a cup of coffe?");
        }

        private static void Subscriber(string s)
        {
            if (s == "Who wants to go for a cup of coffe?")
            {
                Console.WriteLine("*****");
                Console.WriteLine("I am a happy static subscriber number.");
                Console.WriteLine("*****");
            }
            else
            {
                Console.WriteLine("*****");
                Console.WriteLine("No, thanks. I am sad static subcriber number. I wants to go for a cup of coffe.");
                Console.WriteLine("*****");
            }
        }

        private class CarefreeMan
        {
            public CarefreeMan(CountDounTimer timer)
            {
                timer.TimeEvent += EntertainingProgram;
            }

            private void EntertainingProgram(string s)
            {
                if ((s == "Who wants to go for a cup of coffe?") ||
                    (s == "Who wants to go to the theater?")
                   )
                    Console.WriteLine("I am a carefree man, of cource I want.");
                else Console.WriteLine("Maybe I'll go, becouse I am a carefree man.");
            }
        }
    }
}
