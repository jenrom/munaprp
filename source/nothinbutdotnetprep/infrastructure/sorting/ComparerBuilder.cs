using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class ComparerBuilder<ItemToSort> : IComparer<ItemToSort>
    {
        IComparer<ItemToSort> comparer;

        public ComparerBuilder() : this(new EmptyComparer<ItemToSort>())
        {
        }

        public ComparerBuilder(IComparer<ItemToSort> comparer)
        {
            this.comparer = comparer;
        }

        public int Compare(ItemToSort x, ItemToSort y)
        {
            return this.comparer.Compare(x, y);
        }

        public ComparerBuilder<ItemToSort> then_by<PropertyType>(PropertyAccessor<ItemToSort, PropertyType> accessor,
                                                                 params PropertyType[] fixed_order)
        {
            return create_comparer_builder(create_fixed_order_comparer(accessor, fixed_order));
        }

        public ComparerBuilder<ItemToSort> then_by<PropertyType>(PropertyAccessor<ItemToSort, PropertyType> accessor)
            where PropertyType : IComparable<PropertyType>
        {
            return create_comparer_builder(create_anonymous_comparer(accessor));
        }

        public ComparerBuilder<ItemToSort> then_by_descending<PropertyType>(
            PropertyAccessor<ItemToSort, PropertyType> accessor)
            where PropertyType : IComparable<PropertyType>
        {
            return create_comparer_builder(create_reverse_comparer(accessor));
        }

        ComparerBuilder<ItemToSort> create_comparer_builder(IComparer<ItemToSort> new_comparer)
        {
            return new ComparerBuilder<ItemToSort>(new ChainedComparer<ItemToSort>(comparer, new_comparer));
        }

        static IComparer<ItemToSort> create_fixed_order_comparer<PropertyType>(
            PropertyAccessor<ItemToSort, PropertyType> accessor,
            params PropertyType[] fixed_order)
        {
            return new PropertyComparer<ItemToSort, PropertyType>(accessor,
                                                                  new FixedOrderComparer<PropertyType>(fixed_order));
        }

        static IComparer<ItemToSort> create_anonymous_comparer<PropertyType>(
            PropertyAccessor<ItemToSort, PropertyType> accessor)
            where PropertyType : IComparable<PropertyType>
        {
            return new PropertyComparer<ItemToSort, PropertyType>(accessor, new ComparableComparer<PropertyType>());
        }

        static IComparer<ItemToSort> create_reverse_comparer<PropertyType>(
            PropertyAccessor<ItemToSort, PropertyType> accessor)
            where PropertyType : IComparable<PropertyType>
        {
            return new ReverseComparer<ItemToSort>(create_anonymous_comparer(accessor));
        }
    }
}