using Days.Model;
using Days.Model.Configs;
using System;
using System.ComponentModel;
using UnityEngine;

namespace Days.ViewModel
{
    public class DaySettingsViewModel : IDaySettingsViewModel, IDisposable
    {
        private readonly IDaySettingsConfig _config;
        private readonly IDaySettings _model;
        private float _clientsAmountPart;
        private float _dealsCostCoefficientPart;
        private float _clientsTypesAmountPart;

        public float ClientsAmountPart
        {
            get 
            {
                return _clientsAmountPart;
            }
            set
            {
                _model.ClientsAmount = Mathf.RoundToInt(ComputeSettingValue(value, 
                    _config.MinClientsAmount,
                    _config.MaxClientsAmount));
            }
        }

        public float DealsCostCoefficientPart
        {
            get
            {
                return _dealsCostCoefficientPart;
            }
            set
            {
                _model.DealsCostCoefficient = ComputeSettingValue(value,
                    _config.MinDealsCostCoefficient,
                    _config.MaxDealsCostCoefficient);
            }
        }

        public float ClientsTypesAmountPart
        {
            get
            {
                return _clientsTypesAmountPart;
            }
            set
            {
                _model.ClientsTypesAmount = Mathf.RoundToInt(ComputeSettingValue(value,
                    _config.MinClientsTypesAmount,
                    _config.MaxClientsTypesAmount));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public DaySettingsViewModel(IDaySettingsConfig config, IDaySettings model)
        {
            _config = config;
            _model = model;

            if (model.Config != config)
                Debug.LogError($"Wrong {nameof(config)}!");

            ComputeClientsAmountPart();
            ComputeDealsCostCoefficientPart();
            ComputeClientsTypesAmountPart();

            _model.PropertyChanged += OnPropertyChanged;
        }

        public void Dispose()
        {
            _model.PropertyChanged -= OnPropertyChanged;
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            switch (args.PropertyName)
            {
                case nameof(IDaySettings.ClientsAmount):
                    ComputeClientsAmountPart();
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ClientsAmountPart)));
                    break;
                case nameof(IDaySettings.DealsCostCoefficient):
                    ComputeDealsCostCoefficientPart();
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DealsCostCoefficientPart)));
                    break;
                case nameof(IDaySettings.ClientsTypesAmount):
                    ComputeClientsTypesAmountPart();
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ClientsTypesAmountPart)));
                    break;
                default:
                    Debug.LogError("Unexpected property changed");
                    break;
            }
        }

        private void ComputeClientsAmountPart()
        {
            _clientsAmountPart = ComputeSettingPart(_model.ClientsAmount,
                _config.MaxClientsAmount,
                _config.MinClientsAmount);
        }

        private void ComputeDealsCostCoefficientPart()
        {
            _dealsCostCoefficientPart = ComputeSettingPart(_model.DealsCostCoefficient,
                _config.MaxDealsCostCoefficient,
                _config.MinDealsCostCoefficient);
        }

        private void ComputeClientsTypesAmountPart()
        {
            _clientsTypesAmountPart = ComputeSettingPart(_model.ClientsTypesAmount,
                _config.MaxClientsTypesAmount,
                _config.MinClientsTypesAmount);
        }

        private float ComputeSettingPart(float currentValue, float max, float min)
        {
            if (max <= min)
                return 0.5f;
            else
                return (currentValue - min) / (max - min);
        }

        private float ComputeSettingValue(float part, float max, float min)
        {
            return part * (max - min) + min;
        }
    }
}