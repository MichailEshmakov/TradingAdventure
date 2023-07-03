using Days.Model.Configs;
using Goods.Model.Readonly.Resources;
using System;
using System.Collections.Generic;
using Upgrades.Model.Configs;

namespace Upgrades.Model
{
    public interface IUpgradesShop
    {
        public event Action<IUpgradeConfig> UpgradeBought;

        public bool TryBuy(string upgrateName);
        public bool IsBought(string upgrateName);
        public bool CanBuy(string upgrateName);
        public bool TryGetPrice(string name, out IEnumerable<IReadonlyResource> price);
        public IEnumerable<IDaySettingsConfig> GetBoughtUpgrates();
    }
}