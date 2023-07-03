using UnityEngine;

namespace Saving
{
    public class IntSavable : ValuedSavable<int>
    {
        public IntSavable(string key) : base(key)
        {
        }

        protected override bool HasKey(string key)
        {
            return PlayerPrefs.HasKey(key);
        }

        protected override int Load(string key)
        {
            return PlayerPrefs.GetInt(key);
        }

        protected override void Save(int value, string key)
        {
            PlayerPrefs.SetInt(key, value);
        }
    }
}
