using System;
using nothinbutdotnetprep.infrastructure.ranges;

namespace nothinbutdotnetprep.infrastructure.filtering
{
    public static class FilteringExtensions
    {
        public static Criteria<ItemToMatch> equal_to<ItemToMatch,PropertyType>(this IProvideAccessToSpecificationFactories<ItemToMatch,PropertyType> extension_point,PropertyType value)
        {
            return equal_to_any(extension_point,value);
        }

        public static Criteria<ItemToMatch> equal_to_any<ItemToMatch,PropertyType>(this IProvideAccessToSpecificationFactories<ItemToMatch,PropertyType> extension_point,params PropertyType[] values)
        {
            return extension_point.create_from(new EqualToAny<PropertyType>(values));
        }

        public static Criteria<ItemToMatch> greater_than_or_equal_to<ItemToMatch,PropertyType>(this IProvideAccessToSpecificationFactories<ItemToMatch,PropertyType> extension_point,PropertyType value) where PropertyType : IComparable<PropertyType>
        {
            return extension_point.create_from(new FallsInRange<PropertyType>(new RangeWithNoUpperBound<PropertyType>(value))
                               .or(new EqualToAny<PropertyType>(value)));
        }

        public static Criteria<ItemToMatch> less_than_or_equal_to<ItemToMatch,PropertyType>(this IProvideAccessToSpecificationFactories<ItemToMatch,PropertyType> extension_point,PropertyType value) where PropertyType : IComparable<PropertyType>
        {
            return extension_point.create_from(new FallsInRange<PropertyType>(new RangeWithNoLowerBound<PropertyType>(value))
                               .or(new EqualToAny<PropertyType>(value)));
        }

        public static Criteria<ItemToMatch> between<ItemToMatch,PropertyType>(this IProvideAccessToSpecificationFactories<ItemToMatch,PropertyType> extension_point,PropertyType start, PropertyType end) where PropertyType : IComparable<PropertyType>
        {
            return greater_than_or_equal_to(extension_point,start).and(less_than_or_equal_to(extension_point,end));
        }

        public static Criteria<ItemToMatch> greater_than<ItemToMatch,PropertyType>(this IProvideAccessToSpecificationFactories<ItemToMatch,PropertyType> extension_point,PropertyType value) where PropertyType : IComparable<PropertyType>
        {
            return extension_point.create_from(new FallsInRange<PropertyType>(new RangeWithNoUpperBound<PropertyType>(value)));
        }
    }
}