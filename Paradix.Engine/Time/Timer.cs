using System;
using Microsoft.Xna.Framework;

namespace Paradix
{
    public abstract class Timer 
    {
        protected Timer(double intervalSeconds)
            : this(TimeSpan.FromSeconds(intervalSeconds))
        {
        }

        protected Timer(TimeSpan interval)
        {
            Interval = interval;
            Restart();
        }

        public TimeSpan Interval { get; set; }
        public TimeSpan CurrentTime { get; protected set; }
        public TimerState State { get; protected set; }

        public void Update(GameTime gameTime)
        {
            if (State != TimerState.Started)
                return;

            CurrentTime += gameTime.ElapsedGameTime;
            OnUpdate(gameTime);
        }

        public event EventHandler Started;
        public event EventHandler Stopped;
        public event EventHandler Paused;

        public void Start()
        {
            State = TimerState.Started;
            Started?.Invoke(this, EventArgs.Empty);
        }

        public void Stop()
        {
            State = TimerState.Stopped;
            CurrentTime = TimeSpan.Zero;
            OnStopped();
            Stopped?.Invoke(this, EventArgs.Empty);
        }

        public void Restart()
        {
            Stop();
            Start();
        }

        public void Pause()
        {
            State = TimerState.Paused;
            Paused?.Invoke(this, EventArgs.Empty);
        }

        protected abstract void OnStopped();
        protected abstract void OnUpdate(GameTime gameTime);
    }
}