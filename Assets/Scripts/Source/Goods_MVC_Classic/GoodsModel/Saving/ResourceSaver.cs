using Goods.Model.Readonly.Resources;
using System;
using UnityEngine;

namespace Goods.Model.Saving
{
    public class ResourceSaver : IDisposable
    {
        private readonly IReadonlyResource _resource;
        private readonly string _key;

        public Currency Currency => _resource.Currency;

        public ResourceSaver(IKeyFormer keyFormer, IReadonlyResource resource)
        {
            _resource = resource;
            _resource.DecreasedBy += OnResourceDecreased;
            _resource.IncreasedBy += OnResourceIncreased;
            _key = keyFormer.FormKey(_resource.Currency);
        }

        public void Dispose()
        {
            _resource.DecreasedBy -= OnResourceDecreased;
            _resource.IncreasedBy -= OnResourceIncreased;
        }

        private void OnResourceIncreased(int delta)
        {
            Save();
        }

        private void OnResourceDecreased(int delta)
        {
            Save();
        }

        private void Save()
        {
            PlayerPrefs.SetInt(_key, _resource.Value);
        }
    }
}