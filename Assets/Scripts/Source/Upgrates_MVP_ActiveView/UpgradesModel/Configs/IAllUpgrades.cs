using System.Collections.Generic;

namespace Upgrades.Model.Configs
{
    public interface IAllUpgrades
    {
        public IEnumerable<UpgradeConfig> UpgradeConfigs { get; }
    }
}