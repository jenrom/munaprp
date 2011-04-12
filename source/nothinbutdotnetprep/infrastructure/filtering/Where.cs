namespace nothinbutdotnetprep.infrastructure.filtering
{
    public static class Where<ItemToMatch>
    {
        public static FilteringExtensionPoint<ItemToMatch, PropertyType> has_a<PropertyType>(
            PropertyAccessor<ItemToMatch, PropertyType> accessor)
        {
            return new FilteringExtensionPoint<ItemToMatch, PropertyType>(accessor);
        }
    }
}