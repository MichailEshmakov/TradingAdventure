using System.Collections.Generic;
using UnityEngine;

namespace Upgrades.Model.Configs
{
    [CreateAssetMenu(fileName = nameof(AllUpgrades), menuName = "Configs/Model/" + nameof(AllUpgrades), order = 0)]
    public class AllUpgrades : ScriptableObject, IAllUpgrades
    {
        [SerializeField] private List<UpgradeConfig> _upgradeConfigs;

        public IEnumerable<UpgradeConfig> UpgradeConfigs => _upgradeConfigs; 
    }
}