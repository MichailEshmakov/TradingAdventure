using Clients.Model.Configs;
using System;

namespace Clients.Adapter
{
    public interface IClientChangingPubliser
    {
        public event Action<string> ClientChosen;

        public bool TryGetClientName(out string name);
    }
}