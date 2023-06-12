using Days.Model.Alternation;
using System;
using System.ComponentModel;
using UnityEngine;
using Zenject;

namespace Days.ViewModel.Alternation
{
    public class DaysCounterViewModel : IDaysCounterViewModel, IDisposable
    {
        private IDaysCounter _model;

        public event PropertyChangedEventHandler PropertyChanged;

        public int Day => _model.Day;

        [Inject]
        private void Construct(IDaysCounter model)
        {
            _model = model;
            _model.PropertyChanged += OnPropertyChanged;
        }

        public void Dispose()
        {
            _model.PropertyChanged -= OnPropertyChanged;
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == nameof(_model.Day))
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Day)));
            else
                Debug.LogError($"Unexpected property {args.PropertyName}");
        }
    }
}