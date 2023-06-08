using Days.Model;
using Days.Model.Configs;
using UnityEngine;

namespace Tests.UnitTests.Days
{
    public static class Setup
    {
        public static DaySettingsBalancer DaySettingsBalancer(float neededCost, 
            int firstCostOfOne, 
            int secondCostOfOne, 
            int thirdCostOfOne,
            int maxClientsAmount = int.MaxValue,
            int minClientsAmount = 0,
            float maxDealsCostCoefficient = float.MaxValue,
            float minDealsCostCoefficient = 0,
            int maxClientsTypesAmount = int.MaxValue,
            int minClientsTypesAmount = 0)
        {
            IDaySettingsConfig config = DaySettingsConfig(neededCost, 
                firstCostOfOne, 
                secondCostOfOne, 
                thirdCostOfOne,
                maxClientsAmount,
                minClientsAmount,
                maxDealsCostCoefficient,
                minDealsCostCoefficient,
                maxClientsTypesAmount,
                minClientsTypesAmount);

            return new DaySettingsBalancer(config);
        }

        public static IDaySettingsValues DaySettingsValues(int clientsAmount, float dealsCostCoefficient, int clientsTypesAmount)
        {
            return new DaySettingsValues(clientsAmount, dealsCostCoefficient, clientsTypesAmount);
        }

        public static DaySettingsConfig DaySettingsConfig(float neededCost,
            int firstCostOfOne,
            int secondCostOfOne,
            int thirdCostOfOne,
            int maxClientsAmount = int.MaxValue,
            int minClientsAmount = 0,
            float maxDealsCostCoefficient = float.MaxValue,
            float minDealsCostCoefficient = 0,
            int maxClientsTypesAmount = int.MaxValue,
            int minClientsTypesAmount = 0)
        {
            DaySettingsConfig daySettingsConfig = ScriptableObject.CreateInstance<DaySettingsConfig>();
            daySettingsConfig.Init(
                maxClientsAmount: maxClientsAmount,
                minClientsAmount: minClientsAmount,
                maxDealsCostCoefficient: maxDealsCostCoefficient,
                minDealsCostCoefficient: minDealsCostCoefficient,
                maxClientsTypesAmount: maxClientsTypesAmount,
                minClientsTypesAmount: minClientsTypesAmount,
                allSettingsCost: neededCost,
                oneClientCost: firstCostOfOne,
                dealCostCoefficientCost: secondCostOfOne,
                clientTypeCost: thirdCostOfOne);

            return daySettingsConfig;
        }
    }
}