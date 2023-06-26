using Days.Model.Configs;
using Goods.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Upgrades.Model.Configs;

namespace Upgrades.Model
{
    public class UpgradesShop : IUpgradesShop
    {
        private readonly IDictionary<string, BuyableUpgrate> _areUpgratesBought;
        private readonly IStorage _storage;

        public event Action<IDaySettingsConfig> UpgradeBought;

        public UpgradesShop(IEnumerable<IUpgradeConfig> upgrades, IStorage storage)
        {
            _areUpgratesBought = upgrades.ToDictionary(upgrade => upgrade.Name,
                upgrade => new BuyableUpgrate() { Config = upgrade, IsBought = false });
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

        private struct BuyableUpgrate
        {
            public IUpgradeConfig Config;
            public bool IsBought;
        }
    }
}