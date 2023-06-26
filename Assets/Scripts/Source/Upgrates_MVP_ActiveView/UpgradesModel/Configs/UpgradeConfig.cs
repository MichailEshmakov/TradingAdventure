using Goods.Model.Readonly.Resources;
using System.Collections.Generic;
using UnityEngine;

namespace Upgrades.Model.Configs
{
    public class UpgradeConfig : ScriptableObject, IUpgradeConfig
    {
        public string Name => throw new System.NotImplementedException();

        public IEnumerable<IReadonlyResource> Price => throw new System.NotImplementedException();

        public int MaxClientsAmount => throw new System.NotImplementedException();

        public int MinClientsAmount => throw new System.NotImplementedException();

        public float MaxDealsCostCoefficient => throw new System.NotImplementedException();

        public float MinDealsCostCoefficient => throw new System.NotImplementedException();

        public int MaxClientsTypesAmount => throw new System.NotImplementedException();

        public int MinClientsTypesAmount => throw new System.NotImplementedException();

        public float AllSettingsCost => throw new System.NotImplementedException();

        public float OneClientCost => throw new System.NotImplementedException();

        public float DealCostCoefficientCost => throw new System.NotImplementedException();

        public float ClientTypeCost => throw new System.NotImplementedException();
    }
}