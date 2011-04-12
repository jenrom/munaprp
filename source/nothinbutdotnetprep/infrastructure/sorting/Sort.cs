using System;
using System.Collections.Generic;
using nothinbutdotnetprep.infrastructure.filtering;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class Sort<ItemToSort>
    {
        public static ComparerBuilder<ItemToSort> by_descending<PropertyType>(PropertyAccessor<ItemToSort,PropertyType> accessor) where PropertyType : IComparable<PropertyType>
        {
            return new ComparerBuilder<ItemToSort>(new ReverseComparer<ItemToSort>(by(accessor)));
        }

        public static ComparerBuilder<ItemToSort> by<PropertyType>(PropertyAccessor<ItemToSort,PropertyType> accessor,params PropertyType[] values) 
        {
            return new ComparerBuilder<ItemToSort>(new CustomComparer<ItemToSort, PropertyType>(accessor, values));
        }

        public static ComparerBuilder<ItemToSort> by<PropertyType>(PropertyAccessor<ItemToSort,PropertyType> accessor) where PropertyType : IComparable<PropertyType>
        {
            Comparison<ItemToSort> comparison = (x,y) => accessor(x).CompareTo(accessor(y));
            var anonymousComparer = new AnonymousComparer<ItemToSort>(comparison);
            return new ComparerBuilder<ItemToSort>(anonymousComparer);
        }
    }

    public class ComparerBuilder<ItemToSort> : IComparer<ItemToSort>
    {
        private readonly IComparer<ItemToSort> comparer;

        public ComparerBuilder(IComparer<ItemToSort> comparer)
        {
            this.comparer = comparer;
        }

        public int Compare(ItemToSort x, ItemToSort y)
        {
            return comparer.Compare(x, y);
        }

        public ComparerBuilder<ItemToSort> then_by<PropertyType>(PropertyAccessor<ItemToSort,PropertyType> accessor,
            params PropertyType[] fixed_order)
        {
            return new ComparerBuilder<ItemToSort>(new ChainedComparer<ItemToSort>(comparer, Sort<ItemToSort>.by(accessor, fixed_order)));
        }

        public ComparerBuilder<ItemToSort> then_by<PropertyType>(PropertyAccessor<ItemToSort,PropertyType> accessor) where PropertyType : IComparable<PropertyType>
        {
            return new ComparerBuilder<ItemToSort>(new ChainedComparer<ItemToSort>(comparer, Sort<ItemToSort>.by(accessor)));
        }

        public ComparerBuilder<ItemToSort> then_by_descending<PropertyType>(PropertyAccessor<ItemToSort, PropertyType> accessor) where PropertyType : IComparable<PropertyType>
        {
            return new ComparerBuilder<ItemToSort>(new ChainedComparer<ItemToSort>(comparer, Sort<ItemToSort>.by_descending(accessor)));
        }
    }

    public class CustomComparer<ItemToSort, PropertyType> : IComparer<ItemToSort>
    {
        private readonly PropertyAccessor<ItemToSort, PropertyType> accessor;
        private List<PropertyType> orderList = new List<PropertyType>();

        public CustomComparer(PropertyAccessor<ItemToSort, PropertyType> accessor, params PropertyType[] values)
        {
            this.accessor = accessor;
            this.orderList.AddRange(values);
        }

        public int Compare(ItemToSort x, ItemToSort y)
        {
            return orderList.IndexOf(accessor(x)).CompareTo(orderList.IndexOf(accessor(y)));
        }
    }

}