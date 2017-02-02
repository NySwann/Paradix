using System;
using Microsoft.Xna.Framework;

namespace Paradix
{
    public sealed class Clock : Timer
    {
        public Clock(double intervalSeconds)
            : base(intervalSeconds)
        {
        }

        public Clock(TimeSpan interval)
            : base(interval)
        {
        }

        public TimeSpan NextTickTime { get; private set; }

        public event EventHandler Tick;

        protected override void OnStopped()
        {
            NextTickTime = CurrentTime + Interval;
        }

        protected override void OnUpdate(GameTime gameTime)
        {
            if (CurrentTime >= NextTickTime)
            {
                NextTickTime = CurrentTime + Interval;
                Tick?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}