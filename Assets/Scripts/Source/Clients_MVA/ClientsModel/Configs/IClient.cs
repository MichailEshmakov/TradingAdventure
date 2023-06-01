using System.Collections.Generic;

namespace Clients.Model.Configs
{
    public interface IClient
    {
        public string Name { get; }
        public float DealCost { get; }
        public IEnumerable<ClientPreference> ResourceCoefficients { get; }
    }
}