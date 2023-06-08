using Days.Model;
using NUnit.Framework;

namespace Tests.UnitTests.Days
{
    public class BalancerTest
    {

        [Test]
        public void WhenBalancing_AndNoStableTypeAndAllSettingsHasSameCostAndTheirSumLessThanNeeded_ThenTheyStaySame()
        {
            // Arrange.
            int settingsCost = 1;
            DaySettingsBalancer balancer = Setup.DaySettingsBalancer(30, settingsCost, settingsCost, settingsCost);
            IDaySettingsValues primarySettings = Setup.DaySettingsValues(5, 5, 5);

            // Act.
            DaySettingsValues resultSettings = balancer.Balance(primarySettings);

            // Assert.
            float resultFirstSettingCost = resultSettings.ClientsAmount * settingsCost;
            float resultSecondSettingCost = resultSettings.DealsCostCoefficient * settingsCost;
            float resultThirdSettingCost = resultSettings.ClientsTypesAmount * settingsCost;

            Assert.AreEqual(resultFirstSettingCost, resultSecondSettingCost);
            Assert.AreEqual(resultFirstSettingCost, resultThirdSettingCost);
        }

        [Test]
        public void WhenBalancing_AndNoStableTypeAndAllSettingsHasSameCostAndTheirSumMoreThanNeeded_ThenTheyStaySame()
        {
            // Arrange.
            int settingsCost = 1;
            DaySettingsBalancer balancer = Setup.DaySettingsBalancer(30, settingsCost, settingsCost, settingsCost);
            IDaySettingsValues primarySettings = Setup.DaySettingsValues(20, 20, 20);

            // Act.
            DaySettingsValues resultSettings = balancer.Balance(primarySettings);

            // Assert.
            float resultFirstSettingCost = resultSettings.ClientsAmount * settingsCost;
            float resultSecondSettingCost = resultSettings.DealsCostCoefficient * settingsCost;
            float resultThirdSettingCost = resultSettings.ClientsTypesAmount * settingsCost;

            Assert.AreEqual(resultFirstSettingCost, resultSecondSettingCost);
            Assert.AreEqual(resultFirstSettingCost, resultThirdSettingCost);
        }

        [Test]
        public void WhenBalancing_AndNoStableTypeAndTheirSumLessNeeded_ThenTheyAllIncrese()
        {
            // Arrange.
            int settingsCost = 1;
            DaySettingsBalancer balancer = Setup.DaySettingsBalancer(30, settingsCost, settingsCost, settingsCost);
            IDaySettingsValues primarySettings = Setup.DaySettingsValues(5, 5, 5);

            // Act.
            DaySettingsValues resultSettings = balancer.Balance(primarySettings);

            // Assert.
            Assert.Greater(resultSettings.ClientsAmount, primarySettings.ClientsAmount);
            Assert.Greater(resultSettings.DealsCostCoefficient, primarySettings.DealsCostCoefficient);
            Assert.Greater(resultSettings.ClientsTypesAmount, primarySettings.ClientsTypesAmount);
        }

        [Test]
        public void WhenBalancing_AndNoStableTypeAndTheirSumMoreNeeded_ThenTheyAllDecrease()
        {
            // Arrange.
            int settingsCost = 1;
            DaySettingsBalancer balancer = Setup.DaySettingsBalancer(30, settingsCost, settingsCost, settingsCost);
            IDaySettingsValues primarySettings = Setup.DaySettingsValues(15, 15, 15);

            // Act.
            DaySettingsValues resultSettings = balancer.Balance(primarySettings);

            // Assert.
            Assert.Less(resultSettings.ClientsAmount, primarySettings.ClientsAmount);
            Assert.Less(resultSettings.DealsCostCoefficient, primarySettings.DealsCostCoefficient);
            Assert.Less(resultSettings.ClientsTypesAmount, primarySettings.ClientsTypesAmount);
        }

        [Test]
        public void WhenBalancing_AndNoStableType_ThenTheirSumOfCostBecomeNeeded()
        {
            // Arrange.
            int settingsCost = 1;
            float neededCost = 30;
            DaySettingsBalancer balancer = Setup.DaySettingsBalancer(neededCost, settingsCost, settingsCost, settingsCost);
            IDaySettingsValues primarySettings = Setup.DaySettingsValues(15, 15, 15);

            // Act.
            DaySettingsValues resultSettings = balancer.Balance(primarySettings);

            // Assert.
            float actualCost = resultSettings.ClientsAmount * settingsCost +
                resultSettings.DealsCostCoefficient * settingsCost +
                resultSettings.ClientsTypesAmount * settingsCost;

            Assert.Less(neededCost - 1, actualCost);
            Assert.Greater(neededCost + 1, actualCost);
        }

        [Test]
        public void WhenBalancing_AndThereIsStableType_ThenTheirSumOfCostBecomeNeeded()
        {
            // Arrange.
            int settingsCost = 1;
            float neededCost = 30;
            DaySettingsBalancer balancer = Setup.DaySettingsBalancer(neededCost, settingsCost, settingsCost, settingsCost);
            IDaySettingsValues primarySettings = Setup.DaySettingsValues(5, 5, 15);
            DaySettingType stableSetting = DaySettingType.ClientsAmount;

            // Act.
            DaySettingsValues resultSettings = balancer.Balance(primarySettings, stableSetting);

            // Assert.
            float actualCost = resultSettings.ClientsAmount * settingsCost +
                resultSettings.DealsCostCoefficient * settingsCost +
                resultSettings.ClientsTypesAmount * settingsCost;

            Assert.Less(neededCost - 1, actualCost);
            Assert.Greater(neededCost + 1, actualCost);
        }

        [Test]
        public void WhenBalancing_AndThereIsStableTypeAndTheirSumLessNeeded_ThenOtherSettingsIncrese()
        {
            // Arrange.
            int settingsCost = 1;
            float neededCost = 30;
            DaySettingsBalancer balancer = Setup.DaySettingsBalancer(neededCost, settingsCost, settingsCost, settingsCost);
            IDaySettingsValues primarySettings = Setup.DaySettingsValues(5, 5, 5);
            DaySettingType stableSetting = DaySettingType.ClientsAmount;

            // Act.
            DaySettingsValues resultSettings = balancer.Balance(primarySettings, stableSetting);

            // Assert.
            Assert.Greater(resultSettings.DealsCostCoefficient, primarySettings.DealsCostCoefficient);
            Assert.Greater(resultSettings.ClientsTypesAmount, primarySettings.ClientsTypesAmount);
        }

        [Test]
        public void WhenBalancing_AndThereIsStableTypeAndTheirSumMoreNeeded_ThenOtherSettingsDecrease()
        {
            // Arrange.
            int settingsCost = 1;
            float neededCost = 30;
            DaySettingsBalancer balancer = Setup.DaySettingsBalancer(neededCost, settingsCost, settingsCost, settingsCost);
            IDaySettingsValues primarySettings = Setup.DaySettingsValues(15, 15, 15);
            DaySettingType stableSetting = DaySettingType.ClientsAmount;

            // Act.
            DaySettingsValues resultSettings = balancer.Balance(primarySettings, stableSetting);

            // Assert.
            Assert.Less(resultSettings.DealsCostCoefficient, primarySettings.DealsCostCoefficient);
            Assert.Less(resultSettings.ClientsTypesAmount, primarySettings.ClientsTypesAmount);
        }

        [Test]
        public void WhenBalancing_AndThereIsStableTypeAndTheirSumLessNeeded_ThenStableSettingStaySame()
        {
            // Arrange.
            int settingsCost = 1;
            float neededCost = 30;
            DaySettingsBalancer balancer = Setup.DaySettingsBalancer(neededCost, settingsCost, settingsCost, settingsCost);
            IDaySettingsValues primarySettings = Setup.DaySettingsValues(5, 5, 5);
            DaySettingType stableSetting = DaySettingType.ClientsAmount;

            // Act.
            DaySettingsValues resultSettings = balancer.Balance(primarySettings, stableSetting);

            // Assert.
            Assert.AreEqual(primarySettings.ClientsAmount, resultSettings.ClientsAmount);
        }

        [Test]
        public void WhenBalancing_AndThereIsStableTypeAndTheirSumMoreNeeded_ThenStableSettingStaySame()
        {
            // Arrange.
            int settingsCost = 1;
            float neededCost = 30;
            DaySettingsBalancer balancer = Setup.DaySettingsBalancer(neededCost, settingsCost, settingsCost, settingsCost);
            IDaySettingsValues primarySettings = Setup.DaySettingsValues(15, 15, 15);
            DaySettingType stableSetting = DaySettingType.ClientsAmount;

            // Act.
            DaySettingsValues resultSettings = balancer.Balance(primarySettings, stableSetting);

            // Assert.
            Assert.AreEqual(primarySettings.ClientsAmount, resultSettings.ClientsAmount);
        }

        [Test]
        public void WhenBalancing_AndThereIsStableTypeAndThisValueMoreItsMax_ThenStableSettingBecomeMax()
        {
            // Arrange.
            int settingsCost = 1;
            float neededCost = 30f;
            float settingsMax = 10f;
            float settingsMin = 0f;
            DaySettingsBalancer balancer = Setup.DaySettingsBalancer(
                neededCost, 
                settingsCost, 
                settingsCost, 
                settingsCost,
                (int)settingsMax,
                (int)settingsMin,
                settingsMax,
                settingsMin,
                (int)settingsMax,
                (int)settingsMin);
            IDaySettingsValues primarySettings = Setup.DaySettingsValues(15, 15, 15);
            DaySettingType stableSetting = DaySettingType.ClientsAmount;

            // Act.
            DaySettingsValues resultSettings = balancer.Balance(primarySettings, stableSetting);

            // Assert.
            Assert.AreEqual(settingsMax, resultSettings.ClientsAmount);
        }

        [Test]
        public void WhenBalancing_AndThereIsStableTypeAndThisValueLessItsMin_ThenStableSettingBecomeMin()
        {
            // Arrange.
            int settingsCost = 1;
            float neededCost = 30f;
            float settingsMax = 30f;
            float settingsMin = 6f;
            DaySettingsBalancer balancer = Setup.DaySettingsBalancer(
                neededCost,
                settingsCost,
                settingsCost,
                settingsCost,
                (int)settingsMax,
                (int)settingsMin,
                settingsMax,
                settingsMin,
                (int)settingsMax,
                (int)settingsMin);
            IDaySettingsValues primarySettings = Setup.DaySettingsValues(5, 5, 5);
            DaySettingType stableSetting = DaySettingType.ClientsAmount;

            // Act.
            DaySettingsValues resultSettings = balancer.Balance(primarySettings, stableSetting);

            // Assert.
            Assert.AreEqual(settingsMin, resultSettings.ClientsAmount);
        }
    }
}
