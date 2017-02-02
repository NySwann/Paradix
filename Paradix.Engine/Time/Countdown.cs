using System;
using Microsoft.Xna.Framework;

namespace Paradix
{
    public sealed class Countdown : Timer
    {
        public Countdown(double intervalSeconds)
            : base(intervalSeconds)
        {
        }

        public Countdown(TimeSpan interval)
            : base(interval)
        {
        }

        public TimeSpan TimeRemaining { get; private set; }

        public event EventHandler TimeRemainingChanged;
        public event EventHandler Finished;

        protected override void OnStopped()
        {
            CurrentTime = TimeSpan.Zero;
        }

        protected override void OnUpdate(GameTime gameTime)
        {
            TimeRemaining = Interval - CurrentTime;
            TimeRemainingChanged?.Invoke(this, EventArgs.Empty);

            if (CurrentTime >= Interval)
            {
                State = TimerState.Finished;
                CurrentTime = Interval;
                TimeRemaining = TimeSpan.Zero;
                Finished?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}