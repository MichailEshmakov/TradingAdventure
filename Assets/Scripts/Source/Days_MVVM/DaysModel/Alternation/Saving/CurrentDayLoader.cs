using UnityEngine;

namespace Days.Model.Alternation.Saving
{
    public class CurrentDayLoader : IStartCurrentDay
    {
        private const int DefaultFirstDay = 1;

        public int LoadValue()
        {
            return PlayerPrefs.GetInt(SavingKeys.CurrentDay, DefaultFirstDay);
        }
    }
}