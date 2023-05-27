using System.Collections.Generic;
using UnityEngine;

namespace Clients.Model.Configs
{
    [CreateAssetMenu(fileName = nameof(Client), menuName = "Configs/Model/" + nameof(Client), order = 0)]
    public class Client : ScriptableObject
    {
        [SerializeField] private List<ClientPreference> _resourceCoefficients;
        [SerializeField] private float _dealCost = 10f;

        public float DealCost => _dealCost;
        public IEnumerable<ClientPreference> ResourceCoefficients => _resourceCoefficients;

        public void Init(List<ClientPreference> resourceCoefficients, float dealCost)
        {
            if (Application.isPlaying)
                Debug.LogError("Config shouldn't be changed");

            _resourceCoefficients = resourceCoefficients;
            _dealCost = dealCost;
        }
    }
}
