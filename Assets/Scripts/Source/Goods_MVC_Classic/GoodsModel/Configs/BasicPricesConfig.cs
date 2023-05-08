using Goods.Model.Readonly.Resources;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Goods.Model.Configs
{
    [CreateAssetMenu(fileName = nameof(BasicPricesConfig), menuName = "Configs/Model/" + nameof(BasicPricesConfig), order = 0)]
    public class BasicPricesConfig : ScriptableObject, IBasicPricesConfig
    {
        [SerializeField] private List<CurrencyFloatPair> _basicPrices;

        public bool TryFindPrice(Currency currency, out float price)
        {
            price = 0;
            CurrencyFloatPair foundPair = _basicPrices.FirstOrDefault(resource => resource.Currency == currency);
            if (foundPair == null)
                return false;

            price = foundPair.Value;
            return true;
        }
    }
}