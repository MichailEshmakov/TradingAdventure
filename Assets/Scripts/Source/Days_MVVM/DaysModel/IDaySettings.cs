using Days.Model.Configs;
using System.ComponentModel;

namespace Days.Model
{
    public interface IDaySettings : INotifyPropertyChanged
    {
        public int ClientsAmount { get; set; }

        public float DealsCostCoefficient { get; set; }

        public int ClientsTypesAmount { get; set; }
        public IDaySettingsConfig Config { get; }
    }
}