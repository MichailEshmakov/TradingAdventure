using Days.Model.Configs;

namespace Days.Model
{
    public interface IDaySettings : IReadonlyDaySettings
    {
        public new int ClientsAmount { get; set; }
        public new float DealsCostCoefficient { get; set; }
        public new int ClientsTypesAmount { get; set; }
        public IDaySettingsConfig Config { get; }
    }
}