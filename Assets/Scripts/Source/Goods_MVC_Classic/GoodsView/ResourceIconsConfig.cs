using Goods.Model.Readonly.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Goods.View
{
    [CreateAssetMenu(fileName = nameof(ResourceIconsConfig), menuName = "Configs/View/" + nameof(ResourceIconsConfig), order = 0)]
    public class ResourceIconsConfig : ScriptableObject, IResourceIconsConfig
    {
        [SerializeField] private List<CurrencySpritePair> _currencyIcons;

        public bool TryGetSprite(Currency currency, out Sprite sprite)
        {
            sprite = null;
            CurrencySpritePair currencySpritePair = _currencyIcons.FirstOrDefault(pair => pair.Currency == currency);
            if (currencySpritePair == null)
                return false;

            sprite = currencySpritePair.Sprite;
            return true;
        }
    }

    [Serializable]
    public class CurrencySpritePair
    {
        [SerializeField] private Sprite _sprite;
        [SerializeField] private Currency _currency;

        public Sprite Sprite => _sprite;
        public Currency Currency => _currency;

    }
}