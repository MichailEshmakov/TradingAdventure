using UnityEngine;

namespace Days.Model.Configs
{
    [CreateAssetMenu(fileName = nameof(DaySettingsConfig), menuName = "Configs/Model/" + nameof(DaySettingsConfig), order = 0)]
    public class DaySettingsConfig : ScriptableObject, IDaySettingsConfig
    {
        [Header("Min and Max Values")]
        [SerializeField] [Min(1)] private int _maxClientsAmount; 
        [SerializeField] [Min(1)] private int _minClientsAmount;
        [SerializeField] [Min(1)] private float _maxDealsCostCoefficient;
        [SerializeField] [Min(1)] private float _minDealsCostCoefficient;
        [SerializeField] [Min(1)] private int _maxClientsTypesAmount;
        [SerializeField] [Min(1)] private int _minClientsTypesAmount;
        [Header("Costs")]
        [SerializeField] [Min(1)] private float _allSettingsCost;
        [SerializeField] [Min(1)] private float _oneClientCost;
        [SerializeField] [Min(1)] private float _dealCostCoefficientCost;
        [SerializeField] [Min(1)] private float _clientTypeCost;

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

#if UNITY_EDITOR
        public void Init(
            int maxClientsAmount,
            int minClientsAmount,
            float maxDealsCostCoefficient,
            float minDealsCostCoefficient,
            int maxClientsTypesAmount,
            int minClientsTypesAmount,
            float allSettingsCost,
            float oneClientCost,
            float dealCostCoefficientCost,
            float clientTypeCost)
        {
            _maxClientsAmount = maxClientsAmount;
            _minClientsAmount = minClientsAmount;
            _maxDealsCostCoefficient = maxDealsCostCoefficient;
            _minDealsCostCoefficient = minDealsCostCoefficient;
            _maxClientsTypesAmount = maxClientsTypesAmount;
            _minClientsTypesAmount = minClientsTypesAmount;
            _allSettingsCost = allSettingsCost;
            _oneClientCost = oneClientCost;
            _dealCostCoefficientCost = dealCostCoefficientCost;
            _clientTypeCost = clientTypeCost;
        }
#endif
    }
}