using System;
using UnityEngine;
using Upgrades.Model.Configs;
using Zenject;

namespace Upgrades.Model.Saving
{
    public class UpgradesSaver : IDisposable
    {
        private const int IsBoughtTrue = 1;

        private IUpgradesShop _shop;

        [Inject]
        private void Construct(IUpgradesShop shop)
        {
            _shop = shop;
            _shop.UpgradeBought += OnUpgradeBought;
        }

        public void Dispose()
        {
            _shop.UpgradeBought -= OnUpgradeBought;
        }

        private void OnUpgradeBought(IUpgradeConfig upgrade)
        {
            PlayerPrefs.SetInt(upgrade.Name, IsBoughtTrue);
        }
    }
}