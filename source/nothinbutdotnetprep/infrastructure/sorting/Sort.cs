using System;

using nothinbutdotnetprep.infrastructure.filtering;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class Sort<ItemToSort>
    {
        public static ComparerBuilder<ItemToSort> by<PropertyType>(PropertyAccessor<ItemToSort, PropertyType> accessor, params PropertyType[] values)
        {
            return create_builder().then_by(accessor, values);
        }

        public static ComparerBuilder<ItemToSort> by_descending<PropertyType>(PropertyAccessor<ItemToSort, PropertyType> accessor)
            where PropertyType : IComparable<PropertyType>
        {
            return create_builder().then_by_descending(accessor);
        }

        public static ComparerBuilder<ItemToSort> by<PropertyType>(PropertyAccessor<ItemToSort, PropertyType> accessor)
            where PropertyType : IComparable<PropertyType>
        {
            return create_builder().then_by(accessor);
        }

        private static ComparerBuilder<ItemToSort> create_builder()
        {
            return new ComparerBuilder<ItemToSort>();
        }
    }
}