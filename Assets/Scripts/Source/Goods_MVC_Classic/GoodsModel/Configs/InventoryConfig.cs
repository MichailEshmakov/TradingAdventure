using Goods.Model.Readonly.Resources;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Goods.Model.Configs
{
    [CreateAssetMenu(fileName = nameof(InventoryConfig), menuName = "Configs/Model/" + nameof(InventoryConfig), order = 0)]
    public class InventoryConfig : ScriptableObject
    {
        [SerializeField] private List<CurrencyIntPair> _startPlayersResources;

        public IEnumerable<CurrencyIntPair> StartPlayersResources => _startPlayersResources;
    }
}