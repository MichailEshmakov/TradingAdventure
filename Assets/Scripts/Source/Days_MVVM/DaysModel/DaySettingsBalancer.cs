using Days.Model.Configs;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Days.Model
{
    public class DaySettingsBalancer : IDaySettingsBalancer
    {
        private readonly IDaySettingsConfig _config;

        public DaySettingsBalancer(IDaySettingsConfig config)
        {
            _config = config;
        }

        public DaySettingsValues Balance(IDaySettingsValues primarySettings, DaySettingType stableSettingType = DaySettingType.Nothing)
        {
            Dictionary<DaySettingType, float> balancedSettings = new Dictionary<DaySettingType, float>();
            DaySettingsValues climpedSettings = Clamp(primarySettings);
            ICollection<Setting> considerableSettings = CreateSettingsCollection(climpedSettings);

            float neededCost = _config.AllSettingsCost;
            float costOfConsiderableSetting = ComputeCost(considerableSettings);

            Setting stableSetting = considerableSettings.FirstOrDefault(setting => setting.Type == stableSettingType);
            if (stableSetting != null)
                AddToResult(stableSetting);

            List<Setting> limitedSettings = new List<Setting>();
            do
            {
                limitedSettings.Clear();
                foreach (var setting in considerableSettings)
                {
                    Fit(setting, out bool isReachedLimit);
                    if (isReachedLimit)
                        limitedSettings.Add(setting);
                }

                limitedSettings.ForEach(setting => AddToResult(setting));
            }
            while (limitedSettings.Count > 0);

            while (considerableSettings.Count() > 0)
            {
                AddToResult(considerableSettings.First());
            }

            void AddToResult(Setting setting)
            {
                neededCost -= setting.CostOfOne * setting.Value;
                costOfConsiderableSetting -= setting.CostOfOne * setting.Value;
                considerableSettings.Remove(setting);
                balancedSettings.Add(setting.Type, setting.Value);
            }

            void Fit(Setting setting, out bool isReachedLimit)
            {
                setting.Value *= neededCost / costOfConsiderableSetting;

                if (setting.Value >= setting.Max)
                {
                    setting.Value = setting.Max;
                    isReachedLimit = true;
                }
                
                if (setting.Value <= setting.Min)
                {
                    setting.Value = setting.Min;
                    isReachedLimit = true;
                }

                isReachedLimit = false;
            }

            return new DaySettingsValues(Mathf.RoundToInt(balancedSettings[DaySettingType.ClientsAmount]),
                balancedSettings[DaySettingType.DealsCostCoefficient],
                Mathf.RoundToInt(balancedSettings[DaySettingType.ClientsTypesAmount]));
        }

        private float ComputeCost(IEnumerable<Setting> settings)
        {
            return settings.Select(setting => setting.Value * setting.CostOfOne).Sum();
        }

        private DaySettingsValues Clamp(IDaySettingsValues primarySettings)
        {
            int clientsAmount = Mathf.Clamp(primarySettings.ClientsAmount,
                _config.MinClientsAmount,
                _config.MaxClientsAmount);
            float dealsCostCoefficient = Mathf.Clamp(primarySettings.DealsCostCoefficient,
                _config.MinDealsCostCoefficient,
                _config.MaxDealsCostCoefficient);
            int clientsTypesAmount = Mathf.Clamp(primarySettings.ClientsTypesAmount,
                _config.MinClientsTypesAmount,
                _config.MaxClientsTypesAmount);

            return new DaySettingsValues(clientsAmount, dealsCostCoefficient, clientsTypesAmount);
        }

        private ICollection<Setting> CreateSettingsCollection(DaySettingsValues climpedSettings)
        {
            return new List<Setting>()
            {
                new Setting(climpedSettings.ClientsAmount,
                    _config.MaxClientsAmount,
                    _config.MinClientsAmount,
                    _config.OneClientCost,
                    DaySettingType.ClientsAmount),
                new Setting(climpedSettings.DealsCostCoefficient,
                    _config.MaxDealsCostCoefficient,
                    _config.MinDealsCostCoefficient,
                    _config.DealCostCoefficientCost,
                    DaySettingType.DealsCostCoefficient),
                new Setting(climpedSettings.ClientsTypesAmount,
                    _config.MaxClientsTypesAmount,
                    _config.MinClientsTypesAmount,
                    _config.ClientTypeCost,
                    DaySettingType.ClientsTypesAmount)
            };
        }

        private class Setting
        {
            private float _value;
            private readonly float _max;
            private readonly float _min;
            private readonly float _costOfOne;
            private readonly DaySettingType _type;

            public float Value {
                get => _value;
                set
                {
                    _value = Mathf.Clamp(value, _min, _max);
                } 
            }
            public float Max => _max;
            public float Min => _min;
            public float CostOfOne => _costOfOne;
            public DaySettingType Type => _type;

            public Setting(float value, float max, float min, float costOfOne, DaySettingType type)
            {
                _value = value;
                _max = max;
                _min = min;
                _costOfOne = costOfOne;
                _type = type;
            }
        }
    }
}