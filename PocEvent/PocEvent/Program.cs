using System;

namespace PocEvent
{
    internal class Program
    {
        private static void Main()
        {
            //var counter = new CounterWithEventArgs(new Random().Next(10));
            //counter.ThresholdReached += Counter_ThresholdReached;

            var counter = new CounterWithEventArgs(new Random().Next(10));
            counter.ThresholdReached += CounterWithEventArgs_ThresholdReached;

            Console.WriteLine("press 'a' key to increase total");
            while (Console.ReadKey(true).KeyChar == 'a')
            {
                Console.WriteLine("adding one");
                counter.Add(1);
            }           
        }

        static void CounterWithEventArgs_ThresholdReached(object sender, ThresholdReachedEventArgs e)
        {
            Console.WriteLine("The threshold of {0} was reached at {1}.", e.Threshold, e.TimeReached);
            Console.WriteLine("press key for finish");
            Console.ReadKey();
            Environment.Exit(0);
        }

        //private static void Counter_ThresholdReached(object sender, EventArgs e)
        //{
        //    Console.WriteLine("The threshold was reached.");
        //    Console.WriteLine("press key for finish");
        //    Console.ReadKey();
        //    var counter = sender as Counter;
        //    if (counter != null)
        //        counter.ThresholdReached -= Counter_ThresholdReached;
        //    Environment.Exit(0);
        //}
    }    
}