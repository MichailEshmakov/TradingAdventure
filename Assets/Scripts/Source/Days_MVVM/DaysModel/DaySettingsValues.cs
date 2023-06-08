using System;
using UnityEngine;

namespace Days.Model
{
    [Serializable]
    public struct DaySettingsValues : IDaySettingsValues
    {
        [SerializeField] private int _clientsAmount;
        [SerializeField] private float _dealsCostCoefficient;
        [SerializeField] private int _clientsTypesAmount;

        public DaySettingsValues(int clientsAmount, float dealsCostCoefficient, int clientsTypesAmount)
        {
            _clientsAmount = clientsAmount;
            _dealsCostCoefficient = dealsCostCoefficient;
            _clientsTypesAmount = clientsTypesAmount;
        }

        public int ClientsAmount => _clientsAmount;
        public float DealsCostCoefficient => _dealsCostCoefficient;
        public int ClientsTypesAmount => _clientsTypesAmount;
    }
}