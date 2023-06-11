using System;

namespace Days.Model.Alternation
{
    public interface IDayStartingPublisher
    {
        public event Action NextDayStarted;
    }
}