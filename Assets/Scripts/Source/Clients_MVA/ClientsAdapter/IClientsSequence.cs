using Clients.Model.Configs;
using System;

namespace Clients.Adapter
{
    public interface IClientsSequence
    {
        public event Action ClientsGotReady;

        public bool TryGetNext(out IClient client);
    }
}