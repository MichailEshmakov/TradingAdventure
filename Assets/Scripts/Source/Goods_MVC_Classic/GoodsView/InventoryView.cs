using Goods.Model.Readonly;
using Goods.Model.Readonly.Resources;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Goods.View
{
    public class InventoryView : MonoBehaviour
    {
        [SerializeField] private List<ResourceView> _resourcesViews;

        [Inject]
        private void Construct(IReadonlyStorage storage)
        {
            int index = 0;
            foreach (IReadonlyResource resource in storage.Resources)
            {
                _resourcesViews[index].Init(resource);
                index++;
            }
        }
    }
}