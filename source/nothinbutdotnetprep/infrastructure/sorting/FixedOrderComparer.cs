using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class FixedOrderComparer<T> : IComparer<T>
    {
        readonly IList<T> fixedOrder;

        public FixedOrderComparer(params T[] fixed_order)
        {
            this.fixedOrder = new List<T>(fixed_order);
        }

        public int Compare(T x, T y)
        {
            return fixedOrder.IndexOf(x).CompareTo(fixedOrder.IndexOf(y));
        }
    }
}