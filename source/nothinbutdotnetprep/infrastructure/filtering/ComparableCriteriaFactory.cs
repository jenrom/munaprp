using System;
using nothinbutdotnetprep.infrastructure.ranges;
using nothinbutdotnetprep.infrastructure.filtering;

namespace nothinbutdotnetprep.infrastructure.filtering
{
    public class ComparableCriteriaFactory<ItemToMatch, PropertyType>  : ICreateSpecifications<ItemToMatch,PropertyType>
        where PropertyType : IComparable<PropertyType>
    {
        ICreateSpecifications<ItemToMatch, PropertyType> factory;

        public ComparableCriteriaFactory(ICreateSpecifications<ItemToMatch, PropertyType> factory)
        {
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

        public Criteria<ItemToMatch> matches(Criteria<PropertyType> condition)
        {
            return factory.matches(condition);
        }

        public Criteria<ItemToMatch> greater_than_or_equal_to(PropertyType value)
        {
            return matches(new FallsInRange<PropertyType>(new RangeWithNoUpperBound<PropertyType>(value))
                .or(new EqualToAny<PropertyType>(value)));
        }

        public Criteria<ItemToMatch> less_than_or_equal_to(PropertyType value)
        {
            return matches(new FallsInRange<PropertyType>(new RangeWithNoLowerBound<PropertyType>(value))
                .or(new EqualToAny<PropertyType>(value)));
        }

        public Criteria<ItemToMatch> between(PropertyType start, PropertyType end)
        {
            return greater_than_or_equal_to(start).and(less_than_or_equal_to(end));
        }

        public Criteria<ItemToMatch> greater_than(PropertyType value)
        {
            return matches(new FallsInRange<PropertyType>(new RangeWithNoUpperBound<PropertyType>(value)));
        }
    }
}