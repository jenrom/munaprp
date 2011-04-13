using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public static class SortingExtensions
    {
        public static SortedEnumerable<ItemToSort> order_by<ItemToSort, PropertyType>(this IEnumerable<ItemToSort> items, PropertyAccessor<ItemToSort, PropertyType> accessor,  params PropertyType[] orderedValues) 
        {
            return new SortedEnumerable<ItemToSort>(items).then_by(accessor, orderedValues);
        }
    }
}