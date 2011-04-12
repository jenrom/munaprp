using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.filtering
{
    public class CriteriaFactory<ItemToMatch, PropertyType> : ICreateSpecifications<ItemToMatch, PropertyType>
    {
        private IPropertyConditionCriteriaFactory<ItemToMatch, PropertyType> propertyConditionCritieriaFactory;


        public CriteriaFactory(IPropertyConditionCriteriaFactory<ItemToMatch, PropertyType> propertyConditionCritieriaFactory)
        {
            this.propertyConditionCritieriaFactory = propertyConditionCritieriaFactory;
        }

        public Criteria<ItemToMatch> equal_to(PropertyType value)
        {
            return equal_to_any(value);
        }

        public Criteria<ItemToMatch> equal_to_any(params PropertyType[] values)
        {
            return propertyConditionCritieriaFactory.create_for(x => new List<PropertyType>(values).Contains(x));
        }

        public Criteria<ItemToMatch> not_equal_to(PropertyType value)
        {
            return new NegatingCriteria<ItemToMatch>(equal_to(value));
        }
    }
}