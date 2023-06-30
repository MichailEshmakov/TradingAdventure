using Days.Model;
using Days.Model.Configs;
using UnityEngine;
using Zenject;

namespace Days.ViewModel.Installers
{
    public class DaySettingsInstaller : MonoInstaller, IInitializable
    {
        private DaySettingsViewModel _viewModel;

        private void OnDestroy()
        {
            if (_viewModel != null)
                _viewModel.Dispose();
        }

        public override void InstallBindings()
        {
            Container.Bind(typeof(IDaySettings), typeof(IReadonlyDaySettings)).To<DaySettings>().AsSingle();
            Container.Bind<IDaySettingsViewModel>().To<DaySettingsViewModel>().AsSingle();
        }

        public void Initialize()
        {
            _viewModel = (DaySettingsViewModel)Container.Resolve<IDaySettingsViewModel>();
        }
    }
}