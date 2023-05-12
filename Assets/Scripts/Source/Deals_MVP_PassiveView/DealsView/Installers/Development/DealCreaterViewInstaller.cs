using Deals.View.Development;
using UnityEngine;
using Zenject;

namespace Deals.View.Installers.Development
{
    public class DealCreaterViewInstaller : MonoInstaller
    {
        [SerializeField] private DealCreaterView _createrView;

        private void OnValidate()
        {
            if (_createrView == null)
                _createrView = FindObjectOfType<DealCreaterView>();
        }

        public override void InstallBindings()
        {
            Container.Bind<IDealCreaterView>().FromInstance(_createrView).AsSingle();
        }
    }
}