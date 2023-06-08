using Days.Model.Configs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using Zenject;

namespace Days.Model
{
    public class DaySettings : INotifyPropertyChanged
    {
        private IDaySettingsConfig _config;
        private float _clientsAmount;
        private float _dealsCostCoefficient;
        private float _clientsTypesAmount;

        public event PropertyChangedEventHandler PropertyChanged;

        [Inject]
        private void Consrtuct(IDaySettingsConfig config)
        {
            _config = config;
        }
    }
}