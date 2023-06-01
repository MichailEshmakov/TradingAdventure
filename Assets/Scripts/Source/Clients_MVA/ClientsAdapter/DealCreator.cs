using Clients.Model.Configs;
using Deals.Model;
using Goods.Model;
using Goods.Model.Configs;
using Goods.Model.Readonly.Resources;
using Goods.Model.Resources;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Clients.Adapter
{
    public class DealCreator : IDealCreator
    {
        private IBasicPricesConfig _config;
        private IStorage _playerInventory;

        public DealCreator(IBasicPricesConfig config, IStorage playerInventory)
        {
            Construct(config, playerInventory);
        }

        [Inject]
        private void Construct(IBasicPricesConfig config, IStorage playerInventory)
        {
            _config = config;
            _playerInventory = playerInventory;
        }

        public Deal CreateDeal(IClient client)
        {
            List<ClientPreference> cosideringPreferences = client.ResourceCoefficients.ToList();
            IResource demand = CreateDemand(cosideringPreferences, client.DealCost, out ClientPreference demandPreferences);
            cosideringPreferences.Remove(demandPreferences);
            IResource supply = CreateSupply(cosideringPreferences, client.DealCost);
            return new Deal(demand, supply, _playerInventory);
        }

        private IResource CreateResource(Currency currency, float minCoefficient, float maxCoefficient, float dealCost)
        {
            if (_config.TryFindPrice(currency, out float priceOfOne) == false)
                throw new System.Exception($"Cannot find {currency} in {nameof(_config)}");

            float demandCoefficient = Random.Range(minCoefficient, maxCoefficient);
            int resourcesAmount = Mathf.FloorToInt(dealCost / priceOfOne * demandCoefficient);
            return new Resource(resourcesAmount, currency);
        }

        private IResource CreateDemand(IEnumerable<ClientPreference> cosideringPreferences, 
            float dealCost,
            out ClientPreference demandPreferences)
        {
            cosideringPreferences = FitDemandProbabilities(cosideringPreferences);
            demandPreferences = null;
            float demandRandom = Random.value;
            float demandChanceSum = 0f;
            foreach (ClientPreference preference in cosideringPreferences)
            {
                demandChanceSum += preference.DemandChance;
                if (demandChanceSum < demandRandom)
                    continue;

                demandPreferences = preference;
                return CreateResource(demandPreferences.Currency,
                    demandPreferences.MinDemandCoefficient,
                    demandPreferences.MaxDemandCoefficient,
                    dealCost);
            }

            throw new System.ArgumentOutOfRangeException(nameof(ClientPreference.DemandChance));
        }

        private IResource CreateSupply(IEnumerable<ClientPreference> cosideringPreferences,
            float dealCost)
        {
            cosideringPreferences = FitSupplyProbabilities(cosideringPreferences);
            float supplyRandom = Random.value;
            float supplyChanceSum = 0f;
            foreach (ClientPreference preference in cosideringPreferences)
            {
                supplyChanceSum += preference.SupplyChance;
                if (supplyChanceSum < supplyRandom)
                    continue;

                return CreateResource(preference.Currency,
                    preference.MinSupplyCoefficient,
                    preference.MaxSupplyCoefficient,
                    dealCost);
            }

            throw new System.ArgumentOutOfRangeException(nameof(ClientPreference.SupplyChance));
        }

        private IEnumerable<ClientPreference> FitDemandProbabilities(IEnumerable<ClientPreference> clientPreferences)
        {
            float chancesSum = clientPreferences.Select(preference => preference.DemandChance).Sum();
            if (chancesSum == 1f)
                return clientPreferences;

            return clientPreferences.Select(preference => new ClientPreference(
                preference.Currency,
                new Vector2(preference.MinDemandCoefficient, preference.MaxSupplyCoefficient),
                new Vector2(preference.MinSupplyCoefficient, preference.MaxSupplyCoefficient),
                preference.DemandChance / chancesSum,
                preference.SupplyChance));
        }

        private IEnumerable<ClientPreference> FitSupplyProbabilities(IEnumerable<ClientPreference> clientPreferences)
        {
            float chancesSum = clientPreferences.Select(preference => preference.SupplyChance).Sum();
            if (chancesSum == 1f)
                return clientPreferences;

            return clientPreferences.Select(preference => new ClientPreference(
                preference.Currency,
                new Vector2(preference.MinDemandCoefficient, preference.MaxSupplyCoefficient),
                new Vector2(preference.MinSupplyCoefficient, preference.MaxSupplyCoefficient),
                preference.DemandChance,
                preference.SupplyChance / chancesSum));
        }
    }
}