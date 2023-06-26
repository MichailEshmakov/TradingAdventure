using Days.Model.Configs;
using Goods.Model;
using System;
using System.Collections.Generic;
using Upgrades.Model;
using Upgrades.Model.Configs;

namespace Tests.UnitTests.Upgrades
{
    public static class Setup
    {
        public static UpgradesShop UpgradesShop(IEnumerable<IUpgradeConfig> upgrades, IStorage storage)
        {
            return new UpgradesShop(upgrades, storage);
        }

        public static UpgradedDaySettingsConfig UpgradedDaySettingsConfig(IDaySettingsConfig daySettingsConfig, IUpgradesShop shop)
        {
            return new UpgradedDaySettingsConfig(daySettingsConfig, shop);
        }
    }
}