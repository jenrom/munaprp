namespace nothinbutdotnetprep.infrastructure.filtering
{
    public class PropertyCriteria<ItemToMatch, PropertyType> : Criteria<ItemToMatch>
    {
        Criteria<PropertyType> property_condition;
        PropertyAccessor<ItemToMatch, PropertyType> accessor;

        public PropertyCriteria(Criteria<PropertyType> property_condition, PropertyAccessor<ItemToMatch, PropertyType> accessor)
        {
            this.property_condition = property_condition;
            this.accessor = accessor;
        }

        public bool matches(ItemToMatch item)
        {
            return property_condition.matches(accessor(item));
        }
    }
}