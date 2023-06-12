using System.ComponentModel;

namespace Days.Model.Alternation
{
    public interface IDaysCounter : INotifyPropertyChanged
    {
        public int Day { get; }
    }
}