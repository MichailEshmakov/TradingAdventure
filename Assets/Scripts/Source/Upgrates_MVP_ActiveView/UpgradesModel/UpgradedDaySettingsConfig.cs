using Days.Model.Configs;
using System;
using System.Collections.Generic;
using Zenject;

namespace Upgrades.Model
{
    public class UpgradedDaySettingsConfig : IDaySettingsConfig, IDisposable
    {
        private IUpgradesShop _shop;
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

        [Inject]
        private void Construct(IPrimalDaySettingsConfig config, IUpgradesShop shop)
        {
            Construct((IDaySettingsConfig)config, shop);
        }

#if UNITY_EDITOR
        public
#else
        pivate
#endif
            void Construct(IDaySettingsConfig config, IUpgradesShop shop)
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

            IEnumerable<IDaySettingsConfig> boughtUpgrades = shop.GetBoughtUpgrates();
            foreach (IDaySettingsConfig upgrade in boughtUpgrades)
            {
                ApplyUpgrade(upgrade);
            }
        }

        public void Dispose()
        {
            _shop.UpgradeBought -= OnUpgradeBought;
        }

        private void OnUpgradeBought(IDaySettingsConfig upgrade)
        {
            ApplyUpgrade(upgrade);
        }

        private void ApplyUpgrade(IDaySettingsConfig upgrade)
        {
            _maxClientsAmount += upgrade.MaxClientsAmount;
            _minClientsAmount += upgrade.MinClientsAmount;
            _maxDealsCostCoefficient += upgrade.MaxDealsCostCoefficient;
            _minDealsCostCoefficient += upgrade.MinDealsCostCoefficient;
            _maxClientsTypesAmount += upgrade.MaxClientsTypesAmount;
            _minClientsTypesAmount += upgrade.MinClientsTypesAmount;
            _allSettingsCost += upgrade.AllSettingsCost;
            _oneClientCost += upgrade.OneClientCost;
            _dealCostCoefficientCost += upgrade.DealCostCoefficientCost;
            _clientTypeCost += upgrade.ClientTypeCost;
        }
    }
}