using Extensions;
using System.Collections.Generic;
using UnityEngine;

namespace Clients.Model.Configs
{
    [CreateAssetMenu(fileName = nameof(AllClients), menuName = "Configs/Model/" + nameof(AllClients), order = 0)]
    public class AllClients : ScriptableObject
    {
        [SerializeField] private List<Client> _clients;

        public bool TryGetRandom(out Client client)
        {
            return _clients.TryGetRandom(out client);
        }
    }
}