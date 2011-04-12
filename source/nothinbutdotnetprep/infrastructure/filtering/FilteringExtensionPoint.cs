namespace nothinbutdotnetprep.infrastructure.filtering
{
    public interface IProvideAccessToSpecificationFactories<ItemToFilter, PropertyType>
    {
        Criteria<ItemToFilter> create_from(Criteria<PropertyType> criteria);
    }

    public class FilteringExtensionPoint<ItemToFilter, PropertyType> :
        IProvideAccessToSpecificationFactories<ItemToFilter, PropertyType>
    {
        PropertyAccessor<ItemToFilter, PropertyType> accessor;

        public FilteringExtensionPoint(PropertyAccessor<ItemToFilter, PropertyType> accessor)
        {
            this.accessor = accessor;
        }

        public IProvideAccessToSpecificationFactories<ItemToFilter, PropertyType> not
        {
            get { return new NegatingExtensionPoint<ItemToFilter, PropertyType>(this); }
        }

        public Criteria<ItemToFilter> create_from(Criteria<PropertyType> criteria)
        {
            return new PropertyCriteria<ItemToFilter, PropertyType>(criteria, accessor);
        }
    }
}