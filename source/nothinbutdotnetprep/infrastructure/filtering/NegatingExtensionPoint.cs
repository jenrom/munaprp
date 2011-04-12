namespace nothinbutdotnetprep.infrastructure.filtering
{
    public class NegatingExtensionPoint<ItemToFilter, PropertyType> :
        IProvideAccessToSpecificationFactories<ItemToFilter, PropertyType>
    {
        IProvideAccessToSpecificationFactories<ItemToFilter, PropertyType> original;

        public NegatingExtensionPoint(IProvideAccessToSpecificationFactories<ItemToFilter, PropertyType> original)
        {
            this.original = original;
        }

        public Criteria<ItemToFilter> create_from(Criteria<PropertyType> criteria)
        {
            return new NegatingCriteria<ItemToFilter>(original.create_from(criteria));
        }
    }
}