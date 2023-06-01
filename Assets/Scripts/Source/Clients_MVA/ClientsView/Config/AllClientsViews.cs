using Extensions;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Clients.View.Configs
{
    [CreateAssetMenu(fileName = nameof(AllClientsViews), menuName = "Configs/View/" + nameof(AllClientsViews), order = 0)]
    public class AllClientsViews : ScriptableObject, IAllClientsViewConfigs
    {
        [SerializeField] private List<ClientViewConfig> _views;

        public bool TryFind(string name, out ClientViewConfig foundConfig)
        {
            foundConfig = _views.FirstOrDefault(view => view.name == name);
            return foundConfig != null;
        }

        public bool TryGetRandom(out ClientViewConfig randomConfig)
        {
            return _views.TryGetRandom(out randomConfig);
        }
    }
}