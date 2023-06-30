using Goods.Model.Readonly.Resources;
using System.Collections.Generic;
using UnityEngine;

namespace Upgrades.View
{
    public interface IUpgradeBuyingMenu
    {
        public void Open(bool isAwailable, Sprite sprite, IEnumerable<IReadonlyResource> price, string upgradeName);
    }
}