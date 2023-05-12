namespace Deals.Model
{
    public interface IDeal : IReadonlyDeal
    {
        public void Reject();
        public bool TryAccept();
    }
}