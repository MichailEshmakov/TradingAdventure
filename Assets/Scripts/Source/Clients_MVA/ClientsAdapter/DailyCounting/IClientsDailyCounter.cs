namespace Clients.Adapter.DailyCounting
{
    public interface IClientsDailyCounter : IReadonlyClientsDailyCounter
    {
        public void AddOne();
    }
}