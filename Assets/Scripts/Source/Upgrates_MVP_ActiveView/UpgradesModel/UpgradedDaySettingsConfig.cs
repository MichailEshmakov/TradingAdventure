using Days.Model.Configs;
using System;

namespace Upgrades.Model
{
    public class UpgradedDaySettingsConfig : IDaySettingsConfig, IDisposable
    {
        private readonly IUpgradesShop _shop;
        private int _maxClientsAmount;
        private int _minClientsAmount;
        private float _maxDealsCostCoefficient;
        private float _minDealsCostCoefficient;
        private int _maxClientsTypesAmount;
        private int _minClientsTypesAmount;
        private float _allSettingsCost;
        private float _oneClientCost;
        private float _dealCostCoefficientCost;
        private float _clientTypeCost;

        public int MaxClientsAmount => _maxClientsAmount;

        public int MinClientsAmount => _minClientsAmount;

        public float MaxDealsCostCoefficient => _maxDealsCostCoefficient;

        public float MinDealsCostCoefficient => _minDealsCostCoefficient;

        public int MaxClientsTypesAmount => _maxClientsTypesAmount;

        public int MinClientsTypesAmount => _minClientsTypesAmount;

        public float AllSettingsCost => _allSettingsCost;

        public float OneClientCost => _oneClientCost;

        public float DealCostCoefficientCost => _dealCostCoefficientCost;

        public float ClientTypeCost => _clientTypeCost;

        public UpgradedDaySettingsConfig(IDaySettingsConfig config, IUpgradesShop shop)
        {
            _maxClientsAmount = config.MaxClientsAmount;
            _minClientsAmount = config.MinClientsAmount;
            _maxDealsCostCoefficient = config.MaxDealsCostCoefficient;
            _minDealsCostCoefficient = config.MinDealsCostCoefficient;
            _maxClientsTypesAmount = config.MaxClientsTypesAmount;
            _minClientsTypesAmount = config.MinClientsTypesAmount;
            _allSettingsCost = config.AllSettingsCost;
            _oneClientCost = config.OneClientCost;
            _dealCostCoefficientCost = config.DealCostCoefficientCost;
            _clientTypeCost = config.ClientTypeCost;

            _shop = shop;
            _shop.UpgradeBought += OnUpgradeBought;
        }

        public void Dispose()
        {
            _shop.UpgradeBought -= OnUpgradeBought;
        }

        private void OnUpgradeBought(IDaySettingsConfig update)
        {
            _maxClientsAmount += update.MaxClientsAmount;
            _minClientsAmount += update.MinClientsAmount;
            _maxDealsCostCoefficient += update.MaxDealsCostCoefficient;
            _minDealsCostCoefficient += update.MinDealsCostCoefficient;
            _maxClientsTypesAmount += update.MaxClientsTypesAmount;
            _minClientsTypesAmount += update.MinClientsTypesAmount;
            _allSettingsCost += update.AllSettingsCost;
            _oneClientCost += update.OneClientCost;
            _dealCostCoefficientCost += update.DealCostCoefficientCost;
            _clientTypeCost += update.ClientTypeCost;
        }
    }
}