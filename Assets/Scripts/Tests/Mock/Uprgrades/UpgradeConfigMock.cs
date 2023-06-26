using Goods.Model.Readonly.Resources;
using System.Collections.Generic;
using Upgrades.Model.Configs;

namespace Tests.Mock.Upgrades
{
    public class UpgradeConfigMock : IUpgradeConfig
    {
        public int MaxClientsAmount { get; set; }

        public int MinClientsAmount { get; set; }

        public float MaxDealsCostCoefficient { get; set; }

        public float MinDealsCostCoefficient { get; set; }

        public int MaxClientsTypesAmount { get; set; }

        public int MinClientsTypesAmount { get; set; }

        public float AllSettingsCost { get; set; }

        public float OneClientCost { get; set; }

        public float DealCostCoefficientCost { get; set; }

        public float ClientTypeCost { get; set; }

        public string Name { get; set; }

        public IEnumerable<IReadonlyResource> Price { get; set; }

        public UpgradeConfigMock(
            string name,
            IEnumerable<IReadonlyResource> price = null,
            int maxClientsAmount = 0,
            int minClientsAmount = 0,
            float maxDealsCostCoefficient = 0f,
            float minDealsCostCoefficient = 0f,
            int maxClientsTypesAmount = 0,
            int minClientsTypesAmount = 0,
            float allSettingsCost = 0f,
            float oneClientCost = 0f,
            float dealCostCoefficientCost = 0f,
            float clientTypeCost = 0f)
        {
            Name = name;
            Price = price;

            if (Price == null)
            {
                Price = new List<IReadonlyResource>()
                {
                    new ResourceMock(value: 10)
                };
            }

            MaxClientsAmount = maxClientsAmount;
            MinClientsAmount = minClientsAmount;
            MaxDealsCostCoefficient = maxDealsCostCoefficient;
            MinDealsCostCoefficient = minDealsCostCoefficient;
            MaxClientsTypesAmount = maxClientsTypesAmount;
            MinClientsTypesAmount = minClientsTypesAmount;
            AllSettingsCost = allSettingsCost;
            OneClientCost = oneClientCost;
            DealCostCoefficientCost = dealCostCoefficientCost;
            ClientTypeCost = clientTypeCost;
        }
    }
}