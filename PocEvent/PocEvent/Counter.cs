using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocEvent
{
    internal class Counter
    {
        private readonly int _threshold;
        private int _total;

        public Counter(int passedThreshold)
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
                OnThresholdReached(EventArgs.Empty);
        }

        protected virtual void OnThresholdReached(EventArgs e)
        {
            ThresholdReached?.Invoke(this, e);
        }

        public event EventHandler ThresholdReached;
    }
}
