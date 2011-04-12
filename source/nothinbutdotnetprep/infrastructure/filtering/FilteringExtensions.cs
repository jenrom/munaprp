using System;
using nothinbutdotnetprep.infrastructure.ranges;

namespace nothinbutdotnetprep.infrastructure.filtering
{
    public static class FilteringExtensions
    {
        public static Criteria<ItemToMatch> equal_to<ItemToMatch,PropertyType>(this FilteringExtensionPoint<ItemToMatch,PropertyType> extension_point,PropertyType value)
        {
            return equal_to_any(extension_point,value);
        }

        public static Criteria<ItemToMatch> equal_to_any<ItemToMatch,PropertyType>(this FilteringExtensionPoint<ItemToMatch,PropertyType> extension_point,params PropertyType[] values)
        {
            return matches(extension_point, new EqualToAny<PropertyType>(values));
        }


        static Criteria<ItemToMatch> matches<ItemToMatch,PropertyType>(FilteringExtensionPoint<ItemToMatch,PropertyType> filtering_extension_point,Criteria<PropertyType> criteria)
        {
            return new PropertyCriteria<ItemToMatch, PropertyType>(criteria,
                                                                   filtering_extension_point.accessor);
        }
        public static Criteria<ItemToMatch> greater_than_or_equal_to<ItemToMatch,PropertyType>(this FilteringExtensionPoint<ItemToMatch,PropertyType> extension_point,PropertyType value) where PropertyType : IComparable<PropertyType>
        {
            return matches(extension_point,new FallsInRange<PropertyType>(new RangeWithNoUpperBound<PropertyType>(value))
                               .or(new EqualToAny<PropertyType>(value)));
        }

        public static Criteria<ItemToMatch> less_than_or_equal_to<ItemToMatch,PropertyType>(this FilteringExtensionPoint<ItemToMatch,PropertyType> extension_point,PropertyType value) where PropertyType : IComparable<PropertyType>
        {
            return matches(extension_point,new FallsInRange<PropertyType>(new RangeWithNoLowerBound<PropertyType>(value))
                               .or(new EqualToAny<PropertyType>(value)));
        }

        public static Criteria<ItemToMatch> between<ItemToMatch,PropertyType>(this FilteringExtensionPoint<ItemToMatch,PropertyType> extension_point,PropertyType start, PropertyType end) where PropertyType : IComparable<PropertyType>
        {
            return greater_than_or_equal_to(extension_point,start).and(less_than_or_equal_to(extension_point,end));
        }

        public static Criteria<ItemToMatch> greater_than<ItemToMatch,PropertyType>(this FilteringExtensionPoint<ItemToMatch,PropertyType> extension_point,PropertyType value) where PropertyType : IComparable<PropertyType>
        {
            return matches(extension_point,new FallsInRange<PropertyType>(new RangeWithNoUpperBound<PropertyType>(value)));
        }
    }
}