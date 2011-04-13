using System;
using System.Collections;
using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class SortedEnumerable<ItemToSort> : IEnumerable<ItemToSort>
    {
        private readonly IEnumerable<ItemToSort> source;
        IComparer<ItemToSort> comparer = new EmptyComparer<ItemToSort>();

        
        public SortedEnumerable(IEnumerable<ItemToSort> source)
        {
            this.source = source;
            this.comparer = comparer;
        }

        public SortedEnumerable<ItemToSort> then_by<PropertyType>(PropertyAccessor<ItemToSort, PropertyType> accessor,
                                                                 params PropertyType[] fixed_order)
        {
            comparer = create_comparer_builder(create_fixed_order_comparer(accessor, fixed_order));
            return this;
        }

        public SortedEnumerable<ItemToSort> then_by<PropertyType>(PropertyAccessor<ItemToSort, PropertyType> accessor)
            where PropertyType : IComparable<PropertyType>
        {
            comparer = create_comparer_builder(create_anonymous_comparer(accessor));
            return this;
        }

        public SortedEnumerable<ItemToSort> then_by_descending<PropertyType>(
            PropertyAccessor<ItemToSort, PropertyType> accessor)
            where PropertyType : IComparable<PropertyType>
        {
            comparer = create_comparer_builder(create_reverse_comparer(accessor));
            return this;
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

        public IEnumerator<ItemToSort> GetEnumerator()
        {
            var list = new List<ItemToSort>(source);
            list.Sort(comparer);
            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}