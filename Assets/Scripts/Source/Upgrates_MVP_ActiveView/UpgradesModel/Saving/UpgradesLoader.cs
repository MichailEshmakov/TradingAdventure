using UnityEngine;

namespace Upgrades.Model.Saving
{
    public class UpgradesLoader : IStartBoughtFlags
    {
        public bool this[string upgrade] => PlayerPrefs.GetInt(upgrade) > 0;
    }
}