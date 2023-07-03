using Days.Model.Configs;
using Goods.Model;
using Goods.Model.Readonly.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using Upgrades.Model.Configs;
using Upgrades.Model.Saving;
using Zenject;

namespace Upgrades.Model
{
    public class UpgradesShop : IUpgradesShop
    {
        private IDictionary<string, BuyableUpgrate> _areUpgratesBought;
        private IStorage _storage;

        public event Action<IUpgradeConfig> UpgradeBought;

        public UpgradesShop(IEnumerable<IUpgradeConfig> upgrades, IStorage storage)
        {
            Construct(upgrades, storage);
        }

        [Inject]
        private void Construct(IAllUpgrades upgrades, IStorage storage, IStartBoughtFlags startBoughtFlags)
        {
            Construct(upgrades.UpgradeConfigs, storage, startBoughtFlags);
        }

        private void Construct(IEnumerable<IUpgradeConfig> upgrades, IStorage storage, IStartBoughtFlags startBoughtFlags = null)
        {
            _areUpgratesBought = upgrades.ToDictionary(upgrade => upgrade.Name,
                upgrade => new BuyableUpgrate() 
                { 
                    Config = upgrade, 
                    IsBought = startBoughtFlags != null && 
                        startBoughtFlags[upgrade.Name] 
                });
            _storage = storage;
        }

        public bool CanBuy(string upgrateName)
        {
            if (IsBought(upgrateName) == true)
                return false;

            return _areUpgratesBought[upgrateName].Config.Price.All(resource =>
                _storage.CanSpend(resource.Currency, resource.Value));
        }

        public bool IsBought(string upgrateName)
        {
            return _areUpgratesBought[upgrateName].IsBought;
        }

        public bool TryBuy(string upgrateName)
        {
            if (CanBuy(upgrateName) == false)
                return false;

            IUpgradeConfig upgrade = _areUpgratesBought[upgrateName].Config;

            bool isBought = upgrade.Price.All(resource =>
                _storage.TrySpend(resource.Currency, resource.Value));

            if (isBought)
            {
                _areUpgratesBought[upgrateName] = new BuyableUpgrate { Config = upgrade, IsBought = isBought };
                UpgradeBought?.Invoke(upgrade);
            }

            return isBought;
        }

        public bool TryGetPrice(string name, out IEnumerable<IReadonlyResource> price)
        {
            price = null;
            if (_areUpgratesBought.ContainsKey(name) == false)
                return false;

            price = _areUpgratesBought[name].Config.Price;
            return true;
        }

        public IEnumerable<IDaySettingsConfig> GetBoughtUpgrates()
        {
            return _areUpgratesBought.Values
                .Where(upgrade => upgrade.IsBought)
                .Select(upgrade => upgrade.Config);
        }

        private struct BuyableUpgrate
        {
            public IUpgradeConfig Config;
            public bool IsBought;
        }
    }
}