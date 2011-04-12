using System.Collections.Generic;

using nothinbutdotnetprep.infrastructure.filtering;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class FixedOrderComparer<ItemToSort, PropertyType> : IComparer<ItemToSort>
    {
        private readonly PropertyAccessor<ItemToSort, PropertyType> accessor;
        private readonly List<PropertyType> fixedOrder;

        public FixedOrderComparer(PropertyAccessor<ItemToSort, PropertyType> accessor, params PropertyType[] fixed_order)
        {
            this.accessor = accessor;
            this.fixedOrder = new List<PropertyType>(fixed_order);
        }

        public int Compare(ItemToSort x, ItemToSort y)
        {
            return fixedOrder.IndexOf(accessor(x)).CompareTo(fixedOrder.IndexOf(accessor(y)));
        }
    }
}