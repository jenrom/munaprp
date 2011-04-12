using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.filtering
{
    public class CriteriaFactory<ItemToMatch, PropertyType> : ICreateSpecifications<ItemToMatch, PropertyType>
    {
        private readonly PropertyAccessor<ItemToMatch, PropertyType> accessor;
        private bool isNegating;

        public CriteriaFactory(PropertyAccessor<ItemToMatch, PropertyType> accessor)
        {
            this.accessor = accessor;
        }

        public ICreateSpecifications<ItemToMatch, PropertyType> not
        {
            get
            {
                return new NegationConditionFactory<ItemToMatch, PropertyType>(this);

                if(isNegating)
                {
                    throw new InvalidOperationException("Not is not allowed to be called twice");
                }

                this.isNegating = true;
                return this;
            }
        }

        public Criteria<ItemToMatch> equal_to(PropertyType value)
        {
            return equal_to_any(value);
        }

        private Criteria<ItemToMatch> chain(Criteria<ItemToMatch> criteria_to_chain)
        {
            if(isNegating)
            {
                criteria_to_chain = new NegatingCriteria<ItemToMatch>(criteria_to_chain);
            }

            return criteria_to_chain;
        }

        public Criteria<ItemToMatch> equal_to_any(params PropertyType[] values)
        {
            return chain(matches(new EqualToAny<PropertyType>(values)));
        }

        public Criteria<ItemToMatch> matches(Criteria<PropertyType> criteria)
        {
            return chain(new PropertyCriteria<ItemToMatch, PropertyType>(criteria, accessor));
        }
    }
}