using System;

namespace nothinbutdotnetprep.infrastructure.filtering
{
    public class ComparableCriteriaFactory<ItemToMatch, PropertyType>  : ICreateSpecifications<ItemToMatch,PropertyType>
        where PropertyType : IComparable<PropertyType>
    {
        PropertyAccessor<ItemToMatch, PropertyType> accessor;
        ICreateSpecifications<ItemToMatch, PropertyType> factory;

        public ComparableCriteriaFactory(PropertyAccessor<ItemToMatch, PropertyType> accessor, ICreateSpecifications<ItemToMatch, PropertyType> factory)
        {
            this.accessor = accessor;
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

        public Criteria<ItemToMatch> matches(Condition<PropertyType> condition)
        {
            return factory.matches(condition);
        }

        public Criteria<ItemToMatch> greater_than_or_equal_to(PropertyType start)
        {
            return Where<ItemToMatch>.has_a(accessor).equal_to(start).or(greater_than(start));
        }

        public Criteria<ItemToMatch> less_than_or_equal_to(PropertyType end)
        {
            return matches(x => x.CompareTo(end) <= 0);
        }

        public Criteria<ItemToMatch> between(PropertyType start, PropertyType end)
        {
            return greater_than_or_equal_to(start).and(less_than_or_equal_to(end));
        }

        public Criteria<ItemToMatch> greater_than(PropertyType value)
        {
            return matches(x => x.CompareTo(value) > 0);
        }
    }
}