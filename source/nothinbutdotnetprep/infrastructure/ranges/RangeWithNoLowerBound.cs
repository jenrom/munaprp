using System;

namespace nothinbutdotnetprep.infrastructure.ranges
{
    public class RangeWithNoLowerBound<T> : Range<T> where T : IComparable<T>
    {
        public RangeWithNoLowerBound(T start)
        {
            this.start = start;
        }

        T start;

        public bool contains(T value)
        {
            return value.CompareTo(start) < 0;
        }
    }
}