using System;
using System.Collections.Generic;
using nothinbutdotnetprep.infrastructure.filtering;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class Sort<ItemToSort>
    {
        public static ComparerBuilder<ItemToSort> by_descending<PropertyType>(PropertyAccessor<ItemToSort,PropertyType> accessor) where PropertyType : IComparable<PropertyType>
        {
            throw new NotImplementedException();
        }

        public static ComparerBuilder<ItemToSort> by<PropertyType>(PropertyAccessor<ItemToSort,PropertyType> accessor,params PropertyType[] values) 
        {
            throw new NotImplementedException();
        }
        public static ComparerBuilder<ItemToSort> by<PropertyType>(PropertyAccessor<ItemToSort,PropertyType> accessor) where PropertyType : IComparable<PropertyType>
        {
            throw new NotImplementedException();
        }
    }

    public class ComparerBuilder<ItemToSort> : IComparer<ItemToSort>
    {
        public int Compare(ItemToSort x, ItemToSort y)
        {
            throw new NotImplementedException();
        }

        public ComparerBuilder<ItemToSort> then_by<PropertyType>(PropertyAccessor<ItemToSort,PropertyType> accessor,
            params PropertyType[] fixed_order)
        {
            throw new NotImplementedException();
        }

        public ComparerBuilder<ItemToSort> then_by<PropertyType>(PropertyAccessor<ItemToSort,PropertyType> accessor) where PropertyType : IComparable<PropertyType>
        {
            throw new NotImplementedException();
        }

        public ComparerBuilder<ItemToSort> then_by_descending<PropertyType>(PropertyAccessor<ItemToSort,PropertyType> accessor)
        {
            throw new NotImplementedException();
        }
    }
}