using System.ComponentModel;

namespace Days.ViewModel.Alternation
{
    public interface IDaysCounterViewModel : INotifyPropertyChanged
    {
        public int Day { get; }
    }
}