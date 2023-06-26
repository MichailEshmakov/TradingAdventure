using Days.Model.Configs;
using Goods.Model.Readonly.Resources;
using System.Collections.Generic;

namespace Upgrades.Model.Configs
{
    public interface IUpgradeConfig : IDaySettingsConfig
    {
        public string Name { get; }
        public IEnumerable<IReadonlyResource> Price { get; }
    }
}