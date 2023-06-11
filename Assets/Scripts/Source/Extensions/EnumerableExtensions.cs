using System;
using System.Collections.Generic;

namespace Extensions
{
    public static class EnumerableExtensions
    {
        private static readonly Random _random = new Random();

        public static bool TryGetRandom<T>(this IEnumerable<T> collection, out T randomElement)
        {
            List<T> tempList = new List<T>(collection);
            int count = tempList.Count;

            if (count == 0)
            {
                randomElement = default(T);
                return false;
            }

            int randomIndex = _random.Next(count);

            randomElement = tempList[randomIndex];
            return true;
        }
    }
}