using Days.Model.Configs;
using Goods.Model;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Tests.Mock.Days;
using Tests.Mock.Goods;
using Tests.Mock.Upgrades;
using Upgrades.Model;
using Upgrades.Model.Configs;

namespace Tests.UnitTests.Upgrades
{
    public class UpgradesShopTest
    {

        [Test]
        public void WhenTryingBuy_AndUpgrateIsntBoughtAndUpgrateHasParamsAndStorageHasEnoughResources_ThenDaySettingsGetThatParams()
        {
            // Arrange.
            IEnumerable<IUpgradeConfig> upgrades = new List<IUpgradeConfig>()
            {
                new UpgradeConfigMock("Test", maxClientsAmount: 1)
            };
            IStorage storageMock = new StorageMock(true);
            UpgradesShop upgradesShop = Setup.UpgradesShop(upgrades, storageMock);
            IDaySettingsConfig daySettingsConfigMock = new DaySettingsConfigMock();
            UpgradedDaySettingsConfig upgradedDaySettingsConfig = Setup.UpgradedDaySettingsConfig(daySettingsConfigMock, upgradesShop);
            int previousMaxClientsAmount = upgradedDaySettingsConfig.MaxClientsAmount;

            // Act.
            upgradesShop.TryBuy(upgrades.First().Name);
            upgradedDaySettingsConfig.Dispose();

            // Assert.
            int expectedMaxClientsAmount = previousMaxClientsAmount + upgrades.First().MaxClientsAmount;
            Assert.AreEqual(expectedMaxClientsAmount, upgradedDaySettingsConfig.MaxClientsAmount);
        }

        [Test]
        public void WhenTryingBuyTwice_AndUpgrateIsntBoughtAndUpgrateHasParamsAndStorageHasEnoughResources_ThenDaySettingsGetThatParamsOnce()
        {
            // Arrange.
            IEnumerable<IUpgradeConfig> upgrades = new List<IUpgradeConfig>()
            {
                new UpgradeConfigMock("Test", maxClientsAmount: 1)
            };
            IStorage storageMock = new StorageMock(true);
            UpgradesShop upgradesShop = Setup.UpgradesShop(upgrades, storageMock);
            IDaySettingsConfig daySettingsConfigMock = new DaySettingsConfigMock();
            UpgradedDaySettingsConfig upgradedDaySettingsConfig = Setup.UpgradedDaySettingsConfig(daySettingsConfigMock, upgradesShop);
            int previousMaxClientsAmount = upgradedDaySettingsConfig.MaxClientsAmount;

            // Act.
            upgradesShop.TryBuy(upgrades.First().Name);
            upgradesShop.TryBuy(upgrades.First().Name);
            upgradedDaySettingsConfig.Dispose();

            // Assert.
            int expectedMaxClientsAmount = previousMaxClientsAmount + upgrades.First().MaxClientsAmount;
            Assert.AreEqual(expectedMaxClientsAmount, upgradedDaySettingsConfig.MaxClientsAmount);
        }

        [Test]
        public void WhenTryingBuyTwice_AndStorageHasEnoughResources_ThenSecondTryReturnsFalse()
        {
            // Arrange.
            IEnumerable<IUpgradeConfig> upgrades = new List<IUpgradeConfig>()
            {
                new UpgradeConfigMock("Test", maxClientsAmount: 1)
            };
            IStorage storageMock = new StorageMock(true);
            UpgradesShop upgradesShop = Setup.UpgradesShop(upgrades, storageMock);

            // Act.
            upgradesShop.TryBuy(upgrades.First().Name);
            bool isBoughtTwice = upgradesShop.TryBuy(upgrades.First().Name);

            // Assert.
            Assert.IsFalse(isBoughtTwice);
        }

        [Test]
        public void WhenTryingBuy_AndStorageHasEnoughResourcesAndUpgrateIsntBought_ThenTryReturnsTrue()
        {
            // Arrange.
            IEnumerable<IUpgradeConfig> upgrades = new List<IUpgradeConfig>()
            {
                new UpgradeConfigMock("Test", maxClientsAmount: 1)
            };
            IStorage storageMock = new StorageMock(true);
            UpgradesShop upgradesShop = Setup.UpgradesShop(upgrades, storageMock);

            // Act.
            bool isBought = upgradesShop.TryBuy(upgrades.First().Name);

            // Assert.
            Assert.IsTrue(isBought);
        }

        [Test]
        public void WhenCheckingIfCanBuy_AndStorageHasEnoughResourcesAndUpgrateIsntBought_ThenReturnsTrue()
        {
            // Arrange.
            IEnumerable<IUpgradeConfig> upgrades = new List<IUpgradeConfig>()
            {
                new UpgradeConfigMock("Test", maxClientsAmount: 1)
            };
            IStorage storageMock = new StorageMock(true);
            UpgradesShop upgradesShop = Setup.UpgradesShop(upgrades, storageMock);

            // Act.
            bool canBuy = upgradesShop.CanBuy(upgrades.First().Name);

            // Assert.
            Assert.IsTrue(canBuy);
        }

        [Test]
        public void WhenCheckingIfCanBuy_AndStorageHasEnoughResourcesAndUpgrateIsBought_ThenReturnsFalse()
        {
            // Arrange.
            IEnumerable<IUpgradeConfig> upgrades = new List<IUpgradeConfig>()
            {
                new UpgradeConfigMock("Test", maxClientsAmount: 1)
            };
            IStorage storageMock = new StorageMock(true);
            UpgradesShop upgradesShop = Setup.UpgradesShop(upgrades, storageMock);

            // Act.
            upgradesShop.TryBuy(upgrades.First().Name);
            bool canBuy = upgradesShop.CanBuy(upgrades.First().Name);

            // Assert.
            Assert.IsFalse(canBuy);
        }

        [Test]
        public void WhenTryingBuy_AndUpgrateIsntBoughtAndUpgrateHasParamsAndStorageHasNotEnoughResources_ThenDaySettingsGetPreviousParams()
        {
            // Arrange.
            IEnumerable<IUpgradeConfig> upgrades = new List<IUpgradeConfig>()
            {
                new UpgradeConfigMock("Test", maxClientsAmount: 1)
            };
            IStorage storageMock = new StorageMock(false);
            UpgradesShop upgradesShop = Setup.UpgradesShop(upgrades, storageMock);
            IDaySettingsConfig daySettingsConfigMock = new DaySettingsConfigMock();
            UpgradedDaySettingsConfig upgradedDaySettingsConfig = Setup.UpgradedDaySettingsConfig(daySettingsConfigMock, upgradesShop);
            int previousMaxClientsAmount = upgradedDaySettingsConfig.MaxClientsAmount;

            // Act.
            upgradesShop.TryBuy(upgrades.First().Name);
            upgradedDaySettingsConfig.Dispose();

            // Assert.
            Assert.AreEqual(previousMaxClientsAmount, upgradedDaySettingsConfig.MaxClientsAmount);
        }

        [Test]
        public void WhenTryingBuy_AndStorageHasNotEnoughResourcesAndUpgrateIsntBought_ThenTryReturnsFalse()
        {
            // Arrange.
            IEnumerable<IUpgradeConfig> upgrades = new List<IUpgradeConfig>()
            {
                new UpgradeConfigMock("Test", maxClientsAmount: 1)
            };
            IStorage storageMock = new StorageMock(false);
            UpgradesShop upgradesShop = Setup.UpgradesShop(upgrades, storageMock);

            // Act.
            bool isBought = upgradesShop.TryBuy(upgrades.First().Name);

            // Assert.
            Assert.IsFalse(isBought);
        }

        [Test]
        public void WhenCheckingIfCanBuy_AndStorageHasNotEnoughResourcesAndUpgrateIsntBought_ThenReturnsFalse()
        {
            // Arrange.
            IEnumerable<IUpgradeConfig> upgrades = new List<IUpgradeConfig>()
            {
                new UpgradeConfigMock("Test", maxClientsAmount: 1)
            };
            IStorage storageMock = new StorageMock(false);
            UpgradesShop upgradesShop = Setup.UpgradesShop(upgrades, storageMock);

            // Act.
            bool canBuy = upgradesShop.CanBuy(upgrades.First().Name);

            // Assert.
            Assert.IsFalse(canBuy);
        }

        [Test]
        public void WhenCheckingIfIsBought_AndUpgrateIsntBought_ThenReturnsFalse()
        {
            // Arrange.
            IEnumerable<IUpgradeConfig> upgrades = new List<IUpgradeConfig>()
            {
                new UpgradeConfigMock("Test", maxClientsAmount: 1)
            };
            IStorage storageMock = new StorageMock(true);
            UpgradesShop upgradesShop = Setup.UpgradesShop(upgrades, storageMock);

            // Act.
            bool isBought = upgradesShop.IsBought(upgrades.First().Name);

            // Assert.
            Assert.IsFalse(isBought);
        }

        [Test]
        public void WhenCheckingIfIsBought_AndUpgrateIsBought_ThenReturnsTrue()
        {
            // Arrange.
            IEnumerable<IUpgradeConfig> upgrades = new List<IUpgradeConfig>()
            {
                new UpgradeConfigMock("Test", maxClientsAmount: 1)
            };
            IStorage storageMock = new StorageMock(true);
            UpgradesShop upgradesShop = Setup.UpgradesShop(upgrades, storageMock);

            // Act.
            upgradesShop.TryBuy(upgrades.First().Name);
            bool isBought = upgradesShop.IsBought(upgrades.First().Name);

            // Assert.
            Assert.IsTrue(isBought);
        }
    }
}