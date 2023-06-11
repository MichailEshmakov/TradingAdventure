using System.Collections.Generic;

namespace Clients.Model.Configs
{
    public interface IAllClients
    {
        public bool TryGetRandom(out IClient client);
        public IEnumerable<IClient> Take(int amount);
    }
}