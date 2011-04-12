using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class EmptyComparer<T> : IComparer<T>
    {
        public int Compare(T x, T y)
        {
            return 0;
        }
    }
}