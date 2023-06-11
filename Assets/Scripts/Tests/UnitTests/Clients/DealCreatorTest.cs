using Clients.Adapter;
using Clients.Model.Configs;
using Deals.Model;
using Goods.Model.Readonly.Resources;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

namespace Tests.UnitTests.Clients
{
    public class DealCreatorTest
    {
        [Test]
        public void WhenCreatingDeal_AndDemandChanceOfCurrencyIs1_ThenDealsRemovableResourceHasSameCurrency()
        {
            // Arrange.
            Currency clientDemandCurrency = 0;
            Currency clientSupplyCurrency = (Currency)1;
            DealCreator dealCreator = Setup.DealCreator(clientDemandCurrency, clientSupplyCurrency, 1f);
            ClientPreference demand = Setup.ResourceCoefficients(
                currency: clientDemandCurrency, 
                demandChance: 1, 
                supplyChance: 0);

            ClientPreference supply = Setup.ResourceCoefficients(
                currency: clientSupplyCurrency,
                demandChance: 0,
                supplyChance: 1);

            Client client = Setup.Client(
                new List<ClientPreference> { demand, supply });

            // Act.
            IDeal deal = dealCreator.CreateDeal(client);
            Currency dealRemovableResourceCurrency = deal.Removable.Currency;

            // Assert.
            Assert.AreEqual(dealRemovableResourceCurrency, clientDemandCurrency);
        }

        [Test]
        public void WhenCreatingDeal_AndSupplyChanceOfCurrencyIs1_ThenDealsAddableResourceHasSameCurrency()
        {
            // Arrange.
            Currency clientDemandCurrency = 0;
            Currency clientSupplyCurrency = (Currency)1;
            DealCreator dealCreator = Setup.DealCreator(clientDemandCurrency, clientSupplyCurrency, 1f);
            ClientPreference demand = Setup.ResourceCoefficients(
                currency: clientDemandCurrency,
                demandChance: 1,
                supplyChance: 0);

            ClientPreference supply = Setup.ResourceCoefficients(
                currency: clientSupplyCurrency,
                demandChance: 0,
                supplyChance: 1);

            Client client = Setup.Client(
                new List<ClientPreference> { demand, supply });

            // Act.
            IDeal deal = dealCreator.CreateDeal(client);
            Currency dealAddableResourceCurrency = deal.Addable.Currency;

            // Assert.
            Assert.AreEqual(dealAddableResourceCurrency, clientSupplyCurrency);
        }

        [Test]
        public void WhenCreatingDeal_AndDealCost10AndSupplyCoeff2AndCurrencyCostIs1_ThenSupplyCostIs20()
        {
            Currency clientDemandCurrency = 0;
            Currency clientSupplyCurrency = (Currency)1;
            DealCreator dealCreator = Setup.DealCreator(clientDemandCurrency, clientSupplyCurrency, 1f);
            ClientPreference demand = Setup.ResourceCoefficients(
                currency: clientDemandCurrency,
                demandChance: 1,
                supplyChance: 0);

            ClientPreference supply = Setup.ResourceCoefficients(
                currency: clientSupplyCurrency,
                supplyCoefficients: new Vector2(2, 2),
                demandCoefficients: Vector2.one,
                demandChance: 0,
                supplyChance: 1); 

            Client client = Setup.Client(
                new List<ClientPreference> { demand, supply },
                10);

            // Act.
            IDeal deal = dealCreator.CreateDeal(client);
            Currency dealAddableResourceCurrency = deal.Addable.Currency;

            // Assert.
            Assert.AreEqual(dealAddableResourceCurrency, clientSupplyCurrency);
        }

        [Test]
        public void WhenCreatingDeal_AndDealCost10AndDemandCoeff2AndCurrencyCostIs10_ThenDemandCostIs20()
        {
            Currency clientDemandCurrency = 0;
            Currency clientSupplyCurrency = (Currency)1;
            DealCreator dealCreator = Setup.DealCreator(clientDemandCurrency, clientSupplyCurrency, 10f, 1f);
            ClientPreference demand = Setup.ResourceCoefficients(
                currency: clientDemandCurrency,
                demandChance: 1,
                supplyChance: 0);

            ClientPreference supply = Setup.ResourceCoefficients(
                currency: clientSupplyCurrency,
                demandCoefficients: new Vector2(2, 2),
                supplyCoefficients: Vector2.one,
                demandChance: 0,
                supplyChance: 1);

            Client client = Setup.Client(
                new List<ClientPreference> { demand, supply },
                10);

            // Act.
            IDeal deal = dealCreator.CreateDeal(client);
            Currency dealAddableResourceCurrency = deal.Addable.Currency;

            // Assert.
            Assert.AreEqual(dealAddableResourceCurrency, clientSupplyCurrency);
        }
    }
}
