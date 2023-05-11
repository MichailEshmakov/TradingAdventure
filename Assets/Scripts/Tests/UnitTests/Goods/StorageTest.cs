using Goods.Model;
using Goods.Model.Readonly.Resources;
using Goods.Model.Resources;
using NUnit.Framework;

namespace Tests.UnitTests.Goods
{
    public class StorageTest
    {
        [Test]
        public void WhenGettingValue_AndCannotStoreThisType_ThenReturn0()
        {
            // Arrange.
            IResource resource = new Resource(9, 0);
            Storage storage = Setup.Storage(resource);
            Currency gettingType = (Currency)1;

            // Act.
            int gotResources = storage.GetValue(gettingType); 

            // Assert.
            Assert.AreEqual(0, gotResources);
        }

        [Test]
        public void WhenGettingValue_AndResourseValueIs4_ThenReturn4()
        {
            // Arrange.
            int resourceAmount = 4;
            Currency gettingType = 0;
            IResource resource = Setup.Resource(resourceAmount, gettingType);
            Storage storage = Setup.Storage(resource);

            // Act.
            int gotResources = storage.GetValue(gettingType);

            // Assert.
            Assert.AreEqual(resourceAmount, gotResources);
        }

        [Test]
        public void WhenTryingAdd5_AndResourseValueIs4_ThenGetting9()
        {
            // Arrange.
            int resourceAmount = 4;
            Currency resourceType = 0;
            IResource resource = Setup.Resource(resourceAmount, resourceType);
            Storage storage = Setup.Storage(resource);
            int addingValue = 5;

            // Act.
            storage.TryAdd(resourceType, addingValue);
            int gotResources = storage.GetValue(resourceType);

            // Assert.
            Assert.AreEqual(9, gotResources);
        }

        [Test]
        public void WhenTryingAdd5_AndResourseValueIs4_ThenReturnTrue()
        {
            // Arrange.
            int resourceAmount = 4;
            Currency resourceType = 0;
            IResource resource = Setup.Resource(resourceAmount, resourceType);
            Storage storage = Setup.Storage(resource);
            int addingValue = 5;

            // Act.
            bool isAdded = storage.TryAdd(resourceType, addingValue);

            // Assert.
            Assert.IsTrue(isAdded);
        }

        [Test]
        public void WhenTryingAdd_AndCannotStoreThisType_ThenReturnFalse()
        {
            // Arrange.
            int resourceAmount = 4;
            Currency existingResourceType = 0;
            IResource resource = Setup.Resource(resourceAmount, existingResourceType);
            Storage storage = Setup.Storage(resource);
            int addingValue = 5;
            Currency addingResourceType = (Currency)1;

            // Act.
            bool isAdded = storage.TryAdd(addingResourceType, addingValue);

            // Assert.
            Assert.IsFalse(isAdded);
        }

        [Test]
        public void WhenTryingSpend5_AndResourseValueIs4_ThenReturnFalse()
        {
            // Arrange.
            int resourceAmount = 4;
            Currency resourceType = 0;
            IResource resource = Setup.Resource(resourceAmount, resourceType);
            Storage storage = Setup.Storage(resource);
            int substructingValue = 5;;

            // Act.
            bool isSubstructed = storage.TrySpend(resourceType, substructingValue);

            // Assert.
            Assert.IsFalse(isSubstructed);
        }

        [Test]
        public void WhenTryingSpend5_AndResourseValueIs4_ThenGetting4()
        {
            // Arrange.
            int resourceAmount = 4;
            Currency resourceType = 0;
            IResource resource = Setup.Resource(resourceAmount, resourceType);
            Storage storage = Setup.Storage(resource);
            int substructingValue = 5; ;

            // Act.
            storage.TrySpend(resourceType, substructingValue);
            int gotResources = storage.GetValue(resourceType);

            // Assert.
            Assert.AreEqual(resourceAmount, gotResources);
        }

        [Test]
        public void WhenTryingSpend4_AndResourseValueIs5_ThenReturnTrue()
        {
            // Arrange.
            int resourceAmount = 5;
            Currency resourceType = 0;
            IResource resource = Setup.Resource(resourceAmount, resourceType);
            Storage storage = Setup.Storage(resource);
            int substructingValue = 4; ;

            // Act.
            bool isSubstructed = storage.TrySpend(resourceType, substructingValue);

            // Assert.
            Assert.IsTrue(isSubstructed);
        }

        [Test]
        public void WhenTryingSpend4_AndResourseValueIs5_ThenGetting1()
        {
            // Arrange.
            int resourceAmount = 5;
            Currency resourceType = 0;
            IResource resource = Setup.Resource(resourceAmount, resourceType);
            Storage storage = Setup.Storage(resource);
            int substructingValue = 4; ;

            // Act.
            storage.TrySpend(resourceType, substructingValue);
            int gotResources = storage.GetValue(resourceType);

            // Assert.
            Assert.AreEqual(1, gotResources);
        }

        [Test]
        public void WhenTryingSpend_AndCannotStoreThisType_ThenReturnFalse()
        {
            // Arrange.
            int resourceAmount = 5;
            Currency existingResourceType = 0;
            IResource resource = Setup.Resource(resourceAmount, existingResourceType);
            Storage storage = Setup.Storage(resource);
            int substructingValue = 4; ;
            Currency spendingResourceType = (Currency)1;

            // Act.
            bool isSubstructed = storage.TrySpend(spendingResourceType, substructingValue);

            // Assert.
            Assert.IsFalse(isSubstructed);
        }
    }
}