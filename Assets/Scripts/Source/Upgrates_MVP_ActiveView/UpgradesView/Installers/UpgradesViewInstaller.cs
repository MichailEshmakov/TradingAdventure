using UnityEngine;
using Zenject;

namespace Upgrades.View.Installers
{
    public class UpgradesViewInstaller : MonoInstaller
    {
        [SerializeField] private UpgradeBuyingMenu _upgradeBuyingMenu;

        private void OnValidate()
        {
            if (_upgradeBuyingMenu == null)
                _upgradeBuyingMenu = FindObjectOfType<UpgradeBuyingMenu>();
        }

        public override void InstallBindings()
        {
            Container.Bind<IUpgradeBuyingMenu>().FromInstance(_upgradeBuyingMenu).AsSingle();
        }
    }
}