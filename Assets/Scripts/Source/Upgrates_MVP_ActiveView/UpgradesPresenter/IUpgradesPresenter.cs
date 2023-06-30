using Goods.Model.Readonly.Resources;
using System;
using System.Collections.Generic;

namespace Upgrades.Presenter
{
    public interface IUpgradesPresenter
    {
        public event Action<string> UpgradeBought;

        public bool IsUpgradeBought(string upgradeName);
        public bool IsUpgradeAwailable(string upgradeName);
        public bool TryDownloadPrice(string upgradeName, out IEnumerable<IReadonlyResource> price);
        public bool TryBuy(string upgradeName);
    }
}
