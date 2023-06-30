using Goods.Model.Readonly.Resources;
using System;
using System.Collections.Generic;
using Upgrades.Model;
using Upgrades.Model.Configs;
using Zenject;

namespace Upgrades.Presenter
{
    public class UpgradesPresenter : IUpgradesPresenter, IDisposable
    {
        private IUpgradesShop _shop;

        public event Action<string> UpgradeBought;

        [Inject]
        private void Construct(IUpgradesShop shop)
        {
            _shop = shop;
            _shop.UpgradeBought += OnUpgradeBought;
        }

        private void OnUpgradeBought(IUpgradeConfig upgrade)
        {
            UpgradeBought?.Invoke(upgrade.Name);
        }

        public bool IsUpgradeAwailable(string upgradeName)
        {
            return _shop.CanBuy(upgradeName);
        }

        public bool IsUpgradeBought(string upgradeName)
        {
            return _shop.IsBought(upgradeName);
        }

        public bool TryDownloadPrice(string upgradeName, out IEnumerable<IReadonlyResource> price)
        {
            return _shop.TryGetPrice(upgradeName, out price);
        }

        public bool TryBuy(string upgradeName)
        {
            return _shop.TryBuy(upgradeName);
        }

        public void Dispose()
        {
            _shop.UpgradeBought -= OnUpgradeBought;
        }
    }
}