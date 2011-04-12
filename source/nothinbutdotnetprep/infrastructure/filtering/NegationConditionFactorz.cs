using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nothinbutdotnetprep.infrastructure.filtering
{
    public class NegationConditionFactory<ItemToMatch, PropertyType> : ICreateSpecifications<ItemToMatch, PropertyType>
    {
        private ICreateSpecifications<ItemToMatch, PropertyType> criteriaFactory;

        public NegationConditionFactory(ICreateSpecifications<ItemToMatch, PropertyType> criteriaFactory)
        {
            this.criteriaFactory = criteriaFactory;
        }


        public Criteria<ItemToMatch> equal_to(PropertyType value)
        {
            return new NegatingCriteria<ItemToMatch>(criteriaFactory.equal_to(value));
        }

        public Criteria<ItemToMatch> equal_to_any(params PropertyType[] values)
        {
            return new NegatingCriteria<ItemToMatch>(criteriaFactory.equal_to_any(values));
        }

        public Criteria<ItemToMatch> matches(Criteria<PropertyType> itemToMatch)
        {
            return new NegatingCriteria<ItemToMatch>(criteriaFactory.matches(itemToMatch));
        }
    }
}
