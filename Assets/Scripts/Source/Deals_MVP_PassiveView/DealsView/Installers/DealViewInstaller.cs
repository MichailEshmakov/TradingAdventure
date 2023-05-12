using UnityEngine;
using Zenject;

namespace Deals.View.Installers
{
    public class DealViewInstaller : MonoInstaller
    {
        [SerializeField] private DealView _dealView;

        private void OnValidate()
        {
            if (_dealView == null)
                _dealView = FindObjectOfType<DealView>();
        }

        public override void InstallBindings()
        {
            Container.Bind<IDealButtons>().FromInstance(_dealView).AsSingle();
            Container.Bind<IDealView>().FromInstance(_dealView).AsSingle();
        }
    }
}