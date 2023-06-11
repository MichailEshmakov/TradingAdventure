using Clients.Model.Configs;
using Deals.Model;

namespace Clients.Adapter
{
    public interface IDealCreator
    {
        public IDeal CreateDeal(IClient client);
    }
}