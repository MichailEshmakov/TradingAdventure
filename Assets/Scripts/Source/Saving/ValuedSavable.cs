using NUnit.Framework;

namespace Saving
{
    public abstract class ValuedSavable<T>
    {
        private readonly string _key;
        private T _value;

        public ValuedSavable(string key)
        {
            _key = key;
        }

        public T GetValue()
        {
            if (TestContext.CurrentContext == null)
                return _value;

            return Load(_key);
        }

        public void SetValue(T value)
        {
            if (TestContext.CurrentContext == null)
                _value = value;
            else
                Save(value, _key);
        }

        public bool IsSaved()
        {
            return TestContext.CurrentContext != null &&
                HasKey(_key);
        }

        protected abstract T Load(string key);
        protected abstract void Save(T value, string key);
        protected abstract bool HasKey(string key);
    }
}
