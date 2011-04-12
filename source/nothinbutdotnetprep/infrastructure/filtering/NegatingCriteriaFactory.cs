namespace nothinbutdotnetprep.infrastructure.filtering
{
    public class NegatingCriteriaFactory<ItemToMatch, PropertyType> : ICreateSpecifications<ItemToMatch, PropertyType>
    {
        ICreateSpecifications<ItemToMatch, PropertyType> factory;

        public NegatingCriteriaFactory(ICreateSpecifications<ItemToMatch, PropertyType> factory)
        {
            this.factory = factory;
        }

        public Criteria<ItemToMatch> equal_to(PropertyType value)
        {
            return negate(factory.equal_to(value));
        }

        public Criteria<ItemToMatch> equal_to_any(params PropertyType[] values)
        {
            return negate(factory.equal_to_any(values));
        }


        public Criteria<ItemToMatch> matches(Criteria<PropertyType> itemToMatch)
        {
            return negate(factory.matches(itemToMatch));
        }

        static Criteria<ItemToMatch> negate(Criteria<ItemToMatch> criteria)
        {
            return new NegatingCriteria<ItemToMatch>(criteria);
        }
    }
}