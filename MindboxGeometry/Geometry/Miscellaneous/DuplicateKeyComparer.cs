using System;
using System.Collections.Generic;

namespace Geometry
{
    /// <summary>Represents an object comparison operation that treats equal objects as different (omits duplicates).</summary>
    internal class DuplicateKeyComparer<T> : IComparer<T> where T : IComparable
    {
        public int Compare(T x, T y)
        {
            int result = x.CompareTo(y);
            return result != 0 ? result : 1;
        }
    }
}