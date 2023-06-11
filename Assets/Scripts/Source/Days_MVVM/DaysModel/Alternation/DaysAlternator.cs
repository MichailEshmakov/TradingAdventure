using System;

namespace Days.Model.Alternation
{
    public class DaysAlternator : IDaysAlternator, IDayStartingPublisher
    {
        public event Action NextDayStarted;

        public void StartNextDay()
        {
            NextDayStarted?.Invoke();
        }
    }
}