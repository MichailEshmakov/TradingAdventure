using Goods.Model.Configs;
using Goods.Model.Readonly.Resources;
using System.Collections.Generic;
using UnityEngine;

namespace Upgrades.Model.Configs
{
    [CreateAssetMenu(fileName = nameof(UpgradeConfig), menuName = "Configs/Model/" + nameof(UpgradeConfig), order = 0)]
    public class UpgradeConfig : ScriptableObject, IUpgradeConfig
    {
        [SerializeField] private SerializableResources _price;
        [SerializeField] private int _maxClientsAmount;
        [SerializeField] private int _minClientsAmount;
        [SerializeField] private float _maxDealsCostCoefficient;
        [SerializeField] private float _minDealsCostCoefficient;
        [SerializeField] private int _maxClientsTypesAmount;
        [SerializeField] private int _minClientsTypesAmount;
        [SerializeField] private float _allSettingsCost;
        [SerializeField] private float _oneClientCost;
        [SerializeField] private float _dealCostCoefficientCost;
        [SerializeField] private float _clientTypeCost;

        public string Name => name;

        public IEnumerable<IReadonlyResource> Price => _price.FormResources();

        public int MaxClientsAmount => _maxClientsAmount;

        public int MinClientsAmount => _minClientsAmount;

        public float MaxDealsCostCoefficient => _maxDealsCostCoefficient;

        public float MinDealsCostCoefficient => _minDealsCostCoefficient;

        public int MaxClientsTypesAmount => _maxClientsTypesAmount;

        public int MinClientsTypesAmount => _minClientsTypesAmount;

        public float AllSettingsCost => _allSettingsCost;

        public float OneClientCost => _oneClientCost;

        public float DealCostCoefficientCost => _dealCostCoefficientCost;

        public float ClientTypeCost => _clientTypeCost;
    }
}