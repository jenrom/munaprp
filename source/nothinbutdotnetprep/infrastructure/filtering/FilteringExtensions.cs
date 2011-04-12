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
    }
}