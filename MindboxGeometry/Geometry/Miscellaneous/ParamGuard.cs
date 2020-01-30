using System;

namespace Geometry
{
    internal static class ParamGuard
    {
        public static void CheckNotNegative(double value, string paramName)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException("Value cannot be negative", paramName);
        }
    }
}