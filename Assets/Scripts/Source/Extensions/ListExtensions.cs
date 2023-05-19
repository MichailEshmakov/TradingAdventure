using System;
using System.Collections.Generic;

namespace Extensions
{
    public static class ListExtensions
    {
        private static readonly Random _random = new Random();

        public static bool TryGetRandom<T>(this List<T> list, out T result)
        {
            result = default;
            if (list.Count == 0)
                return false;

            int randomIndex = _random.Next(list.Count);
            result = list[randomIndex];
            return true;
        }
    }
}