using Days.Model.Alternation;
using Days.ViewModel.Alternation;
using Zenject;

namespace Days.ViewModel.Installers.Alternation
{
    public class DaysAlternationInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            DaysAlternator model = new DaysAlternator();
            IDaysAlternatorViewModel viewModel = new DaysAlternatorViewModel(model);
            Container.Bind<IDaysAlternatorViewModel>().FromInstance(viewModel).AsSingle();
            Container.Bind<IDayStartingPublisher>().FromInstance(model).AsSingle();
        }
    }
}