namespace Days.Model.Configs
{
    public interface IDaySettingsConfig
    {
        public int MaxClientsAmount { get; }
        public int MinClientsAmount { get; }
        public float MaxDealsCostCoefficient { get; }
        public float MinDealsCostCoefficient { get; }
        public int MaxClientsTypesAmount { get; }
        public int MinClientsTypesAmount { get; }
        public float AllSettingsCost { get; }
        public float OneClientCost { get; }
        public float DealCostCoefficientCost { get; }
        public float ClientTypeCost { get; }
    }
}