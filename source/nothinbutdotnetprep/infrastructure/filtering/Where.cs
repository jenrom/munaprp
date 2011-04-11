namespace nothinbutdotnetprep.infrastructure.filtering
{
    public static class Where<ItemToMatch>
    {
        public static CriteriaBuilder<ItemToMatch, PropertyType> has_a<PropertyType>(
            PropertyAccessor<ItemToMatch, PropertyType> accessor)
        {
            return CriteriaBuilder<ItemToMatch, PropertyType>.Create(accessor);
        }
    }
}