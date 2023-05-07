using Goods.Model.Readonly.Resources;
using UnityEngine;

namespace Goods.View
{
    public interface IResourceIconsConfig
    {
        public bool TryGetSprite(Currency currency, out Sprite sprite);
    }
}