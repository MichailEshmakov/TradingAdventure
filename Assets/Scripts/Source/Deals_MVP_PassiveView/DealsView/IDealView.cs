using Goods.Model.Readonly.Resources;

namespace Deals.View
{
    public interface IDealView
    {
        public void Init(IReadonlyResource addableResource, IReadonlyResource removableResource);
        void Hide();
        void Show();
    }
}