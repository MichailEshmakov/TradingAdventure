using Goods.Model.Readonly.Resources;
using System;
using UnityEngine;

namespace Goods.Model.Configs
{
    [Serializable]
    public class CurrencyIntPair
    {
        [SerializeField] private Currency _currency;
        [SerializeField] [Min(0)] private int _value;

        public Currency Currency => _currency;
        public int Value => _value;
    }
}