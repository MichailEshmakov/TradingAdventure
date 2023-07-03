using Days.Model.Alternation.Saving;
using System;
using System.ComponentModel;
using Zenject;

namespace Days.Model.Alternation
{
    public class DaysCounter : IDisposable, IDaysCounter
    {
        private int _day = 1;
        private IDayStartingPublisher _startingPublisher;

        public event PropertyChangedEventHandler PropertyChanged;

        public int Day => _day;

        [Inject]
        private void Construct(IDayStartingPublisher startingPublisher, IStartCurrentDay currentDay)
        {
            _day = currentDay.LoadValue();
            _startingPublisher = startingPublisher;
            _startingPublisher.NextDayStarted += OnNextDayStarted;
        }

        public void Dispose()
        {
            _startingPublisher.NextDayStarted -= OnNextDayStarted;
        }

        private void OnNextDayStarted()
        {
            _day++;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Day)));
        }
    }
}