using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.filtering
{
    public class CriteriaFactory<ItemToMatch, PropertyType> : ICreateSpecifications<ItemToMatch, PropertyType>
    {
        readonly PropertyAccessor<ItemToMatch, PropertyType> accessor;

        public CriteriaFactory(PropertyAccessor<ItemToMatch, PropertyType> accessor)
        {
            this.accessor = accessor;
        }

        public Criteria<ItemToMatch> equal_to(PropertyType value)
        {
            return equal_to_any(value);
        }

        public Criteria<ItemToMatch> equal_to_any(params PropertyType[] values)
        {
            return matches(x => new List<PropertyType>(values).Contains(x));
        }

        public Criteria<ItemToMatch> not_equal_to(PropertyType value)
        {
            return new NegatingCriteria<ItemToMatch>(equal_to(value));
        }

        public Criteria<ItemToMatch> matches(Condition<PropertyType> condition)
        {
            return new AnonymousCriteria<ItemToMatch>(x => condition(accessor(x)));
        }
    }
}