using Days.Model.Configs;
using UnityEngine;
using Zenject;

namespace Days.ViewModel.Installers
{
    public class DaySettingsConfigsInstaller : MonoInstaller
    {
        [SerializeField] private StartDaySettings _startDaySettings;
        [SerializeField] private DaySettingsConfig _config;

        public override void InstallBindings()
        {
            Container.Bind<IPrimalDaySettingsConfig>().FromInstance(_config).AsSingle();
            Container.Bind<IStartDaySettings>().FromInstance(_startDaySettings).AsSingle();
        }
    }
}