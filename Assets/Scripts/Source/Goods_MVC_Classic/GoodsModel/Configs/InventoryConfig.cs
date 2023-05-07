using Goods.Model.Readonly.Resources;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Goods.Model.Configs
{
    [CreateAssetMenu(fileName = nameof(InventoryConfig), menuName = "Configs/Model/" + nameof(InventoryConfig), order = 0)]
    public class InventoryConfig : ScriptableObject
    {
        [SerializeField] private List<CurrencyValuePair> _startPlayersResources;

        public IEnumerable<CurrencyValuePair> StartPlayersResources => _startPlayersResources;
    }

    [Serializable]
    public struct CurrencyValuePair
    {
        [SerializeField] private Currency _currency;
        [SerializeField] [Min(0)] private int _value;

        public Currency Currency => _currency;
        public int Value => _value;
    }
}