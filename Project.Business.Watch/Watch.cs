using System;
using System.Diagnostics;

namespace Project.Business.Watch
{
    public class Watch
    {
        public int Hours {  get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }     

        public Stopwatch Stopwatch = new();

        public Watch() { }
        

        public void Start()
        {
            Stopwatch.Start();
        }

        public void Stop()
        {
            Stopwatch.Stop();
        }

        public void Restart()
        {
            Stopwatch.Restart();
        }






    }
}
