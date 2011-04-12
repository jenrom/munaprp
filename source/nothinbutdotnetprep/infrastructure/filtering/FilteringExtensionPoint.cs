namespace nothinbutdotnetprep.infrastructure.filtering
{
    public class FilteringExtensionPoint<ItemToFilter, PropertyType>
    {
        public PropertyAccessor<ItemToFilter, PropertyType> accessor;

        public FilteringExtensionPoint(PropertyAccessor<ItemToFilter, PropertyType> accessor)

        {
            this.accessor = accessor;
        }
    }
}