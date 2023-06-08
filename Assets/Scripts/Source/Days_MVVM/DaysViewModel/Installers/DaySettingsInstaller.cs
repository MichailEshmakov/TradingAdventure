using Days.Model;
using Days.Model.Configs;
using UnityEngine;
using Zenject;

namespace Days.ViewModel.Installers
{
    public class DaySettingsInstaller : MonoInstaller
    {
        [SerializeField] private DaySettingsConfig _config;
        [SerializeField] private StartDaySettings _startDaySettings;

        private DaySettingsViewModel _viewModel;

        public override void InstallBindings()
        {
            DaySettings model = new DaySettings(_config, _startDaySettings.Values);
            _viewModel = new DaySettingsViewModel(_config, model);
            Container.Bind<IDaySettingsViewModel>().FromInstance(_viewModel);
        }

        private void OnDestroy()
        {
            _viewModel.Dispose();
        }
    }
}