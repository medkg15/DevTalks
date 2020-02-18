using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Examples.Encapsulation
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var light = new TrafficLight(TimeSpan.FromSeconds(10), TimeSpan.FromSeconds(3));

            var previous = DateTime.Now;

            while (true)
            {
                var now = DateTime.Now;
                var delta = now - previous;
                previous = now;

                light.AdvanceTime(delta);

                Console.WriteLine($"At {now}:");
                Console.WriteLine("North/South: " + light.CheckSignal(TrafficLight.Direction.NorthSouth));
                Console.WriteLine("East/West: " + light.CheckSignal(TrafficLight.Direction.EastWest));
                Console.WriteLine();

                // simulate the passage of time doing other things in the program...
                Thread.Sleep(1000);
            }
        }
    }
}
