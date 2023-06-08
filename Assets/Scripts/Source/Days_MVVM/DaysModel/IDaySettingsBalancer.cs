namespace Days.Model
{
    public interface IDaySettingsBalancer
    {
        public DaySettingsValues Balance(IDaySettingsValues primarySettings, DaySettingType balancingConst);
    }
}