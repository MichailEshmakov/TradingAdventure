using Days.Model.Alternation;

namespace Days.ViewModel.Alternation
{
    public class DaysAlternatorViewModel : IDaysAlternatorViewModel
    {
        private readonly IDaysAlternator _model;

        public DaysAlternatorViewModel(IDaysAlternator model)
        {
            _model = model;
        }

        public void StartNextDay()
        {
            _model.StartNextDay();
        }
    }
}