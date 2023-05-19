using System.Collections.Generic;
using UnityEngine;

namespace Clients.Model.Configs
{
    [CreateAssetMenu(fileName = nameof(Client), menuName = "Configs/Model/" + nameof(Client), order = 0)]
    public class Client : ScriptableObject
    {
        [SerializeField] private List<ResourceCoefficients> _resourceCoefficients;
        [SerializeField] private float _dealCost = 10f;

        public float DealCost => _dealCost;
        public IEnumerable<ResourceCoefficients> ResourceCoefficients => _resourceCoefficients;
    }
}
