using System;
using System.ComponentModel;
using UnityEngine;
using Zenject;

namespace Days.Model.Alternation.Saving
{
    public class CurrentDaySaver : IDisposable
    {
        private IDaysCounter _daysCounter;

        [Inject]
        public void Construct(IDaysCounter daysCounter)
        {
            _daysCounter = daysCounter;
            _daysCounter.PropertyChanged += OnDaysCounterPropertyChanged;
        }

        public void Dispose()
        {
            _daysCounter.PropertyChanged -= OnDaysCounterPropertyChanged;
        }

        private void OnDaysCounterPropertyChanged(object sender, PropertyChangedEventArgs args)
        { 
            if (args.PropertyName == nameof(_daysCounter.Day))
                PlayerPrefs.SetInt(SavingKeys.CurrentDay, _daysCounter.Day);
        }
    }
}