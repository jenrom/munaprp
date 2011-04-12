using System;
using System.Collections.Generic;

using nothinbutdotnetprep.infrastructure.filtering;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class ComparerBuilder<ItemToSort> : IComparer<ItemToSort>
    {
        private IComparer<ItemToSort> currentComparer = new EmptyComparer<ItemToSort>();

        public int Compare(ItemToSort x, ItemToSort y)
        {
            return this.currentComparer.Compare(x, y);
        }

        public ComparerBuilder<ItemToSort> then_by<PropertyType>(PropertyAccessor<ItemToSort, PropertyType> accessor,
                                                                 params PropertyType[] fixed_order)
        {
            this.currentComparer = new ChainedComparer<ItemToSort>(this.currentComparer,
                                                                   new FixedOrderComparer<ItemToSort, PropertyType>(accessor, fixed_order));
            return this;
        }

        public ComparerBuilder<ItemToSort> then_by<PropertyType>(PropertyAccessor<ItemToSort, PropertyType> accessor)
            where PropertyType : IComparable<PropertyType>
        {
            this.currentComparer = this.chain_anonymous(accessor);
            return this;
        }

        public ComparerBuilder<ItemToSort> then_by_descending<PropertyType>(PropertyAccessor<ItemToSort, PropertyType> accessor)
            where PropertyType : IComparable<PropertyType>
        {
            this.currentComparer = new ReverseComparer<ItemToSort>(this.chain_anonymous(accessor));
            return this;
        }

        private IComparer<ItemToSort> chain_anonymous<PropertyType>(PropertyAccessor<ItemToSort, PropertyType> accessor)
            where PropertyType : IComparable<PropertyType>
        {
            return new ChainedComparer<ItemToSort>(this.currentComparer,
                                                   new AnonymousComparer<ItemToSort>((x, y) => accessor(x).CompareTo(accessor(y))));
        }
    }
}