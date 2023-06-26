using Days.Model.Configs;
using System;

namespace Upgrades.Model
{
    public interface IUpgradesShop
    {
        public event Action<IDaySettingsConfig> UpgradeBought;

        public bool TryBuy(string upgrateName);
        public bool IsBought(string upgrateName);
        public bool CanBuy(string upgrateName);
    }
}