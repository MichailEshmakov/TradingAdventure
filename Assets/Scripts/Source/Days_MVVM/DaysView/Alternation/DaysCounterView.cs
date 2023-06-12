using Days.ViewModel.Alternation;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using Zenject;

namespace Days.View.Alternation
{
    public class DaysCounterView : MonoBehaviour
    {
        [SerializeField] private string _beforeNumberPart = "Day ";
        [SerializeField] private TMP_Text _text;

        private IDaysCounterViewModel _viewModel;

        [Inject]
        private void Construct(IDaysCounterViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        private void OnEnable()
        {
            UpdateText();
            _viewModel.PropertyChanged += OnPropertyChanged;
        }

        private void OnDisable()
        {
            _viewModel.PropertyChanged -= OnPropertyChanged;
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == nameof(_viewModel.Day))
                UpdateText();
            else
                Debug.LogError($"Unexpected property {args.PropertyName}");
        }

        private void UpdateText()
        {
            _text.text = _beforeNumberPart + _viewModel.Day;
        }
    } 
}
