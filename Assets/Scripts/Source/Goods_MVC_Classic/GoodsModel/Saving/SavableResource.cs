using Goods.Model.Readonly.Resources;
using Goods.Model.Resources;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Goods.Model.Saving
{
    public class SavableResource : IResource
    {
        public int Value => throw new NotImplementedException();

        public Currency Currency => throw new NotImplementedException();

        public event Action<int> IncreasedBy;
        public event Action<int> DecreasedBy;

        public void Add(int addableValue)
        {
            throw new NotImplementedException();
        }

        public bool CanSubtract(int subtractValue)
        {
            throw new NotImplementedException();
        }

        public bool TrySubtract(int subtractValue)
        {
            throw new NotImplementedException();
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}