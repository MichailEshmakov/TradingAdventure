using System;

namespace Clients.Adapter.DailyCounting
{
    public interface IReadonlyClientsDailyCounter
    {
        public event Action AllClientsServed;

        public bool IsEnough();
    }
}