using Goods.Model;
using Goods.Model.Configs;
using Goods.Model.Readonly.Resources;
using Goods.Model.Resources;
using System.Collections.Generic;
using Tests.Mock;
using UnityEngine;

namespace Tests.UnitTests.Goods
{
    public static class Setup
    {
        public static FinalPrice FinalPrice(float basicPrice, params float[] coefficients)
        {
            FinalPrice finalPrice = new FinalPrice(basicPrice);

            foreach (float coefficient in coefficients)
            {
                IPriceCoefficient coefficientObject = new PriceCoefficientMock(coefficient);
                finalPrice.TryAddCoefficient(coefficientObject);
            }

            return finalPrice;
        }

        public static Storage Storage(params IResource[] resources)
        {
            return new Storage(resources);
        }

        public static Storage Storage(params Currency[] currencies)
        {
            IResource[] resources = new IResource[currencies.Length];
            for (int i = 0; i < resources.Length; i++)
            {
                resources[i] = new Resource(0, currencies[i]);
            }

            return Storage(resources);
        }
        
        public static Resource Resource(int value, Currency currency)
        {
            return new Resource(value, currency);
        }

        public static BasicPricesConfig BasicPricesConfig(IDictionary<Currency, float> prices)
        {
            BasicPricesConfig config = ScriptableObject.CreateInstance<BasicPricesConfig>();
            config.Init(prices);
            return config;
        }
    }
}