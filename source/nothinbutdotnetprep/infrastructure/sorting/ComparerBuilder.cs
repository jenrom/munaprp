using System;
using System.Collections.Generic;

using nothinbutdotnetprep.infrastructure.filtering;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class ComparerBuilder<ItemToSort> : IComparer<ItemToSort>
    {
        private readonly IComparer<ItemToSort> comparer;

        public ComparerBuilder()
        {
        }

        public ComparerBuilder(IComparer<ItemToSort> currentComparer, IComparer<ItemToSort> newComparer)
        {
            this.comparer = currentComparer != null ? new ChainedComparer<ItemToSort>(currentComparer, newComparer) : newComparer;
        }

        public int Compare(ItemToSort x, ItemToSort y)
        {
            return this.comparer.Compare(x, y);
        }

        public ComparerBuilder<ItemToSort> then_by<PropertyType>(PropertyAccessor<ItemToSort, PropertyType> accessor,
                                                                 params PropertyType[] fixed_order)
        {
            return create_comparer_builder(this.comparer, create_fixed_order_comparer(accessor, fixed_order));
        }

        public ComparerBuilder<ItemToSort> then_by<PropertyType>(PropertyAccessor<ItemToSort, PropertyType> accessor)
            where PropertyType : IComparable<PropertyType>
        {
            return create_comparer_builder(this.comparer, create_anonymous_comparer(accessor));
        }

        public ComparerBuilder<ItemToSort> then_by_descending<PropertyType>(PropertyAccessor<ItemToSort, PropertyType> accessor)
            where PropertyType : IComparable<PropertyType>
        {
            return create_comparer_builder(this.comparer, create_reverse_comparer(accessor));
        }

        private static ComparerBuilder<ItemToSort> create_comparer_builder(IComparer<ItemToSort> currentComparer, IComparer<ItemToSort> newComparer)
        {
            return new ComparerBuilder<ItemToSort>(currentComparer, newComparer);
        }

        private static IComparer<ItemToSort> create_fixed_order_comparer<PropertyType>(PropertyAccessor<ItemToSort, PropertyType> accessor,
                                                                                params PropertyType[] fixed_order)
        {
            return new FixedOrderComparer<ItemToSort, PropertyType>(accessor, fixed_order);
        }

        private static IComparer<ItemToSort> create_anonymous_comparer<PropertyType>(PropertyAccessor<ItemToSort, PropertyType> accessor)
            where PropertyType : IComparable<PropertyType>
        {
            return new AnonymousComparer<ItemToSort>((x, y) => accessor(x).CompareTo(accessor(y)));
        }

        private static IComparer<ItemToSort> create_reverse_comparer<PropertyType>(PropertyAccessor<ItemToSort, PropertyType> accessor)
            where PropertyType : IComparable<PropertyType>
        {
            return new ReverseComparer<ItemToSort>(create_anonymous_comparer(accessor));
        }
    }
}