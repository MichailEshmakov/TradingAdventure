using Deals.Model;
using Goods.Model;
using Goods.Model.Readonly.Resources;
using Goods.Model.Resources;
using NUnit.Framework;

namespace Tests.UnitTests.Deals
{
    public class DealTest
    {
        [Test]
        public void WhenChekingIfCanAccept_AndInventoryResourceLessThanRemovable_ThenReturnFalse()
        {
            // Arrange.
            IResource inStorage = Goods.Setup.Resource(5, 0);
            IStorage storage = Goods.Setup.Storage(inStorage);
            IResource removable = Goods.Setup.Resource(10, 0);
            Deal deal = Setup.Deal(storage, removable);

            // Act.
            bool canAccept = deal.CanAccept();

            // Assert.
            Assert.IsFalse(canAccept);
        }

        [Test]
        public void WhenChekingIfCanAccept_AndInventoryResourceMoreThanRemovable_ThenReturnTrue()
        {
            // Arrange.
            IResource inStorage = Goods.Setup.Resource(50, 0);
            IStorage storage = Goods.Setup.Storage(inStorage);
            IResource removable = Goods.Setup.Resource(10, 0);
            Deal deal = Setup.Deal(storage, removable);

            // Act.
            bool canAccept = deal.CanAccept();

            // Assert.
            Assert.IsTrue(canAccept);
        }

        [Test]
        public void WhenRejecting_AndThereAreResourcesInStorage_ThenValueOfAddingCurrencyDoesntChange()
        {
            // Arrange.
            int inStorageFirstValue = 10;
            Currency firstCurrency = 0;
            IResource inStorageFirst = Goods.Setup.Resource(inStorageFirstValue, firstCurrency);

            int inStorageSecondValue = 20;
            Currency secondCurrency = (Currency)1;
            IResource inStorageSecond = Goods.Setup.Resource(inStorageSecondValue, secondCurrency);
            IStorage storage = Goods.Setup.Storage(inStorageFirst, inStorageSecond);

            IResource addable = Goods.Setup.Resource(10, firstCurrency);
            IResource removable = Goods.Setup.Resource(10, secondCurrency);
            Deal deal = Setup.Deal(storage, removable, addable);

            // Act.
            deal.Reject();

            // Assert.
            Assert.AreEqual(inStorageFirstValue, ((IReadonlyResource)inStorageFirst).Value);
        }

        [Test]
        public void WhenRejecting_AndThereAreResourcesInStorage_ThenValueOfRemovingCurrencyDoesntChange()
        {
            // Arrange.
            int inStorageFirstValue = 10;
            Currency firstCurrency = 0;
            IResource inStorageFirst = Goods.Setup.Resource(inStorageFirstValue, firstCurrency);

            int inStorageSecondValue = 20;
            Currency secondCurrency = (Currency)1;
            IResource inStorageSecond = Goods.Setup.Resource(inStorageSecondValue, secondCurrency);
            IStorage storage = Goods.Setup.Storage(inStorageFirst, inStorageSecond);

            IResource addable = Goods.Setup.Resource(10, firstCurrency);
            IResource removable = Goods.Setup.Resource(10, secondCurrency);
            Deal deal = Setup.Deal(storage, removable, addable);

            // Act.
            deal.Reject();

            // Assert.
            Assert.AreEqual(inStorageSecondValue, ((IReadonlyResource)inStorageSecond).Value);
        }

        [Test]
        public void WhenAccepting_AndStorageHasEnoughResources_ThenStorageValueIncresesByDealValue()
        {
            // Arrange.
            int inStorageFirstValue = 10;
            Currency firstCurrency = 0;
            IResource inStorageFirst = Goods.Setup.Resource(inStorageFirstValue, firstCurrency);

            int inStorageSecondValue = 20;
            Currency secondCurrency = (Currency)1;
            IResource inStorageSecond = Goods.Setup.Resource(inStorageSecondValue, secondCurrency);
            IStorage storage = Goods.Setup.Storage(inStorageFirst, inStorageSecond);

            int addableValue = 13;
            IResource addable = Goods.Setup.Resource(addableValue, firstCurrency);
            int removableValue = 16;
            IResource removable = Goods.Setup.Resource(removableValue, secondCurrency);
            Deal deal = Setup.Deal(storage, removable, addable);

            // Act.
            deal.TryAccept();

            // Assert.
            Assert.AreEqual(inStorageFirstValue + addableValue, ((IReadonlyResource)inStorageFirst).Value);
        }

        [Test]
        public void WhenAccepting_AndStorageHasEnoughResources_ThenStorageValueDecresesByDealValue()
        {
            // Arrange.
            int inStorageFirstValue = 10;
            Currency firstCurrency = 0;
            IResource inStorageFirst = Goods.Setup.Resource(inStorageFirstValue, firstCurrency);

            int inStorageSecondValue = 20;
            Currency secondCurrency = (Currency)1;
            IResource inStorageSecond = Goods.Setup.Resource(inStorageSecondValue, secondCurrency);
            IStorage storage = Goods.Setup.Storage(inStorageFirst, inStorageSecond);

            int addableValue = 13;
            IResource addable = Goods.Setup.Resource(addableValue, firstCurrency);
            int removableValue = 16;
            IResource removable = Goods.Setup.Resource(removableValue, secondCurrency);
            Deal deal = Setup.Deal(storage, removable, addable);

            // Act.
            deal.TryAccept();

            // Assert.
            Assert.AreEqual(inStorageSecondValue - removableValue, ((IReadonlyResource)inStorageSecond).Value);
        }

        [Test]
        public void WhenAccepting_AndStorageHasEnoughResources_ThenReturnTrue()
        {
            // Arrange.
            int inStorageFirstValue = 10;
            Currency firstCurrency = 0;
            IResource inStorageFirst = Goods.Setup.Resource(inStorageFirstValue, firstCurrency);

            int inStorageSecondValue = 20;
            Currency secondCurrency = (Currency)1;
            IResource inStorageSecond = Goods.Setup.Resource(inStorageSecondValue, secondCurrency);
            IStorage storage = Goods.Setup.Storage(inStorageFirst, inStorageSecond);

            int addableValue = 13;
            IResource addable = Goods.Setup.Resource(addableValue, firstCurrency);
            int removableValue = 16;
            IResource removable = Goods.Setup.Resource(removableValue, secondCurrency);
            Deal deal = Setup.Deal(storage, removable, addable);

            // Act.
            bool isAccepted = deal.TryAccept();

            // Assert.
            Assert.IsTrue(isAccepted);
        }

        [Test]
        public void WhenAccepting_AndStorageDoesntHaveEnoughResources_ThenReturnFalse()
        {
            // Arrange.
            int inStorageFirstValue = 10;
            Currency firstCurrency = 0;
            IResource inStorageFirst = Goods.Setup.Resource(inStorageFirstValue, firstCurrency);

            int inStorageSecondValue = 2;
            Currency secondCurrency = (Currency)1;
            IResource inStorageSecond = Goods.Setup.Resource(inStorageSecondValue, secondCurrency);
            IStorage storage = Goods.Setup.Storage(inStorageFirst, inStorageSecond);

            int addableValue = 13;
            IResource addable = Goods.Setup.Resource(addableValue, firstCurrency);
            int removableValue = 16;
            IResource removable = Goods.Setup.Resource(removableValue, secondCurrency);
            Deal deal = Setup.Deal(storage, removable, addable);

            // Act.
            bool isAccepted = deal.TryAccept();

            // Assert.
            Assert.IsFalse(isAccepted);
        }

        [Test]
        public void WhenAccepting_AndStorageDoesntHaveEnoughResources_ThenValueOfAddingCurrencyDoesntChange()
        {
            // Arrange.
            int inStorageFirstValue = 10;
            Currency firstCurrency = 0;
            IResource inStorageFirst = Goods.Setup.Resource(inStorageFirstValue, firstCurrency);

            int inStorageSecondValue = 2;
            Currency secondCurrency = (Currency)1;
            IResource inStorageSecond = Goods.Setup.Resource(inStorageSecondValue, secondCurrency);
            IStorage storage = Goods.Setup.Storage(inStorageFirst, inStorageSecond);

            int addableValue = 13;
            IResource addable = Goods.Setup.Resource(addableValue, firstCurrency);
            int removableValue = 16;
            IResource removable = Goods.Setup.Resource(removableValue, secondCurrency);
            Deal deal = Setup.Deal(storage, removable, addable);

            // Act.
            deal.TryAccept();

            // Assert.
            Assert.AreEqual(inStorageFirstValue, ((IReadonlyResource)inStorageFirst).Value);
        }

        [Test]
        public void WhenAccepting_AndStorageDoesntHaveEnoughResources_ThenValueOfRemovingCurrencyDoesntChange()
        {
            // Arrange.
            int inStorageFirstValue = 10;
            Currency firstCurrency = 0;
            IResource inStorageFirst = Goods.Setup.Resource(inStorageFirstValue, firstCurrency);

            int inStorageSecondValue = 2;
            Currency secondCurrency = (Currency)1;
            IResource inStorageSecond = Goods.Setup.Resource(inStorageSecondValue, secondCurrency);
            IStorage storage = Goods.Setup.Storage(inStorageFirst, inStorageSecond);

            int addableValue = 13;
            IResource addable = Goods.Setup.Resource(addableValue, firstCurrency);
            int removableValue = 16;
            IResource removable = Goods.Setup.Resource(removableValue, secondCurrency);
            Deal deal = Setup.Deal(storage, removable, addable);

            // Act.
            deal.TryAccept();

            // Assert.
            Assert.AreEqual(inStorageSecondValue, ((IReadonlyResource)inStorageSecond).Value);
        }
    }
}