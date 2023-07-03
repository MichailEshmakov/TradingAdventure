using Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Saving.Numerics
{
    public class ChangableSavable<T> : IChangable<T>
    {
        private ValuedSavable<T> _value;
        private IChangable<T> _logic;

        public ChangableSavable(IChangable<T> logic)
        {
            
        }

        public T Value => throw new System.NotImplementedException();

        public void Add(T addableValue)
        {
            throw new System.NotImplementedException();
        }

        public bool CanSubtract(T subtractValue)
        {
            throw new System.NotImplementedException();
        }

        public bool TrySubtract(T subtractValue)
        {
            throw new System.NotImplementedException();
        }
    }
}
