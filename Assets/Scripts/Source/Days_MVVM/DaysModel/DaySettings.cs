using Days.Model.Configs;
using System.ComponentModel;

namespace Days.Model
{
    public class DaySettings : IDaySettings
    {
        private readonly IDaySettingsBalancer _balancer;
        private readonly IDaySettingsConfig _config;
        private int _clientsAmount;
        private float _dealsCostCoefficient;
        private int _clientsTypesAmount;

        public event PropertyChangedEventHandler PropertyChanged;

        public int ClientsAmount
        {
            get 
            {
                return _clientsAmount;
            }
            set
            {
                IDaySettingsValues primarySettings = new DaySettingsValues(value, _dealsCostCoefficient, _clientsTypesAmount);
                IDaySettingsValues resultSettings = _balancer.Balance(primarySettings, DaySettingType.ClientsAmount);
                SetSettings(resultSettings);
            }
        }

        public float DealsCostCoefficient
        {
            get
            {
                return _dealsCostCoefficient;
            }
            set
            {
                IDaySettingsValues primarySettings = new DaySettingsValues(_clientsAmount, value , _clientsTypesAmount);
                IDaySettingsValues resultSettings = _balancer.Balance(primarySettings, DaySettingType.DealsCostCoefficient);
                SetSettings(resultSettings);
            }
        }

        public int ClientsTypesAmount
        {
            get
            {
                return _clientsTypesAmount;
            }
            set
            {
                IDaySettingsValues primarySettings = new DaySettingsValues(_clientsAmount, _dealsCostCoefficient, value);
                IDaySettingsValues resultSettings = _balancer.Balance(primarySettings, DaySettingType.ClientsTypesAmount);
                SetSettings(resultSettings);
            }
        }

        public IDaySettingsConfig Config => _config;

        public DaySettings(IDaySettingsConfig config, IDaySettingsValues startValues)
        {
            _config = config;
            _balancer = new DaySettingsBalancer(config);
            SetSettings(_balancer.Balance(startValues, DaySettingType.Nothing));
        }

        private void SetSettings(IDaySettingsValues values)
        {
            _clientsAmount = values.ClientsAmount;
            _dealsCostCoefficient = values.DealsCostCoefficient;
            _clientsTypesAmount = values.ClientsTypesAmount;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ClientsAmount)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DealsCostCoefficient)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ClientsTypesAmount)));
        }
    }
}