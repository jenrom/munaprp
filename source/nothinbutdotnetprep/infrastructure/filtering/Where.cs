namespace nothinbutdotnetprep.infrastructure.filtering
{
    public static class Where<ItemToMatch>
    {
        public static CriteriaFactory<ItemToMatch, PropertyType> has_a<PropertyType>(
            PropertyAccessor<ItemToMatch, PropertyType> accessor)
        {
            return new CriteriaFactory<ItemToMatch, PropertyType>(accessor);
        }
    }
}