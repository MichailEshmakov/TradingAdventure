using Extensions;
using System.Collections.Generic;
using UnityEngine;

namespace Clients.Model.Configs
{
    [CreateAssetMenu(fileName = nameof(AllClients), menuName = "Configs/Model/" + nameof(AllClients), order = 0)]
    public class AllClients : ScriptableObject, IAllClients
    {
        [SerializeField] private List<Client> _clients;

        public bool TryGetRandom(out IClient client)
        {
            bool isFound = _clients.TryGetRandom(out Client randomClient);
            client = randomClient;
            return isFound;
        }
    }
}