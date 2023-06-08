using NaughtyAttributes;
using UnityEngine;

namespace Days.Model.Configs
{
    [CreateAssetMenu(fileName = nameof(StartDaySettings), menuName = "Configs/Model/" + nameof(StartDaySettings), order = 0)]
    public class StartDaySettings : ScriptableObject
    {
        [SerializeField] private bool _isAutomaticValidate = false;
        [SerializeField] private DaySettingsConfig _config;
        [SerializeField] private DaySettingsValues _values;

        private IDaySettingsBalancer _balancer;

        private void OnValidate()
        {
            if (_isAutomaticValidate)
                Validate();
        }

        [Button(nameof(Validate))]
        private void Validate()
        {
            if (_config != null)
            {
                if (_balancer == null)
                    _balancer = new DaySettingsBalancer(_config);

                _values = _balancer.Balance(_values, DaySettingType.Nothing);
            }
        }
    }
}
