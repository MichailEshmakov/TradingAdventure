using System.ComponentModel;

namespace Days.Model
{
    public interface IReadonlyDaySettings : INotifyPropertyChanged
    {
        public int ClientsAmount { get; }

        public float DealsCostCoefficient { get; }

        public int ClientsTypesAmount { get; }
    }
}