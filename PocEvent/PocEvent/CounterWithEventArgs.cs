using System;

namespace PocEvent
{
    internal class CounterWithEventArgs
    {
        private readonly int _threshold;
        private int _total;

        public CounterWithEventArgs(int passedThreshold)
        {
            _threshold = passedThreshold;            
            Console.WriteLine($"0 / {_threshold}");
        }

        public void Add(int x)
        {
            // agrega
            _total += x;

            // update display
            var posLeft = Console.CursorLeft;
            var posTop = Console.CursorTop;
            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"{_total} / {_threshold}");
            Console.SetCursorPosition(posLeft, posTop);

            // test threshold
            if (_total >= _threshold)
            {
                var args = new ThresholdReachedEventArgs
                {
                    Threshold = _threshold,
                    TimeReached = DateTime.Now
                };
                OnThresholdReached(args);
            }
        }

        protected virtual void OnThresholdReached(ThresholdReachedEventArgs e)
        {
            ThresholdReached?.Invoke(this, e);            
        }

        public event EventHandler<ThresholdReachedEventArgs> ThresholdReached;
    }

    public class ThresholdReachedEventArgs : EventArgs
    {
        public int Threshold { get; set; }
        public DateTime TimeReached { get; set; }
    }
}
