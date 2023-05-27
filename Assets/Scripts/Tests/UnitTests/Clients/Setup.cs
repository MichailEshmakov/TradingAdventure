using Clients.Adapter;
using Clients.Model.Configs;
using Goods.Model;
using Goods.Model.Configs;
using Goods.Model.Readonly.Resources;
using System.Collections.Generic;
using UnityEngine;

namespace Tests.UnitTests.Clients
{
    public static class Setup
    {
        public static DealCreator DealCreator(
            Currency firstCurrency,
            Currency secondCurrency,
            BasicPricesConfig config = null)
        {
            if (config == null)
                return DealCreator(firstCurrency, secondCurrency, 1f);

            IStorage inventory = Goods.Setup.Storage(firstCurrency, secondCurrency);
            return new DealCreator(config, inventory);
        }

        public static DealCreator DealCreator(
            Currency firstCurrency, 
            Currency secondCurrency, 
            float allGoodsPrice)
        {
            return DealCreator(firstCurrency, secondCurrency, allGoodsPrice, allGoodsPrice);
        }

        public static DealCreator DealCreator(
            Currency firstCurrency, 
            Currency secondCurrency, 
            float firstCurrencyCost, 
            float secondCurrencyCost)
        {
            Dictionary<Currency, float> prices = new Dictionary<Currency, float>
                {
                    { firstCurrency, firstCurrencyCost },
                    { secondCurrency, secondCurrencyCost }
                };

            BasicPricesConfig config = Goods.Setup.BasicPricesConfig(prices);
            return DealCreator(firstCurrency, secondCurrency, config);
        }

        public static Client Client(List<ClientPreference> resourceCoefficients = null, float dealCost = 10)
        {
            if (resourceCoefficients == null)
            {
                resourceCoefficients = new List<ClientPreference>
                {
                    ResourceCoefficients(0),
                    ResourceCoefficients((Currency)1)
                };
            }

            Client client = ScriptableObject.CreateInstance<Client>();
            client.Init(resourceCoefficients, dealCost);
            return client;
        }

        public static ClientPreference ResourceCoefficients(
            Vector2 demandCoefficients,
            Vector2 supplyCoefficients,
            Currency currency = 0,
            float demandChance = 1f,
            float supplyChance = 1f)
        {
            return new ClientPreference(currency, demandCoefficients, supplyCoefficients, demandChance, supplyChance);
        }

        public static ClientPreference ResourceCoefficients(
            Currency currency = 0,
            float demandChance = 1f,
            float supplyChance = 1f)
        {
            Vector2 demandCoefficients = Vector2.one;
            Vector2 supplyCoefficients = Vector2.one;
            return ResourceCoefficients(demandCoefficients, supplyCoefficients, currency, demandChance, supplyChance);
        }
    }
}