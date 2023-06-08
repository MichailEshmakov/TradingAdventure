using System.ComponentModel;

namespace Days.ViewModel
{
    public interface IDaySettingsViewModel : INotifyPropertyChanged
    {
        public float ClientsAmountPart { get; set; }
        public float DealsCostCoefficientPart { get; set; }
        public float ClientsTypesAmountPart { get; set; }
    }
}