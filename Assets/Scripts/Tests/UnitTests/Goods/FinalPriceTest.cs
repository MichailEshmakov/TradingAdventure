using Goods.Model;
using NUnit.Framework;

namespace Tests.UnitTests.Goods
{
    public class FinalPriceTest
    {
        [Test]
        public void WhenComutingValue_AndThereIsNoCoefficients_ThenBasicGoodsPriceReturns()
        {
            // Arrange.
            float basicPrice = 7f;
            IFinalPrice finalPrice = Setup.FinalPrice(basicPrice);

            // Act.
            float finalPriceValue = finalPrice.ComputeValue();

            // Assert.
            Assert.AreEqual(basicPrice, finalPriceValue);
        }

        [Test]
        public void WhenComutingValue_AndCoeffsAre2And3BasicIs10_Then60Returns()
        {
            // Arrange.
            float basicPrice = 10f;
            float firstCoefficient = 2f;
            float secondCoefficient = 3f;
            IFinalPrice finalPrice = Setup.FinalPrice(basicPrice, firstCoefficient, secondCoefficient);

            // Act.
            float finalPriceValue = finalPrice.ComputeValue();

            // Assert.
            Assert.AreEqual(60, finalPriceValue);

        }
    }
}