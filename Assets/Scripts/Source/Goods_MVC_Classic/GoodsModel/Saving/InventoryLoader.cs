using Goods.Model.Readonly.Resources;
using UnityEngine;

namespace Goods.Model.Saving
{
    public class InventoryLoader
    {
        private readonly IKeyFormer _keyFormer;

        public InventoryLoader(IKeyFormer keyFormer)
        {
            _keyFormer = keyFormer;
        }

        public int Load(Currency currency)
        {
            return PlayerPrefs.GetInt(_keyFormer.FormKey(currency));
        }

        public bool HasKey(Currency currency)
        {
            return PlayerPrefs.HasKey(_keyFormer.FormKey(currency));
        }
    }
}