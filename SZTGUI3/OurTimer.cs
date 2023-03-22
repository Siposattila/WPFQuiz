using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Timers;

namespace SZTGUI3
{
    internal class OurTimer
    {
        private static System.Timers.Timer timer;
        private static Thread timerThread;
        private static int timePassed = 0;

        public delegate void OnTimerEnd();
        public static event OnTimerEnd onTimerEnd;

        private static void SetTimer()
        {
            timer = new System.Timers.Timer(1000);
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine("One sec passed!");
            timePassed++;
            if (timePassed >= 60)
            {
                onTimerEnd?.Invoke();
                StopTimer();
            }
        }

        public static void StartTimer()
        {
            Console.WriteLine("Staring timer.");
            timerThread = new Thread(new ThreadStart(SetTimer));
            timerThread.Start();
        }

        public static void StopTimer()
        {
            timerThread.Suspend();
            timerThread = null;
            timer = null;
            timePassed = 0;
        }
    }
}
