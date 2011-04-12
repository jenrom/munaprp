using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.filtering
{
    public class CriteriaFactory<ItemToMatch, PropertyType> : ICreateSpecifications<ItemToMatch, PropertyType>
    {
        readonly PropertyAccessor<ItemToMatch, PropertyType> accessor;
        public NegatingCriteriaFactory<ItemToMatch, PropertyType> not;

        public CriteriaFactory(PropertyAccessor<ItemToMatch, PropertyType> accessor)
        {
            this.accessor = accessor;
            this.not = new NegatingCriteriaFactory<ItemToMatch, PropertyType>(this);
        }

        public Criteria<ItemToMatch> equal_to(PropertyType value)
        {
            return equal_to_any(value);
        }

        public Criteria<ItemToMatch> equal_to_any(params PropertyType[] values)
        {
            return matches(new EqualToAny<PropertyType>(values));
        }

        public Criteria<ItemToMatch> not_equal_to(PropertyType value)
        {
            return new NegatingCriteria<ItemToMatch>(equal_to(value));
        }

        public Criteria<ItemToMatch> matches(Criteria<PropertyType> criteria)
        {
            return new PropertyCriteria<ItemToMatch, PropertyType>(criteria,
                                                                   accessor);
        }
    }
}