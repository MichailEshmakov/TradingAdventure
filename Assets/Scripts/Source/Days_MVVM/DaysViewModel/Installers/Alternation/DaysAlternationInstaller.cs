using Days.Model.Alternation;
using Days.Model.Alternation.Saving;
using Days.ViewModel.Alternation;
using UnityEngine;
using Zenject;

namespace Days.ViewModel.Installers.Alternation
{
    public class DaysAlternationInstaller : MonoInstaller, IInitializable
    {
        private DaysCounter _daysCounter;
        private DaysCounterViewModel _daysCounterViewModel;
        private CurrentDaySaver _saver;

        private void OnDestroy()
        {
            if (_daysCounter != null)
                _daysCounter.Dispose();

            if (_daysCounterViewModel != null)
                _daysCounterViewModel.Dispose();

            if (_saver != null)
                _saver.Dispose();
        }

        public override void InstallBindings()
        {
            Container.Bind<IStartCurrentDay>().To<CurrentDayLoader>().AsSingle();

            DaysAlternator model = new DaysAlternator();
            IDaysAlternatorViewModel viewModel = new DaysAlternatorViewModel(model);
            Container.Bind<IDaysAlternatorViewModel>().FromInstance(viewModel).AsSingle();
            Container.Bind<IDayStartingPublisher>().FromInstance(model).AsSingle();

            Container.Bind<IDaysCounter>().To<DaysCounter>().AsSingle();
            Container.Bind<IDaysCounterViewModel>().To<DaysCounterViewModel>().AsSingle();

            Container.BindInterfacesTo<DaysAlternationInstaller>().FromInstance(this).AsSingle();
        }

        public void Initialize()
        {
            _daysCounter = (DaysCounter)Container.Resolve<IDaysCounter>();
            _daysCounterViewModel = (DaysCounterViewModel)Container.Resolve<IDaysCounterViewModel>();
            _saver = Container.Instantiate<CurrentDaySaver>();
        }
    }
}