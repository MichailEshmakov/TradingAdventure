using Goods.Model.Readonly.Resources;
using System;
using UnityEngine;

namespace Goods.Model.Configs
{
    [Serializable]
    public class CurrencyFloatPair
    {
        [SerializeField] private Currency _currency;
        [SerializeField] [Min(0)] private float _value;

        public Currency Currency => _currency;
        public float Value => _value;

        public CurrencyFloatPair(Currency currency, float value)
        {
            _currency = currency;
            _value = value;
        }
    }
}