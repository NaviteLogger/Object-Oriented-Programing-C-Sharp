using System;

namespace Program
{
    class U<T> : IComparable<T>
    {
        public int CompareTo(T? other)
        {
            if (other == null)
            {
                return 1;
            }

            return 0;
        }
    }
}