using Days.ViewModel;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Days.View
{
    public class DaySettingsView : MonoBehaviour
    {
        [SerializeField] private Slider _advertisement;
        [SerializeField] private Slider _goodsAmount;
        [SerializeField] private Slider _townScale;

        private IDaySettingsViewModel _viewModel;

        [Inject]
        private void Construct(IDaySettingsViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        private void OnEnable()
        {
            _viewModel.PropertyChanged += OnPropertyChanged;
            _advertisement.value = 1 - _viewModel.ClientsAmountPart;
            _goodsAmount.value = 1 - _viewModel.DealsCostCoefficientPart;
            _townScale.value = 1 - _viewModel.ClientsTypesAmountPart;

            _advertisement.onValueChanged.AddListener(OnAdvertismentValueChanged);
            _goodsAmount.onValueChanged.AddListener(OnGoodsAmountValueChanged);
            _townScale.onValueChanged.AddListener(OnTownScaleValueChanged);
        }

        private void OnDisable()
        {
            _viewModel.PropertyChanged -= OnPropertyChanged;

            _advertisement.onValueChanged.RemoveListener(OnAdvertismentValueChanged);
            _goodsAmount.onValueChanged.RemoveListener(OnGoodsAmountValueChanged);
            _townScale.onValueChanged.RemoveListener(OnTownScaleValueChanged);
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            switch (args.PropertyName)
            {
                case nameof(_viewModel.ClientsAmountPart):
                    _advertisement.onValueChanged.RemoveListener(OnAdvertismentValueChanged);
                    _advertisement.value = _viewModel.ClientsAmountPart;
                    _advertisement.onValueChanged.AddListener(OnAdvertismentValueChanged);
                    break;
                case nameof(_viewModel.DealsCostCoefficientPart):
                    _goodsAmount.onValueChanged.RemoveListener(OnGoodsAmountValueChanged);
                    _goodsAmount.value = _viewModel.DealsCostCoefficientPart;
                    _goodsAmount.onValueChanged.AddListener(OnGoodsAmountValueChanged);
                    break;
                case nameof(_viewModel.ClientsTypesAmountPart):
                    _townScale.onValueChanged.RemoveListener(OnTownScaleValueChanged);
                    _townScale.value = _viewModel.ClientsTypesAmountPart;
                    _townScale.onValueChanged.AddListener(OnTownScaleValueChanged);
                    break;
                default:
                    Debug.LogError($"Unexpected {nameof(args.PropertyName)}");
                    break;
            }
        }

        private void OnAdvertismentValueChanged(float newValue)
        {
            Debug.Log(newValue);
            Debug.Log(_advertisement.value);
            _viewModel.ClientsAmountPart = newValue;
        }

        private void OnGoodsAmountValueChanged(float newValue)
        {
            _viewModel.DealsCostCoefficientPart = newValue;
        }

        private void OnTownScaleValueChanged(float newValue)
        {
            _viewModel.ClientsTypesAmountPart = newValue;
        }
    }
}
