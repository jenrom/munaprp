using System;

namespace nothinbutdotnetprep.infrastructure.filtering
{
    public class ComparableCriteriaFactory<ItemToMatch, PropertyType>  : ICreateSpecifications<ItemToMatch,PropertyType>
        where PropertyType : IComparable<PropertyType>
    {
        ICreateSpecifications<ItemToMatch, PropertyType> factory;
        IPropertyConditionCriteriaFactory<ItemToMatch, PropertyType> propertyConditionCritieriaFactory;

        public ComparableCriteriaFactory(ICreateSpecifications<ItemToMatch, PropertyType> factory, IPropertyConditionCriteriaFactory<ItemToMatch, PropertyType> propertyConditionCritieriaFactory)
        {
            this.propertyConditionCritieriaFactory = propertyConditionCritieriaFactory;
            this.factory = factory;
        }

        public Criteria<ItemToMatch> equal_to(PropertyType value)
        {
            return factory.equal_to(value);
        }

        public Criteria<ItemToMatch> equal_to_any(params PropertyType[] values)
        {
            return factory.equal_to_any(values);
        }

        public Criteria<ItemToMatch> not_equal_to(PropertyType value)
        {
            return factory.not_equal_to(value);
        }
        
        public Criteria<ItemToMatch> greater_than_or_equal_to(PropertyType start)
        {
            return equal_to(start).or(greater_than(start));
        }

        public Criteria<ItemToMatch> less_than_or_equal_to(PropertyType end)
        {
            return propertyConditionCritieriaFactory.create_for(x => x.CompareTo(end) <= 0);
        }

        public Criteria<ItemToMatch> between(PropertyType start, PropertyType end)
        {
            return greater_than_or_equal_to(start).and(less_than_or_equal_to(end));
        }

        public Criteria<ItemToMatch> greater_than(PropertyType value)
        {
            return propertyConditionCritieriaFactory.create_for(x => x.CompareTo(value) > 0);
        }
    }
}