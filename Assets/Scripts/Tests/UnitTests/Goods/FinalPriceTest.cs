using Goods.Model;
using NUnit.Framework;
using Tests.Mock;

namespace Tests.UnitTests.Goods
{
    public class FinalPriceTest
    {
        [Test]
        public void WhenComutingValue_AndThereIsNoCoefficients_ThenBasicGoodsPriceReturns()
        {
            // Arrange.
            float basicPrice = 7f;
            IFinalPrice finalPrice = new FinalPrice(basicPrice);

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
            IFinalPrice finalPrice = new FinalPrice(basicPrice);
            IPriceCoefficient firstCoefficientObject = new PriceCoefficientMock(firstCoefficient);
            IPriceCoefficient secondCoefficientObject = new PriceCoefficientMock(secondCoefficient);
            finalPrice.TryAddCoefficient(firstCoefficientObject);
            finalPrice.TryAddCoefficient(secondCoefficientObject);

            // Act.
            float finalPriceValue = finalPrice.ComputeValue();

            // Assert.
            Assert.AreEqual(60, finalPriceValue);

        }
    }
}