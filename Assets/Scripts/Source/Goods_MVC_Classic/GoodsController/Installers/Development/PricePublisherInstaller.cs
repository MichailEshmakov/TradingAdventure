using Goods.Model;
using Goods.Model.Configs;
using Goods.Model.Readonly;
using Goods.Model.Readonly.Resources;
using Goods.Model.Resources;
using TMPro;
using UnityEngine;
using Zenject;

namespace Goods.Controller.Installers.Development
{
    public class PricePublisherInstaller : MonoInstaller
    {
        [SerializeField] TMP_Dropdown _dropdown;
        [SerializeField] BasicPricesConfig _config;

        private IReadonlyStorage _storage;

        [Inject]
        private void Construct(IReadonlyStorage storage)
        {
            _storage = storage;
        }

        public override void InstallBindings()
        {
            if (_storage.TryFindResource((Currency)_dropdown.value, out IReadonlyResource resource) == false)
            {
                if (_storage.TryGetFirstResource(out resource) == false)
                {
                    Debug.LogError($"Cannot find a {nameof(resource)}");
                    resource = new Resource(0, 0);
                }
                
            }

            ResourcePricePublisher resourcePricePublisher = new ResourcePricePublisher(_config, resource);
            Container.Bind<IResourcePricePublisher>().FromInstance(resourcePricePublisher).AsSingle();
            Container.Bind<IReadonlyResourcePricePublisher>().FromInstance(resourcePricePublisher).AsSingle();
        }
    }
}