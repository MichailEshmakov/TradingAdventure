using Goods.Model.Resources;
using System.Collections.Generic;
using UnityEngine;

namespace Goods.Model.Configs
{
    [CreateAssetMenu(fileName = nameof(ResourcesConfig), menuName = "Configs/Model/" + nameof(ResourcesConfig), order = 0)]
    public class ResourcesConfig : ScriptableObject
    {
        [SerializeField] private SerializableResources _resources;

        public IEnumerable<IResource> Resources => _resources.FormResources();
    }
}