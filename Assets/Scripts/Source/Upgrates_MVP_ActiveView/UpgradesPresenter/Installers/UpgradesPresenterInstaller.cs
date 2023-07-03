using Days.Model.Configs;
using UnityEngine;
using Upgrades.Model;
using Upgrades.Model.Configs;
using Upgrades.Model.Saving;
using Zenject;

namespace Upgrades.Presenter.Installers
{
    public class UpgradesPresenterInstaller : MonoInstaller, IInitializable
    {
        [SerializeField] private AllUpgrades _upgrades;

        private UpgradesPresenter _upgradesPresenter;
        private UpgradedDaySettingsConfig _upgradedDaySettingsConfig;
        private UpgradesSaver _saver;

        private void OnDestroy()
        {
            if (_upgradesPresenter != null)
                _upgradesPresenter.Dispose();

            if (_upgradedDaySettingsConfig != null)
                _upgradedDaySettingsConfig.Dispose();

            if (_saver != null)
                _saver.Dispose();
        }

        public override void InstallBindings()
        {
            Container.Bind<IStartBoughtFlags>().To<UpgradesLoader>().AsSingle();

            Container.Bind<IAllUpgrades>().FromInstance(_upgrades).AsSingle();
            Container.Bind<IUpgradesShop>().To<UpgradesShop>().AsSingle();
            Container.Bind<IDaySettingsConfig>().To<UpgradedDaySettingsConfig>().AsSingle();
            Container.Bind<IUpgradesPresenter>().To<UpgradesPresenter>().AsSingle();

            Container.BindInterfacesTo<UpgradesPresenterInstaller>().FromInstance(this).AsSingle();
        }

        public void Initialize()
        {
            _upgradesPresenter = (UpgradesPresenter)Container.Resolve<IUpgradesPresenter>();
            _upgradedDaySettingsConfig = (UpgradedDaySettingsConfig)Container.Resolve<IDaySettingsConfig>();
            _saver = Container.Instantiate<UpgradesSaver>();
        }
    }
}